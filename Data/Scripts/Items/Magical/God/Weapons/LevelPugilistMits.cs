using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0x13C6, 0x13C6 )]
	public class LevelPugilistGloves : BaseLevelBashing
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.Disarm; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.WhirlwindAttack; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.FistsOfFury; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.DeathBlow; } }

		public override int AosStrengthReq{ get{ return 20; } }
		public override int AosMinDamage{ get{ return (int)(8 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(10 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 2; } }
		public override float MlSpeed{ get{ return 2.00f; } }

		public override int DefHitSound{ get{ return 0x13D; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 50; } }

		public override SkillName DefSkill{ get{ return SkillName.FistFighting; } }
		public override WeaponType DefType{ get{ return WeaponType.Fists; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Punching; } }

		[Constructable]
		public LevelPugilistGloves() : base( 0x13C6 )
		{
			Name = "pugilist gloves";
			Weight = 2.0;
			Hue = Utility.RandomColor(0);
			Layer = Layer.OneHanded;
			Attributes.SpellChanneling = 1;
			Resource = CraftResource.RegularLeather;
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1049644, "Cannot be used with hand-held weapons" );
		}

		public LevelPugilistGloves( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}