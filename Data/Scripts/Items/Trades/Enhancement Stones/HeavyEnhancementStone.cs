using System;
using Server;
using Server.Targeting;

namespace Server.Items
{
	public class HeavyEnhancementStone : Item
	{
		private int i_Uses;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Uses { get { return i_Uses; } set { i_Uses = value; InvalidateProperties(); } }

		[Constructable] 
		public HeavyEnhancementStone() : this( 5 )
		{
		}

		[Constructable] 
		public HeavyEnhancementStone( int uses ) : base( 0x1F14 ) 
		{ 
			Weight = 1.0;
			i_Uses = uses;
			Hue = 0x38C;
			Name = "Heavy Enhancement Stone";
		} 

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( 1060584, "{0}\t{1}", i_Uses.ToString(), "Uses" );
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				if ( Uses < 1 )
				{
					Delete();
					from.SendMessage(32, "This have no charges so it's gone!");
				}
				from.SendMessage("Which weapon you want to try to enhance?");
				from.Target = new HeavyEnhancementStoneTarget(this);
			}
			else
				from.SendMessage("This must be in your backpack to use.");
		}
		
        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Can Wondrously Increase a Weapon's Damage");
        }

		public void Enhancement(Mobile from, object o)
		{
			if ( o is Item )
			{
				if ( !((Item)o).IsChildOf( from.Backpack ) )
				{
					from.SendMessage(32, "This must be in your backpack to enhance");
				}
				else if (o is BaseWeapon && ((BaseWeapon)o).IsChildOf(from.Backpack))
				{
					BaseWeapon weap = o as BaseWeapon;
					int i_DI = weap.Attributes.WeaponDamage;
					if (weap.Quality == WeaponQuality.Exceptional)
						i_DI += 15;
					if (i_DI >= 80)
					{
						from.SendMessage(32, "This weapon cannot be enhanced any further");
						return;
					}
					else if (from.Skills[SkillName.Blacksmith].Value < 80.0)
						from.SendMessage(32, "You need at least 80.0 blacksmith to enhance weapons with this stone");
					else if ( !Deleted )
					{
						int bonus = Utility.Random((int)(from.Skills[SkillName.Blacksmith].Value/10));
						if (bonus > 0)
						{
							if (80 < i_DI + bonus)
								bonus = 80 - i_DI;
							weap.Attributes.WeaponDamage += bonus;
							from.SendMessage(88, "You enhance the weapon with {0} damange increase", bonus);
						}
						else
							from.SendMessage(32, "You fail to enhance the weapon");
						if (Uses <= 1)
						{
							from.SendMessage(32, "You used up the enhancement stone");
							Delete();
						}
						else
						{
							--Uses;
							from.SendMessage(32, "You have {0} uses left", Uses);
						}
					}
				}
				else
				{
					from.SendMessage(32, "You cannot enhance that item.");
				}
			}
			else
			{
				from.SendMessage(32, "You cannot enhance that.");
			}
		}

		public HeavyEnhancementStone( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (int) i_Uses );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			i_Uses = reader.ReadInt();
			if ( version == 0 ) { Serial sr_Owner = reader.ReadInt(); }
		}
	}

	public class HeavyEnhancementStoneTarget : Target
	{
		private HeavyEnhancementStone sb_Weapon;

		public HeavyEnhancementStoneTarget(HeavyEnhancementStone weapon) : base( 18, false, TargetFlags.None )
		{
			sb_Weapon = weapon;
		}

		protected override void OnTarget(Mobile from, object targeted)
		{
			if (sb_Weapon.Deleted)
				return;

			sb_Weapon.Enhancement(from, targeted);
		}
	}
}