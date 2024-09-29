using System;
using Server;

namespace Server.Items
{
	public class RingOfHealth : GoldRing
	{
		public override int LabelNumber{ get{ return 1061103; } } // Ring of Health

		[Constructable]
		public RingOfHealth()
		{
			Name = "Ring of Health";
			Hue = 0x21;
			ItemID = 0x4CF8;
			Attributes.BonusHits = 4;
			Attributes.RegenHits = 7;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public RingOfHealth( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_RingOfHealth(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}