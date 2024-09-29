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
	public class RuneBag : BaseContainer
	{
		public override int DefaultGumpID{ get{ return 0x3D; } }
		public override int DefaultDropSound{ get{ return 0x48; } }

		public override Rectangle2D Bounds
		{
			get{ return new Rectangle2D( 29, 34, 108, 94 ); }
		}

		[Constructable]
		public RuneBag() : base( 0xE84 )
		{
			Name = "rune bag";
			Weight = 1.0;
		}

		public void RuneBagCast( Mobile m, RuneBag bag )
		{

// descs from U6. For reference.
// I've left in my notes for rareness, this is custom to my shard.

			bool foundAn	= false; // Negate/Dispel	- common
			bool foundBet	= false; // Small		- semi-common
			bool foundCorp	= false; // Death		- rare
			bool foundDes	= false; // Lower/Down		- semi-common
			bool foundEx	= false; // Freedom		- semi-common
			bool foundFlam	= false; // Flame		- semi-common
			bool foundGrav	= false; // Energy/Field	- rare
			bool foundHur	= false; // Wind		- semi-common
			bool foundIn	= false; // Make/Create/Cause	- common
			bool foundJux	= false; // Danger/Trap/Harm	- semi-common
			bool foundKal	= false; // Summon/Invoke	- common
			bool foundLor	= false; // Light		- common
			bool foundMani	= false; // Life/Healing	- common
			bool foundNox	= false; // Poison		- semi-common
			bool foundOrt	= false; // Magic		- semi-common
			bool foundPor	= false; // Move/Movement	- semi-common
			bool foundQuas	= false; // Illusion		- semi-common
			bool foundRel	= false; // Change		- common
			bool foundSanct	= false; // Protect/Protection	- semi-common
			bool foundTym	= false; // Time		- rare
			bool foundUus	= false; // Raise/Up		- semi-common
			bool foundVas	= false; // Great		- rare
			bool foundWis	= false; // Know/Knowledge	- semi-common
			bool foundXen	= false; // Creature		- semi-common
			bool foundYlem	= false; // Matter		- semi-common
			bool foundZu	= false; // Sleep		- semi-common

			foreach( Item I in bag.Items ) 
			{ 
				if      ( I is An )
					foundAn		= true;
				else if ( I is Bet )
					foundBet	= true;
				else if ( I is Corp )
					foundCorp	= true;
				else if ( I is Des )
					foundDes	= true;
				else if ( I is Ex )
					foundEx		= true;
				else if ( I is Flam )
					foundFlam	= true;
				else if ( I is Grav )
					foundGrav	= true;
				else if ( I is Hur )
					foundHur	= true;
				else if ( I is In )
					foundIn		= true;
				else if ( I is Jux )
					foundJux	= true;
				else if ( I is Kal )
					foundKal	= true;
				else if ( I is Lor )
					foundLor	= true;
				else if ( I is Mani )
					foundMani	= true;
				else if ( I is Nox )
					foundNox	= true;
				else if ( I is Ort )
					foundOrt	= true;
				else if ( I is Por )
					foundPor	= true;
				else if ( I is Quas )
					foundQuas	= true;
				else if ( I is Rel )
					foundRel	= true;
				else if ( I is Sanct )
					foundSanct	= true;
				else if ( I is Tym )
					foundTym	= true;
				else if ( I is Uus )
					foundUus	= true;
				else if ( I is Vas )
					foundVas	= true;
				else if ( I is Wis )
					foundWis	= true;
				else if ( I is Xen )
					foundXen	= true;
				else if ( I is Ylem )
					foundYlem	= true;
				else if ( I is Zu )
					foundZu		= true;
			}

			int m_SpellID = -1;  // no match

/// spells go here.  ////////////////////////////////////////////
/*
			if ( ( found ) ) && bag.Items.Count ==  )
				m_SpellID = ;
*/

///  first circle   /////////////////////////////////////////////

// clumsy: Uus Jux
			if ( ( foundUus && foundJux ) && bag.Items.Count == 2 )
				m_SpellID = 0;

// Create food: In Mani Ylem
			if ( ( foundIn && foundMani && foundYlem ) && bag.Items.Count == 3 )
				m_SpellID = 1;

// Feeblemind: Rel Wis
			if ( ( foundRel && foundWis ) && bag.Items.Count == 2 )
				m_SpellID = 2;

// Heal: In Mani
			if ( ( foundIn && foundMani ) && bag.Items.Count == 2 )
				m_SpellID = 3;

// Magic arrow: In Por Ylem
			if ( ( foundIn && foundPor && foundYlem ) && bag.Items.Count == 3 )
				m_SpellID = 4;

// Night sight: In Lor
			if ( ( foundIn && foundLor ) && bag.Items.Count == 2 )
				m_SpellID = 5;

// Reactive armor: Flam Sanct
			if ( ( foundFlam && foundSanct ) && bag.Items.Count == 2 )
				m_SpellID = 6;

// Weaken: Des Mani
			if ( ( foundDes && foundMani ) && bag.Items.Count == 2 )
				m_SpellID = 7;

///  second circle   ///////////////////////////////////////////////

// Agility: Ex Uus
			if ( ( foundUus && foundEx ) && bag.Items.Count == 2 )
				m_SpellID = 8;

// Cunning: Uus Wis
			if ( ( foundUus && foundWis ) && bag.Items.Count == 2 )
				m_SpellID = 9;

// Cure: An Nox
			if ( ( foundAn && foundNox ) && bag.Items.Count == 2 )
				m_SpellID = 10;

// Harm: An Mani
			if ( ( foundAn && foundMani ) && bag.Items.Count == 2 )
				m_SpellID = 11;

// Magic Trap: In Jux
			if ( ( foundIn && foundJux ) && bag.Items.Count == 2 )
				m_SpellID = 12;

// Magic Untrap: An Jux
			if ( ( foundAn && foundJux ) && bag.Items.Count == 2 )
				m_SpellID = 13;

// Protection: Uus Sanct
			if ( ( foundUus && foundSanct ) && bag.Items.Count == 2 )
				m_SpellID = 14;

// Strength: Uus Mani
			if ( ( foundUus && foundMani ) && bag.Items.Count == 2 )
				m_SpellID = 15;

///  Third circle   ////////////////////////////////////////////

// Bless: Rel Sanct
			if ( ( foundRel && foundSanct ) && bag.Items.Count == 2 )
				m_SpellID = 16;

// Fireball: Vas Flam
			if ( ( foundVas && foundFlam ) && bag.Items.Count == 2 )
				m_SpellID = 17;

// Magic Lock: An Por
			if ( ( foundAn && foundPor ) && bag.Items.Count == 2 )
				m_SpellID = 18;

// Poison: In Nox
			if ( ( foundIn && foundNox ) && bag.Items.Count == 2 )
				m_SpellID = 19;

// Telekinesis: Ort Por Ylem
			if ( ( foundOrt && foundPor && foundYlem ) && bag.Items.Count == 3 )
				m_SpellID = 20;

// Teleport: Rel Por
			if ( ( foundRel && foundPor ) && bag.Items.Count == 2 )
				m_SpellID = 21;

// Unlock: Ex Por
			if ( ( foundEx && foundPor ) && bag.Items.Count == 2 )
				m_SpellID = 22;

// Wall of Stone: In Sanct Ylem
			if ( ( foundIn && foundSanct && foundYlem ) && bag.Items.Count == 3 )
				m_SpellID = 23;

///  Fourth circle   ////////////////////////////////////////////

// Arch Cure: Vas An Nox
			if ( ( foundVas && foundAn && foundNox ) && bag.Items.Count == 3 )
				m_SpellID = 24;

// Arch Protection: Vas Uus Sanct
			if ( ( foundVas && foundUus && foundSanct ) && bag.Items.Count == 3 )
				m_SpellID = 25;

// Curse: Des Sanct
			if ( ( foundDes && foundSanct ) && bag.Items.Count == 2 )
				m_SpellID = 26;

// Fire Field: In Flam Grav
			if ( ( foundIn && foundFlam && foundGrav ) && bag.Items.Count == 3 )
				m_SpellID = 27;

// Greater Heal: In Vas Mani
			if ( ( foundIn && foundVas && foundMani ) && bag.Items.Count == 3 )
				m_SpellID = 28;

// Lightning: Por Ort Grav
			if ( ( foundPor && foundOrt && foundGrav ) && bag.Items.Count == 3 )
				m_SpellID = 29;

// Mana Drain: Ort Rel
			if ( ( foundOrt && foundRel ) && bag.Items.Count == 2 )
				m_SpellID = 30;

// Recall: Kal Ort Por
			if ( ( foundKal && foundOrt && foundPor ) && bag.Items.Count == 3 )
				m_SpellID = 31;

/// Fifth  circle   ////////////////////////////////////////////

// Blade Spirits: In Jux Hur Ylem
			if ( ( foundIn && foundJux && foundHur && foundYlem ) && bag.Items.Count == 4 )
				m_SpellID = 32;

// Dispel Field: An Grav
			if ( ( foundAn && foundGrav ) && bag.Items.Count == 2 )
				m_SpellID = 33;

// Incognito: Kal In Ex
			if ( ( foundKal && foundIn && foundEx ) && bag.Items.Count == 3 )
				m_SpellID = 34;

// Magic Reflection: In Jux Sanct
			if ( ( foundIn && foundJux && foundSanct ) && bag.Items.Count == 3 )
				m_SpellID = 35;

// Mind Blast: Por Corp Wis
			if ( ( foundPor && foundCorp && foundWis ) && bag.Items.Count == 3 )
				m_SpellID = 36;

// Paralyze: An Ex Por
			if ( ( foundAn && foundEx && foundPor ) && bag.Items.Count == 3 )
				m_SpellID = 37;

// PoisonField: In Nox Grav
			if ( ( foundIn && foundNox && foundGrav ) && bag.Items.Count == 3 )
				m_SpellID = 38;

// Summon Creature: Kal Xen
			if ( ( foundKal && foundXen ) && bag.Items.Count == 2 )
				m_SpellID = 39;

/// Sixth  circle   ////////////////////////////////////////////

// Dispel: An Ort
			if ( ( foundAn && foundOrt ) && bag.Items.Count == 2 )
				m_SpellID = 40;

// Eenrgy Bolt: Corp Por
			if ( ( foundCorp && foundPor ) && bag.Items.Count == 2 )
				m_SpellID = 41;

// Explosion: Vas Ort Flam
			if ( ( foundVas && foundOrt && foundFlam ) && bag.Items.Count == 3 )
				m_SpellID = 42;

// Invisibility: An Lor Xen
			if ( ( foundAn && foundLor && foundXen ) && bag.Items.Count == 3 )
				m_SpellID = 43;

// Mark: Kal Por Ylem
			if ( ( foundKal && foundPor && foundYlem ) && bag.Items.Count == 3 )
				m_SpellID = 44;

// Mass Curse: Vas Des Sanct
			if ( ( foundVas && foundDes && foundSanct ) && bag.Items.Count == 3 )
				m_SpellID = 45;

// Paralyze Field: In Ex Grav
			if ( ( foundIn && foundEx && foundGrav ) && bag.Items.Count == 3 )
				m_SpellID = 46;

// Reveal: Wis Quas
			if ( ( foundWis && foundQuas ) && bag.Items.Count == 2 )
				m_SpellID = 47;

/// Seventh  circle   ////////////////////////////////////////////

// Chain Lightning: Vas Ort Grav
			if ( ( foundVas && foundOrt && foundGrav ) && bag.Items.Count == 3 )
				m_SpellID = 48;

// Energy Field: In Sanct Grav
			if ( ( foundIn && foundSanct && foundGrav ) && bag.Items.Count == 3 )
				m_SpellID = 49;

// Flame Strike: Kal Vas Flam
			if ( ( foundKal && foundVas && foundFlam ) && bag.Items.Count == 3 )
				m_SpellID = 50;

// Gate Travel: Vas Rel Por
			if ( ( foundVas && foundRel && foundPor ) && bag.Items.Count == 3 )
				m_SpellID = 51;

// Mana Vampire: Ort Sanct
			if ( ( foundOrt && foundSanct ) && bag.Items.Count == 2 )
				m_SpellID = 52;

// Mass Dispel: Vas An Ort
			if ( ( foundVas && foundAn && foundOrt ) && bag.Items.Count == 3 )
				m_SpellID = 53;

// Meteor Swarm: Flam Kal Des Ylem
			if ( ( foundFlam && foundKal && foundDes && foundYlem ) && bag.Items.Count == 4 )
				m_SpellID = 54;

// Polymorph: Vas Ylem Rel
			if ( ( foundVas && foundYlem && foundRel ) && bag.Items.Count == 3 )
				m_SpellID = 55;

// Captain the First was the First one to code the 8th circle spells and publish them!
/// Eighth  circle   //////////////////////////////////////////// 

// "Earthquake", "In Vas Por" 
         if ( ( foundIn && foundVas && foundPor ) && bag.Items.Count == 3 ) 
            m_SpellID = 56; 

// "Energy Vortex", "Vas Corp Por" 
         if ( ( foundVas && foundCorp && foundPor ) && bag.Items.Count == 3 ) 
            m_SpellID = 57; 

// "Resurrection", "An Corp" 
         if ( ( foundAn && foundCorp ) && bag.Items.Count == 2 ) 
            m_SpellID = 58; 

// "Air Elemental", "Kal Vas Xen Hur" 
         if ( ( foundKal && foundVas && foundXen && foundHur ) && bag.Items.Count ==  4 ) 
            m_SpellID = 59; 

// "Summon Daemon", "Kal Vas Xen Corp" 
         if ( ( foundKal && foundVas && foundXen && foundCorp ) && bag.Items.Count ==  4 ) 
            m_SpellID = 60; 

// "Earth Elemental", "Kal Vas Xen Ylem" 
         if ( ( foundKal && foundVas && foundXen && foundYlem ) && bag.Items.Count ==  4 ) 
            m_SpellID = 61; 

// "Fire Elemental", "Kal Vas Xen Flam" 
         if ( ( foundKal && foundVas && foundXen && foundFlam ) && bag.Items.Count ==  4 ) 
            m_SpellID = 62; 

// "Water Elemental", "Kal Vas Xen An Flam" 
         if ( ( foundKal && foundVas && foundXen && foundAn && foundFlam ) && bag.Items.Count ==  5 ) 
            m_SpellID = 63; 

//FIST Start Necromancy Spells

// "Curse Weapon", An Sanct Grav Corp
		 if ( ( foundAn && foundSanct && foundGrav && foundCorp ) && bag.Items.Count == 4 )
			 m_SpellID = 103;
// "Blood Oath", In Jux Mani Xen
		 if ( ( foundIn && foundJux && foundMani && foundXen ) && bag.Items.Count == 4 )
			 m_SpellID = 101;
// "Corpse Skin", In An Corp Ylem
		 if ( ( foundIn && foundAn && foundCorp && foundYlem ) && bag.Items.Count == 4 )
			 m_SpellID = 102;
// "Evil Omen", Por Tym An Sanct
		 if ( ( foundPor && foundTym && foundAn && foundSanct ) && bag.Items.Count == 4 )
			 m_SpellID = 104;
// "Pain Spike", In Sanct
		 if ( ( foundIn && foundSanct ) && bag.Items.Count == 2 )
			 m_SpellID = 108;
// "Wraith Form", Rel Xen Uus
		 if ( ( foundRel && foundXen && foundUus ) && bag.Items.Count == 3 )
			 m_SpellID = 115;
// "Mind Rot", Wis An Bet
		 if ( ( foundAn && foundWis && foundBet ) && bag.Items.Count == 3 )
			 m_SpellID = 107;
// "Summon Familiar, Kal Xen Bet
		 if ( ( foundKal && foundXen && foundBet ) && bag.Items.Count == 3 )
			 m_SpellID = 111;
// "Animate Dead", Uus Corp
		 if ( ( foundUus && foundCorp ) && bag.Items.Count == 2 )
			 m_SpellID = 100;
// "Horrific Beast, Rel Xen Vas Bet
		 if ( ( foundRel && foundXen && foundVas && foundBet ) && bag.Items.Count == 4 )
			 m_SpellID = 105;
// "Poison Strike", In Vas Nox
		 if ( ( foundIn && foundVas && foundNox ) && bag.Items.Count == 3 )
			 m_SpellID = 109;
// "Wither", Kal Vas An Flam
		 if ( ( foundKal && foundVas && foundAn && foundFlam ) && bag.Items.Count == 4 )
			 m_SpellID = 114;
// "Strangle", In Bet Nox
		 if ( ( foundIn && foundBet && foundNox ) && bag.Items.Count == 3 )
			 m_SpellID = 110;
// "Lich Form", Rel Xen Corp Ort
		 if ( ( foundRel && foundXen && foundCorp && foundOrt ) && bag.Items.Count == 4 )
			 m_SpellID = 106;
// "Exorcism", Ort Corp Grav
		 if ( ( foundOrt && foundCorp && foundGrav ) && bag.Items.Count == 3 )
			 m_SpellID = 116;
// "Vengeful Spirit", Kal Xen Bet Bet
		 if ( ( foundKal && foundXen && foundBet ) && bag.Items.Count == 4 )//FIST Should say for as Bet is found, but need 2 of them. May work with any other rune as well...
			 m_SpellID = 113;
// "Vampiric Embrace", Rel Xen An Sanct
		 if ( ( foundRel && foundXen && foundAn && foundSanct ) && bag.Items.Count == 4 )
			 m_SpellID = 112;
		 
/// end spells /////////////////////////////////////

         if ( foundBet || foundTym || foundZu )  // currently unused.
		m.SendMessage( "One of the runestones feels cold." );

/// end spells /////////////////////////////////////

/// begin spellcasting /////////////////////////////

			if ( !Multis.DesignContext.Check( m ) )
				return; // They are customizing

			if ( !IsChildOf( m.Backpack ) )
			{
				m.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
				return;
			}

			if ( m_SpellID == -1 )
			{
				m.SendMessage( "Not a known spell" );
				return;
			}

			Spell spell = SpellRegistry.NewSpell( m_SpellID, m, this );

			if ( spell != null )
			{
				spell.Cast();
			}
			else
				m.SendLocalizedMessage( 502345 ); // This spell has been temporarily disabled.
		}

		public class RuneBagMenu : ContextMenuEntry 
		{ 
			private RuneBag i_RuneBag; 
			private Mobile m_From; 

			public RuneBagMenu( Mobile from, RuneBag bag ) : base( 6122, 1 ) 
			{ 
				m_From = from; 
				i_RuneBag = bag; 
			} 

			public override void OnClick() 
			{          
				if( i_RuneBag.IsChildOf( m_From.Backpack ) ) 
				{ 
					i_RuneBag.Open( m_From );
				} 
				else 
				{
					m_From.SendMessage( "This must be in your backpack to look through." );
				} 
			} 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );

			if ( from.Alive )
				list.Add( new RuneBagMenu( from, this ) );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( this.IsChildOf( from.Backpack ) ) 
			{ 
				this.RuneBagCast( from, this );
			}
			else
			{
				from.SendMessage( "This must be in your backpack to look through." );
			}
		}

		public RuneBag( Serial serial ) : base( serial )
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
			Timer.DelayCall( TimeSpan.FromSeconds( 10.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Container cont = (Container)state;

			Item item = new MagicRuneBag();
			item.Resource = CraftResource.RegularLeather;

			if ( cont.Parent is Container )
			{
				List<Item> belongings = new List<Item>();
				foreach( Item i in cont.Items )
				{
					belongings.Add(i);
				}

				Container box = (Container)(cont.Parent);
				foreach ( Item stuff in belongings )
				{
					box.DropItem(stuff);
				}
			}

			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}