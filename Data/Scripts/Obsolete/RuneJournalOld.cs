using System;
using System.Collections;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using Server.ContextMenus;
using Server.Spells;
using System.Collections.Generic;
using Server.Misc;
using Server;
using Server.Gumps;
using Server.Commands;

namespace Server.Items
{
	public class RuneMagicBook : WritingBook
	{
		[Constructable]
		public RuneMagicBook() : base( "Rune Magic", "Garamon", 50, true ) // writable so players can make notes
		{
			Hue = Utility.RandomColor(0);
			ItemID = 0x2255;

			// NOTE: There are 8 lines per page and 
			// approx 22 to 24 characters per line! 
			//	0----+----1----+----2----+ 
			int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"     Rune Magic", 
				"     by Garamon", 
				"", 
				"With reagents being rare", 
				"in the Abyss, I began to", 
				"research other ways to",
				"cast magery spells. I",
				"have found various old", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"stone tablets here that", 
				"describe the use of rune", 
				"stones in this manner.", 
				"One must find a rune of", 
				"marked with the symbols", 
				"needed to speak the", 
				"mantra for the spell.", 
				"Once the correct ones", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"are assembled they must", 
				"be placed in a magical", 
				"rune bag where one can", 
				"then use the sack to", 
				"unleash the magic power", 
				"of the spell. This is", 
				"by no means a simple", 
				"process, as gathering", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"the runes can be quite", 
				"tedious, but it is a", 
				"way to cast spells in", 
				"a pinch. The runes and", 
				"bag seem to bind with", 
				"the caster as I thought", 
				"I lost them at one", 
				"point, but they seemed", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"to have come back to me", 
				"as if magically. Though", 
				"I could lose my spell", 
				"book and reagents, the", 
				"runes allow me to still", 
				"work with spells. I", 
				"have been searching for", 
				"a spell to summon a", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"daemon for years now.", 
				"I have already found the", 
				"runes that will allow me", 
				"to cast such a spell", 
				"without the need of a", 
				"rare scroll. Many mages", 
				"scoff at the use of", 
				"runes, but to me they", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"are becoming a valuable", 
				"arcana that I have not", 
				"been able to do without.", 
				"I will attempt to write", 
				"my findings on these", 
				"ancient ways to cast", 
				"magic spells so others", 
				"may one day benefit.", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"     Rune Magic", 
				"     by Garamon", 
				"", 
				"The following is all of", 
				"my research on rune", 
				"magic, the known spells,",
				"and the rune symbols.",
				"", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"     Rune Bags", 
				"", 
				"Rune bags and runes are", 
				"imbued with the power to", 
				"assist the caster in the", 
				"casting of a spell without", 
				"the need of reagents.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"Place one of each", 
				"required rune stone", 
				"inside the rune bag", 
				"by opening the bag.", 
				"[click on the bag]", 
				"and concentrate on the", 
				"incantation of the spell.", 
				"[double click the bag]", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"Following is a complete", 
				"list of all known spells", 
				"and the runes needed to", 
				"cast them.", 
				"Note that even with the", 
				"runes, a mage must still", 
				"have the will and power", 
				"to cast the spell.", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"First Circle", 
				" Clumsy", 
				"    In Jux", 
				"",
				"",
				" Create Food", 
				"    In Mani Ylem", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"", 
				" Feeblemind", 
				"    Rel Wis", 
				"",
				"",
				" Heal", 
				"    In Mani", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"", 
				" Magic Arrow", 
				"    In Por Ylem", 
				"",
				"",
				" Night Sight", 
				"    In Lor", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"", 
				" Reactive Armor", 
				"    Flam Sanct", 
				"",
				"", 
				" Weaken", 
				"    Des Mani", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"  Meanings of Runes", 
				"", 
				"An   - Negate/Dispel", 
				"Bet  - Small", 
				"Corp - Death", 
				"Des  - Lower/Down", 
				"Ex   - Freedom", 
				"Flam - Flame", 
			}; 
			Pages[cnt++].Lines = lines; 

			lines = new string[] 
			{ 
				"Grav - Energy/Field", 
				"Hur  - Wind", 
				"In   - Make/Create/Cause", 
				"Jux  - Danger/Trap/Harm", 
				"Kal  - Summon/Invoke", 
				"Lor  - Light", 
				"Mani - Life/Healing", 
				"Nox  - Poison", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"Ort  - Magic", 
				"Por  - Move/Movement", 
				"Quas - Illusion", 
				"Rel  - Change", 
				"Sanct- Protection", 
				"Tym  - Time", 
				"Uus  - Raise/Up", 
				"Vas  - Great", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"Wis  - Knowledge", 
				"Xen  - Creature", 
				"Ylem - Matter", 
				"Zu   - Sleep", 
				"", 
				"Runes must be used in", 
				"combinations to form", 
				"spells of power!", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"", 
				"The meanings are the key!", 
				"", 
				"", 
				"The following pages have", 
				"been left blank for thee", 
				"to take thy notes here.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;

			lines = new string[] 
			{ 
				"", 
				"Go forth to learn", 
				"the other spells.", 
				"", 
				"Best of luck in", 
				"thy experiments!", 
				"", 
				" - Garamon", 

			}; 
			Pages[cnt++].Lines = lines;
		}

		public RuneMagicBook( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new RuneJournal();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}

	public class RuneBagBook : RuneMagicBook
	{
		[Constructable]
		public RuneBagBook() : base()
		{
		}

		public RuneBagBook( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new RuneJournal();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}