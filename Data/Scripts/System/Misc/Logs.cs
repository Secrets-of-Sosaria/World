using Server.Accounting;
using Server.Commands.Generic;
using Server.Commands;
using Server.Guilds;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Regions;
using Server;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using System;

namespace Server.Misc
{
    class LoggingFunctions
    {
		public static bool LoggingEvents()
		{
			return true; // SET TO TRUE TO ENABLE LOG SYSTEM FOR GAME EVENTS AND TOWN CRIERS
		}

		public static void CreateFile(string sPath)
		{
			/// CREATE THE FILE IF IT DOES NOT EXIST ///
			StreamWriter w = null; 
			try
			{
				using (w = File.AppendText( sPath ) ){}
			}
			catch(Exception)
			{
			}
			finally
			{
				if (w != null)
					w.Dispose();
			}
		}

		public static void UpdateFile(string filename, string header)
		{
			int nLine = 0;
			int nTrim = 150;
			string tempfile = Path.GetTempFileName();
			StreamWriter writer = null;
			StreamReader reader = null;
			using (writer = new StreamWriter(tempfile))
			using (reader = new StreamReader(filename))
			{
				writer.WriteLine(header);
				while (!reader.EndOfStream)
				{
					nLine = nLine + 1;
					if ( nLine < nTrim )
					{
						writer.WriteLine(reader.ReadLine());
					}
					else
					{
						reader.ReadLine();
					}
				}
			}

			if (writer != null)
				writer.Dispose();

			if (reader != null)
				reader.Dispose();

			File.Copy(tempfile, filename, true);
			File.Delete(tempfile);
		}

		public static void DeleteFile(string filename)
		{
			try
			{
				File.Delete(filename);
			}
			catch(Exception)
			{
			}
		}

		public static string LogEvent( string sEvent, string sLog )
		{
			if ( LoggingFunctions.LoggingEvents() == true )
			{
				if ( !Directory.Exists( "Saves/Data" ) )
					Directory.CreateDirectory( "Saves/Data" );

				string sPath = "Saves/Data/adventures.txt";

				if ( sLog == "Logging Adventures" ){ sPath = "Saves/Data/adventures.txt"; }
				else if ( sLog == "Logging Quests" ){ sPath = "Saves/Data/quests.txt"; }
				else if ( sLog == "Logging Battles" ){ sPath = "Saves/Data/battles.txt"; }
				else if ( sLog == "Logging Deaths" ){ sPath = "Saves/Data/deaths.txt"; }
				else if ( sLog == "Logging Murderers" ){ sPath = "Saves/Data/murderers.txt"; }
				else if ( sLog == "Logging Journies" ){ sPath = "Saves/Data/journies.txt"; }
				else if ( sLog == "Logging Server" ){ sPath = "Saves/Data/server.txt"; }
				
				CreateFile( sPath );

				/// PREPEND THE FILE WITH THE EVENT ///
				try
				{
					UpdateFile(sPath, sEvent);
				}
				catch(Exception)
				{
				}
			}
			return null;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogRead( string sLog, Mobile m )
		{
			if ( !Directory.Exists( "Saves/Data" ) )
				Directory.CreateDirectory( "Saves/Data" );

			string sPath = "Saves/Data/adventures.txt";

			if ( sLog == "Logging Adventures" ){ sPath = "Saves/Data/adventures.txt"; }
			else if ( sLog == "Logging Quests" ){ sPath = "Saves/Data/quests.txt"; }
			else if ( sLog == "Logging Battles" ){ sPath = "Saves/Data/battles.txt"; }
			else if ( sLog == "Logging Deaths" ){ sPath = "Saves/Data/deaths.txt"; }
			else if ( sLog == "Logging Murderers" ){ sPath = "Saves/Data/murderers.txt"; }
			else if ( sLog == "Logging Journies" ){ sPath = "Saves/Data/journies.txt"; }

			string sBreak = "";

			if ( sLog == "Logging Murderers"){ sBreak = "<br>"; }
			string sLogEntries = "";

			CreateFile( sPath );

			string eachLine = "";
			int nLine = 0;
			int nBlank = 1;
			StreamReader reader = null;

			try
			{
				using (reader = new StreamReader( sPath ))
				{
					while (!reader.EndOfStream)
					{
						eachLine = reader.ReadLine();
						string[] eachWord = eachLine.Split('#');
						nLine = 1;
						foreach (string eachWords in eachWord)
						{
							if ( nLine == 1 ){ nLine = 2; sLogEntries = sLogEntries + eachWords + ".<br>" + sBreak; nBlank = 0; }
							else { nLine = 1; sLogEntries = sLogEntries + " - " + eachWords + "<br><br>"; }
						}
					}
				}
			}
			catch(Exception)
			{
				sLogEntries = sLogEntries + "Sorry, " + m.Name + ". I am busy at the moment.";
			}
			finally
			{
				if (reader != null)
					reader.Dispose();
			}

			if ( nBlank == 1 )
			{
				if ( sLog == "Logging Murderers" ){ sLogEntries = sLogEntries + "I am happy to say " + m.Name + ", that no one is wanted for murder."; }
				else if ( sLog == "Logging Battles" ){ sLogEntries = sLogEntries + "Sorry, " + m.Name + ". I have no new tales of bravery to tell."; }
				else if ( sLog == "Logging Adventures" ){ sLogEntries = sLogEntries + "Sorry, " + m.Name + ". I have no new gossip to tell."; }
				else if ( sLog == "Logging Quests" ){ sLogEntries = sLogEntries + "Sorry, " + m.Name + ". I have no new tales of deeds to tell."; }
				else if ( sLog == "Logging Deaths" ){ sLogEntries = sLogEntries + "I am happy to say " + m.Name + ", that all of Sosaria's citizens are alive and well."; }
				else if ( sLog == "Logging Journies" ){ sLogEntries = sLogEntries + "Sorry, " + m.Name + ". I have no new tales of exploration to tell."; }
				else { sLogEntries = sLogEntries + "Sorry, " + m.Name + ". I have nothing new to tell of such things."; }
			}

			if ( sLogEntries.Contains(" .") ){ sLogEntries = sLogEntries.Replace(" .", "."); }
			if ( sLogEntries.Contains("..") ){ sLogEntries = sLogEntries.Replace("..", "."); }

			return sLogEntries;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogArticles( int article, int section )
		{
			if ( !Directory.Exists( "Info" ) )
				Directory.CreateDirectory( "Info" );

			if ( !Directory.Exists( "Info/Articles" ) )
				Directory.CreateDirectory( "Info/Articles" );

			if ( article > 10 ){ article = 0; }
			else if ( article > 0 ){}
			else { article = 0; }

			string text = article.ToString();

			string path = "Info/Articles/" + text + ".txt";

			string part = "";

			string title = "";
			string date = "";
			string message = "";

			CreateFile( path );

			StreamReader reader = null;

			int line = 0;

			try
			{
				using (reader = new StreamReader( path ))
				{
					while (!reader.EndOfStream)
					{
						if ( line == 0 ){ title = reader.ReadLine(); }
						else if ( line == 1 ){ date = reader.ReadLine(); }
						else { message = reader.ReadLine(); }

						line++;
					}
				}
			}
			catch(Exception)
			{
			}
			finally
			{
				if (reader != null)
					reader.Dispose();
			}

			if ( section == 1 ){ part = title; }
			else if ( section == 2 ){ part = date; }
			else if ( section == 3 ){ part = message; }

			if ( part.Contains(" .") ){ part = part.Replace(" .", "."); }

			return part;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static int TotalLines(string filePath)
		{
			int i = 0;
			using (StreamReader r = new StreamReader(filePath)){ while (r.ReadLine() != null) { i++; } }
			return i;
		}

		public static string LogShout()
		{
			if ( !Directory.Exists( "Saves/Data" ) )
				Directory.CreateDirectory( "Saves/Data" );

			string sLog = "Logging Adventures";
			switch ( Utility.Random( 6 ))
			{
				case 0: sLog = "Logging Deaths"; break;
				case 1: sLog = "Logging Quests"; break;
				case 2: sLog = "Logging Battles"; break;
				case 3: sLog = "Logging Journies"; break;
				case 4: sLog = "Logging Murderers"; break;
				case 5: sLog = "Logging Adventures"; break;
			};

			string sPath = "Saves/Data/adventures.txt";

			if ( sLog == "Logging Adventures" ){ sPath = "Saves/Data/adventures.txt"; }
			else if ( sLog == "Logging Quests" ){ sPath = "Saves/Data/quests.txt"; }
			else if ( sLog == "Logging Battles" ){ sPath = "Saves/Data/battles.txt"; }
			else if ( sLog == "Logging Deaths" ){ sPath = "Saves/Data/deaths.txt"; }
			else if ( sLog == "Logging Murderers" ){ sPath = "Saves/Data/murderers.txt"; }
			else if ( sLog == "Logging Journies" ){ sPath = "Saves/Data/journies.txt"; }

			CreateFile( sPath );

			int lineCount = 1;
			string sGreet = "Hear ye, hear ye!";
				switch ( Utility.Random( 4 ))
				{
					case 0: sGreet = "Hear ye, hear ye!"; break;
					case 1: sGreet = "Everyone listen!"; break;
					case 2: sGreet = "All hail and hear my words!"; break;
					case 3: sGreet = "Your attention please!"; break;
				};

			string myShout = "";
			if ( sLog == "Logging Murderers" ){ myShout = Server.Mobiles.TownHerald.randomShout( null ); }
			else { myShout = Server.Mobiles.TownHerald.randomShout( null ); }

			try
			{
				lineCount = TotalLines( sPath );
			}
			catch(Exception)
			{
			}

			lineCount = Utility.RandomMinMax( 1, lineCount );
			string readLine = "";
			StreamReader reader = null;
			int nWhichLine = 0;
			int nLine = 1;
			try
			{
				using (reader = new StreamReader( sPath ))
				{
					string line;

					while ((line = reader.ReadLine()) != null)
					{
						nWhichLine = nWhichLine + 1;
						if ( nWhichLine == lineCount )
						{
							readLine = line;
							string[] shoutOut = readLine.Split('#');
							foreach (string shoutOuts in shoutOut)
							{
								if ( nLine == 1 ){ nLine = 2; readLine = shoutOuts; }
							}
						}
					}
					if ( readLine != "" ){ myShout = readLine; }
				}
			}
			catch(Exception)
			{
			}
			finally
			{
				if (reader != null)
					reader.Dispose();
			}

			string sVerb1 = "";
			string sVerb2 = "";
			switch ( Utility.Random( 4 ))
			{
				case 0: sVerb1 = "was seen in";				sVerb2 = "was seen leaving"; 			break;
				case 1: sVerb1 = "was spotted in";			sVerb2 = "was spotted leaving"; 		break;
				case 2: sVerb1 = "was known to be in";		sVerb2 = "was seen near"; 				break;
				case 3: sVerb1 = "was rumored to be in";	sVerb2 = "was spotted by"; 				break;
			};

			myShout = sGreet + " " + myShout + "!";
			if ( myShout.Contains(" !") ){ myShout = myShout.Replace(" !", "!"); }
			if ( myShout.Contains(" had entered ") ){ myShout = myShout.Replace(" had entered ", " " + sVerb1 + " "); }
			if ( myShout.Contains(" had left ") ){ myShout = myShout.Replace(" left ", " " + sVerb2 + " "); }

			return myShout;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogSpeak()
		{
			if ( !Directory.Exists( "Saves/Data" ) )
				Directory.CreateDirectory( "Saves/Data" );

			string sLog = "Logging Murderers";
			switch ( Utility.Random( 6 ))
			{
				case 0: sLog = "Logging Deaths"; break;
				case 1: sLog = "Logging Battles"; break;
				case 2: sLog = "Logging Journies"; break;
				case 3: sLog = "Logging Battles"; break;
				case 4: sLog = "Logging Journies"; break;
			};

			string sPath = "Saves/Data/murderers.txt";

			if ( sLog == "Logging Battles" ){ sPath = "Saves/Data/battles.txt"; }
			else if ( sLog == "Logging Deaths" ){ sPath = "Saves/Data/deaths.txt"; }
			else if ( sLog == "Logging Journies" ){ sPath = "Saves/Data/journies.txt"; }

			CreateFile( sPath );

			int lineCount = 1;

			string mySpeaking = "things being quiet throughout the land";

			try
			{
				lineCount = TotalLines( sPath );
			}
			catch(Exception)
			{
			}

			lineCount = Utility.RandomMinMax( 1, lineCount );
			string readLine = "";
			StreamReader reader = null;
			int nWhichLine = 0;
			int nLine = 1;
			try
			{
				using (reader = new StreamReader( sPath ))
				{
					string line;

					while ((line = reader.ReadLine()) != null)
					{
						nWhichLine = nWhichLine + 1;
						if ( nWhichLine == lineCount )
						{
							readLine = line;
							string[] shoutOut = readLine.Split('#');
							foreach (string shoutOuts in shoutOut)
							{
								if ( nLine == 1 ){ nLine = 2; readLine = shoutOuts; }
							}
						}
					}
					if ( readLine != "" ){ mySpeaking = readLine; }
				}
			}
			catch(Exception)
			{
			}
			finally
			{
				if (reader != null)
					reader.Dispose();
			}

			string sVerb1 = "";
			string sVerb2 = "";
			string sVerb3 = "";
			switch ( Utility.Random( 4 ))
			{
				case 0: sVerb1 = "being seen in";		sVerb2 = "being seen leaving"; 		sVerb3 = "killing";		break;
				case 1: sVerb1 = "being spotted in";	sVerb2 = "being spotted leaving"; 	sVerb3 = "slaying";		break;
				case 2: sVerb1 = "being seen in";		sVerb2 = "being seen near"; 		sVerb3 = "besting";		break;
				case 3: sVerb1 = "being spotted in";	sVerb2 = "being spotted by"; 		sVerb3 = "slaying";		break;
			};

			if ( mySpeaking.Contains(" had been ") ){ mySpeaking = mySpeaking.Replace(" had been ", " being "); }
			if ( mySpeaking.Contains(" had slain ") ){ mySpeaking = mySpeaking.Replace(" had slain ", " " + sVerb3 + " "); }
			if ( mySpeaking.Contains(" had killed ") ){ mySpeaking = mySpeaking.Replace(" had killed ", " accidentally killing "); }
			if ( mySpeaking.Contains(" made a fatal mistake ") ){ mySpeaking = mySpeaking.Replace(" made a fatal mistake ", " making a fatal mistake "); }
			if ( mySpeaking.Contains(" entered ") ){ mySpeaking = mySpeaking.Replace(" entered ", " " + sVerb1 + " "); }
			if ( mySpeaking.Contains(" left ") ){ mySpeaking = mySpeaking.Replace(" left ", " " + sVerb2 + " "); }
						
			return mySpeaking;
		}

		public static string LogSpeakQuest()
		{
			if ( !Directory.Exists( "Saves/Data" ) )
				Directory.CreateDirectory( "Saves/Data" );

			string sPath = "Saves/Data/quests.txt";

			CreateFile( sPath );

			int lineCount = 1;

			string mySpeaking = "Adventurers seem to be all sitting around in taverns";

			try
			{
				lineCount = TotalLines( sPath );
			}
			catch(Exception)
			{
			}

			lineCount = Utility.RandomMinMax( 1, lineCount );
			string readLine = "";
			StreamReader reader = null;
			int nWhichLine = 0;
			int nLine = 1;
			try
			{
				using (reader = new StreamReader( sPath ))
				{
					string line;

					while ((line = reader.ReadLine()) != null)
					{
						nWhichLine = nWhichLine + 1;
						if ( nWhichLine == lineCount )
						{
							readLine = line;
							string[] shoutOut = readLine.Split('#');
							foreach (string shoutOuts in shoutOut)
							{
								if ( nLine == 1 ){ nLine = 2; readLine = shoutOuts; }
							}
						}
					}
					if ( readLine != "" ){ mySpeaking = readLine; }
				}
			}
			catch(Exception)
			{
			}
			finally
			{
				if (reader != null)
					reader.Dispose();
			}
						
			return mySpeaking;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogRegions( Mobile m, string sRegion, string sDirection )
		{
			if ( m is PlayerMobile )
			{
				int nDifficulty = Server.Difficult.GetDifficulty( m.Location, m.Map );
				string sDifficulty = "";

				if ( nDifficulty == -1 ){ sDifficulty = " (Easy)"; }
				else if ( nDifficulty == 0 ){ sDifficulty = " (Normal)"; }
				else if ( nDifficulty == 1 ){ sDifficulty = " (Difficult)"; }
				else if ( nDifficulty == 2 ){ sDifficulty = " (Challenging)"; }
				else if ( nDifficulty == 3 ){ sDifficulty = " (Hard)"; }
				else if ( nDifficulty == 4 ){ sDifficulty = " (Deadly)"; }
				else if ( nDifficulty > 4 ){ sDifficulty = " (Epic)"; }

				if ( sDirection == "enter" ){ m.SendMessage("You have entered " + sRegion + sDifficulty + "."); }
				else { m.SendMessage("You have left " + sRegion + "."); }
			}

			if ( ( m is PlayerMobile ) && ( m.AccessLevel < AccessLevel.GameMaster ) )
			{
				if ( !m.Alive && m.QuestArrow == null ){ GhostHelper.OnGhostWalking( m ); }
				string sDateString = GetPlayerInfo.GetTodaysDate();
				string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
				if ( m.Title != null ){ sTitle = m.Title; }

				PlayerMobile pm = (PlayerMobile)m;
				if (pm.PublicInfo == true)
				{
					string sEvent;

					if ( sDirection == "enter" ){ sEvent = m.Name + " " + sTitle + " entered " + sRegion + "#" + sDateString; LoggingFunctions.LogEvent( sEvent, "Logging Journies" ); }
					// else { sEvent = m.Name + " " + sTitle + " left " + sRegion + "#" + sDateString; LoggingFunctions.LogEvent( sEvent, "Logging Journies" ); }
				}
			}
			return null;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogBattles( Mobile m, Mobile mob )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();

			if ( m is PlayerMobile && mob != null )
			{
				string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
				if ( m.Title != null ){ sTitle = m.Title; }

				PlayerMobile pm = (PlayerMobile)m;

				string sKiller = mob.Name;
				string[] eachWord = sKiller.Split('[');
				int nLine = 1;
				foreach (string eachWords in eachWord)
				{
					if ( nLine == 1 ){ nLine = 2; sKiller = eachWords; }
				}
				sKiller = sKiller.TrimEnd();

				if ( mob is BaseCreature && ( mob.Fame > -1000 && mob.Fame < 1000 ) )
				{
					// NOT WORTH RECORDING OTHERWISE YOU GET A BATTLE LOG FULL OF GOAT OR RABBIT SLAYINGS...OR BASICALLY EASY MONSTERS
				}
				else if ( pm.PublicInfo == true )
				{
					string Killed = sKiller;
						if ( mob.Title != "" && mob.Title != null ){ Killed = Killed + " " + mob.Title; }
					string sEvent = m.Name + " " + sTitle + " had slain " + Killed + "#" + sDateString;
					LoggingFunctions.LogEvent( sEvent, "Logging Battles" );
				}
				else
				{
					string privateEnemy = "an opponent";
					switch ( Utility.Random( 6 ) )
					{
						case 0: privateEnemy = "an opponent"; break;
						case 1: privateEnemy = "an enemy"; break;
						case 2: privateEnemy = "another"; break;
						case 3: privateEnemy = "an adversary"; break;
						case 4: privateEnemy = "a foe"; break;
						case 5: privateEnemy = "a rival"; break;
					}
					string sEvent = m.Name + " " + sTitle + " had slain " + privateEnemy + "#" + sDateString;
					LoggingFunctions.LogEvent( sEvent, "Logging Battles" );
				}
			}
			return null;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogTraps( Mobile m, string sTrap )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			string sTrip = "had triggered";
			switch( Utility.Random( 7 ) )
			{
				case 0: sTrip = "had triggered";	break;
				case 1: sTrip = "had set off";	break;
				case 2: sTrip = "had walked into";	break;
				case 3: sTrip = "had stumbled into";	break;
				case 4: sTrip = "had been struck with";	break;
				case 5: sTrip = "had been affected with";	break;
				case 6: sTrip = "had ran into";	break;
			}

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " " + sTrip + " " + sTrap + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Adventures" );
			}

			return null;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogVoid( Mobile m, string sTrap )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " " + sTrap + ", teleporting them far away#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Adventures" );
			}

			return null;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogPrison( Mobile m, string sJail )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " was sent to the " + sJail + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Journies" );
			}

			return null;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogKillTile( Mobile m, string sTrap )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " made a fatal mistake from " + sTrap + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Journies" );
			}

			return null;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogLoot( Mobile m, string sBox, string sType )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			string sLoot = "had searched through a";
			switch( Utility.Random( 7 ) )
			{
				case 0: sLoot = "had searched through a";	break;
				case 1: sLoot = "had found a";	break;
				case 2: sLoot = "had discovered a";	break;
				case 3: sLoot = "had looked through a";	break;
				case 4: sLoot = "had stumbled upon a";	break;
				case 5: sLoot = "had dug through a";	break;
				case 6: sLoot = "had opened a";	break;
			}
			if ( sType == "boat" )
			{
				switch( Utility.Random( 5 ) )
				{
					case 0: sLoot = "had searched through a";	break;
					case 1: sLoot = "had found a";	break;
					case 2: sLoot = "had discovered a";	break;
					case 3: sLoot = "had looked through a";	break;
					case 4: sLoot = "had sailed upon a";	break;
				}
				if ( sBox.Contains("Abandoned") || sBox.Contains("Adrift") ){ sLoot = sLoot + "n"; }
			}
			else if ( sType == "corpse" )
			{
				switch( Utility.Random( 5 ) )
				{
					case 0: sLoot = "had searched through a";	break;
					case 1: sLoot = "had found a";	break;
					case 2: sLoot = "had discovered a";	break;
					case 3: sLoot = "had looked through a";	break;
					case 4: sLoot = "had sailed upon a";	break;
				}
				if ( sBox.Contains("Abandoned") || sBox.Contains("Adrift") ){ sLoot = sLoot + "n"; }
			}

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " " + sLoot + " " + sBox + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Adventures" );
			}

			return null;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogSlayingLord( Mobile m, string creature )
		{
			if ( m != null )
			{
				if ( m is BaseCreature )
					m = ((BaseCreature)m).GetMaster();

				if ( m is PlayerMobile )
				{
					string sDateString = GetPlayerInfo.GetTodaysDate();
					string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
					if ( m.Title != null ){ sTitle = m.Title; }

					string verb = "has destroyed";
					switch( Utility.Random( 4 ) )
					{
						case 0: verb = "has defeated";		break;
						case 1: verb = "has slain";		break;
						case 2: verb = "has destroyed";	break;
						case 3: verb = "has vanquished";	break;
					}

					PlayerMobile pm = (PlayerMobile)m;
					if (pm.PublicInfo == true)
					{
						string sEvent = m.Name + " " + sTitle + " " + verb + " " + creature + "#" + sDateString;
						LoggingFunctions.LogEvent( sEvent, "Logging Quests" );
					}
				}
			}

			return null;
		}
		// --------------------------------------------------------------------------------------------
		public static string LogCreatedArtifact( Mobile m, string sArty )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = "The gods have created a legendary artefact called " + sArty + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Quests" );
			}

			return null;
		}
		// --------------------------------------------------------------------------------------------
		public static string LogRuneOfVirtue( Mobile m, string side )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			string sText = "has cleansed the Runes to the Chamber of Virtue.";
				if ( side == "evil" ){ sText = "has corrupted the Runes of Virtue."; }

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " " + sText + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Quests" );
			}

			return null;
		}
		// --------------------------------------------------------------------------------------------
		public static string LogCreatedSyth( Mobile m, string sArty )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = "A Syth constructed a weapon called " + sArty + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Quests" );
			}

			return null;
		}
		// --------------------------------------------------------------------------------------------
		public static string LogCreatedJedi( Mobile m, string sArty )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = "A Jedi constructed a weapon called " + sArty + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Quests" );
			}

			return null;
		}
		// --------------------------------------------------------------------------------------------
		public static string LogGenericQuest( Mobile m, string sText )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " " + sText + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Quests" );
			}

			return null;
		}
		// --------------------------------------------------------------------------------------------
		public static string LogFoundItemQuest( Mobile m, string sBox )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			string sLoot = "has discovered the";
			switch( Utility.Random( 4 ) )
			{
				case 0: sLoot = "has found the";		break;
				case 1: sLoot = "has recovered the";	break;
				case 2: sLoot = "has unearthed the";	break;
				case 3: sLoot = "has discovered the";	break;
			}

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " " + sLoot + " " + sBox + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Quests" );
			}

			return null;
		}
		// --------------------------------------------------------------------------------------------
		public static string LogQuestItem( Mobile m, string sBox )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			string sLoot = "has discovered";
			switch( Utility.Random( 4 ) )
			{
				case 0: sLoot = "has found";		break;
				case 1: sLoot = "has recovered";	break;
				case 2: sLoot = "has unearthed";	break;
				case 3: sLoot = "has discovered";	break;
			}

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " " + sLoot + " " + sBox + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Quests" );
			}

			return null;
		}
		// --------------------------------------------------------------------------------------------
		public static string LogQuestBody( Mobile m, string sBox )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			string sLoot = "has found";
			switch( Utility.Random( 4 ) )
			{
				case 0: sLoot = "has found";		break;
				case 1: sLoot = "has recovered";	break;
				case 2: sLoot = "has unearthed";	break;
				case 3: sLoot = "has dug up";		break;
			}

			string sBone = "the bones";
			switch( Utility.Random( 4 ) )
			{
				case 0: sBone = "the bones";		break;
				case 1: sBone = "the body";			break;
				case 2: sBone = "the remains";		break;
				case 3: sBone = "the corpse";		break;
			}

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " " + sLoot + " " + sBone + " of " + sBox + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Quests" );
			}

			return null;
		}
		// --------------------------------------------------------------------------------------------
		public static string LogQuestChest( Mobile m, string sBox )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			string sLoot = "has found";
			switch( Utility.Random( 4 ) )
			{
				case 0: sLoot = "has found";		break;
				case 1: sLoot = "has recovered";	break;
				case 2: sLoot = "has unearthed";	break;
				case 3: sLoot = "has dug up";		break;
			}

			string sChest = "the hidden";
			switch( Utility.Random( 4 ) )
			{
				case 0: sChest = "the hidden";		break;
				case 1: sChest = "the lost";		break;
				case 2: sChest = "the missing";		break;
				case 3: sChest = "the secret";		break;
			}

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " " + sLoot + " " + sChest + " chest of " + sBox + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Quests" );
			}

			return null;
		}
		// --------------------------------------------------------------------------------------------
		public static string LogQuestMap( Mobile m, int sLevel, string chest )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			string sLoot = "has found";
			switch( Utility.Random( 4 ) )
			{
				case 0: sLoot = "has found";		break;
				case 1: sLoot = "has recovered";	break;
				case 2: sLoot = "has unearthed";	break;
				case 3: sLoot = "has dug up";		break;
			}

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " " + sLoot + " " + chest + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Quests" );
			}

			return null;
		}
		// --------------------------------------------------------------------------------------------
		public static string LogQuestSea( Mobile m, int sLevel, string sShip )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			string sLoot = "has fished up";
			switch( Utility.Random( 4 ) )
			{
				case 0: sLoot = "has surfaced";		break;
				case 1: sLoot = "has salvaged";		break;
				case 2: sLoot = "has brought up";	break;
				case 3: sLoot = "has fished up";	break;
			}

			string sChest = "a grand sunken chest";
			switch( sLevel )
			{
				case 0: sChest = "a meager sunken chest";		break;
				case 1: sChest = "a simple sunken chest";		break;
				case 2: sChest = "a good sunken chest";			break;
				case 3: sChest = "a great sunken chest";		break;
				case 4: sChest = "an excellent sunken chest";	break;
				case 5: sChest = "a superb sunken chest";		break;
			}

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " " + sLoot + " " + sChest + " from " + sShip + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Quests" );
			}

			return null;
		}
		// --------------------------------------------------------------------------------------------
		public static string LogQuestKill( Mobile m, string sBox, Mobile t )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			string sLoot = "";
			string sWho = "";
			
			if ( sBox == "bounty" )
			{
				sWho = "";
				switch( Utility.Random( 4 ) )
				{
					case 0: sLoot = "has fullfilled a bounty on";	break;
					case 1: sLoot = "has claimed a bounty on";		break;
					case 2: sLoot = "has served a bounty on";		break;
					case 3: sLoot = "has completed a bounty on";	break;
				}
			}
			if ( sBox == "sea" )
			{
				sWho = " on the high seas";
				switch( Utility.Random( 4 ) )
				{
					case 0: sLoot = "has fullfilled a bounty on";	break;
					case 1: sLoot = "has claimed a bounty on";		break;
					case 2: sLoot = "has served a bounty on";		break;
					case 3: sLoot = "has completed a bounty on";	break;
				}
			}
			if ( sBox == "assassin" )
			{
				sWho = " for the guild";
				switch( Utility.Random( 4 ) )
				{
					case 0: sLoot = "has assassinated";		break;
					case 1: sLoot = "has dispatched";		break;
					case 2: sLoot = "has dealt with";		break;
					case 3: sLoot = "has eliminated";		break;
				}
			}
			
			sLoot = sLoot + " " + t.Name + " " + t.Title;

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " " + sLoot + sWho + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Quests" );
			}

			return null;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogGeneric( Mobile m, string sText )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " " + sText + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Quests" );
			}

			return null;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogStandard( Mobile m, string sText )
		{
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			PlayerMobile pm = (PlayerMobile)m;
			if (pm.PublicInfo == true)
			{
				string sEvent = m.Name + " " + sTitle + " " + sText + "#" + sDateString;
				LoggingFunctions.LogEvent( sEvent, "Logging Adventures" );
			}

			return null;
		}
		
		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogAccess( Mobile m, string sAccess )
		{
			PlayerMobile pm = (PlayerMobile)m;
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

            if ( m.AccessLevel < AccessLevel.GameMaster )
            {
				m.ResetInn();
				string sEvent;
				if ( sAccess == "login" )
				{
					sEvent = m.Name + " " + sTitle + " had entered the realm#" + sDateString;
					World.Broadcast(0x35, true, "{0} {1} has entered the realm", m.Name, sTitle);
				}
				else
				{
					sEvent = m.Name + " " + sTitle + " had left the realm#" + sDateString;
					World.Broadcast(0x35, true, "{0} {1} has left the realm", m.Name, sTitle);
				}

				LoggingFunctions.LogEvent( sEvent, "Logging Adventures" );
            }

			return null;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogDeaths( Mobile m, Mobile mob )
		{
			if ( m is PlayerMobile && mob != null )
			{
				PlayerMobile pm = (PlayerMobile)m;
				string sDateString = GetPlayerInfo.GetTodaysDate();
				string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
				if ( m.Title != null ){ sTitle = m.Title; }

				string sKiller = mob.Name;
				string[] eachWord = sKiller.Split('[');
				int nLine = 1;
				foreach (string eachWords in eachWord)
				{
					if ( nLine == 1 ){ nLine = 2; sKiller = eachWords; }
				}
				sKiller = sKiller.TrimEnd();

				///////// PLAYER DIED SO DO SINGLE FILES //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				if ( m.AccessLevel < AccessLevel.GameMaster )
				{
					string sEvent = "";

					if ( pm.PublicInfo == true )
					{
						if ( ( mob == m ) && ( mob != null ) )
						{
							sEvent = m.Name + " " + sTitle + " had killed themselves#" + sDateString;
						}
						else if ( ( mob != null ) && ( mob is PlayerMobile ) )
						{
							string kTitle = " the " + GetPlayerInfo.GetSkillTitle( mob );
							if ( mob.Title != null ){ kTitle = " " + mob.Title; }
							sEvent = m.Name + " " + sTitle + " had been killed by " + sKiller + kTitle + "#" + sDateString;
						}
						else if ( mob != null )
						{
							string kTitle = "";
							if ( mob.Title != null ){ kTitle = " " + mob.Title; }
							sEvent = m.Name + " " + sTitle + " had been killed by " + sKiller + kTitle + "#" + sDateString;
						}
						else
						{
							sEvent = m.Name + " " + sTitle + " had been killed#" + sDateString;
						}
					}
					else
					{
						string privateEnemy = "an opponent";
						switch ( Utility.Random( 6 ) )
						{
							case 0: privateEnemy = "an opponent"; break;
							case 1: privateEnemy = "an enemy"; break;
							case 2: privateEnemy = "another"; break;
							case 3: privateEnemy = "an adversary"; break;
							case 4: privateEnemy = "a foe"; break;
							case 5: privateEnemy = "a rival"; break;
						}

						if ( ( mob == m ) && ( mob != null ) )
						{
							sEvent = m.Name + " " + sTitle + " had killed themselves#" + sDateString;
						}
						else if ( ( mob != null ) && ( mob is PlayerMobile ) )
						{
							string kTitle = "the " + GetPlayerInfo.GetSkillTitle( mob );
							if ( mob.Title != null ){ kTitle = mob.Title; }
							sEvent = m.Name + " " + sTitle + " had been killed by " + sKiller + " " + kTitle + "#" + sDateString;
						}
						else if ( mob != null )
						{
							sEvent = m.Name + " " + sTitle + " had been killed by " + privateEnemy + "#" + sDateString;
						}
						else
						{
							sEvent = m.Name + " " + sTitle + " had been killed#" + sDateString;
						}
					}
					LoggingFunctions.LogEvent( sEvent, "Logging Deaths" );
				}
			}
			return null;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogKillers( Mobile m, int nKills )
		{
			string sEvent = "";
			string sDateString = GetPlayerInfo.GetTodaysDate();
			string sTitle = "the " + GetPlayerInfo.GetSkillTitle( m );
			if ( m.Title != null ){ sTitle = m.Title; }

			if ( m.Kills > 1){ sEvent = m.Name + " " + sTitle + " is wanted for the murder of " + m.Kills + " people."; }
			else if ( m.Kills > 0){ sEvent = m.Name + " " + sTitle + " is wanted for murder."; }

			LoggingFunctions.LogEvent( sEvent, "Logging Murderers" );

			return null;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public static string LogClear( string sLog )
		{
			string sPath = "Saves/Data/adventures.txt";
 
			if ( sLog == "Logging Adventures" ){ sPath = "Saves/Data/adventures.txt"; }
			else if ( sLog == "Logging Battles" ){ sPath = "Saves/Data/battles.txt"; }
			else if ( sLog == "Logging Deaths" ){ sPath = "Saves/Data/deaths.txt"; }
			else if ( sLog == "Logging Murderers" ){ sPath = "Saves/Data/murderers.txt"; }
			else if ( sLog == "Logging Journies" ){ sPath = "Saves/Data/journies.txt"; }

			DeleteFile( sPath );

			return null;
		}
	}
}

namespace Server.Misc
{
	public class StatusPage : Timer
	{
		public static bool Enabled = true;

		public static void Initialize()
		{
			if ( Enabled )
				new StatusPage().Start();
		}

		public StatusPage() : base( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 60.0 ) )
		{
			Priority = TimerPriority.FiveSeconds;
		}

		private static string Encode( string input )
		{
			StringBuilder sb = new StringBuilder( input );

			sb.Replace( "&", "&amp;" );
			sb.Replace( "<", "&lt;" );
			sb.Replace( ">", "&gt;" );
			sb.Replace( "\"", "&quot;" );
			sb.Replace( "'", "&apos;" );

			return sb.ToString();
		}

		protected override void OnTick()
		{
			if ( !Directory.Exists( "Saves/Data" ) )
				Directory.CreateDirectory( "Saves/Data" );

			LoggingFunctions.CreateFile( "Saves/Data/online.txt" );

			using ( StreamWriter op = new StreamWriter( "Saves/Data/online.txt" ) )
			{
				foreach ( NetState state in NetState.Instances )
				{
					Mobile m = state.Mobile;

					if ( m != null && ( m.AccessLevel < AccessLevel.GameMaster ) )
					{
						op.Write( Encode( m.Name ) );
						op.Write( " the " );
						op.Write( GetPlayerInfo.GetSkillTitle( m ) );
						op.Write( "\n" );
					}
				}
			}

			if ( LoggingFunctions.LoggingEvents() == true )
			{
				LoggingFunctions.LogClear( "Logging Murderers" );

				// GET ALL OF THE MURDERERS ///////////////////////////////
				foreach ( Account a in Accounts.GetAccounts() )
				{
					if (a == null)
						break;

					int index = 0;

					for (int i = 0; i < a.Length; ++i)
					{
						Mobile m = a[i];

						if (m == null)
							continue;

						if ( ( m.Kills > 0 ) && (m.AccessLevel < AccessLevel.GameMaster) )
						{
							LoggingFunctions.LogKillers( m, m.Kills );
						}

						++index;
					}
				}
			}
		}
	}
}

namespace Server.Gumps
{
	public class LoggingGumpCrier : Gump
	{
        public LoggingGumpCrier( Mobile from, int page ) : base( 50, 50 )
        {
			from.SendSound( 0x4A ); 
			string color = "#aecdf6";
			string sEvents = "";
			bool scroll = false;

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			AddImage(0, 0, 7018, Server.Misc.PlayerSettings.GetGumpHue( from ));

			AddHtml( 12, 12, 835, 20, @"<BODY><BASEFONT Color=" + color + ">THE NEWS FROM THE TOWN CRIER</BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(879, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);

			int btn1 = 3609;
			int btn2 = 3609;
			int btn3 = 3609;
			int btn4 = 3609;
			int btn5 = 3609;
			int btn6 = 3609;

			if ( page == 2 )
			{
				sEvents = "Deeds In The Realm<br><br>" + LoggingFunctions.LogRead( "Logging Quests", from ); scroll = true; btn1 = 4011;
			}
			else if ( page == 3 )
			{
				sEvents = "Exploration In The Realm<br><br>" + LoggingFunctions.LogRead( "Logging Journies", from ); scroll = true; btn2 = 4011;
			}
			else if ( page == 4 )
			{
				sEvents = "Victories In The Realm<br><br>" + LoggingFunctions.LogRead( "Logging Battles", from ); scroll = true; btn3 = 4011;
			}
			else if ( page == 5 )
			{
				sEvents = "Recent Deaths In The Realm<br><br>" + LoggingFunctions.LogRead( "Logging Deaths", from ); scroll = true; btn4 = 4011;
			}
			else if ( page == 6 )
			{
				sEvents = "Murderers In The Realm<br><br>" + LoggingFunctions.LogRead( "Logging Murderers", from ); scroll = true; btn5 = 4011;
			}
			else if ( page == 7 )
			{
				sEvents = "Gossip In The Realm<br><br>" + LoggingFunctions.LogRead( "Logging Adventures", from ); scroll = true; btn6 = 4011;
			}

			AddButton(12, 48, btn1, btn1, 1, GumpButtonType.Reply, 0);
			AddHtml( 52, 50, 185, 20, @"<BODY><BASEFONT Color=" + color + ">Deeds in the Realm</BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(344, 49, btn2, btn2, 2, GumpButtonType.Reply, 0);
			AddHtml( 384, 51, 185, 20, @"<BODY><BASEFONT Color=" + color + ">Exploration in the Realm</BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(676, 50, btn3, btn3, 3, GumpButtonType.Reply, 0);
			AddHtml( 716, 52, 185, 20, @"<BODY><BASEFONT Color=" + color + ">Victories in Battle</BASEFONT></BODY>", (bool)false, (bool)false);


			AddButton(12, 77, btn6, btn6, 6, GumpButtonType.Reply, 0);
			AddHtml( 52, 79, 185, 20, @"<BODY><BASEFONT Color=" + color + ">Gossip in the Realm</BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(344, 78, btn4, btn4, 4, GumpButtonType.Reply, 0);
			AddHtml( 384, 80, 185, 20, @"<BODY><BASEFONT Color=" + color + ">Recent Deaths</BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(676, 79, btn5, btn5, 5, GumpButtonType.Reply, 0);
			AddHtml( 716, 81, 185, 20, @"<BODY><BASEFONT Color=" + color + ">Wanted Murderers</BASEFONT></BODY>", (bool)false, (bool)false);

			AddHtml( 12, 111, 888, 491, @"<BODY><BASEFONT Color=" + color + ">" + sEvents + "</BASEFONT></BODY>", (bool)false, (bool)scroll);
        }

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;
			from.SendSound( 0x4A ); 

			switch ( info.ButtonID )
			{
				case 1:
				{
					from.CloseGump( typeof( LoggingGumpCrier ) );
					from.SendGump( new LoggingGumpCrier( from, 2 ) );
					break;
				}
				case 2:
				{
					from.CloseGump( typeof( LoggingGumpCrier ) );
					from.SendGump( new LoggingGumpCrier( from, 3 ) );
					break;
				}
				case 3:
				{
					from.CloseGump( typeof( LoggingGumpCrier ) );
					from.SendGump( new LoggingGumpCrier( from, 4 ) );
					break;
				}
				case 4:
				{
					from.CloseGump( typeof( LoggingGumpCrier ) );
					from.SendGump( new LoggingGumpCrier( from, 5 ) );
					break;
				}
				case 5:
				{
					from.CloseGump( typeof( LoggingGumpCrier ) );
					from.SendGump( new LoggingGumpCrier( from, 6 ) );
					break;
				}
				case 6:
				{
					from.CloseGump( typeof( LoggingGumpCrier ) );
					from.SendGump( new LoggingGumpCrier( from, 7 ) );
					break;
				}
			}
		}
    }
}