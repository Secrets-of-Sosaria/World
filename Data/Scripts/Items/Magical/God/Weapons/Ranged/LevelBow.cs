using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class LevelBow : BaseLevelRanged
	{
		public override int EffectID{ get{ return ArrowType(1); } }
		public override Type AmmoType{ get{ return typeof( Arrow ); } }
		public override Item Ammo{ get{ return new Arrow(); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.DoubleShot; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.MovingShot; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.ZapIntStrike; } }

		public override int AosStrengthReq{ get{ return 30; } }
		public override int AosMinDamage{ get{ return Core.ML ? (int)(15 * GetDamageScaling()) : (int)(16 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return Core.ML ? (int)(19 * GetDamageScaling()) : (int)(18 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 25; } }
		public override float MlSpeed{ get{ return 4.25f; } }

		public override int OldStrengthReq{ get{ return 20; } }
		public override int OldMinDamage{ get{ return 9; } }
		public override int OldMaxDamage{ get{ return 41; } }
		public override int OldSpeed{ get{ return 20; } }

		public override int DefMaxRange{ get{ return 10; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 60; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } }

		[Constructable]
		public LevelBow() : base( 0x13B2 )
		{
			Weight = 6.0;
			Layer = Layer.TwoHanded;
			Resource = CraftResource.RegularWood;
			Name = "bow";
			ItemID = Utility.RandomList( 0x13B2, 0x13B1, 0x2667, 0x2668, 0x63A2, 0x63A3, 0x63A4, 0x63A5 );
		}

		public LevelBow( Serial serial ) : base( serial )
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

			if ( Weight == 7.0 )
				Weight = 6.0;
		}
	}
}