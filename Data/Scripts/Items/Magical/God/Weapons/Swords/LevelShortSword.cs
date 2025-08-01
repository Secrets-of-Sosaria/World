using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class LevelShortSword : BaseLevelSword
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DefenseMastery; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Bladeweave; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.ElementalStrike; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.FrenziedWhirlwind; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.ShadowInfectiousStrike; } }

		public override int AosStrengthReq{ get{ return 20; } }
		public override int AosMinDamage{ get{ return (int)(13 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(15 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 41; } }
		public override float MlSpeed{ get{ return 2.75f; } }

		public override int OldStrengthReq{ get{ return 20; } }
		public override int OldMinDamage{ get{ return 13; } }
		public override int OldMaxDamage{ get{ return 15; } }
		public override int OldSpeed{ get{ return 41; } }

		public override int DefHitSound{ get{ return 0x23B; } }
		public override int DefMissSound{ get{ return 0x239; } }

		public override int InitMinHits{ get{ return 30; } }
		public override int InitMaxHits{ get{ return 60; } }

		[Constructable]
		public LevelShortSword() : base( 0x2672 )
		{
			Weight = 5.0;
			Layer = Layer.OneHanded;
			Name = "short sword";
		}

		public LevelShortSword( Serial serial ) : base( serial )
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