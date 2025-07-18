using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class LevelCleaver : BaseLevelKnife
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.InfectiousStrike; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.MeleeProtection2; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.ZapDexStrike; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.ZapStamStrike; } }

		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return (int)(11 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(13 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 46; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int OldStrengthReq{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 2; } }
		public override int OldMaxDamage{ get{ return 13; } }
		public override int OldSpeed{ get{ return 40; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 50; } }

		[Constructable]
		public LevelCleaver() : base( 0xEC3 )
		{
			Weight = 2.0;
			Name = "cleaver";
			ItemID = Utility.RandomList( 0xEC3, 0x2AB6 );
		}

		public LevelCleaver( Serial serial ) : base( serial )
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

			if ( Weight == 1.0 )
				Weight = 2.0;
		}
	}
}