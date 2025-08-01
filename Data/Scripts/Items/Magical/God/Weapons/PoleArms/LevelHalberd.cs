using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class LevelHalberd : BaseLevelPoleArm
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.WhirlwindAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.ZapStrStrike; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.FreezeStrike; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.RidingSwipe; } }

		public override int AosStrengthReq{ get{ return 95; } }
		public override int AosMinDamage{ get{ return (int)(19 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(20 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 25; } }
		public override float MlSpeed{ get{ return 4.25f; } }

		public override int OldStrengthReq{ get{ return 45; } }
		public override int OldMinDamage{ get{ return 5; } }
		public override int OldMaxDamage{ get{ return 49; } }
		public override int OldSpeed{ get{ return 25; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 80; } }

		[Constructable]
		public LevelHalberd() : base( 0x143E )
		{
			Weight = 16.0;
			Name = "halberd";
			ItemID = Utility.RandomList( 0x143E, 0x143F, 0x143E, 0x2679, 0x267A, 0x267B );
		}

		public LevelHalberd( Serial serial ) : base( serial )
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