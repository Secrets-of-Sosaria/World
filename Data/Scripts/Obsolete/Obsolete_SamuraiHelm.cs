using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x236C, 0x236D )]
	public class SamuraiHelm : BaseArmor
	{
		public override int LabelNumber{ get{ return 1062923; } } // Ancient Samurai Helm

		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public SamuraiHelm() : base( 0x236C )
		{
			Weight = 5.0;
			Attributes.DefendChance = 15;
			ArmorAttributes.SelfRepair = 10;
			ArmorAttributes.LowerStatReq = 100;
			ArmorAttributes.MageArmor = 1;
		}

		public SamuraiHelm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_SamuraiHelm(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}