using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfNecroReagents : Bag
	{
		[Constructable]
		public BagOfNecroReagents()
		{
			Weight = 10.0;
		}

		public override void Open( Mobile from )
		{
			int amount = 50;
			if ( this.Weight > 2.0 )
			{
				Item i = null;
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

		public BagOfNecroReagents( Serial serial ) : base( serial )
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