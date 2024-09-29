using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x1DB9, 0x1DBA )]
	public class WhiteFurCap : SkullCap
	{
		public override int BasePhysicalResistance{ get{ return 0; } }
		public override int BaseFireResistance{ get{ return 0; } }
		public override int BaseColdResistance{ get{ return 5; } }
		public override int BasePoisonResistance{ get{ return 0; } }
		public override int BaseEnergyResistance{ get{ return 0; } }

		[Constructable]
		public WhiteFurCap() : base( 0x1DB9 )
		{
			Name = "fur cap";
			Hue = 0x481;
			Weight = 2.0;
		}

		public WhiteFurCap( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new SkullCap();
			item.Resource = CraftResource.WoolyFabric;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}