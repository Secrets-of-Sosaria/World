using System;
using Server.Network;
using Server.Items;
using Server.Misc;

namespace Server.Items
{
	public class BaseWhip : BaseBashing
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.Disarm; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.WhirlwindAttack; } }

		public override int AosStrengthReq{ get{ return 30; } }
		public override int AosMinDamage{ get{ return 10; } }
		public override int AosMaxDamage{ get{ return 12; } }
		public override int AosSpeed{ get{ return 44; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int OldStrengthReq{ get{ return 10; } }
		public override int OldMinDamage{ get{ return 8; } }
		public override int OldMaxDamage{ get{ return 24; } }
		public override int OldSpeed{ get{ return 40; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 40; } }

		public override int DefHitSound{ get{ return 0x3CA; } }
		public override int DefMissSound{ get{ return 0x3CB; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Bash1H; } }

		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public BaseWhip( int itemID ) : base( itemID )
		{
			Weight = 3.0;
			Name = "whip";
			ResourceMods.DefaultItemHue( this );
		}

		public BaseWhip( Serial serial ) : base( serial )
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