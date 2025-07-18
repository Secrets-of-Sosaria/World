using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class LevelKatana : BaseLevelSword
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleWhirlwindAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.FireStrike; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.DeathBlow; } }

		public override int AosStrengthReq{ get{ return 25; } }
		public override int AosMinDamage{ get{ return (int)(11 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(13 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 46; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int OldStrengthReq{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 5; } }
		public override int OldMaxDamage{ get{ return 26; } }
		public override int OldSpeed{ get{ return 58; } }

		public override int DefHitSound{ get{ return 0x23B; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 90; } }

		[Constructable]
		public LevelKatana() : base( 0x13FF )
		{
			Weight = 6.0;
			Name = "katana";
			ItemID = Utility.RandomList( 0x13FF, 0x2680, 0x2CFF );
		}

		public LevelKatana( Serial serial ) : base( serial )
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