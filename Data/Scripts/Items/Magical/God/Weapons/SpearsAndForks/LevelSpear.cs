using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class LevelSpear : BaseLevelSpear
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.AchillesStrike; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.ShadowInfectiousStrike; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.DoubleWhirlwindAttack; } }

		public override int AosStrengthReq{ get{ return 50; } }
		public override int AosMinDamage{ get{ return (int)(13 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(15 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 42; } }
		public override float MlSpeed{ get{ return 2.75f; } }

		public override int OldStrengthReq{ get{ return 30; } }
		public override int OldMinDamage{ get{ return 2; } }
		public override int OldMaxDamage{ get{ return 36; } }
		public override int OldSpeed{ get{ return 46; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 80; } }

		[Constructable]
		public LevelSpear() : base( 0xF62 )
		{
			Weight = 7.0;
			Name = "spear";
			ItemID = Utility.RandomList( 0xF62, 0xF63, 0xF62, 0x2691, 0x2692, 0x2AAB );
		}

		public LevelSpear( Serial serial ) : base( serial )
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