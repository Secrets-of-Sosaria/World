using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1401, 0x1400 )]
	public class LevelKryss : BaseLevelSword
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.InfectiousStrike; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.ZapDexStrike; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.LightningStriker; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.ToxicStrike; } }

		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return (int)(10 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(12 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 53; } }
		public override float MlSpeed{ get{ return 2.00f; } }

		public override int OldStrengthReq{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 3; } }
		public override int OldMaxDamage{ get{ return 28; } }
		public override int OldSpeed{ get{ return 53; } }

		public override int DefHitSound{ get{ return 0x23C; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 90; } }

		public override SkillName DefSkill{ get{ return SkillName.Fencing; } }
		public override WeaponType DefType{ get{ return WeaponType.Piercing; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

		[Constructable]
		public LevelKryss() : base( 0x1401 )
		{
			Weight = 2.0;
		}

		public LevelKryss( Serial serial ) : base( serial )
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

			if ( Weight == 1.0 )
				Weight = 2.0;
		}
	}
}