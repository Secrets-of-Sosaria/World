using System;
using Server;
using Server.Network;
using Server.Engines.Craft;
using Server.Gumps;

namespace Server.Items
{
	public enum ToolQuality
	{
		Low,
		Regular,
		Exceptional
	}

	public abstract class BaseTool : Item, IUsesRemaining, ICraftable
	{
		public override string DefaultDescription{ get{ return "These tools are used in various crafting trades. They must be equipped to be used and have a limited amount of uses before they break."; } }

		public override Catalogs DefaultCatalog{ get{ return Catalogs.Tool; } }

		public override void ResourceChanged( CraftResource resource )
		{
			if ( !ResourceCanChange() )
				return;

			ResourceMods.Modify( this, true );
			m_Resource = resource;
			Hue = CraftResources.GetHue(m_Resource);
			ResourceMods.Modify( this, false );
			InvalidateProperties();
		}

		public virtual Layer DefaultLayer{ get{ return Layer.OneHanded; } }

		private ToolQuality m_Quality;
		private int m_UsesRemaining;
		private AosSkillBonuses m_AosSkillBonuses;

		[CommandProperty( AccessLevel.GameMaster )]
		public ToolQuality Quality
		{
			get{ return m_Quality; }
			set{ UnscaleUses(); m_Quality = value; InvalidateProperties(); ScaleUses(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public AosSkillBonuses SkillBonuses
		{
			get{ return m_AosSkillBonuses; }
			set{}
		}

		public override void OnAfterDuped( Item newItem )
		{
			BaseTool tool = newItem as BaseTool;

			if ( tool == null )
				return;

			tool.m_AosSkillBonuses = new AosSkillBonuses( newItem, m_AosSkillBonuses );
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int UsesRemaining
		{
			get { return m_UsesRemaining; }
			set { m_UsesRemaining = value; InvalidateProperties(); }
		}

		public void ScaleUses()
		{
			m_UsesRemaining = (m_UsesRemaining * GetUsesScalar()) / 100;
			InvalidateProperties();
		}

		public void UnscaleUses()
		{
			m_UsesRemaining = (m_UsesRemaining * 100) / GetUsesScalar();
		}

		public int GetUsesScalar()
		{
			if ( m_Quality == ToolQuality.Exceptional )
				return 200;

			return 100;
		}

		public bool ShowUsesRemaining{ get{ return true; } set{} }

		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }

		public abstract CraftSystem CraftSystem{ get; }

		public override void OnAdded( object parent )
		{
			DefaultMainHue( this );
			Mobile mob = parent as Mobile;

			if ( mob != null )
				m_AosSkillBonuses.AddTo( mob );

			base.OnAdded( parent );
		}

		public override void OnRemoved( object parent )
		{
			if ( parent is Mobile && m_AosSkillBonuses != null )
			{
				Mobile from = (Mobile)parent;
				m_AosSkillBonuses.Remove();
			}
			base.OnRemoved( parent );
		}

		public override void DefaultMainHue( Item item )
		{
			ResourceMods.DefaultItemHue( item );
		}

		private string GetNameString()
		{
			string name = this.Name;

			if ( name == null )
				name = String.Format( "#{0}", LabelNumber );

			return name;
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			if ( CraftResources.GetClilocLowerCaseName( m_Resource ) > 0 && m_SubResource == CraftResource.None )
				list.Add( 1053099, "#{0}\t{1}", CraftResources.GetClilocLowerCaseName( m_Resource ), GetNameString() ); // ~1_oretype~ ~2_armortype~
			else if ( Name == null )
				list.Add( LabelNumber );
			else
				list.Add( Name );
		}

		public BaseTool( int itemID ) : this( 50, itemID )
		{
		}

		public BaseTool( int uses, int itemID ) : base( itemID )
		{
			if ( CraftSystem.CraftSystemTxt != null )
				InfoText1 = CraftSystem.CraftSystemTxt;

			m_AosSkillBonuses = new AosSkillBonuses( this );
			m_UsesRemaining = uses;
			m_Quality = ToolQuality.Regular;
			Layer = DefaultLayer;
		}

		public BaseTool( Serial serial ) : base( serial )
		{
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( m_Quality == ToolQuality.Exceptional )
				list.Add( 1060636 ); // exceptional

			m_AosSkillBonuses.GetProperties( list );

			list.Add( 1061182, EquipLayerName( Layer ) );

			list.Add( 1060584, "{0}\t{1}", m_UsesRemaining.ToString(), "Uses" );
		}

		public virtual void DisplayDurabilityTo( Mobile m )
		{
			LabelToAffix( m, 1017323, AffixType.Append, ": " + m_UsesRemaining.ToString() ); // Durability
		}

		public static bool CheckAccessible( Item tool, Mobile m )
		{
			return ( tool.IsChildOf( m ) || tool.Parent == m );
		}

		public static bool CheckTool( Item tool, Mobile m )
		{
			Item check = m.FindItemOnLayer( Layer.OneHanded );

			if ( check is BaseTool && check != tool )
				return false;

			check = m.FindItemOnLayer( Layer.TwoHanded );

			if ( check is BaseTool && check != tool )
				return false;

			return true;
		}

		public override void OnSingleClick( Mobile from )
		{
			DisplayDurabilityTo( from );

			base.OnSingleClick( from );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !MySettings.S_AllowMacroResources )
			{ 
				CaptchaGump.sendCaptcha(from, BaseTool.OnDoubleClickRedirected, this);
			}
			else if ( Parent == from || ( MySettings.S_AllowBackpackCraftTool && this.IsChildOf(from.Backpack) ) )
			{
				CraftSystem system = this.CraftSystem;

				int num = system.CanCraft( from, this, null );

				if ( num > 0 && ( num != 1044267 || !Core.SE ) ) // Blacksmithing shows the gump regardless of proximity of an anvil and forge after SE
				{
					from.SendLocalizedMessage( num );
				}
				else
				{
					CraftContext context = system.GetContext( from );

					from.SendGump( new CraftGump( from, system, this, null ) );

					if ( this is TomeOfWands ){ from.SendSound( 0x55 ); }
				}
			}
			else
			{
				if (MySettings.S_AllowBackpackCraftTool) {
					from.SendLocalizedMessage( 1042004 ); // That must be equipped or in your pack to use it.
				} else {
					from.SendLocalizedMessage( 502641 ); // You must equip this item to use it.
				}
			}
		}

		public static void OnDoubleClickRedirected(Mobile from, object o)
		{
			if (o == null || (!(o is BaseTool)))
				return;

			BaseTool tool = (BaseTool)o;

			if ( tool.Parent == from || ( MySettings.S_AllowBackpackCraftTool && tool.IsChildOf(from.Backpack) ) )
			{
				CraftSystem system = tool.CraftSystem;

				int num = system.CanCraft(from, tool, null);

				if (num > 0 && (num != 1044267 || !Core.SE)) // Blacksmithing shows the gump regardless of proximity of an anvil and forge after SE
				{
					from.SendLocalizedMessage(num);
				}
				else
				{
					CraftContext context = system.GetContext(from);

					from.SendGump(new CraftGump(from, system, tool, null));
				}
			}
			else
			{
				int localizedMessageId = MySettings.S_AllowBackpackCraftTool
					? 1042004 // That must be equipped or in your pack to use it.
					: 502641; // You must equip this item to use it.
				
				from.SendLocalizedMessage( localizedMessageId ); 
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 3 ); // version
			writer.Write( (int) m_Quality );
			writer.Write( (int) m_UsesRemaining );
			m_AosSkillBonuses.Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 3:
				case 2:
				case 1:
				{
					if ( version < 2 )
						m_BuiltBy = reader.ReadMobile();

					m_Quality = (ToolQuality) reader.ReadInt();
					goto case 0;
				}
				case 0:
				{
					m_UsesRemaining = reader.ReadInt();
					break;
				}
			}

			if ( version < 3 )
				m_AosSkillBonuses = new AosSkillBonuses( this );
			else if ( version > 2 )
				m_AosSkillBonuses = new AosSkillBonuses( this, reader );

			if ( Parent is Mobile )
				m_AosSkillBonuses.AddTo( (Mobile)Parent );

			if ( CraftSystem.CraftSystemTxt != null )
				InfoText1 = CraftSystem.CraftSystemTxt;

			Layer = DefaultLayer;
		}
		#region ICraftable Members

		public int OnCraft( int quality, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue )
		{
			Quality = (ToolQuality)quality;

			Type resourceType = typeRes;

			if ( resourceType == null )
				resourceType = craftItem.Resources.GetAt( 0 ).ItemType;

			Resource = CraftResources.GetFromType( resourceType );

			return quality;
		}

		#endregion
	}
}