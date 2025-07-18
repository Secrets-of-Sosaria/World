using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class LevelVikingSword : BaseLevelSword
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.RidingSwipe; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.DeathBlow; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.MeleeProtection2; } }

		public override int AosStrengthReq{ get{ return 40; } }
		public override int AosMinDamage{ get{ return (int)(15 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(17 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 28; } }
		public override float MlSpeed{ get{ return 3.75f; } }

		public override int OldStrengthReq{ get{ return 40; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 34; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 100; } }

		[Constructable]
		public LevelVikingSword() : base( 0x13B9 )
		{
			Name = "barbarian sword";
			Weight = 6.0;
			ItemID = Utility.RandomList( 0x13B9, 0x13BA, 0x2CFE );
		}

		public LevelVikingSword( Serial serial ) : base( serial )
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