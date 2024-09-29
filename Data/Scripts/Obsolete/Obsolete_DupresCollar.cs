using System;
using Server;

namespace Server.Items
{
	public class DupresCollar : PlateGorget
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseFireResistance{ get{ return 13; } }
		public override int BaseColdResistance{ get{ return 11; } }
		public override int BasePhysicalResistance{ get{ return 8; } }
		public override int BaseEnergyResistance{ get{ return 12; } }

		[Constructable]
		public DupresCollar()
		{
			Name = "Dupre's Collar";
			Hue = 794;
			Attributes.BonusStr = 5;
			Attributes.RegenHits = 2;
			Attributes.DefendChance = 20;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public DupresCollar( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_DupresCollar(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

		}
	}
}