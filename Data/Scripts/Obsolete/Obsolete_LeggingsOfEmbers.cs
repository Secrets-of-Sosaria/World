using System;
using Server;

namespace Server.Items
{
	public class LeggingsOfEmbers : PlateLegs
	{
		public override int LabelNumber{ get{ return 1062911; } } // Royal Leggings of Embers

		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 25; } }
		public override int BaseColdResistance{ get{ return 0; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		[Constructable]
		public LeggingsOfEmbers()
		{
			Hue = 0x2C;
			ItemID = 0x46AA;
			ArmorAttributes.SelfRepair = 10;
			ArmorAttributes.MageArmor = 1;
			ArmorAttributes.LowerStatReq = 100;
		}

		public LeggingsOfEmbers( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_LeggingsOfEmbers(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}