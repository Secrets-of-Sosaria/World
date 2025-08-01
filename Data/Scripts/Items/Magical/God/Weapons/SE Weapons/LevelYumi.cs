using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class LevelYumi : BaseLevelRanged
	{
		public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return typeof( Arrow ); } }
		public override Item Ammo{ get{ return new Arrow(); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorPierce; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.DoubleShot; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.ZapStrStrike; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.MovingShot; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.DoubleWhirlwindAttack; } }

		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return Core.ML ? (int)(16 * GetDamageScaling()) : (int)(18 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(20 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 25; } }
		public override float MlSpeed{ get{ return 4.5f; } }

		public override int OldStrengthReq{ get{ return 35; } }
		public override int OldMinDamage{ get{ return 18; } }
		public override int OldMaxDamage{ get{ return 20; } }
		public override int OldSpeed{ get{ return 25; } }

		public override int DefMaxRange{ get{ return 10; } }

		public override int InitMinHits{ get{ return 55; } }
		public override int InitMaxHits{ get{ return 60; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } }

		[Constructable]
		public LevelYumi() : base( 0x27A5 )
		{
			Weight = 9.0;
			Layer = Layer.TwoHanded;
			Resource = CraftResource.RegularWood;
			Name = "yumi";
			ItemID = Utility.RandomList( 0x27A5, 0x27F0, 0x63A1 );
		}

		public LevelYumi( Serial serial ) : base( serial )
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