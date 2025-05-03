using System;
using Server;
using Server.Targeting;

namespace Server.Items
{
	public class ElementalEnhancementStone : Item
	{
		private int i_Uses;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Uses { get { return i_Uses; } set { i_Uses = value; InvalidateProperties(); } }

		[Constructable] 
		public ElementalEnhancementStone() : this( 5 )
		{
		}

		[Constructable] 
		public ElementalEnhancementStone( int uses ) : base( 0x1F14 ) 
		{ 
			Weight = 1.0;
			i_Uses = uses;
			Hue = 0x38C;
			Name = "Elemental Enhancement Stone";
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
				from.Target = new ElementalEnhancementStoneTarget(this);
			}
			else
				from.SendMessage("This must be in your backpack to use.");
		}
		
        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Can Increase A Weapon's Damage");
			list.Add( 1049644, "Even Damage To All Defenses"); // PARENTHESIS
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
					if (i_DI >= 70)
					{
						from.SendMessage(32, "This weapon cannot be enhanced any further");
						return;
					}
					else if (from.Skills[SkillName.Blacksmith].Value < 100.0)
						from.SendMessage(32, "You need at least 100.0 blacksmith and magery to enhance weapons with elemental power");
					else if (from.Skills[SkillName.Magery].Value < 100.0)
						from.SendMessage(32, "You need at least 100.0 blacksmith and magery to enhance weapons with elemental power");
					else if ( !Deleted )
					{
						int bonus = Utility.Random((int)(from.Skills[SkillName.Blacksmith].Value/20));
						if (bonus > 0)
						{
							if (70 < i_DI + bonus)
								bonus = 70 - i_DI;
							weap.Attributes.WeaponDamage += bonus;
							weap.AosElementDamages.Fire = 20;
							weap.AosElementDamages.Cold = 20;
							weap.AosElementDamages.Poison = 20;
							weap.AosElementDamages.Energy = 20;
							weap.AosElementDamages.Physical = 20;
							from.SendMessage(88, "You enhanced the weapon with {0} elemental damage increase", bonus);
						}
						else
							from.SendMessage(32, "You fail to enhanced the weapon");
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
				from.SendMessage(32, "You can only enhance edged weapons");
			}
		}

		public ElementalEnhancementStone( Serial serial ) : base( serial )
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

	public class ElementalEnhancementStoneTarget : Target
	{
		private ElementalEnhancementStone sb_Blade;

		public ElementalEnhancementStoneTarget(ElementalEnhancementStone blade) : base( 18, false, TargetFlags.None )
		{
			sb_Blade = blade;
		}

		protected override void OnTarget(Mobile from, object targeted)
		{
			if (sb_Blade.Deleted)
				return;

			sb_Blade.Enhancement(from, targeted);
		}
	}
}