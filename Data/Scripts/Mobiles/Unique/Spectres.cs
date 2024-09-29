using System;
using Server;
using Server.Items;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using Server.Misc;
using Server.Commands;
using Server.Commands.Generic;

namespace Server.Mobiles
{
	[CorpseName( "a ghostly corpse" )]
	public class Spectres : BaseCreature
	{
		[Constructable]
		public Spectres() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a spectre";
			BaseSoundID = Utility.RandomList( 0x19C, 0x3E9 );
			Hue = 16385;
			Body = 24;
			EmoteHue = 123;

			SetStr( 171, 200 );
			SetDex( 126, 145 );
			SetInt( 276, 305 );

			SetHits( 103, 120 );

			SetDamage( 24, 26 );

			SetDamageType( ResistanceType.Physical, 10 );
			SetDamageType( ResistanceType.Cold, 40 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 40, 60 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 55, 65 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Necromancy, 89, 99.1 );
			SetSkill( SkillName.Spiritualism, 90.0, 99.0 );

			SetSkill( SkillName.Psychology, 100.0 );
			SetSkill( SkillName.Magery, 70.1, 80.0 );
			SetSkill( SkillName.Meditation, 85.1, 95.0 );
			SetSkill( SkillName.MagicResist, 80.1, 100.0 );
			SetSkill( SkillName.Tactics, 70.1, 90.0 );

			Fame = 8000;
			Karma = -8000;

			VirtualArmor = 50;
			PackItem( new GnarledStaff() );
			PackReg( 17, 24 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.MedScrolls, 2 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 3; } }

		public override bool OnBeforeDeath()
		{
			this.Body = 13;

			Map map = this.Map;

			bool validLocation = false;
			Point3D loc = this.Location;

			for ( int j = 0; !validLocation && j < 10; ++j )
			{
				int x = X + Utility.Random( 3 ) - 1;
				int y = Y + Utility.Random( 3 ) - 1;
				int z = map.GetAverageZ( x, y );

				if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
					loc = new Point3D( x, y, Z );
				else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
					loc = new Point3D( x, y, z );
			}

			return base.OnBeforeDeath();
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			SpectresBox MyChest = new SpectresBox();
   			c.DropItem( MyChest );
		}

		public Spectres( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace Server.Items
{
	public class SpectresBox : Item
	{
		[Constructable]
		public SpectresBox() : base( 0x1C0E )
		{
			Name = "the spectre's box";
			Movable = false;
			Hue = 0x51F;
			ItemID = Utility.RandomList( 0x1C0E, 0x1C0F );
		}

		public SpectresBox( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( PlayerSettings.GetBardsTaleQuest( from, "BardsTaleSpectreEye" ) && PlayerSettings.GetBardsTaleQuest( from, "BardsTaleHarkynKey" ) )
			{
				from.PrivateOverheadMessage(MessageType.Regular, 1150, false, "You find nothing of interest.", from.NetState);
			}
			else
			{
				PlayerSettings.SetBardsTaleQuest( from, "BardsTaleSpectreEye", true );
				PlayerSettings.SetBardsTaleQuest( from, "BardsTaleHarkynKey", true );
				from.SendSound( 0x3D );
				from.PrivateOverheadMessage(MessageType.Regular, 1150, false, "You found a mysterious eye and a key with a dragon symbol on it.", from.NetState);
				from.CloseGump( typeof(Server.Gumps.ClueGump) );
				from.SendGump(new Server.Gumps.ClueGump( from, "You have obtained an eye from the slain spectre, and the box has a key with a dragon symbol on it. A scribbled parchment claims it to be the Eye of Tarjan.", "The Spectre's Eye" ) );
			}
		}

		public override bool OnDragLift( Mobile from )
		{
			if ( !NotModAble )
			{
				NotModAble = true;
				OnDoubleClick( from );
			}
			return true;
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
		}
	}
}