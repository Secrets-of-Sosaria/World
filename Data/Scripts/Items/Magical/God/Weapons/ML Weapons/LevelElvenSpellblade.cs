using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class LevelElvenSpellblade : BaseLevelKnife
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.PsychicAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.MagicProtection2; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.FireStrike; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.MeleeProtection; } }

		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return (int)(12 * GetDamageScaling()); } }
		public override int AosMaxDamage{ get{ return (int)(14 * GetDamageScaling()); } }
		public override int AosSpeed{ get{ return 44; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int OldStrengthReq{ get{ return 35; } }
		public override int OldMinDamage{ get{ return 12; } }
		public override int OldMaxDamage{ get{ return 14; } }
		public override int OldSpeed{ get{ return 44; } }

		public override int DefMissSound{ get{ return 0x239; } }

		public override int InitMinHits{ get{ return 30; } } // TODO
		public override int InitMaxHits{ get{ return 60; } } // TODO

		[Constructable]
		public LevelElvenSpellblade() : base( 0x2D20 )
		{
			Name = "assassin sword";
			Weight = 5.0;
			ItemID = Utility.RandomList( 0x2D20, 0x2D2C, 0x2D20, 0x2CF9, 0x2CFA, 0x2CFB );
		}

		public LevelElvenSpellblade( Serial serial ) : base( serial )
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