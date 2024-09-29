using System;
using Server;

namespace Server.Items
{
	public class LegsOfTheFallenKing : LeatherLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1061094; } } // Legs of the Fallen King

		public override int BaseColdResistance{ get{ return 17; } }
		public override int BaseEnergyResistance{ get{ return 17; } }

		[Constructable]
		public LegsOfTheFallenKing()
		{
			Name = "Leggings of the Fallen";
			Hue = 0x76D;
			Attributes.BonusStr = 6;
			Attributes.RegenHits = 10;
			Attributes.RegenStam = 3;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public LegsOfTheFallenKing( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_LegsOfTheFallenKing(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if ( version < 1 )
			{
				if ( Hue == 0x551 )
					Hue = 0x76D;

				ColdBonus = 0;
				EnergyBonus = 0;
			}
		}
	}
}