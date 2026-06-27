using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Server.Web
{
	//LLM: .NET 10 migration — minimal local replacement for System.Web.UI.HtmlTextWriter (System.Web/UI has
	//LLM: no modern-.NET equivalent). Reproduces ONLY the surface used by Data/Scripts/System/Misc/Reporting.cs
	//LLM: (the optional web-stats report generator): ctor(TextWriter, tab), AddAttribute(enum|string, value),
	//LLM: RenderBeginTag/RenderEndTag, Indent, plus Write/WriteLine (inherited from TextWriter). Tag and
	//LLM: attribute names are the enum member name lower-cased. See SoS_dotnet10_howto.md §7.

	public enum HtmlTextWriterTag
	{
		A, Body, Center, Head, Html, Img, Link, Table, Td, Title, Tr
	}

	public enum HtmlTextWriterAttribute
	{
		Align, Border, Cellpadding, Cellspacing, Class, Colspan, Height, Href, Onclick, Src, Type, Width
	}

	public class HtmlTextWriter : TextWriter
	{
		private readonly TextWriter m_Inner;
		private readonly string m_TabString;
		private readonly List<string> m_Attributes = new List<string>();
		private readonly Stack<string> m_Tags = new Stack<string>();

		public int Indent { get; set; }

		public HtmlTextWriter( TextWriter inner, string tabString )
		{
			m_Inner = inner;
			m_TabString = tabString;
		}

		public override Encoding Encoding { get { return m_Inner.Encoding; } }

		public void AddAttribute( HtmlTextWriterAttribute key, string value )
		{
			AddAttribute( key.ToString().ToLowerInvariant(), value );
		}

		public void AddAttribute( string key, string value )
		{
			m_Attributes.Add( key + "=\"" + value + "\"" );
		}

		public void RenderBeginTag( HtmlTextWriterTag tag )
		{
			string name = tag.ToString().ToLowerInvariant();

			m_Inner.Write( "<" + name );

			foreach ( string attr in m_Attributes )
				m_Inner.Write( " " + attr );

			m_Inner.Write( ">" );

			m_Attributes.Clear();
			m_Tags.Push( name );
		}

		public void RenderEndTag()
		{
			if ( m_Tags.Count > 0 )
				m_Inner.Write( "</" + m_Tags.Pop() + ">" );
		}

		public override void Write( char value ) { m_Inner.Write( value ); }
		public override void Write( string value ) { m_Inner.Write( value ); }
		public override void Flush() { m_Inner.Flush(); }
	}
}
