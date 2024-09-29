using System;
using System.Collections.Generic;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Engines.Craft
{
	public enum CraftECA
	{
		ChanceMinusSixty,
		FiftyPercentChanceMinusTenPercent,
		ChanceMinusSixtyToFourtyFive
	}

	public abstract class CraftSystem
	{
		private int m_MinCraftEffect;
		private int m_MaxCraftEffect;
		private double m_Delay;
		private bool m_BreakDown;
		private bool m_Repair;
		private bool m_CanEnhance;
		public BaseTool m_Tools;

		private CraftItemCol m_CraftItems;
		private CraftGroupCol m_CraftGroups;
		private CraftSubResCol m_CraftSubRes;

		public int MinCraftEffect { get { return m_MinCraftEffect; } }
		public int MaxCraftEffect { get { return m_MaxCraftEffect; } }
		public double Delay { get { return m_Delay; } }

		public CraftItemCol CraftItems{ get { return m_CraftItems; } }
		public CraftGroupCol CraftGroups{ get { return m_CraftGroups; } }
		public CraftSubResCol CraftSubRes{ get { return m_CraftSubRes; } }
		
		public abstract SkillName MainSkill{ get; }

		public virtual int GumpImage{ get{ return 0; } }
		public virtual int GumpTitleNumber{ get{ return 0; } }
		public virtual string GumpTitleString{ get{ return ""; } }
		public virtual string CraftSystemTxt{ get{ return ""; } }
		public virtual bool ShowGumpInfo{ get{ return false; } }
		public virtual CraftResourceType BreakDownType{ get{ return CraftResourceType.Metal; } }
		public virtual CraftResourceType BreakDownTypeAlt{ get{ return CraftResourceType.None; } }

		public virtual CraftECA ECA{ get{ return CraftECA.ChanceMinusSixty; } }

		private Dictionary<Mobile, CraftContext> m_ContextTable = new Dictionary<Mobile, CraftContext>();

		public abstract double GetChanceAtMin( CraftItem item );

		public static bool AllowManyCraft( BaseTool tool )
		{
			if ( tool != null && ( tool is BaseRunicTool || tool is TomeOfWands ) )
				return false;

			return MySettings.S_CraftMany;
		}

		public static void SetCraftResource( CraftContext context, int index, CraftSubRes res )
		{
			if ( context != null && index > -1 && res != null )
			{
				context.LastResourceIndex = index;

				Type resType = res.ItemType;

				Item tempRes = (Item)Activator.CreateInstance(resType);

				context.CraftingResource = CraftResource.None;
				if ( tempRes is BaseIngot )
					context.CraftingResource = ((BaseIngot)tempRes).Resource;
				else if ( tempRes is BaseFabric )
					context.CraftingResource = ((BaseFabric)tempRes).Resource;
				else if ( tempRes is BaseScales )
					context.CraftingResource = ((BaseScales)tempRes).Resource;
				else if ( tempRes is BaseLeather )
					context.CraftingResource = ((BaseLeather)tempRes).Resource;
				else if ( tempRes is BaseWoodBoard )
					context.CraftingResource = ((BaseWoodBoard)tempRes).Resource;
				else if ( tempRes is BaseLog )
					context.CraftingResource = ((BaseLog)tempRes).Resource;
				else if ( tempRes is BaseHides )
					context.CraftingResource = ((BaseHides)tempRes).Resource;
				else if ( tempRes is BaseOre )
					context.CraftingResource = ((BaseOre)tempRes).Resource;
				else if ( tempRes is BaseBlocks )
					context.CraftingResource = ((BaseBlocks)tempRes).Resource;
				else if ( tempRes is BaseSkins )
					context.CraftingResource = ((BaseSkins)tempRes).Resource;
				else if ( tempRes is BaseSkeletal )
					context.CraftingResource = ((BaseSkeletal)tempRes).Resource;
				else if ( tempRes is BaseSpecial )
					context.CraftingResource = ((BaseSpecial)tempRes).Resource;

				tempRes.Delete();
			}
		}

		public static void SetDescription( CraftContext context, BaseTool tool, Type type, CraftSystem system, string nameString, Mobile from, CraftItem cItem )
		{
			int typeHue = 0;

			if ( type != null && context != null )
			{
				context.ItemSelected = type;
				context.NameString = nameString;

				CraftResource resource = context.CraftingResource;

				if ( system is DefDraconic && !( resource >= CraftResource.RedScales && resource <= CraftResource.KraytScales ) )
				{
					resource = CraftResource.RedScales;
					context.CraftingResource = CraftResource.RedScales;
				}
				else if ( system is DefLapidary && !( resource >= CraftResource.AmethystBlock && resource <= CraftResource.CaddelliteBlock ) )
				{
					resource = CraftResource.AmethystBlock;
					context.CraftingResource = CraftResource.AmethystBlock;
				}
				else if ( system is DefStitching && !( resource >= CraftResource.DemonSkin && resource <= CraftResource.DeadSkin ) )
				{
					resource = CraftResource.DemonSkin;
					context.CraftingResource = CraftResource.DemonSkin;
				}

				if ( tool is BaseRunicTool )
					resource = ((BaseRunicTool)tool).Resource;

				Item descriptor = (Item)Activator.CreateInstance(type);
				ResourceMods.DefaultItemHue( descriptor );

				if ( descriptor.Catalog == Catalogs.Jewelry && descriptor is BaseTrinket )
				{
					if ( nameString.Contains("star sapphire") ){ ((BaseTrinket)descriptor).GemType = GemType.StarSapphire; }
					else if ( nameString.Contains("emerald") ){ ((BaseTrinket)descriptor).GemType = GemType.Emerald; }
					else if ( nameString.Contains("sapphire") ){ ((BaseTrinket)descriptor).GemType = GemType.Sapphire; }
					else if ( nameString.Contains("ruby") ){ ((BaseTrinket)descriptor).GemType = GemType.Ruby; }
					else if ( nameString.Contains("citrine") ){ ((BaseTrinket)descriptor).GemType = GemType.Citrine; }
					else if ( nameString.Contains("amethyst") ){ ((BaseTrinket)descriptor).GemType = GemType.Amethyst; }
					else if ( nameString.Contains("tourmaline") ){ ((BaseTrinket)descriptor).GemType = GemType.Tourmaline; }
					else if ( nameString.Contains("amber") ){ ((BaseTrinket)descriptor).GemType = GemType.Amber; }
					else if ( nameString.Contains("diamond") ){ ((BaseTrinket)descriptor).GemType = GemType.Diamond; }
					else if ( nameString.Contains("pearl") ){ ((BaseTrinket)descriptor).GemType = GemType.Pearl; }
				}
				else if ( descriptor.Catalog == Catalogs.Trinket && descriptor.NotIDSource == Identity.Wand && descriptor is BaseTrinket )
				{
					descriptor.Delete();
					descriptor = new MagicalWand( SpellItems.GetWand( nameString ) );
				}

				typeHue = descriptor.Hue;

				descriptor.Resource = resource;

				if ( typeHue < 1 || ( typeHue != descriptor.Hue && descriptor.Hue > 0 ) || system is DefDraconic || system is DefLapidary || system is DefStitching )
					typeHue = descriptor.Hue;

				string description = ItemProps.ItemProperties( descriptor, true );

				if ( tool is BaseRunicTool )
					description += "Potentially Magical";

				context.Description = description;
				context.ItemID = descriptor.ItemID;

				if ( cItem != null )
					system.OnMade( from, cItem );

				descriptor.Delete();
			}

			context.Hue = typeHue;
		}

		public static bool CraftingMany( Mobile m )
		{
			if ( m is PlayerMobile && ((PlayerMobile)m).CraftQueue > 1 )
				return true;

			return false;
		}

		public static void CraftStarting( Mobile m )
		{
			if ( m is PlayerMobile )
				if ( CraftSystem.CraftGetQueue( m ) > 1 )
					((PlayerMobile)m).CraftDone = DateTime.Now + TimeSpan.FromSeconds( 7.0 );
		}

		public static bool CraftFinished( Mobile m, BaseTool tool )
		{
			if ( !AllowManyCraft( tool ) )
				return true;
			if ( m is PlayerMobile && DateTime.Now >= ((PlayerMobile)m).CraftDone )
				return true;
			else
				m.SendMessage( "You must wait a moment before doing something else." );

			return false;
		}

		public static void CraftSetQueue( Mobile m, int val )
		{
			if ( m is PlayerMobile )
				((PlayerMobile)m).CraftQueue = val;
		}

		public static int CraftGetQueue( Mobile m )
		{
			if ( m is PlayerMobile )
				return ((PlayerMobile)m).CraftQueue;

			return 0;
		}

		public static void CraftReduceQueue( Mobile m, int val )
		{
			if ( m is PlayerMobile )
			{
				if ( val == 1 )
					((PlayerMobile)m).CraftQueue--;
				else 
					((PlayerMobile)m).CraftQueue = val;
			}
		}

		public static void CraftReduceTool( Mobile m, BaseTool tool )
		{
			if ( m is PlayerMobile && !((PlayerMobile)m).CraftToolReduced )
			{
				tool.UsesRemaining--;
				((PlayerMobile)m).CraftToolReduced = true;
			}
		}

		public static void CraftStartTool( Mobile m )
		{
			if ( m is PlayerMobile )
				((PlayerMobile)m).CraftToolReduced = false;
		}

		public static void CraftAddItem( Mobile m, bool exceptional, int qty )
		{
			if ( m is PlayerMobile && exceptional )
				((PlayerMobile)m).CraftExceptional = ((PlayerMobile)m).CraftExceptional + qty;
			else if ( m is PlayerMobile )
				((PlayerMobile)m).CraftSuccess = ((PlayerMobile)m).CraftSuccess + qty;
		}

		public static void CraftError( Mobile m )
		{
			if ( m is PlayerMobile )
			{
				((PlayerMobile)m).CraftQueue = 0;
				((PlayerMobile)m).CraftError = 1;
			}
		}

		public static void CraftSound( Mobile m, int sound, BaseTool tool )
		{
			if ( m is PlayerMobile )
			{
				if ( !AllowManyCraft( tool ) )
					m.PlaySound( sound );
				else if ( ((PlayerMobile)m).CraftSound == -1 )
					((PlayerMobile)m).CraftSound = sound;
				else if ( ((PlayerMobile)m).CraftSound > 0 ){}
					// DO NOTHING
				else
					m.PlaySound( sound );
			}
		}

		public static void CraftSoundAfter( Mobile m, int sound, BaseTool tool )
		{
			if ( m is PlayerMobile )
			{
				if ( !AllowManyCraft( tool ) )
					m.PlaySound( sound );
				else if ( ((PlayerMobile)m).CraftSoundAfter == -1 )
					((PlayerMobile)m).CraftSoundAfter = sound;
				else if ( ((PlayerMobile)m).CraftSoundAfter > 0 ){}
					// DO NOTHING
				else
					m.PlaySound( sound );
			}
		}

		public static void CraftClear( Mobile m )
		{
			if ( m is PlayerMobile )
			{
				((PlayerMobile)m).CraftQueue = 0;
				((PlayerMobile)m).CraftSuccess = 0;
				((PlayerMobile)m).CraftExceptional = 0;
				((PlayerMobile)m).CraftError = 0;
				((PlayerMobile)m).CraftSound = 0;
				((PlayerMobile)m).CraftSoundAfter = 0;
			}
		}

		public virtual bool RetainsColorFrom( CraftItem item, Type type )
		{
			return false;
		}

		public CraftContext GetContext( Mobile m )
		{
			if ( m == null )
				return null;

			if ( m.Deleted )
			{
				m_ContextTable.Remove( m );
				return null;
			}

			CraftContext c = null;
			m_ContextTable.TryGetValue( m, out c );

			if ( c == null )
				m_ContextTable[m] = c = new CraftContext();

			return c;
		}

		public void OnMade( Mobile m, CraftItem item )
		{
			CraftContext c = GetContext( m );

			if ( c != null )
				c.OnMade( item );
		}

		public BaseTool Tools
		{
			get { return m_Tools; }
			set { m_Tools = value; }
		}

		public bool BreakDown
		{
			get { return m_BreakDown; }
			set { m_BreakDown = value; }
		}

		public bool Repair
		{
			get{ return m_Repair; }
			set{ m_Repair = value; }
		}

		public bool CanEnhance
		{
			get{ return m_CanEnhance; }
			set{ m_CanEnhance = value; }
		}

		public CraftSystem( int minCraftEffect, int maxCraftEffect, double delay )
		{
			m_MinCraftEffect = minCraftEffect;
			m_MaxCraftEffect = maxCraftEffect;
			m_Delay = delay;

			m_CraftItems = new CraftItemCol();
			m_CraftGroups = new CraftGroupCol();
			m_CraftSubRes = new CraftSubResCol();

			InitCraftList();
		}

		public virtual bool ConsumeOnFailure( Mobile from, Type resourceType, CraftItem craftItem )
		{
			return true;
		}

		public void CreateItem( Mobile from, Type type, Type typeRes, BaseTool tool, CraftItem realCraftItem )
		{	
			// Verify if the type is in the list of the craftable item
			CraftItem craftItem = m_CraftItems.SearchFor( type );
			if ( craftItem != null )
			{
				// The item is in the list, try to create it
				// Test code: items like sextant parts can be crafted either directly from ingots, or from different parts
				realCraftItem.Craft( from, this, typeRes, tool );
				//craftItem.Craft( from, this, typeRes, tool );
			}
		}

		public int AddCraft( Type typeItem, TextDefinition group, TextDefinition name, double minSkill, double maxSkill, Type typeRes, TextDefinition nameRes, int amount )
		{
			return AddCraft( typeItem, group, name, MainSkill, minSkill, maxSkill, typeRes, nameRes, amount, "" );
		}

		public int AddCraft( Type typeItem, TextDefinition group, TextDefinition name, double minSkill, double maxSkill, Type typeRes, TextDefinition nameRes, int amount, TextDefinition message )
		{
			return AddCraft( typeItem, group, name, MainSkill, minSkill, maxSkill, typeRes, nameRes, amount, message );
		}

		public int AddCraft( Type typeItem, TextDefinition group, TextDefinition name, SkillName skillToMake, double minSkill, double maxSkill, Type typeRes, TextDefinition nameRes, int amount )
		{
			return AddCraft( typeItem, group, name, skillToMake, minSkill, maxSkill, typeRes, nameRes, amount, "" );
		}

		public int AddCraft( Type typeItem, TextDefinition group, TextDefinition name, SkillName skillToMake, double minSkill, double maxSkill, Type typeRes, TextDefinition nameRes, int amount, TextDefinition message )
		{
			CraftItem craftItem = new CraftItem( typeItem, group, name );
			craftItem.AddRes( typeRes, nameRes, amount, message );
			craftItem.AddSkill( skillToMake, minSkill, maxSkill );

			DoGroup( group, craftItem );
			return m_CraftItems.Add( craftItem );
		}

		private void DoGroup( TextDefinition groupName, CraftItem craftItem )
		{
			int index = m_CraftGroups.SearchFor( groupName );

			if ( index == -1)
			{
				CraftGroup craftGroup = new CraftGroup( groupName );
				craftGroup.AddCraftItem( craftItem );
				m_CraftGroups.Add( craftGroup );
			}
			else
			{
				m_CraftGroups.GetAt( index ).AddCraftItem( craftItem );
			}
		}

		public void SetManaReq( int index, int mana )
		{
			CraftItem craftItem = m_CraftItems.GetAt( index );
			craftItem.Mana = mana;
		}

		public void SetStamReq( int index, int stam )
		{
			CraftItem craftItem = m_CraftItems.GetAt( index );
			craftItem.Stam = stam;
		}

		public void SetHitsReq( int index, int hits )
		{
			CraftItem craftItem = m_CraftItems.GetAt( index );
			craftItem.Hits = hits;
		}
		
		public void SetUseAllRes( int index, bool useAll )
		{
			CraftItem craftItem = m_CraftItems.GetAt( index );
			craftItem.UseAllRes = useAll;
		}

		public void SetNeedHeat( int index, bool needHeat )
		{
			CraftItem craftItem = m_CraftItems.GetAt( index );
			craftItem.NeedHeat = needHeat;
		}

		public void SetNeedOven( int index, bool needOven )
		{
			CraftItem craftItem = m_CraftItems.GetAt( index );
			craftItem.NeedOven = needOven;
		}

		public void SetNeedMill( int index, bool needMill )
		{
			CraftItem craftItem = m_CraftItems.GetAt( index );
			craftItem.NeedMill = needMill;
		}

		public void SetNeededExpansion( int index, Expansion expansion )
		{
			CraftItem craftItem = m_CraftItems.GetAt( index );
			craftItem.RequiredExpansion = expansion;
		}

		public void AddRes( int index, Type type, TextDefinition name, int amount )
		{
			AddRes( index, type, name, amount, "" );
		}

		public void AddRes( int index, Type type, TextDefinition name, int amount, TextDefinition message )
		{
			CraftItem craftItem = m_CraftItems.GetAt( index );
			craftItem.AddRes( type, name, amount, message );
		}

		public void AddSkill( int index, SkillName skillToMake, double minSkill, double maxSkill )
		{
			CraftItem craftItem = m_CraftItems.GetAt(index);
			craftItem.AddSkill(skillToMake, minSkill, maxSkill);
		}

		public void ForceNonExceptional( int index )
		{
			CraftItem craftItem = m_CraftItems.GetAt( index );
			craftItem.ForceNonExceptional = true;
		}

		public void SetSubRes( Type type, string name )
		{
			m_CraftSubRes.ResType = type;
			m_CraftSubRes.NameString = name;
			m_CraftSubRes.Init = true;
		}

		public void SetSubRes( Type type, int name )
		{
			m_CraftSubRes.ResType = type;
			m_CraftSubRes.NameNumber = name;
			m_CraftSubRes.Init = true;
		}

		public void AddSubRes( Type type, int name, double reqSkill, object message )
		{
			CraftSubRes craftSubRes = new CraftSubRes( type, name, reqSkill, message );
			m_CraftSubRes.Add( craftSubRes );
		}

		public void AddSubRes( Type type, int name, double reqSkill, int genericName, object message )
		{
			CraftSubRes craftSubRes = new CraftSubRes( type, name, reqSkill, genericName, message );
			m_CraftSubRes.Add( craftSubRes );
		}

		public void AddSubRes( Type type, string name, double reqSkill, object message )
		{
			CraftSubRes craftSubRes = new CraftSubRes( type, name, reqSkill, message );
			m_CraftSubRes.Add( craftSubRes );
		}

		public abstract void InitCraftList();

		public abstract void PlayCraftEffect( Mobile from );
		public abstract int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, CraftItem item );

		public abstract int CanCraft( Mobile from, BaseTool tool, Type itemType );
	}
}