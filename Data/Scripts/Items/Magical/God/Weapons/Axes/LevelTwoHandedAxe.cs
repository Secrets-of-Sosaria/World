using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class LevelTwoHandedAxe : BaseLevelAxe
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ShadowStrike; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.ToxicStrike; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.ZapIntStrike; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.DefenseMastery; } }

		public override int AosStrengthReq{ get{ return 40; } }
		public override int AosMinDamage{ get{ return (int)(16 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(17 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 31; } }
		public override float MlSpeed{ get{ return 3.50f; } }

		public override int OldStrengthReq{ get{ return 35; } }
		public override int OldMinDamage{ get{ return 5; } }
		public override int OldMaxDamage{ get{ return 39; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 90; } }

		[Constructable]
		public LevelTwoHandedAxe() : base( 0x1443 )
		{
			Weight = 8.0;
			Name = "two handed axe";
			ItemID = Utility.RandomList( 0x1443, 0x1442, 0x1443, 0x1442, 0x1443, 0x1442, 0x265E, 0x265F, 0x2661, 0x2662, 0x2663, 0x2664 );
		}

		public LevelTwoHandedAxe( Serial serial ) : base( serial )
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