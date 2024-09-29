using System;
using Server;

namespace Server.Items
{
	public class JackalsLeggings : PlateLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1061594; } } // Jackal's Leggings

		public override int BaseFireResistance{ get{ return 23; } }
		public override int BaseColdResistance{ get{ return 19; } }

		[Constructable]
		public JackalsLeggings()
		{
			Name = "Jackal's Leggings";
			Hue = 0x6D1;
			ItemID = 0x46AA;
			Attributes.BonusDex = 15;
			Attributes.RegenHits = 2;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public JackalsLeggings( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_JackalsLeggings(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if ( version < 1 )
			{
				if ( Hue == 0x54B )
					Hue = 0x6D1;

				FireBonus = 0;
				ColdBonus = 0;
			}
		}
	}
}