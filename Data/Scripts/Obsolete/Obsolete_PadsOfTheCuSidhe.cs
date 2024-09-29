using System;
using Server;

namespace Server.Items
{
	public class PadsOfTheCuSidhe : FurBoots
	{
		public override int LabelNumber{ get{ return 1075048; } } // Pads of the Cu Sidhe

		[Constructable]
		public PadsOfTheCuSidhe() : base( 0x47E )
		{
		}

		public PadsOfTheCuSidhe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_PadsOfTheCuSidhe(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}