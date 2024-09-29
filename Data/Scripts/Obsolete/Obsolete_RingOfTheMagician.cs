using System;
using Server;

namespace Server.Items
{
	public class RingOfTheMagician : GoldRing
	{
		public override int LabelNumber{ get{ return 1061105; } } // Ring of the Magician

		[Constructable]
		public RingOfTheMagician()
		{
			Name = "Ring of the Magician";
			Hue = 0x554;
			ItemID = 0x4CF8;
			Attributes.CastRecovery = 3;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 10;
			Attributes.LowerRegCost = 10;
			Resistances.Energy = 15;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public RingOfTheMagician( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_RingOfTheMagician(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if ( Hue == 0x12B )
				Hue = 0x554;
		}
	}
}