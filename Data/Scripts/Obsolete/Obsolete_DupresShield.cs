using System;
using Server;

namespace Server.Items
{
	public class DupresShield : BaseShield
	{
		public override int LabelNumber { get { return 1075196; } } // Dupre’s Shield

		public override int BasePhysicalResistance { get { return 1; } }
		public override int BaseFireResistance { get { return 0; } }
		public override int BaseColdResistance { get { return 0; } }
		public override int BasePoisonResistance { get { return 0; } }
		public override int BaseEnergyResistance { get { return 1; } }

		public override int InitMinHits { get { return 50; } }
		public override int InitMaxHits { get { return 100; } }

		public override int AosStrReq { get { return 50; } }

		public override int ArmorBase { get { return 15; } }

		[Constructable]
		public DupresShield() : base( 0x2B01 )
		{
			Weight = 6.0;
			Attributes.BonusHits = 5;
			Attributes.RegenHits = 1;
			SkillBonuses.SetValues( 0, SkillName.Parry, 5 );
		}

		public DupresShield( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); //version
		}

		private void Cleanup( object state ){ Item item = new Artifact_DupresShield(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}
