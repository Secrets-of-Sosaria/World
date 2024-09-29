using System;
using Server.Items;

namespace Server.Items
{
	public class SpellWovenBritches : LeatherLegs
	{
		public override int LabelNumber{ get{ return 1072929; } } // Spell Woven Britches

		public override int BaseFireResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 16; } }

		[Constructable]
		public SpellWovenBritches()
		{
			Hue = 0x487;

			SkillBonuses.SetValues( 0, SkillName.Meditation, 10.0 );

			Attributes.BonusInt = 8;
			Attributes.SpellDamage = 10;
			Attributes.LowerManaCost = 10;
		}

		public SpellWovenBritches( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 );
		}

		private void Cleanup( object state ){ Item item = new Artifact_SpellWovenBritches(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}