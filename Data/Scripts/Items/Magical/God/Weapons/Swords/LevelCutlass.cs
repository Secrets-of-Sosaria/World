using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class LevelCutlass : BaseLevelSword
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ShadowStrike; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.TalonStrike; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.RidingSwipe; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.ToxicStrike; } }

		public override int AosStrengthReq{ get{ return 25; } }
		public override int AosMinDamage{ get{ return (int)(11 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(13 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 44; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int OldStrengthReq{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 28; } }
		public override int OldSpeed{ get{ return 45; } }

		public override int DefHitSound{ get{ return 0x23B; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 70; } }

		[Constructable]
		public LevelCutlass() : base( 0x1441 )
		{
			Weight = 8.0;
			Name = "cutlass";
			ItemID = Utility.RandomList( 0x1441, 0x268E );
		}

		public LevelCutlass( Serial serial ) : base( serial )
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