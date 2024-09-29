using System;
using Server;

namespace Server.Items
{
	public class OrcChieftainHelm : OrcHelm
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BasePhysicalResistance{ get{ return 23; } }
		public override int BaseFireResistance{ get{ return 1; } }
		public override int BaseColdResistance{ get{ return 23; } }
		public override int BasePoisonResistance{ get{ return 3; } }
		public override int BaseEnergyResistance{ get{ return 5; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public OrcChieftainHelm()
		{
			Name = "Orc Chieftain Helm";
			Hue = 0x2a3;

			Attributes.Luck = 100;
			Attributes.RegenHits = 3;

			if( Utility.RandomBool() )
				Attributes.BonusHits = 30;
			else
				Attributes.AttackChance = 30;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public OrcChieftainHelm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_OrcChieftainHelm(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if (version < 1 && Hue == 0x3f) /* Pigmented? */
			{
				Hue = 0x2a3;
			}
		}
	}
}
