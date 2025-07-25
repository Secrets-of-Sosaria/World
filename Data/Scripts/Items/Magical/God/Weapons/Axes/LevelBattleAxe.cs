using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class LevelBattleAxe : BaseLevelAxe
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.RidingAttack; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.WhirlwindAttack; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.ElementalStrike; } }

		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return (int)(15 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(17 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 31; } }
		public override float MlSpeed{ get{ return 3.50f; } }

		public override int OldStrengthReq{ get{ return 40; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 38; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 70; } }

		[Constructable]
		public LevelBattleAxe() : base( 0xF47 )
		{
			Weight = 8.0;
			Layer = Layer.TwoHanded;
			Name = "battle axe";
			ItemID = Utility.RandomList( 0xF47, 0xF48, 0x265B, 0x2660 );
		}

		public LevelBattleAxe( Serial serial ) : base( serial )
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