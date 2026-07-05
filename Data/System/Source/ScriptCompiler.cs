/***************************************************************************
 *                             ScriptCompiler.cs
 *                            -------------------
 *   begin                : May 1, 2002
 *   copyright            : (C) The RunUO Software Team
 *   email                : info@runuo.com
 *
 *   $Id$
 *
 ***************************************************************************/

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

using System;
//LLM: .NET 10 migration (keystone) — runtime script compilation ported from System.CodeDom
//LLM: (CSharpCodeProvider throws PlatformNotSupportedException on modern .NET) to Roslyn
//LLM: (Microsoft.CodeAnalysis.CSharp). The net4.x CodeDom original is preserved on the `master`
//LLM: branch + git history; see SoS_dotnet10_howto.md §4. Removed usings: System.CodeDom,
//LLM: System.CodeDom.Compiler, Microsoft.CSharp, Microsoft.VisualBasic. Added the Roslyn usings below.
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Security.Cryptography;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Text;

namespace Server
{
	public static class ScriptCompiler
	{
		private static Assembly[] m_Assemblies;

		public static Assembly[] Assemblies
		{
			get
			{
				return m_Assemblies;
			}
			set
			{
				m_Assemblies = value;
			}
		}

		private static List<string> m_AdditionalReferences = new List<string>();

		public static string[] GetReferenceAssemblies()
		{
			List<string> list = new List<string>();

			string path = Path.Combine( Core.BaseDirectory, "Data/System/CFG/Assemblies.cfg" );

			if( File.Exists( path ) )
			{
				using( StreamReader ip = new StreamReader( path ) )
				{
					string line;

					while( (line = ip.ReadLine()) != null )
					{
						if( line.Length > 0 && !line.StartsWith( "#" ) )
							list.Add( line );
					}
				}
			}

			list.Add( Core.ExePath );

			list.AddRange( m_AdditionalReferences );

			return list.ToArray();
		}

		//LLM: .NET 10 keystone — build Roslyn MetadataReferences. There is NO GAC on modern .NET, so the
		//LLM: framework + engine deps are supplied as real files via TRUSTED_PLATFORM_ASSEMBLIES (every
		//LLM: assembly the host process trusts). We also add the engine assembly (Server.* types) and any
		//LLM: absolute-path extras from Assemblies.cfg; legacy BARE framework names there (System.dll, ...)
		//LLM: are skipped because they no longer resolve without a GAC. Microsoft.CodeAnalysis* is filtered
		//LLM: out so scripts can't accidentally reference Roslyn. Replaces the csc-era GetReferenceAssemblies().
		public static List<MetadataReference> GetMetadataReferences()
		{
			List<MetadataReference> refs = new List<MetadataReference>();
			HashSet<string> seen = new HashSet<string>( StringComparer.OrdinalIgnoreCase );

			string tpa = AppContext.GetData( "TRUSTED_PLATFORM_ASSEMBLIES" ) as string;

			if( tpa != null )
			{
				foreach( string p in tpa.Split( Path.PathSeparator ) )
				{
					if( !p.EndsWith( ".dll", StringComparison.OrdinalIgnoreCase ) || !File.Exists( p ) )
						continue;

					if( Path.GetFileName( p ).StartsWith( "Microsoft.CodeAnalysis", StringComparison.OrdinalIgnoreCase ) )
						continue;

					AddReference( refs, seen, p );
				}
			}

			// The engine assembly itself (Server.* types) is not always in the TPA — add it explicitly.
			AddReference( refs, seen, typeof( ScriptCompiler ).Assembly.Location );

			foreach( string extra in m_AdditionalReferences )
				AddReference( refs, seen, extra );

			string cfg = Path.Combine( Core.BaseDirectory, "Data/System/CFG/Assemblies.cfg" );

			if( File.Exists( cfg ) )
			{
				foreach( string raw in File.ReadAllLines( cfg ) )
				{
					string line = raw.Trim();

					if( line.Length == 0 || line.StartsWith( "#" ) )
						continue;

					if( Path.IsPathRooted( line ) && File.Exists( line ) )
						AddReference( refs, seen, line );
					// bare framework names (non-rooted) come from the TPA above — skip
				}
			}

			return refs;
		}

		private static void AddReference( List<MetadataReference> refs, HashSet<string> seen, string path )
		{
			if( !string.IsNullOrEmpty( path ) && File.Exists( path ) && seen.Add( Path.GetFileName( path ) ) )
				refs.Add( MetadataReference.CreateFromFile( path ) );
		}

		public static string GetDefines()
		{
			StringBuilder sb = null;

#if MONO
			AppendDefine( ref sb, "/d:MONO" );
#endif

			//These two defines are legacy, ie, depreciated.
			if( Core.Is64Bit )
				AppendDefine( ref sb, "/d:x64" );

			AppendDefine( ref sb, "/d:Framework_2_0" );

#if Framework_4_0
			AppendDefine( ref sb, "/d:Framework_4_0" );
#endif

			return (sb == null ? null : sb.ToString());
		}

		public static void AppendDefine( ref StringBuilder sb, string define )
		{
			if( sb == null )
				sb = new StringBuilder();
			else
				sb.Append( ' ' );

			sb.Append( define );
		}

		//LLM: .NET 10 keystone — preprocessor symbols for the Roslyn parse, mirroring the csc-era GetDefines()
		//LLM: (which emitted "/d:" switches). Same symbols the scripts were always compiled with: x64 (when
		//LLM: 64-bit) and Framework_2_0 (legacy/inert markers). Replaces passing a /d: string to csc.
		public static IEnumerable<string> GetPreprocessorSymbols()
		{
			List<string> symbols = new List<string>();

#if MONO
			symbols.Add( "MONO" );
#endif

			if( Core.Is64Bit )
				symbols.Add( "x64" );

			symbols.Add( "Framework_2_0" );

#if Framework_4_0
			symbols.Add( "Framework_4_0" );
#endif

			return symbols;
		}

		private static byte[] GetHashCode( string compiledFile, string[] scriptFiles, bool debug )
		{
			using( MemoryStream ms = new MemoryStream() )
			{
				using( BinaryWriter bin = new BinaryWriter( ms ) )
				{
					FileInfo fileInfo = new FileInfo( compiledFile );

					bin.Write( fileInfo.LastWriteTimeUtc.Ticks );

					foreach( string scriptFile in scriptFiles )
					{
						fileInfo = new FileInfo( scriptFile );

						bin.Write( fileInfo.LastWriteTimeUtc.Ticks );
					}

					bin.Write( debug );
					bin.Write( Core.Version.ToString() );

					ms.Position = 0;

					using( SHA1 sha1 = SHA1.Create() )
					{
						return sha1.ComputeHash( ms );
					}
				}
			}
		}

		public static bool CompileCSScripts( out Assembly assembly )
		{
			return CompileCSScripts( false, true, out assembly );
		}

		public static bool CompileCSScripts( bool debug, out Assembly assembly )
		{
			return CompileCSScripts( debug, true, out assembly );
		}

		public static bool CompileCSScripts( bool debug, bool cache, out Assembly assembly )
		{
			DeleteFiles( "Data.ref" );

			string[] files = GetScripts( "*.cs" );

			if( files.Length == 0 )
			{
				Console.WriteLine( "no files found." );
				assembly = null;
				return true;
			}

			if( File.Exists( "Data/Data.bin" ) )
			{
				if( cache && File.Exists( "Data/Data.hash" ) )
				{
					try
					{
						byte[] hashCode = GetHashCode( "Data/Data.bin", files, debug );

						using( FileStream fs = new FileStream( "Data/Data.hash", FileMode.Open, FileAccess.Read, FileShare.Read ) )
						{
							using( BinaryReader bin = new BinaryReader( fs ) )
							{
								byte[] bytes = bin.ReadBytes( hashCode.Length );

								if( bytes.Length == hashCode.Length )
								{
									bool valid = true;

									for( int i = 0; i < bytes.Length; ++i )
									{
										if( bytes[i] != hashCode[i] )
										{
											valid = false;
											break;
										}
									}

									if( valid )
									{
										assembly = Assembly.LoadFrom( "Data/Data.bin" );

										if( !m_AdditionalReferences.Contains( assembly.Location ) )
										{
											m_AdditionalReferences.Add( assembly.Location );
										}

										//Console.WriteLine( "done (cached)" );

										return true;
									}
								}
							}
						}
					}
					catch
					{
					}
				}
			}

			DeleteFiles( "Data*.bin" );

			//LLM: .NET 10 keystone — compile ALL scripts as one assembly with Roslyn and emit to Data.bin,
			//LLM: replacing CSharpCodeProvider.CompileAssemblyFromFile (throws PlatformNotSupported on modern
			//LLM: .NET). Scripts are interdependent, so they MUST compile as a single compilation (as before).
			//LLM: References: TRUSTED_PLATFORM_ASSEMBLIES + engine (no GAC). The Data.hash cache logic below is
			//LLM: unchanged. net4.x CodeDom original on master + git history. See SoS_dotnet10_howto.md §4.
			//LLM: (Removed: the leaked, unused "Data/Data.ref" StreamWriter and the per-error MONO loop.)
			string path = GetUnusedPath( "Data" );

			CSharpParseOptions parseOptions = new CSharpParseOptions( LanguageVersion.Latest )
				.WithPreprocessorSymbols( GetPreprocessorSymbols() );

			List<SyntaxTree> trees = new List<SyntaxTree>( files.Length );

			foreach( string file in files )
				trees.Add( CSharpSyntaxTree.ParseText( SourceText.From( File.ReadAllText( file ), Encoding.UTF8 ), parseOptions, file ) );

			CSharpCompilation compilation = CSharpCompilation.Create(
				Path.GetFileNameWithoutExtension( path ),
				trees,
				GetMetadataReferences(),
				new CSharpCompilationOptions(
					OutputKind.DynamicallyLinkedLibrary,
					optimizationLevel: debug ? OptimizationLevel.Debug : OptimizationLevel.Release,
					allowUnsafe: true,
					platform: Core.Is64Bit ? Platform.X64 : Platform.AnyCpu,
					deterministic: false ) );

			EmitResult emitResult;

			using( FileStream fs = new FileStream( path, FileMode.Create, FileAccess.ReadWrite, FileShare.Read ) )
				emitResult = compilation.Emit( fs );

			m_AdditionalReferences.Add( path );

			Display( emitResult.Diagnostics );

			if( !emitResult.Success )
			{
				DeleteFiles( "Data*.bin" ); // never leave a failed/partial emit to be cached
				assembly = null;
				return false;
			}

			if( cache && Path.GetFileName( path ) == "Data.bin" )
			{
				try
				{
					byte[] hashCode = GetHashCode( path, files, debug );

					using( FileStream fs = new FileStream( "Data/Data.hash", FileMode.Create, FileAccess.Write, FileShare.None ) )
					{
						using( BinaryWriter bin = new BinaryWriter( fs ) )
						{
							bin.Write( hashCode, 0, hashCode.Length );
						}
					}
				}
				catch
				{
				}
			}

			assembly = Assembly.LoadFrom( path );
			return true;
		}

		//LLM: .NET 10 keystone — report Roslyn Diagnostics (was CompilerResults/CompilerError). Errors are
		//LLM: printed in detail, grouped by file (path made relative to Data/Scripts); warnings are COUNTED,
		//LLM: not dumped, because modern analyzers (CA1416, CS8xxx nullable) are extremely noisy. The fresh-
		//LLM: compile path prints "done (N warnings)"; the cached path stays silent. See howto §4.
		public static void Display( IEnumerable<Diagnostic> diagnostics )
		{
			List<Diagnostic> errors = new List<Diagnostic>();
			int warningCount = 0;

			foreach( Diagnostic d in diagnostics )
			{
				if( d.Severity == DiagnosticSeverity.Error )
					errors.Add( d );
				else if( d.Severity == DiagnosticSeverity.Warning )
					++warningCount;
			}

			if( errors.Count == 0 )
			{
				if( warningCount > 0 )
					Console.WriteLine( "done ({0} warnings)", warningCount );

				return;
			}

			Console.WriteLine( "failed ({0} errors, {1} warnings)", errors.Count, warningCount );

			string scriptRoot = Path.GetFullPath( Path.Combine( Core.BaseDirectory, "Data/Scripts" + Path.DirectorySeparatorChar ) );

			Dictionary<string, List<Diagnostic>> byFile = new Dictionary<string, List<Diagnostic>>( StringComparer.OrdinalIgnoreCase );

			foreach( Diagnostic e in errors )
			{
				string file = e.Location.SourceTree != null ? e.Location.SourceTree.FilePath : "";

				List<Diagnostic> list;

				if( !byFile.TryGetValue( file, out list ) )
					byFile[file] = list = new List<Diagnostic>();

				list.Add( e );
			}

			Utility.PushColor( ConsoleColor.Red );
			Console.WriteLine( "Errors:" );

			foreach( KeyValuePair<string, List<Diagnostic>> kvp in byFile )
			{
				string file = kvp.Key;

				string shown = string.IsNullOrEmpty( file )
					? "(compiler)"
					: ( file.StartsWith( scriptRoot, StringComparison.OrdinalIgnoreCase ) ? file.Substring( scriptRoot.Length ) : file );

				Console.WriteLine( " + {0}:", shown );

				Utility.PushColor( ConsoleColor.DarkRed );

				foreach( Diagnostic e in kvp.Value )
				{
					int line = e.Location.GetLineSpan().StartLinePosition.Line + 1;
					Console.WriteLine( "    {0}: Line {1}: {2}", e.Id, line, e.GetMessage() );
				}

				Utility.PopColor();
			}

			Utility.PopColor();
		}

		public static void DeleteFiles( string mask )
		{
			try
			{
				string[] files = Directory.GetFiles( Path.Combine( Core.BaseDirectory, "Data" ), mask );

				foreach( string file in files )
				{
					try { File.Delete( file ); }
					catch { }
				}
			}
			catch
			{
			}
		}

		//LLM: .NET 10 — removed the vestigial `private delegate CompilerResults Compiler( bool debug );`
		//LLM: (unused, and CompilerResults no longer exists after the CodeDom -> Roslyn port).

		public static bool Compile()
		{
			return Compile( false );
		}

		public static bool Compile( bool debug )
		{
			return Compile( debug, true );
		}

		public static bool Compile( bool debug, bool cache )
		{
			EnsureDirectory( "Data/" );

			if( m_AdditionalReferences.Count > 0 )
				m_AdditionalReferences.Clear();

			List<Assembly> assemblies = new List<Assembly>();

			Assembly assembly;

			if( CompileCSScripts( debug, cache, out assembly ) )
			{
				if( assembly != null )
				{
					assemblies.Add( assembly );
				}
			}
			else
			{
				return false;
			}

			if( assemblies.Count == 0 )
			{
				return false;
			}

			m_Assemblies = assemblies.ToArray();

			Stopwatch watch = Stopwatch.StartNew();
			
			Core.VerifySerialization();
			
			watch.Stop();

			return true;
		}

		public static void Invoke( string method )
		{
			List<MethodInfo> invoke = new List<MethodInfo>();

			for( int a = 0; a < m_Assemblies.Length; ++a )
			{
				Type[] types = m_Assemblies[a].GetTypes();

				for( int i = 0; i < types.Length; ++i )
				{
					MethodInfo m = types[i].GetMethod( method, BindingFlags.Static | BindingFlags.Public );

					if( m != null )
						invoke.Add( m );
				}
			}

			invoke.Sort( new CallPriorityComparer() );

			for( int i = 0; i < invoke.Count; ++i )
				invoke[i].Invoke( null, null );
		}

		private static Dictionary<Assembly, TypeCache> m_TypeCaches = new Dictionary<Assembly, TypeCache>();
		private static TypeCache m_NullCache;

		public static TypeCache GetTypeCache( Assembly asm )
		{
			if( asm == null )
			{
				if( m_NullCache == null )
					m_NullCache = new TypeCache( null );

				return m_NullCache;
			}

			TypeCache c = null;
			m_TypeCaches.TryGetValue( asm, out c );

			if( c == null )
				m_TypeCaches[asm] = c = new TypeCache( asm );

			return c;
		}

		public static string GetUnusedPath( string name )
		{
			string path = Path.Combine( Core.BaseDirectory, String.Format( "Data/{0}.bin", name ) );

			for( int i = 2; File.Exists( path ) && i <= 1000; ++i )
				path = Path.Combine( Core.BaseDirectory, String.Format( "Data/{0}.{1}.bin", name, i ) );

			return path;
		}

		public static Type FindTypeByFullName( string fullName )
		{
			return FindTypeByFullName( fullName, true );
		}

		public static Type FindTypeByFullName( string fullName, bool ignoreCase )
		{
			Type type = null;

			for( int i = 0; type == null && i < m_Assemblies.Length; ++i )
				type = GetTypeCache( m_Assemblies[i] ).GetTypeByFullName( fullName, ignoreCase );

			if( type == null )
				type = GetTypeCache( Core.Assembly ).GetTypeByFullName( fullName, ignoreCase );

			return type;
		}

		public static Type FindTypeByName( string name )
		{
			return FindTypeByName( name, true );
		}

		public static Type FindTypeByName( string name, bool ignoreCase )
		{
			Type type = null;

			for( int i = 0; type == null && i < m_Assemblies.Length; ++i )
				type = GetTypeCache( m_Assemblies[i] ).GetTypeByName( name, ignoreCase );

			if( type == null )
				type = GetTypeCache( Core.Assembly ).GetTypeByName( name, ignoreCase );

			return type;
		}

		public static void EnsureDirectory( string dir )
		{
			string path = Path.Combine( Core.BaseDirectory, dir );

			if( !Directory.Exists( path ) )
				Directory.CreateDirectory( path );
		}

		public static string[] GetScripts( string filter )
		{
			List<string> list = new List<string>();

			GetScripts( list, Path.Combine( Core.BaseDirectory, "Data/Scripts" ), filter );
			GetScripts( list, Path.Combine( Core.BaseDirectory, "Info/Scripts" ), filter );

			return list.ToArray();
		}

		public static void GetScripts( List<string> list, string path, string filter )
		{
			foreach( string dir in Directory.GetDirectories( path ) )
				GetScripts( list, dir, filter );

			list.AddRange( Directory.GetFiles( path, filter ) );
		}
	}

	public class TypeCache
	{
		private Type[] m_Types;
		private TypeTable m_Names, m_FullNames;

		public Type[] Types { get { return m_Types; } }
		public TypeTable Names { get { return m_Names; } }
		public TypeTable FullNames { get { return m_FullNames; } }

		public Type GetTypeByName( string name, bool ignoreCase )
		{
			return m_Names.Get( name, ignoreCase );
		}

		public Type GetTypeByFullName( string fullName, bool ignoreCase )
		{
			return m_FullNames.Get( fullName, ignoreCase );
		}

		public TypeCache( Assembly asm )
		{
			if( asm == null )
				m_Types = Type.EmptyTypes;
			else
				m_Types = asm.GetTypes();

			m_Names = new TypeTable( m_Types.Length );
			m_FullNames = new TypeTable( m_Types.Length );

			Type typeofTypeAliasAttribute = typeof( TypeAliasAttribute );

			for( int i = 0; i < m_Types.Length; ++i )
			{
				Type type = m_Types[i];

				m_Names.Add( type.Name, type );
				m_FullNames.Add( type.FullName, type );

				if( type.IsDefined( typeofTypeAliasAttribute, false ) )
				{
					object[] attrs = type.GetCustomAttributes( typeofTypeAliasAttribute, false );

					if( attrs != null && attrs.Length > 0 )
					{
						TypeAliasAttribute attr = attrs[0] as TypeAliasAttribute;

						if( attr != null )
						{
							for( int j = 0; j < attr.Aliases.Length; ++j )
								m_FullNames.Add( attr.Aliases[j], type );
						}
					}
				}
			}
		}
	}

	public class TypeTable
	{
		private Dictionary<string, Type> m_Sensitive, m_Insensitive;

		public void Add( string key, Type type )
		{
			m_Sensitive[key] = type;
			m_Insensitive[key] = type;
		}

		public Type Get( string key, bool ignoreCase )
		{
			Type t = null;

			if( ignoreCase )
				m_Insensitive.TryGetValue( key, out t );
			else
				m_Sensitive.TryGetValue( key, out t );

			return t;
		}

		public TypeTable( int capacity )
		{
			m_Sensitive = new Dictionary<string, Type>( capacity );
			m_Insensitive = new Dictionary<string, Type>( capacity, StringComparer.OrdinalIgnoreCase );
		}
	}
}
