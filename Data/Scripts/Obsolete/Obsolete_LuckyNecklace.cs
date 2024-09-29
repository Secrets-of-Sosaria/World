using System;
using Server.Mobiles;

namespace Server.Items
{
	public class LuckyNecklace : BaseTrinket
	{
		public override int Hue{ get { return 1150; } }
		public override int LabelNumber{ get { return 1075239; } }  //Lucky Necklace	1075239

		[Constructable]
		public LuckyNecklace( ): base( 0x4CFF, Layer.Neck  )
		{
			base.Attributes.Luck = 300;
		}

		public LuckyNecklace( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_LuckyNecklace(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			reader.ReadInt(); /* int version = reader.ReadInt(); Why? Just to have an unused var? */
		}
	}
}
