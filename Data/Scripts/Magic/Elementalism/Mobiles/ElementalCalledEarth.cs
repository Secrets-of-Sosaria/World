using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an elemental corpse" )]
	public class ElementalCalledEarth : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 67.5; } }
		public override double DispelFocus{ get{ return 30.0; } }
		public override bool DeleteCorpseOnDeath{ get{ return true; } }

		public override int BreathPhysicalDamage{ get{ return 100; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectSound{ get{ return 0x65A; } }
		public override int BreathEffectItemID{ get{ return 0; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 29 ); }

		[Constructable]
		public ElementalCalledEarth() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an earth elemental";
			Body = Utility.RandomList( 14, 446, 974 );
			BaseSoundID = 268;
			Hue = 0xB26;

			SetStr( 100 );
			SetDex( 100 );
			SetInt( 50 );

			SetDamage( 6, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.Meditation, 45.0 );
			SetSkill( SkillName.Psychology, 40.0 );
			SetSkill( SkillName.Magery, 40.0 );
			SetSkill( SkillName.MagicResist, 35.0 );
			SetSkill( SkillName.Tactics, 50.0 );
			SetSkill( SkillName.FistFighting, 40.0 );

			VirtualArmor = 20;
			ControlSlots = 1;
		}

		public ElementalCalledEarth( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}