using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class GiftClaymore : BaseGiftSword
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.MortalStrike; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.DeathBlow; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.MeleeProtection2; } }

		public override int AosStrengthReq{ get{ return 85; } }
		public override int AosMinDamage{ get{ return 18; } }
		public override int AosMaxDamage{ get{ return 19; } }
		public override int AosSpeed{ get{ return 22; } }
		public override float MlSpeed{ get{ return 4.00f; } }

		public override int OldStrengthReq{ get{ return 45; } }
		public override int OldMinDamage{ get{ return 5; } }
		public override int OldMaxDamage{ get{ return 49; } }
		public override int OldSpeed{ get{ return 25; } }

		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 90; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Slash1H; } }

		[Constructable]
		public GiftClaymore() : base( 0x568F )
		{
			Name = "claymore";
			Weight = 15.0;
			ItemID = Utility.RandomList( 0x568F, 0x56B7, 0x2CFC, 0x2CFD );
		}

		public GiftClaymore( Serial serial ) : base( serial )
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