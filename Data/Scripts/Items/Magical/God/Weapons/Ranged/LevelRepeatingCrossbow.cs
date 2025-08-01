using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x26C3, 0x26CD )]
	public class LevelRepeatingCrossbow : BaseLevelRanged
	{
		public override int EffectID{ get{ return ArrowType(0); } }
		public override Type AmmoType{ get{ return typeof( Bolt ); } }
		public override Item Ammo{ get{ return new Bolt(); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MovingShot; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.StunningStrike; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.ZapManaStrike; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.ZapDexStrike; } }

		public override int AosStrengthReq{ get{ return 30; } }
		public override int AosMinDamage{ get{ return Core.ML ? (int)(8 * GetDamageScaling()) : (int)(10 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(12 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 41; } }
		public override float MlSpeed{ get{ return 2.75f; } }

		public override int OldStrengthReq{ get{ return 30; } }
		public override int OldMinDamage{ get{ return 10; } }
		public override int OldMaxDamage{ get{ return 12; } }
		public override int OldSpeed{ get{ return 41; } }

		public override int DefMaxRange{ get{ return 7; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 80; } }

		[Constructable]
		public LevelRepeatingCrossbow() : base( 0x26C3 )
		{
			Weight = 6.0;
			Resource = CraftResource.RegularWood;
		}

		public LevelRepeatingCrossbow( Serial serial ) : base( serial )
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