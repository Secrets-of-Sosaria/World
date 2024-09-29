using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfAllReagents : Bag
	{
		[Constructable]
		public BagOfAllReagents()
		{
			Weight = 10.0;
		}

		public override void Open( Mobile from )
		{
			int amount = 50;
			if ( this.Weight > 2.0 )
			{
				Item i = null;
				i = new BlackPearl( amount ); DropItem( i );
				i = new Bloodmoss( amount ); DropItem( i );
				i = new Garlic( amount ); DropItem( i );
				i = new Ginseng( amount ); DropItem( i );
				i = new MandrakeRoot( amount ); DropItem( i );
				i = new Nightshade( amount ); DropItem( i );
				i = new SulfurousAsh( amount ); DropItem( i );
				i = new SpidersSilk( amount ); DropItem( i );
				i = new Brimstone( amount ); DropItem( i );
				i = new ButterflyWings( amount ); DropItem( i );
				i = new EyeOfToad( amount ); DropItem( i );
				i = new FairyEgg( amount ); DropItem( i );
				i = new GargoyleEar( amount ); DropItem( i );
				i = new BeetleShell( amount ); DropItem( i );
				i = new MoonCrystal( amount ); DropItem( i );
				i = new PixieSkull( amount ); DropItem( i );
				i = new RedLotus( amount ); DropItem( i );
				i = new SeaSalt( amount ); DropItem( i );
				i = new SilverWidow( amount ); DropItem( i );
				i = new SwampBerries( amount ); DropItem( i );
				i = new BatWing( amount ); DropItem( i );
				i = new GraveDust( amount ); DropItem( i );
				i = new DaemonBlood( amount ); DropItem( i );
				i = new NoxCrystal( amount ); DropItem( i );
				i = new PigIron( amount ); DropItem( i );
				i = new BitterRoot( amount ); DropItem( i );
				i = new BlackSand( amount ); DropItem( i );
				i = new BloodRose( amount ); DropItem( i );
				i = new DriedToad( amount ); DropItem( i );
				i = new Maggot( amount ); DropItem( i );
				i = new MummyWrap( amount ); DropItem( i );
				i = new VioletFungus( amount ); DropItem( i );
				i = new WerewolfClaw( amount ); DropItem( i );
				i = new Wolfsbane( amount ); DropItem( i );

				this.Weight = 2.0;
			}

			base.Open( from );
		}

		public BagOfAllReagents( Serial serial ) : base( serial )
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