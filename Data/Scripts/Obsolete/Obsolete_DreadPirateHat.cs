using System;
using Server;

namespace Server.Items
{
	public class DreadPirateHat : TricorneHat
	{
		public override int LabelNumber{ get{ return 1063467; } }

		public override int BaseColdResistance{ get{ return 14; } }
		public override int BasePoisonResistance{ get{ return 10; } }

		[Constructable]
		public DreadPirateHat()
		{
			Hue = 0x497;

			SkillBonuses.SetValues( 0, Utility.RandomCombatSkill(), 10.0 );
			SkillBonuses.SetValues( 0, SkillName.Seafaring, 20 );

			Attributes.BonusDex = 8;
			Attributes.AttackChance = 10;
			Attributes.NightSight = 1;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public DreadPirateHat( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 3 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_DreadPirateHat(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if ( version < 3 )
			{
				Resistances.Cold = 0;
				Resistances.Poison = 0;
			}

			if ( version < 1 )
			{
				Attributes.Luck = 0;
				Attributes.AttackChance = 10;
				Attributes.NightSight = 1;
				SkillBonuses.SetValues( 0, Utility.RandomCombatSkill(), 10.0 );
				SkillBonuses.SetBonus( 1, 0 );
			}
		}
	}
}