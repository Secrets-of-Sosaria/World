using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Craft
{
	public class DefApothecary : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Alchemy; }
		}

        public override int GumpImage
        {
            get { return 9598; }
        }

        public override int GumpTitleNumber
        {
            get { return 0; }
        }

        public override bool ShowGumpInfo
        {
            get { return true; }
        }
 
        public override string GumpTitleString
        {
            get { return "<BASEFONT Color=#FBFBFB><CENTER>APOTHECARY MENU</CENTER></BASEFONT>"; }
        }

		public override string CraftSystemTxt
		{
			get { return "Crafting: Apothecary"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefApothecary();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefApothecary() : base( 1, 1, 1.25 )// base( 1, 1, 4.5 )
		{
		}

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			if( tool == null || tool.Deleted || tool.UsesRemaining < 0 )
				return 1044038; // You have worn out your tool!
			else if ( !(tool.Parent == from ) )
				return 1044263; // The tool must be on your person to use.
			else if ( from.Skills[SkillName.Alchemy].Value < 70.0 )
				return 1063801;
			else if ( from.Map == Map.SavagedEmpire && from.X > 1098 && from.X < 1121 && from.Y > 1908 && from.Y < 1931 )
				return 0;

			return 1044146;
		}

		public override void PlayCraftEffect( Mobile from )
		{
			CraftSystem.CraftSound( from, 0x242, m_Tools );
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, CraftItem item )
		{
			Server.Gumps.RegBar.RefreshRegBar( from );

			if ( toolBroken )
				from.SendLocalizedMessage( 1044038 ); // You have worn out your tool

			if ( failed )
			{
				if ( lostMaterial )
					return 1044043; // You failed to create the item, and some of your materials are lost.
				else
					return 1044157; // You failed to create the item, but no materials were lost.
			}
			else
			{
				return 1044154; // You create the item.
			}
		}

		public override void InitCraftList()
		{
			int index = -1;

			#region Potions

			index = AddCraft( typeof( LesserInvisibilityPotion ), "Invisibility", "Invisibility Potion, Lesser", 70.0, 105.0, typeof( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( SilverSerpentVenom ), "Silver Serpent Venom", 1, 1042081 );
			AddRes( index, typeof( DragonBlood ), "Dragon Blood", 2, 1042081 );

			index = AddCraft( typeof( InvisibilityPotion ), "Invisibility", "Invisibility Potion", 80.0, 115.0, typeof( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( SilverSerpentVenom ), "Silver Serpent Venom", 2, 1042081 );
			AddRes( index, typeof( DragonBlood ), "Dragon Blood", 4, 1042081 );

			index = AddCraft( typeof( GreaterInvisibilityPotion ), "Invisibility", "Invisibility Potion, Greater", 90.0, 125.0, typeof( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( SilverSerpentVenom ), "Silver Serpent Venom", 3, 1042081 );
			AddRes( index, typeof( DragonBlood ), "Dragon Blood", 6, 1042081 );

			index = AddCraft( typeof( InvulnerabilityPotion ), "Invulnerability", "Invulnerability Potion", 90.0, 125.0, typeof( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( EnchantedSeaweed ), "Enchanted Seaweed", 3, 1042081 );
			AddRes( index, typeof( DragonTooth ), "Dragon Tooth", 2, 1042081 );

			index = AddCraft( typeof( LesserManaPotion ), "Mana", "Mana Potion, Lesser", 70.0, 105.0, typeof( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( GoldenSerpentVenom ), "Golden Serpent Venom", 1, 1042081 );
			AddRes( index, typeof( LichDust ), "Lich Dust", 2, 1042081 );

			index = AddCraft( typeof( ManaPotion ), "Mana", "Mana Potion", 80.0, 115.0, typeof( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( GoldenSerpentVenom ), "Golden Serpent Venom", 2, 1042081 );
			AddRes( index, typeof( LichDust ), "Lich Dust", 4, 1042081 );

			index = AddCraft( typeof( GreaterManaPotion ), "Mana", "Mana Potion, Greater", 90.0, 125.0, typeof( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( GoldenSerpentVenom ), "Golden Serpent Venom", 3, 1042081 );
			AddRes( index, typeof( LichDust ), "Lich Dust", 6, 1042081 );

			index = AddCraft( typeof( LesserRejuvenatePotion ), "Rejuvenate", "Rejuvenation Potion, Lesser", 70.0, 105.0, typeof( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( DemonClaw ), "Demon Claw", 1, 1042081 );
			AddRes( index, typeof( UnicornHorn ), "Unicorn Horn", 1, 1042081 );

			index = AddCraft( typeof( RejuvenatePotion ), "Rejuvenate", "Rejuvenation Potion", 80.0, 115.0, typeof( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( DemonClaw ), "Demon Claw", 2, 1042081 );
			AddRes( index, typeof( UnicornHorn ), "Unicorn Horn", 2, 1042081 );

			index = AddCraft( typeof( GreaterRejuvenatePotion ), "Rejuvenate", "Rejuvenation Potion, Greater", 90.0, 125.0, typeof( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( DemonClaw ), "Demon Claw", 3, 1042081 );
			AddRes( index, typeof( UnicornHorn ), "Unicorn Horn", 3, 1042081 );

			index = AddCraft( typeof( SuperPotion ), "Rejuvenate", "Superior Potion", 90.0, 125.0, typeof( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( DemonClaw ), "Demon Claw", 3, 1042081 );
			AddRes( index, typeof( UnicornHorn ), "Unicorn Horn", 3, 1042081 );

			index = AddCraft( typeof( AutoResPotion ), "Resurrection", "Resurrect Self Potion", 90.0, 125.0, typeof( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( DemigodBlood ), "Demigod Blood", 3, 1042081 );
			AddRes( index, typeof( GhostlyDust ), "Ghostly Dust", 2, 1042081 );

			index = AddCraft( typeof( ResurrectPotion ), "Resurrection", "Resurrect Others Potion", 90.0, 125.0, typeof( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( DemigodBlood ), "Demigod Blood", 3, 1042081 );
			AddRes( index, typeof( GhostlyDust ), "Ghostly Dust", 2, 1042081 );

			index = AddCraft( typeof( RepairPotion ), "Repair", "Repairing Potion", 90.0, 125.0, typeof( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( UnicornHorn ), "Unicorn Horn", 3, 1042081 );
			AddRes( index, typeof( SilverSerpentVenom ), "Silver Serpent Venom", 2, 1042081 );

			index = AddCraft( typeof( DurabilityPotion ), "Repair", "Durability Potion", 110.0, 125.0, typeof( Bottle ), 1044529, 1, 500315 );
			AddRes( index, typeof( GoldenSerpentVenom ), "Golden Serpent Venom", 3, 1042081 );
			AddRes( index, typeof( DragonBlood ), "Dragon Blood", 2, 1042081 );

			#endregion
		}
	}
}