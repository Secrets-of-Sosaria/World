using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class LevelLongsword : BaseLevelSword
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.DevastatingBlow; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.ToxicStrike; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.DoubleWhirlwindAttack; } }

		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return (int)(15 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(16 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 30; } }
		public override float MlSpeed{ get{ return 3.50f; } }

		public override int OldStrengthReq{ get{ return 25; } }
		public override int OldMinDamage{ get{ return 5; } }
		public override int OldMaxDamage{ get{ return 33; } }
		public override int OldSpeed{ get{ return 35; } }

		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 110; } }

		[Constructable]
		public LevelLongsword() : base( 0xF61 )
		{
			Weight = 7.0;
			Name = "longsword";
			ItemID = Utility.RandomList( 0xF61, 0xF60, 0xF61, 0xF60, 0xF61, 0x2AAD, 0x2AAE, 0x2AAF, 0x2AB2, 0x2AB3, 0x2D00 );
		}

		public LevelLongsword( Serial serial ) : base( serial )
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