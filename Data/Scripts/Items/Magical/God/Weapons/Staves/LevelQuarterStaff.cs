using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xE89, 0xE8a )]
	public class LevelQuarterStaff : BaseLevelStaff
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.MeleeProtection; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.MagicProtection; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.DeathBlow; } }

		public override int AosStrengthReq{ get{ return 30; } }
		public override int AosMinDamage{ get{ return (int)(11 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(14 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 48; } }
		public override float MlSpeed{ get{ return 2.25f; } }

		public override int OldStrengthReq{ get{ return 30; } }
		public override int OldMinDamage{ get{ return 8; } }
		public override int OldMaxDamage{ get{ return 28; } }
		public override int OldSpeed{ get{ return 48; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 60; } }

		[Constructable]
		public LevelQuarterStaff() : base( 0xE89 )
		{
			Weight = 4.0;
			Resource = CraftResource.RegularWood;
		}

		public LevelQuarterStaff( Serial serial ) : base( serial )
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