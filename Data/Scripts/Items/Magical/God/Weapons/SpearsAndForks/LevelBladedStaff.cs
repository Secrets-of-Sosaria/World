using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x26BD, 0x26C7 )]
    public class LevelBladedStaff : BaseLevelSpear
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Dismount; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.EarthStrike; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.MagicProtection; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.Disarm; } }

		public override int AosStrengthReq{ get{ return 40; } }
		public override int AosMinDamage{ get{ return (int)(14 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(16 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 37; } }
		public override float MlSpeed{ get{ return 3.00f; } }

		public override int OldStrengthReq{ get{ return 40; } }
		public override int OldMinDamage{ get{ return 14; } }
		public override int OldMaxDamage{ get{ return 16; } }
		public override int OldSpeed{ get{ return 37; } }

		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 110; } }

		public override SkillName DefSkill{ get{ return SkillName.Swords; } }

		[Constructable]
		public LevelBladedStaff() : base( 0x26BD )
		{
			Weight = 4.0;
		}

		public LevelBladedStaff( Serial serial ) : base( serial )
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