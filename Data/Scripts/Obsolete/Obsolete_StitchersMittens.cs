using System;
using Server.Items;

namespace Server.Items
{
	public class StitchersMittens : LeatherGloves
	{
		public override int LabelNumber{ get{ return 1072932; } } // Stitcher's Mittens

		public override int BasePhysicalResistance{ get{ return 20; } }
		public override int BaseColdResistance{ get{ return 20; } }

		[Constructable]
		public StitchersMittens()
		{
			Hue = 0x481;

			SkillBonuses.SetValues( 0, SkillName.Healing, 10.0 );

			Attributes.BonusDex = 5;
			Attributes.LowerRegCost = 30;
		}

		public StitchersMittens( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_StitchersMittens(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();

		}
	}
}