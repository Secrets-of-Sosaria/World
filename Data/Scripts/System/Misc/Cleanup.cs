using System;
using System.Collections.Generic;
using System.Collections;
using Server;
using Server.Items;
using Server.Multis;
using Server.Mobiles;
using Server.Regions;
using System.Text;
using System.IO;
using System.Threading;

namespace Server.Misc
{
	public class Cleanup
	{
		public static void Initialize()
		{
			Timer.DelayCall( TimeSpan.FromSeconds( 2.5 ), new TimerCallback( Run ) );
		}

		public static void Run()
		{
			List<Item> items = new List<Item>();
			List<Item> validItems = new List<Item>();
			List<Mobile> hairCleanup = new List<Mobile>();

			int boxes = 0;

			foreach ( Item item in World.Items.Values )
			{
				if ( item.Map == null )
				{
					items.Add( item );
					continue;
				}
				else if ( item is BaseHouse )
				{
					BaseHouse house = (BaseHouse)item;

					foreach ( RelocatedEntity relEntity in house.RelocatedEntities )
					{
						if ( relEntity.Entity is Item )
							validItems.Add( (Item)relEntity.Entity );
					}

					foreach ( VendorInventory inventory in house.VendorInventories )
					{
						foreach ( Item subItem in inventory.Items )
							validItems.Add( subItem );
					}
				}
				else if ( item is BankBox )
				{
					BankBox box = (BankBox)item;
					Mobile owner = box.Owner;

					if ( owner == null )
					{
						items.Add( box );
						++boxes;
					}
					else if ( box.Items.Count == 0 )
					{
						items.Add( box );
						++boxes;
					}

					continue;
				}
				else if ( (item.Layer == Layer.Hair || item.Layer == Layer.FacialHair) )
				{
					object rootParent = item.RootParent;

					if ( rootParent is Mobile )
					{
						Mobile rootMobile = (Mobile)rootParent;
						if ( item.Parent != rootMobile && rootMobile.AccessLevel == AccessLevel.Player )
						{
							items.Add( item );
							continue;
						}
						else if( item.Parent == rootMobile )
						{
							hairCleanup.Add( rootMobile );
							continue;
						}
					}
				}

				if ( item.Parent != null || item.Map != Map.Internal || item.HeldBy != null )
					continue;

				if ( item.Location != Point3D.Zero )
					continue;

				if ( !IsBuggable( item ) )
					continue;

				items.Add( item );
			}

			for ( int i = 0; i < validItems.Count; ++i )
				items.Remove( validItems[i] );

			if ( items.Count > 0 )
			{
				for ( int i = 0; i < items.Count; ++i )
					items[i].Delete();
			}

			if ( hairCleanup.Count > 0 )
			{
				for ( int i = 0; i < hairCleanup.Count; i++ )
					hairCleanup[i].ConvertHair();
			}

			ArrayList cleanup = new ArrayList();
			foreach ( Mobile creature in World.Mobiles.Values )
			{
				if ( creature is BaseCreature && creature.Map == Map.Internal )
				{
					if (((BaseCreature)creature).IsStabled){} // DO NOTHING
					else if ( creature is BaseMount && ((BaseMount)creature).Rider != null ){} // DO NOTHING
					else { cleanup.Add( creature ); }
				}
			}
			for ( int i = 0; i < cleanup.Count; ++i )
			{
				Mobile creature = ( Mobile )cleanup[ i ];
				creature.Delete();
			}
		}

		public static bool IsBuggable( Item item )
		{
			if ( item is Fists )
				return false;

			if ( item is Multis.BaseBoat
				|| item is Fish || item is BigFish
				|| item is BasePotion || item is Food || item is CookableFood
				|| item is SpecialFishingNet || item is BaseMagicFish
				|| item is Shoes || item is Sandals
				|| item is Boots || item is ThighBoots
				|| item is TreasureMap || item is MessageInABottle
				|| item is BaseArmor || item is BaseWeapon
				|| item is BaseClothing
				|| (item is BaseInstrument && Core.AOS) 
				|| (item is BaseTrinket && Core.AOS) 
				|| (item is BasePotion && Core.ML))
				return true;

			return false;
		}

		public static void OnAfterDuped( Item oldItem, Item newItem )
		{
			if ( oldItem == null || newItem == null )
				return;

			BaseTrinket trinket = oldItem as BaseTrinket;
			BaseClothing clothing = newItem as BaseClothing;

			clothing.Attributes.RegenHits = trinket.Attributes.RegenHits;
			clothing.Attributes.RegenStam = trinket.Attributes.RegenStam;
			clothing.Attributes.RegenMana = trinket.Attributes.RegenMana;
			clothing.Attributes.DefendChance = trinket.Attributes.DefendChance;
			clothing.Attributes.AttackChance = trinket.Attributes.AttackChance;
			clothing.Attributes.BonusStr = trinket.Attributes.BonusStr;
			clothing.Attributes.BonusDex = trinket.Attributes.BonusDex;
			clothing.Attributes.BonusInt = trinket.Attributes.BonusInt;
			clothing.Attributes.BonusHits = trinket.Attributes.BonusHits;
			clothing.Attributes.BonusStam = trinket.Attributes.BonusStam;
			clothing.Attributes.BonusMana = trinket.Attributes.BonusMana;
			clothing.Attributes.WeaponDamage = trinket.Attributes.WeaponDamage;
			clothing.Attributes.WeaponSpeed = trinket.Attributes.WeaponSpeed;
			clothing.Attributes.SpellDamage = trinket.Attributes.SpellDamage;
			clothing.Attributes.CastRecovery = trinket.Attributes.CastRecovery;
			clothing.Attributes.CastSpeed = trinket.Attributes.CastSpeed;
			clothing.Attributes.LowerManaCost = trinket.Attributes.LowerManaCost;
			clothing.Attributes.LowerRegCost = trinket.Attributes.LowerRegCost;
			clothing.Attributes.ReflectPhysical = trinket.Attributes.ReflectPhysical;
			clothing.Attributes.EnhancePotions = trinket.Attributes.EnhancePotions;
			clothing.Attributes.Luck = trinket.Attributes.Luck;
			clothing.Attributes.SpellChanneling = trinket.Attributes.SpellChanneling;
			clothing.Attributes.NightSight = trinket.Attributes.NightSight;

			clothing.Resistances.Physical = trinket.Resistances.Physical;
			clothing.Resistances.Fire = trinket.Resistances.Fire;
			clothing.Resistances.Cold = trinket.Resistances.Cold;
			clothing.Resistances.Poison = trinket.Resistances.Poison;
			clothing.Resistances.Energy = trinket.Resistances.Energy;

			clothing.SkillBonuses.Skill_1_Name = trinket.SkillBonuses.Skill_1_Name;
			clothing.SkillBonuses.Skill_1_Value = trinket.SkillBonuses.Skill_1_Value;
			clothing.SkillBonuses.Skill_2_Name = trinket.SkillBonuses.Skill_2_Name;
			clothing.SkillBonuses.Skill_2_Value = trinket.SkillBonuses.Skill_2_Value;
			clothing.SkillBonuses.Skill_3_Name = trinket.SkillBonuses.Skill_3_Name;
			clothing.SkillBonuses.Skill_3_Value = trinket.SkillBonuses.Skill_3_Value;
			clothing.SkillBonuses.Skill_4_Name = trinket.SkillBonuses.Skill_4_Name;
			clothing.SkillBonuses.Skill_4_Value = trinket.SkillBonuses.Skill_4_Value;
			clothing.SkillBonuses.Skill_5_Name = trinket.SkillBonuses.Skill_5_Name;
			clothing.SkillBonuses.Skill_5_Value = trinket.SkillBonuses.Skill_5_Value;
		}

		public static void DoCleanup( Item oldItem, Item newItem )
		{
			bool equip = false;
			Mobile p = null;
			string name = newItem.Name;

			if ( oldItem is BaseTrinket && newItem is BaseClothing )
				OnAfterDuped( oldItem, newItem );
			else if ( newItem is BaseWeapon && oldItem is BaseWeapon )
				((BaseWeapon)oldItem).OnAfterDuped ( (BaseWeapon)newItem );
			else if ( newItem is BaseArmor && oldItem is BaseArmor )
				((BaseArmor)oldItem).OnAfterDuped ( (BaseArmor)newItem );
			else if ( newItem is BaseClothing && oldItem is BaseClothing )
				((BaseClothing)oldItem).OnAfterDuped ( (BaseClothing)newItem );
			else if ( newItem is BaseQuiver && oldItem is BaseQuiver )
				((BaseQuiver)oldItem).OnAfterDuped ( (BaseQuiver)newItem );
			else if ( newItem is BaseInstrument && oldItem is BaseInstrument )
				((BaseInstrument)oldItem).OnAfterDuped ( (BaseInstrument)newItem );
			else if ( newItem is BaseTrinket && oldItem is BaseTrinket )
				((BaseTrinket)oldItem).OnAfterDuped ( (BaseTrinket)newItem );
			else if ( newItem is Spellbook && oldItem is Spellbook )
				((Spellbook)oldItem).OnAfterDuped ( (Spellbook)newItem );
			else if ( newItem is BaseBook && oldItem is BaseBook )
				((BaseBook)oldItem).OnAfterDuped ( (BaseBook)newItem );

			if ( oldItem.ItemID == 0x2B78 || oldItem.ItemID == 0x316F || oldItem.ItemID == 0x2B79 || oldItem.ItemID == 0x3170 || oldItem.ItemID == 0x2B77 || oldItem.ItemID == 0x316E || oldItem.ItemID == 0x2B76 || oldItem.ItemID == 0x316D )
			{
				// We will change old fur armor back to leather looking armor.
			}
			else if ( oldItem is Container && !(newItem is Container) )
			{
				// Do nothing to wands
			}
			else if ( newItem is MagicalWand || newItem is WritingBook )
			{
				// Do nothing to wands
			}
			else if ( newItem.ArtifactLevel == 2 )
			{
				// Do nothing to artifacts
			}
			else if ( oldItem is BaseTrinket && newItem is BaseTrinket && newItem.Catalog == Catalogs.Jewelry )
			{
				newItem.Hue = oldItem.Hue;
				newItem.Name = oldItem.Name;
				newItem.GraphicHue = newItem.Hue;
			}
			else if ( oldItem is BaseTrinket && newItem is BaseTrinket && newItem.Catalog == Catalogs.Trinket )
			{
				newItem.Hue = oldItem.Hue;
				newItem.Name = oldItem.Name;
				newItem.ItemID = oldItem.ItemID;
				newItem.GraphicID = oldItem.GraphicID;
				newItem.GraphicHue = newItem.Hue;
			}
			else if ( newItem is Spellbook && oldItem is Spellbook )
			{
				newItem.Hue = oldItem.Hue;
				newItem.Name = oldItem.Name;
				newItem.GraphicHue = newItem.Hue;
			}
			else if ( newItem is Bandana )
			{
				newItem.Hue = oldItem.Hue;
				newItem.GraphicHue = oldItem.GraphicHue;
			}
			else if ( newItem is BaseArmor || newItem is BaseWeapon || newItem is BaseTrinket || newItem is BaseClothing || newItem is BaseQuiver || newItem is BaseInstrument )
			{
				newItem.Hue = oldItem.Hue;
				newItem.Name = oldItem.Name;
				newItem.ItemID = oldItem.ItemID;
				newItem.GraphicID = oldItem.GraphicID;
				newItem.GraphicHue = oldItem.GraphicHue;
			}
			else if ( newItem is Fabric )
			{
				newItem.Hue = oldItem.Hue;
				newItem.Amount = newItem.Amount * oldItem.Amount;
			}

			if ( !(newItem is Fabric) )
				newItem.Amount = oldItem.Amount;

			if ( newItem is Pickaxe && name == "gargoyle pickaxe" )
			{
				newItem.Name = "gargoyle pickaxe";
				newItem.Resource = CraftResource.Dwarven;
			}

			if ( oldItem.Parent is Mobile )
			{
				p = (Mobile)(oldItem.Parent);

				if ( newItem.Layer != Layer.Invalid )
					equip = true;
				else
					p.AddToBackpack( newItem );
			}
			else if ( oldItem.Parent is Container )
			{
				(((Container)oldItem.Parent)).DropItem( newItem );
			}
			else if ( oldItem.Parent == null && Region.Find( oldItem.Location, oldItem.Map ) is HouseRegion )
			{
				BaseHouse house = ((HouseRegion)(Region.Find( oldItem.Location, oldItem.Map ))).Home;
				Mobile owner = house.Owner;

				if ( owner != null && owner.BankBox != null )
					(owner.BankBox).DropItem( newItem );
				else
					newItem.Delete();
			}
			else
			{
				newItem.Delete();
			}

			oldItem.Delete();

			if ( newItem.Resource != CraftResource.None && newItem is BaseArmor)
			{
				if ( (newItem.Name).Contains("Amethyst ") ){ (newItem.Name) = (newItem.Name).Replace("Amethyst ", ""); }
				else if ( (newItem.Name).Contains("Caddellite ") ){ (newItem.Name) = (newItem.Name).Replace("Caddellite ", ""); }
				else if ( (newItem.Name).Contains("Emerald ") ){ (newItem.Name) = (newItem.Name).Replace("Emerald ", ""); }
				else if ( (newItem.Name).Contains("Garnet ") ){ (newItem.Name) = (newItem.Name).Replace("Garnet ", ""); }
				else if ( (newItem.Name).Contains("Ice ") ){ (newItem.Name) = (newItem.Name).Replace("Ice ", ""); }
				else if ( (newItem.Name).Contains("Jade ") ){ (newItem.Name) = (newItem.Name).Replace("Jade ", ""); }
				else if ( (newItem.Name).Contains("Marble ") ){ (newItem.Name) = (newItem.Name).Replace("Marble ", ""); }
				else if ( (newItem.Name).Contains("Onyx ") ){ (newItem.Name) = (newItem.Name).Replace("Onyx ", ""); }
				else if ( (newItem.Name).Contains("Quartz ") ){ (newItem.Name) = (newItem.Name).Replace("Quartz ", ""); }
				else if ( (newItem.Name).Contains("Ruby ") ){ (newItem.Name) = (newItem.Name).Replace("Ruby ", ""); }
				else if ( (newItem.Name).Contains("Sapphire ") ){ (newItem.Name) = (newItem.Name).Replace("Sapphire ", ""); }
				else if ( (newItem.Name).Contains("Silver ") ){ (newItem.Name) = (newItem.Name).Replace("Silver ", ""); }
				else if ( (newItem.Name).Contains("Spinel ") ){ (newItem.Name) = (newItem.Name).Replace("Spinel ", ""); }
				else if ( (newItem.Name).Contains("Star Ruby ") ){ (newItem.Name) = (newItem.Name).Replace("Star Ruby ", ""); }
				else if ( (newItem.Name).Contains("Topaz ") ){ (newItem.Name) = (newItem.Name).Replace("Topaz ", ""); }

				else if ( (newItem.Name).Contains("Dead Skin ") ){ (newItem.Name) = (newItem.Name).Replace("Dead Skin ", ""); }
				else if ( (newItem.Name).Contains("Icy Skin ") ){ (newItem.Name) = (newItem.Name).Replace("Icy Skin ", ""); }
				else if ( (newItem.Name).Contains("Lava Skin ") ){ (newItem.Name) = (newItem.Name).Replace("Lava Skin ", ""); }
				else if ( (newItem.Name).Contains("Seaweed ") ){ (newItem.Name) = (newItem.Name).Replace("Seaweed Skin ", ""); }
				else if ( (newItem.Name).Contains("Demon Skin ") ){ (newItem.Name) = (newItem.Name).Replace("Demon Skin ", ""); }
				else if ( (newItem.Name).Contains("Dragon Skin ") ){ (newItem.Name) = (newItem.Name).Replace("Dragon Skin ", ""); }
				else if ( (newItem.Name).Contains("Nightmare Skin ") ){ (newItem.Name) = (newItem.Name).Replace("Nightmare Skin ", ""); }
				else if ( (newItem.Name).Contains("Serpent Skin ") ){ (newItem.Name) = (newItem.Name).Replace("Serpent Skin ", ""); }
				else if ( (newItem.Name).Contains("Troll Skin ") ){ (newItem.Name) = (newItem.Name).Replace("Troll Skin ", ""); }
				else if ( (newItem.Name).Contains("Unicorn Skin ") ){ (newItem.Name) = (newItem.Name).Replace("Unicorn Skin ", ""); }
			}

			ResourceMods.DefaultItemHue( newItem );

			if ( equip && p != null )
				p.AddItem( newItem );
		}

		public static void RemoveScripts()
		{
			using (StreamReader reader = new StreamReader("Data/System/CFG/cleanup.cfg"))
			{
				string str;
				while ((str = reader.ReadLine()) != null)
				{
					Server.Misc.Cleanup.RemoveScript( str );
				}
			}
		}

		/*

		To get rid of items and replace them with another item you can put this snip of code in each item being deleted.
		It will create a newer version the best way possible and place it in the same container or equipment slot.

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new PlateLegs();
			((BaseArmor)item).Resource = CraftResource.CaddelliteBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}


		*/

		public static void RemoveScript( string script )
		{
			if ( System.IO.File.Exists( "Data/Scripts/Obsolete/" + script + ".cs" ) )
			{
				if ( System.IO.File.Exists( "Data/Obsolete/" + script + ".cs" ) )
					System.IO.File.Delete( "Data/Obsolete/" + script + ".cs" );

				System.IO.File.Move( "Data/Scripts/Obsolete/" + script + ".cs", "Data/Obsolete/" + script + ".cs" );
			}
		}
	}
}