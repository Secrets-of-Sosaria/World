using System;
using System.Collections;
using Server;
using Server.Network;

namespace Server.Items
{
	public class BaseShield : BaseArmor
	{
		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		public BaseShield( int itemID ) : base( itemID )
		{
		}

		public BaseShield( Serial serial ) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );//version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

		public override double ArmorRating
		{
			get
			{
				Mobile m = this.Parent as Mobile;
				double ar = base.ArmorRating;

				if ( m != null )
					return ( ( m.Skills[SkillName.Parry].Value * ar ) / 200.0 ) + 1.0;
				else
					return ar;
			}
		}

		public override int OnHit( BaseWeapon weapon, int damage )
		{
			double halfArmor = ArmorRating / 2.0;
			int absorbed = (int)(halfArmor + (halfArmor*Utility.RandomDouble()));

			if( absorbed < 2 )
				absorbed = 2;

			int wear;

			if( weapon.Type == WeaponType.Bashing )
				wear = (absorbed / 2);
			else
				wear = Utility.Random( 2 );

			int ruin = 60 + ( (int)Density * 5 ); // chance to lower durability

			if ( Utility.Random( 100 ) > ruin && wear > 0 && Density != Density.None ) // chance to lower durability
			{
				if( ArmorAttributes.SelfRepair > Utility.Random( 10 ) )
					HitPoints += Utility.RandomMinMax( 1, (int)Density );

				if( HitPoints >= wear )
				{
					HitPoints -= wear;
					wear = 0;
				}
				else
				{
					wear -= HitPoints;
					HitPoints = 0;
				}

				if( wear > 0 )
				{
					if( MaxHitPoints > wear )
					{
						MaxHitPoints -= wear;

						if( Parent is Mobile )
							((Mobile)Parent).LocalOverheadMessage( MessageType.Regular, 0x3B2, 1061121 ); // Your equipment is severely damaged.
					}
				}

				if ( MaxHitPoints < 1 )
					Delete();
			}

			return 0;
		}
	}
}
