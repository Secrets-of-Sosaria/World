using System;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Network;
using Server.Engines.Craft;
using Server.Engines.Harvest;
using Server.ContextMenus;

namespace Server.Items
{
	public interface IUsesRemaining
	{
		int UsesRemaining{ get; set; }
		bool ShowUsesRemaining{ get; set; }
	}

	public abstract class BaseHarvestTool : Item, IUsesRemaining, ICraftable
	{
		public override string DefaultDescription{ get{ return "These tools are used for harvesting resources, that are used in various crafting trades. They must be equipped to be used and have a limited amount of uses before they break."; } }

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
			BaseHarvestTool tool = newItem as BaseHarvestTool;

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

		public abstract HarvestSystem HarvestSystem{ get; }

		public BaseHarvestTool( int itemID ) : this( 50, itemID )
		{
		}

		public BaseHarvestTool( int usesRemaining, int itemID ) : base( itemID )
		{
			m_UsesRemaining = usesRemaining;
			m_Quality = ToolQuality.Regular;
			m_AosSkillBonuses = new AosSkillBonuses( this );

			if ( HarvestSystem.HarvestSystemTxt( HarvestSystem, this ) != null )
				InfoText1 = HarvestSystem.HarvestSystemTxt( HarvestSystem, this );

			Layer = DefaultLayer;
		}

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

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( m_Quality == ToolQuality.Exceptional )
				list.Add( 1060636 ); // exceptional

			m_AosSkillBonuses.GetProperties( list );

			list.Add( 1061182, EquipLayerName( Layer ) );

			list.Add( 1060584, "{0}\t{1}", m_UsesRemaining.ToString(), "Uses" );
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

		public virtual void DisplayDurabilityTo( Mobile m )
		{
			LabelToAffix( m, 1017323, AffixType.Append, ": " + m_UsesRemaining.ToString() ); // Durability
		}

		public override void OnSingleClick( Mobile from )
		{
			DisplayDurabilityTo( from );

			base.OnSingleClick( from );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Parent == from || ( MySettings.S_AllowBackpackHarvestTool && this.IsChildOf(from.Backpack) ) ) 
			{
				HarvestSystem.BeginHarvesting( from, this );
			} 
			else 
			{	
				int localizedMessageId = MySettings.S_AllowBackpackHarvestTool 
					? 1042004 // That must be equipped or in your pack to use it.
					: 502641; // You must equip this item to use it.
				
				from.SendLocalizedMessage( localizedMessageId ); 
			}
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			AddContextMenuEntries( from, this, list, HarvestSystem );
		}

		public static void AddContextMenuEntries( Mobile from, Item item, List<ContextMenuEntry> list, HarvestSystem system )
		{
			if ( system != Mining.System )
				return;

			if ( !item.IsChildOf( from.Backpack ) && item.Parent != from )
				return;

			PlayerMobile pm = from as PlayerMobile;

			if ( pm == null )
				return;

			ContextMenuEntry miningEntry = new ContextMenuEntry( pm.ToggleMiningStone ? 6179 : 6178 );
			miningEntry.Color = 0x421F;
			list.Add( miningEntry );

			list.Add( new ToggleMiningStoneEntry( pm, false, 6176 ) );
			list.Add( new ToggleMiningStoneEntry( pm, true, 6177 ) );
		}

		private class ToggleMiningStoneEntry : ContextMenuEntry
		{
			private PlayerMobile m_Mobile;
			private bool m_Value;

			public ToggleMiningStoneEntry( PlayerMobile mobile, bool value, int number ) : base( number )
			{
				m_Mobile = mobile;
				m_Value = value;

				bool stoneMining = ( mobile.StoneMining && mobile.Skills[SkillName.Mining].Base >= 100.0 );

				if ( mobile.ToggleMiningStone == value || ( value && !stoneMining ) )
					this.Flags |= CMEFlags.Disabled;
			}

			public override void OnClick()
			{
				bool oldValue = m_Mobile.ToggleMiningStone;

				if ( m_Value )
				{
					if ( oldValue )
					{
						m_Mobile.SendLocalizedMessage( 1054023 ); // You are already set to mine both ore and stone!
					}
					else if ( !m_Mobile.StoneMining || m_Mobile.Skills[SkillName.Mining].Base < 100.0 )
					{
						m_Mobile.SendLocalizedMessage( 1054024 ); // You have not learned how to mine stone or you do not have enough skill!
					}
					else
					{
						m_Mobile.ToggleMiningStone = true;
						m_Mobile.SendLocalizedMessage( 1054022 ); // You are now set to mine both ore and stone.
					}
				}
				else
				{
					if ( oldValue )
					{
						m_Mobile.ToggleMiningStone = false;
						m_Mobile.SendLocalizedMessage( 1054020 ); // You are now set to mine only ore.
					}
					else
					{
						m_Mobile.SendLocalizedMessage( 1054021 ); // You are already set to mine only ore!
					}
				}
			}
		}

		public BaseHarvestTool( Serial serial ) : base( serial )
		{
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

			if ( HarvestSystem.HarvestSystemTxt( HarvestSystem, this ) != null )
				InfoText1 = HarvestSystem.HarvestSystemTxt( HarvestSystem, this );

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