using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class LevelDoubleBladedStaff : BaseLevelSpear
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.InfectiousStrike; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.ZapStrStrike; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.FreezeStrike; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.RidingSwipe; } }

		public override int AosStrengthReq{ get{ return 50; } }
		public override int AosMinDamage{ get{ return (int)(12 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(13 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 49; } }
		public override float MlSpeed{ get{ return 2.25f; } }

		public override int OldStrengthReq{ get{ return 50; } }
		public override int OldMinDamage{ get{ return 12; } }
		public override int OldMaxDamage{ get{ return 13; } }
		public override int OldSpeed{ get{ return 49; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 80; } }

		[Constructable]
		public LevelDoubleBladedStaff() : base( 0x26BF )
		{
			Weight = 9.0;
			Name = "double bladed staff";
			ItemID = Utility.RandomList( 0x26BF, 0x2678 );
		}

		public LevelDoubleBladedStaff( Serial serial ) : base( serial )
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