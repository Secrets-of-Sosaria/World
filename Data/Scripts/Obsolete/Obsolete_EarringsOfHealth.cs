using System;
using Server;

namespace Server.Items
{
	public class EarringsOfHealth : GoldEarrings
	{
		public override int LabelNumber{ get{ return 1061103; } } // Earrings of Health

		[Constructable]
		public EarringsOfHealth()
		{
			Name = "Earrings of Health";
			Hue = 0x21;
			Attributes.BonusHits = 3;
			Attributes.RegenHits = 5;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public EarringsOfHealth( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_EarringsOfHealth(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}