using System;

namespace Server.Misc
{
	//LLM: Secrets of Sosaria shard build/version display (adopted 2026-06-27; the build line restarts at V#0.0.001,
	//LLM: independent of the Efellen sibling's numbering). This lives in the runtime scripts (Data/Scripts) so
	//LLM: the build number can be bumped WITHOUT recompiling World.exe. It is printed to the server console at
	//LLM: startup via Configure(), which the core auto-invokes (ScriptCompiler.Invoke( "Configure" ) at
	//LLM: Data/System/Source/Main.cs:486, just before World.Load()).
	//LLM: Version scheme V#0.E.BBB = release.epoch.build: release always 0; epoch bumps only on explicit request;
	//LLM: build +1 per accepted milestone and NEVER resets. Bump Current to the next value BEFORE handing a build
	//LLM: off for HW-Test, so the running shard's banner shows the number actually under test. During the
	//LLM: test/rework cycle append roman letters (e.g. "0.0.001a"); strip them on acceptance. See memory notes:
	//LLM: version-scheme, hw-test-and-commit.
	public class ShardVersion
	{
		public const string Current = "0.0.001";

		public static string Display { get { return "V#" + Current; } }

		public static void Configure()
		{
			Console.WriteLine( "Secrets of Sosaria Shard {0}", Display );
		}
	}
}
