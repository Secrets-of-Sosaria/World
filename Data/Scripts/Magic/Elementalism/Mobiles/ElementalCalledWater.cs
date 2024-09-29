using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an elemental corpse" )]
	public class ElementalCalledWater : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 67.5; } }
		public override double DispelFocus{ get{ return 30.0; } }
		public override bool DeleteCorpseOnDeath{ get{ return true; } }

		public override int BreathPhysicalDamage{ get{ return 50; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 50; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectSound{ get{ return 0x012; } }
		public override int BreathEffectItemID{ get{ return 0x1A85; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 30 ); }

		[Constructable]
		public ElementalCalledWater () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a water elemental";
			Body = 16;
			BaseSoundID = 278;

			if ( Utility.RandomBool() )
			{
				Body = 977;
				Hue = Utility.RandomList( 0xBA7, 0xB3F, 0xB3D );
			}

			SetStr( 100 );
			SetDex( 100 );
			SetInt( 50 );

			SetDamage( 6, 10 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Cold, 100 );

			SetResistance( ResistanceType.Physical, 20, 40 );
			SetResistance( ResistanceType.Fire, 0, 10 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.Meditation, 45.0 );
			SetSkill( SkillName.Psychology, 40.0 );
			SetSkill( SkillName.Magery, 40.0 );
			SetSkill( SkillName.MagicResist, 35.0 );
			SetSkill( SkillName.Tactics, 50.0 );
			SetSkill( SkillName.FistFighting, 40.0 );

			VirtualArmor = 20;
			ControlSlots = 1;
			CanSwim = true;
		}

		public ElementalCalledWater( Serial serial ) : base( serial )
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