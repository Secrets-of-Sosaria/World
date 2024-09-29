using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Multis;
using Server.Network;
using Server.ContextMenus;
using Server.Engines.PartySystem;
using Server.Misc;

namespace Server.Items
{
	public class BuriedBody : LockableContainer
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.BrittleSkeletal; } }

		[Constructable]
		public BuriedBody() : this( 0, null, null )
		{
		}

		[Constructable]
		public BuriedBody( int level, string who, Mobile digger ) : base( 0xe40 )
		{
			if ( who != null && level > 0 )
			{
				string sCorpse = ContainerFunctions.GetOwner( "Body" );

				if ( who != "" && who != null )
				{
					sCorpse = "bones";
					switch ( Utility.RandomMinMax( 0, 3 ) ) 
					{
						case 0: sCorpse = "bones"; break;
						case 1: sCorpse = "body"; break;
						case 2: sCorpse = "skeletal remains"; break;
						case 3: sCorpse = "skeletal bones"; break;
					}
				}

				Name = sCorpse;
				ColorText1 = "The " + sCorpse + " of";
				ColorHue1 = "ef4848";
				ColorText2 = who;
				ColorHue2 = "ef4848";

				Movable = true;
				Weight = 5;
				GumpID = 0x2A73;
				DropSound = 0x48;
				ItemID = 3786 + Utility.Random( 8 );

				ContainerFunctions.FillTheContainer( level, this, digger );

				if ( level > 4 ){ ContainerFunctions.FillTheContainer( level, this, digger ); }
				if ( level > 8 ){ ContainerFunctions.FillTheContainer( level, this, digger ); }
				if ( GetPlayerInfo.LuckyPlayer( digger.Luck ) ){ ContainerFunctions.FillTheContainer( level, this, digger ); }

				int xTraCash = Utility.RandomMinMax( (level*300), (level*500) );
				LootPackChange.AddGoldToContainer( xTraCash, this, digger, level );

				if (  Utility.Random( 500 ) < ( level ) )
				{
					Item arty = Loot.RandomArty();
					DropItem( arty );
				}

				TrapType = TrapType.None;
				TrapPower = 0;
				TrapLevel = 0;
				Locked = false;
				LockLevel = 0;
				MaxLockLevel = 0;
				RequiredSkill = 0;
			}
		}

		public BuriedBody( Serial serial ) : base( serial )
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
		}
	}
}