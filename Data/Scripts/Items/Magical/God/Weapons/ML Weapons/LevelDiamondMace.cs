using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class LevelDiamondMace : BaseLevelBashing
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.PsychicAttack; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.Block; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.DoubleWhirlwindAttack; } }

		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return (int)(14 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(17 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 37; } }
		public override float MlSpeed{ get{ return 3.00f; } }

		public override int OldStrengthReq{ get{ return 35; } }
		public override int OldMinDamage{ get{ return 14; } }
		public override int OldMaxDamage{ get{ return 17; } }
		public override int OldSpeed{ get{ return 37; } }

		public override int InitMinHits{ get{ return 30; } } // TODO
		public override int InitMaxHits{ get{ return 60; } } // TODO

		[Constructable]
		public LevelDiamondMace() : base( 0x2D24 )
		{
			Weight = 10.0;
			Name = "battle mace";
			ItemID = Utility.RandomList( 0x2D24, 0x2D30, 0x2D24, 0x2682, 0x268B, 0x268D );
		}

		public LevelDiamondMace( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}