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
	[FlipableAttribute( 0x4FF4, 0x4FF5 )]
	public class SunkenChest : LockableContainer
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }

		public string ContainerOwner;

		[CommandProperty(AccessLevel.Owner)]
		public string Container_Owner { get { return ContainerOwner; } set { ContainerOwner = value; InvalidateProperties(); } }

		public string ContainerDigger;

		[CommandProperty(AccessLevel.Owner)]
		public string Container_Digger { get { return ContainerDigger; } set { ContainerDigger = value; InvalidateProperties(); } }

		[Constructable]
		public SunkenChest() : this( 0, null, 0 )
		{
		}

		[Constructable]
		public SunkenChest( int level, Mobile digger, int ancient ) : base( 0x4FF4 )
		{
			Catalog = Catalogs.TreasureChest;

			if ( level > 0 && digger != null )
			{
				level = level + 4;
					if ( level > 10 ){ level = 10; }

				ContainerFunctions.BuildContainer( this, 0, Utility.RandomList( 1, 2 ), 0, 0 );

				int xTraCash = Utility.RandomMinMax( (level*500), (level*800) );
				LootPackChange.AddGoldToContainer( xTraCash, this, digger, level );

				if ( level > 0 ){ ContainerFunctions.FillTheContainer( level, this, digger ); }
				if ( level > 3 ){ ContainerFunctions.FillTheContainer( level, this, digger ); }
				if ( level > 7 ){ ContainerFunctions.FillTheContainer( level, this, digger ); }
				if ( GetPlayerInfo.LuckyPlayer( digger.Luck ) ){ ContainerFunctions.FillTheContainer( level, this, digger ); }

				ContainerOwner = ContainerFunctions.GetOwner( "Sunken" );
				ContainerDigger = digger.Name;

				Name = "sunken chest";
				ColorText1 = "Sunken Chest";
				ColorHue1 = "4ecbff";
				ColorText2 = ContainerOwner;
				ColorHue2 = "4ecbff";
				ColorText3 = "Resurfaced By " + ContainerDigger + "";
				ColorHue3 = "a8e0f7";

				// = ARTIFACTS
				int artychance = GetPlayerInfo.LuckyPlayerArtifacts( digger.Luck ) + 10;
				if ( Utility.Random( 100 ) < ( ( level * 10 ) + artychance ) )
				{
					Item arty = Loot.RandomArty();
					DropItem( arty );
				}

				int giveRelics = level;
				Item relic = Loot.RandomRelic( digger );
				while ( giveRelics > 0 )
				{
					relic = Loot.RandomRelic( digger );
						if ( Utility.RandomMinMax(1,100) > 94 && GetPlayerInfo.LuckyPlayer( digger.Luck ) ){ relic.Delete(); relic = Loot.RandomSea(); }
						else { relic.CoinPrice = (int)(relic.CoinPrice * 0.2 * level) + relic.CoinPrice; }
					DropItem( relic );
					giveRelics--;
				}

				if ( ancient > 0 )
				{
					Name = "ancient sunken chest";
					Hue = Utility.RandomList( 0xB8E, 0xB8F, 0xB90, 0xB91, 0xB92, 0xB89, 0xB8B );
					Item net = new FabledFishingNet();
					DropItem( net );
				}
				else
				{
					Item net = new FishingNet();
					if ( Utility.RandomMinMax( 1, 3 ) == 1 ){ net = new SpecialFishingNet(); }
					DropItem( net );
					ItemID = Utility.RandomList( 0x52E2, 0x52E3, 0x507E, 0x507F, 0x4910, 0x4911, 0x3332, 0x3333, 0x4FF4, 0x4FF5 );
					Hue = 0;
					if ( Utility.RandomMinMax(1,4) == 1 )
					{
						ItemID = Utility.RandomList( 0x5718, 0x5719, 0x571A, 0x571B, 0x5752, 0x5753 );
						ResourceMods.SetRandomResource( false, false, this, CraftResource.RegularWood, false, null );
					}
				}
			}
		}

		public SunkenChest( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
            writer.Write( ContainerOwner );
            writer.Write( ContainerDigger );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			ContainerOwner = reader.ReadString();
			ContainerDigger = reader.ReadString();
		}
	}
}