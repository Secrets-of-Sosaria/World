using System;
using Server.Items;
using Server.Mobiles;
using System.Globalization;

namespace Server.Engines.Craft
{
	public class DefWands : CraftSystem
	{
		public override SkillName MainSkill
		{
			get	{ return SkillName.Inscribe; }
		}

        public override int GumpImage
        {
            get { return 9606; }
        }

        public override bool ShowGumpInfo
        {
            get { return true; }
        }

        public override int GumpTitleNumber
        {
            get { return 0; }
        }
 
        public override string GumpTitleString
        {
            get { return "<BASEFONT Color=#FBFBFB><CENTER>WAND CRAFTING MENU</CENTER></BASEFONT>"; }
        }

		public override string CraftSystemTxt
		{
			get { return "Crafting: Wand Creation"; }
		}

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefWands();

				return m_CraftSystem;
			}
		}

		public override CraftECA ECA{ get{ return CraftECA.ChanceMinusSixtyToFourtyFive; } }

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.5; // 50%
		}

		private DefWands() : base( 1, 1, 1.25 )// base( 1, 1, 4.5 )
		{
		}

		private static Type typeofAnvil = typeof( AnvilAttribute );
		private static Type typeofForge = typeof( ForgeAttribute );

		public override int CanCraft( Mobile from, BaseTool tool, Type itemType )
		{
			int say = 0;

			bool anvil, forge;
			Server.Engines.Craft.DefBlacksmithy.CheckAnvilAndForge( from, 2, out anvil, out forge );

			if( tool == null || tool.Deleted || tool.UsesRemaining < 0 )
			{
				from.SendMessage( "Your book is worn out and no longer usable." );
				say = 1150845;
			}
			else if ( !BaseTool.CheckAccessible( tool, from ) )
			{
				from.SendMessage( "You need the book in your pack." );
				say = 1150845;
			}
			else if ( from.Backpack.FindItemByType( typeof ( SmithHammer ) ) == null )
			{
				from.SendMessage( "You need a blacksmith hammer to mold the metal." );
				say = 1150845;
			}
			else if ( !anvil || !forge )
			{
				return 1044267; // You must be near an anvil and a forge to smith items.;
			}

			return say;
		}

		public override void PlayCraftEffect( Mobile from )
		{
			CraftSystem.CraftSound( from, 0x542, m_Tools );
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, CraftItem item )
		{
			if ( toolBroken )
				from.SendMessage("The book is worn out from constant use.");

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

			int wandTypes = 0;
			string strCircle = "1st Circle";
			double wandSkill = 0.0;
			int scrollAmount = 1;
			int ingotCliloc = 1074916;
			Type ingotType = typeof( DullCopperIngot );

			while ( wandTypes < 64 )
			{
				wandTypes++;

				if ( wandTypes > 56 ){ 				strCircle = "Eighth Circle";	wandSkill = 115.0;		scrollAmount = 30;		ingotCliloc = 1074923;		ingotType = typeof( ValoriteIngot );	}
				else if ( wandTypes > 48 ){ 		strCircle = "Seventh Circle";	wandSkill = 110.0;		scrollAmount = 23;		ingotCliloc = 1074922;		ingotType = typeof( VeriteIngot );		}
				else if ( wandTypes > 40 ){ 		strCircle = "Sixth Circle";		wandSkill = 105.0;		scrollAmount = 17;		ingotCliloc = 1074921;		ingotType = typeof( AgapiteIngot );		}
				else if ( wandTypes > 32 ){ 		strCircle = "Fifth Circle";		wandSkill = 100.0;		scrollAmount = 12;		ingotCliloc = 1074920;		ingotType = typeof( GoldIngot );		}
				else if ( wandTypes > 24 ){ 		strCircle = "Fourth Circle";	wandSkill = 90.0;		scrollAmount = 8;		ingotCliloc = 1074919;		ingotType = typeof( BronzeIngot );		}
				else if ( wandTypes > 16 ){ 		strCircle = "Third Circle";		wandSkill = 80.0;		scrollAmount = 5;		ingotCliloc = 1074918;		ingotType = typeof( CopperIngot );		}
				else if ( wandTypes > 8 ){ 			strCircle = "Second Circle";	wandSkill = 70.0;		scrollAmount = 2;		ingotCliloc = 1074917;		ingotType = typeof( ShadowIronIngot );	}
				else {						 		strCircle = "First Circle";		wandSkill = 60.0;		scrollAmount = 1;		ingotCliloc = 1074916;		ingotType = typeof( DullCopperIngot );	}

				Item res = (Item)Activator.CreateInstance( SpellItems.GetScroll( (MagicSpell)wandTypes ) );

				if ( res != null )
				{
					TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;

					index = AddCraft( typeof( MagicalWand ), strCircle, SpellItems.GetName( (MagicSpell)wandTypes ), wandSkill, wandSkill+30.0, ingotType, ingotCliloc, 4, 1053098 );
					AddRes( index, res.GetType(), cultInfo.ToTitleCase(res.Name), scrollAmount, 1053098 );
					AddRes( index, typeof( ArcaneGem ), "Arcane Gem", 1, 1053098 );

					res.Delete();
				}
			}
		}
	}
}