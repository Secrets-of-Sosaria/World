using System;
using Server;

namespace Server.Items
{
	public class BraceletOfHealth : GoldBracelet
	{
		public override int LabelNumber{ get{ return 1061103; } } // Bracelet of Health

		[Constructable]
		public BraceletOfHealth()
		{
			Hue = 0x21;
			Attributes.BonusHits = 5;
			Attributes.RegenHits = 10;
			ItemID = 0x4CEC;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public BraceletOfHealth( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_BraceletOfHealth(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}