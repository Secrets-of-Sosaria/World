using System;

namespace Server.Items
{
    public class CrimsonCincture : HalfApron
	{
		public override int LabelNumber{ get{ return 1075043; } } // Crimson Cincture
	
		[Constructable]
		public CrimsonCincture() : base()
		{
			Hue = 0x485;
			
			Attributes.BonusDex = 5;
			Attributes.BonusHits = 10;
			Attributes.RegenHits = 2;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public CrimsonCincture( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_CrimsonCincture(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			
			int version = reader.ReadInt();
		}
	}
}

