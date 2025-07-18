using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class LevelBoneHarvester : BaseLevelSword
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.Disrobe; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.ZapManaStrike; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.Block; } }

		public override int AosStrengthReq{ get{ return 25; } }
		public override int AosMinDamage{ get{ return (int)(13 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(15 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 36; } }
		public override float MlSpeed{ get{ return 3.00f; } }

		public override int OldStrengthReq{ get{ return 25; } }
		public override int OldMinDamage{ get{ return 13; } }
		public override int OldMaxDamage{ get{ return 15; } }
		public override int OldSpeed{ get{ return 36; } }

		public override int DefHitSound{ get{ return 0x23B; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 70; } }
		[Constructable]
		public LevelBoneHarvester() : base( 0x26BB )
		{
			Name = "sickle";
			Weight = 3.0;
			ItemID = Utility.RandomList( 0x26BB, 0x2666 );
		}

		public LevelBoneHarvester( Serial serial ) : base( serial )
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