using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an elemental corpse" )]
	public class ElementalCalledFire : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 67.5; } }
		public override double DispelFocus{ get{ return 30.0; } }
		public override bool DeleteCorpseOnDeath{ get{ return true; } }

		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 17 ); }

		[Constructable]
		public ElementalCalledFire () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a fire elemental";
			Body = 15;
			BaseSoundID = 838;

			SetStr( 100 );
			SetDex( 100 );
			SetInt( 50 );

			SetDamage( 6, 10 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Fire, 100 );

			SetResistance( ResistanceType.Physical, 30, 40 );
			SetResistance( ResistanceType.Fire, 50, 60 );
			SetResistance( ResistanceType.Cold, 0, 10 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.Meditation, 45.0 );
			SetSkill( SkillName.Psychology, 40.0 );
			SetSkill( SkillName.Magery, 40.0 );
			SetSkill( SkillName.MagicResist, 35.0 );
			SetSkill( SkillName.Tactics, 50.0 );
			SetSkill( SkillName.FistFighting, 40.0 );

			VirtualArmor = 20;
			ControlSlots = 1;

			AddItem( new LighterSource() );
		}

		public ElementalCalledFire( Serial serial ) : base( serial )
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
