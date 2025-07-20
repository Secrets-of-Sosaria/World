using System;
using Server.Network;
using Server.Engines.Craft;
using Server.ContextMenus;
using System.Collections;
using System.Collections.Generic;

namespace Server.Items
{
	public class BaseQuiver : Container, ICraftable
	{
		public override int DefaultGumpID{ get{ return 0x108; } }
		public override int DefaultMaxItems{ get{ return 1; } }
		public override int DefaultMaxWeight{ get{ return 50; } }
		public override double DefaultWeight{ get{ return 2.0; } }

		private AosAttributes m_Attributes;
		private int m_Capacity;
		private int m_LowerAmmoCost;
		private int m_WeightReduction;
		private int m_DamageIncrease;

		[CommandProperty( AccessLevel.GameMaster)]
		public AosAttributes Attributes
		{
			get{ return m_Attributes; }
			set{}
		}

		[CommandProperty( AccessLevel.GameMaster)]
		public int Capacity
		{
			get{ return m_Capacity; }
			set{ m_Capacity = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster)]
		public int LowerAmmoCost
		{
			get{ return m_LowerAmmoCost; }
			set{ m_LowerAmmoCost = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster)]
		public int WeightReduction
		{
			get{ return m_WeightReduction; }
			set{ m_WeightReduction = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster)]
		public int DamageIncrease
		{
			get{ return m_DamageIncrease; }
			set{ m_DamageIncrease = value; InvalidateProperties(); }
		}

		private ClothingQuality m_Quality;

		[CommandProperty( AccessLevel.GameMaster )]
		public ClothingQuality Quality
		{
			get{ return m_Quality; }
			set{ m_Quality = value; InvalidateProperties(); }
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			if ( from.Alive && IsChildOf( from ) )
				list.Add( new OrganizeQuiverEntry( this, from ) );
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			if ( dropped == null || dropped.Deleted )
				return false;

			Item current = Ammo;
			int capacity = Capacity;
			int currentAmount = (current != null && !current.Deleted) ? current.Amount : 0;

			if ( dropped is Arrow || dropped is Bolt )
			{
				if ( current != null && current.GetType() != dropped.GetType() )
				{
					from.SendMessage( "You cannot mix arrows and bolts in the same quiver." );
					return false;
				}

				int spaceLeft = capacity - currentAmount;

				if ( spaceLeft <= 0 )
				{
					from.SendMessage( "Your quiver is already full." );
					return false;
				}

				int toAdd = Math.Min( dropped.Amount, spaceLeft );

				Item partToAdd;

				if ( dropped is Arrow )
					partToAdd = new Arrow();
				else
					partToAdd = new Bolt();

				partToAdd.Amount = toAdd;

				if ( base.TryDropItem( from, partToAdd, false ) )
				{
					int leftover = dropped.Amount - toAdd;

					dropped.Delete();

					if ( leftover > 0 )
					{
						Item remainder;

						if ( dropped is Arrow )
							remainder = new Arrow();
						else
							remainder = new Bolt();

						remainder.Amount = leftover;
						from.Backpack.DropItem( remainder );
					}

					from.SendMessage( "You add {0} ammunition to your quiver. The rest remains in your pack.", toAdd );
					InvalidateWeight();
					return true;
				}
				else
				{
					partToAdd.Delete();
					from.SendMessage( "You could not add that to your quiver." );
					return false;
				}
			}

			from.SendLocalizedMessage( 1074836 ); // The container can not hold that type of object.
			return false;
		}



		
		public Item Ammo
		{
			get{ return Items.Count > 0 ? Items[ 0 ] : null; }
		}

		public BaseQuiver() : this( 0x2B02 )
		{
		}

		public BaseQuiver( int itemID ) : base( itemID )
		{
			Weight = 2.0;
			Capacity = 500;
			Layer = Layer.Cloak;
			GumpID = 0x3D;

			m_Attributes = new AosAttributes( this );

			DamageIncrease = 25;
			ItemID = Utility.RandomList( 0x2B02, 0x2B03, 0x5770, 0x5770 );
		}

		public BaseQuiver( Serial serial ) : base( serial )
		{
		}

		public override void OnAfterDuped( Item newItem )
		{
			BaseQuiver quiver = newItem as BaseQuiver;

			if ( quiver == null )
				return;

			quiver.m_Attributes = new AosAttributes( newItem, m_Attributes );
		}

		public virtual int GetLuckBonus()
		{
			CraftResourceInfo resInfo = CraftResources.GetInfo( m_Resource );

			if ( resInfo == null )
				return 0;

			CraftAttributeInfo attrInfo = resInfo.AttributeInfo;

			if ( attrInfo == null )
				return 0;

			return attrInfo.ArmorLuck;
		}

		public override void UpdateTotal( Item sender, TotalType type, int delta )
		{
			InvalidateProperties();

 			base.UpdateTotal(sender, type, delta);
		}

		public override int GetTotal( TotalType type )
		{
			int total = base.GetTotal( type );

			if ( type == TotalType.Weight )
				total -= total * m_WeightReduction / 100;

			return total;
		}

		private static Type[] m_Ammo = new Type[]
		{
			typeof( Arrow ), typeof( Bolt )
		};

		public bool CheckType( Item item )
		{
			Type type = item.GetType();
			Item ammo = Ammo;

			if ( ammo != null )
			{
				if ( ammo.GetType() == type )
					return true;
			}
			else
			{
				for ( int i = 0; i < m_Ammo.Length; i++ )
				{
					if ( type == m_Ammo[ i ] )
						return true;
				}
			}

			return false;
		}

		public override bool CheckHold( Mobile m, Item item, bool message, bool checkItems, int plusItems, int plusWeight )
		{
			if ( !CheckType( item ) )
			{
				if ( message )
					m.SendLocalizedMessage( 1074836 ); // The container can not hold that type of object.

				return false;
			}

			Item arrow = this.FindItemByType( typeof ( Arrow ) );
			Item bolt = this.FindItemByType( typeof ( Bolt ) );

			if ( arrow != null && item is Arrow )
			{
				if ( arrow.Amount + item.Amount <= m_Capacity )
					return true;
			}
			if ( bolt != null && item is Bolt )
			{
				if ( bolt.Amount + item.Amount <= m_Capacity )
					return true;
			}

			if ( Items.Count < DefaultMaxItems )
			{
				if ( item.Amount <= m_Capacity )
					return base.CheckHold( m, item, message, checkItems, plusItems, plusWeight );

				return false;
			}
			else if ( checkItems )
				return false;

			Item ammo = Ammo;

			if ( ammo == null || ammo.Deleted )
				return false;

			if ( ammo.Amount + item.Amount <= m_Capacity )
				return true;

			return false;
		}

		public override void AddItem( Item dropped )
		{
			base.AddItem( dropped );

			InvalidateWeight();
		}
		
		public override void RemoveItem( Item dropped )
		{
			base.RemoveItem( dropped );

			InvalidateWeight();
		}
		
		public override void OnAdded( object parent )
		{
			if ( parent is Mobile )
			{
				Mobile mob = (Mobile) parent;

				m_Attributes.AddStatBonuses( mob );
			}
			base.OnAdded( parent );
		}
		
		public override void OnRemoved( object parent )
		{
			if ( parent is Mobile )
			{
				Mobile mob = (Mobile) parent;

				m_Attributes.RemoveStatBonuses( mob );
			}
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
				
			if ( m_BuiltBy != null )
				list.Add( 1050043, m_BuiltBy.Name ); // crafted by ~1_NAME~

			if ( m_Quality == ClothingQuality.Exceptional )
				list.Add( 1063341 ); // exceptional

			Item ammo = Ammo;

			if ( ammo != null )
			{
				if ( ammo is Arrow )
					list.Add( 1075265, "{0}\t{1}", ammo.Amount, Capacity ); // Ammo: ~1_QUANTITY~/~2_CAPACITY~ arrows
				else if ( ammo is Bolt )
					list.Add( 1075266, "{0}\t{1}", ammo.Amount, Capacity ); // Ammo: ~1_QUANTITY~/~2_CAPACITY~ bolts
			}
			else
				list.Add( 1075265, "{0}\t{1}", 0, Capacity ); // Ammo: ~1_QUANTITY~/~2_CAPACITY~ arrows

			int prop;

			if ( (prop = (m_Attributes.WeaponDamage+m_DamageIncrease)) != 0 )
				list.Add( 1074762, prop.ToString() ); // Damage modifier: ~1_PERCENT~%
			
			int phys, fire, cold, pois, nrgy, chaos, direct;
			phys = fire = cold = pois = nrgy = chaos = direct = 0;

			AlterBowDamage( ref phys, ref fire, ref cold, ref pois, ref nrgy, ref chaos, ref direct );

			if ( phys != 0 )
				list.Add( 1060403, phys.ToString() ); // physical damage ~1_val~%

			if ( fire != 0 )
				list.Add( 1060405, fire.ToString() ); // fire damage ~1_val~%

			if ( cold != 0 )
				list.Add( 1060404, cold.ToString() ); // cold damage ~1_val~%

			if ( pois != 0 )
				list.Add( 1060406, pois.ToString() ); // poison damage ~1_val~%

			if ( nrgy != 0 )
				list.Add( 1060407, nrgy.ToString() ); // energy damage ~1_val

			if ( chaos != 0 )
				list.Add( 1072846, chaos.ToString() ); // chaos damage ~1_val~%

			if ( direct != 0 )
				list.Add( 1079978, direct.ToString() ); // Direct Damage: ~1_PERCENT~%

			if ( (prop = m_Attributes.DefendChance) != 0 )
				list.Add( 1060408, prop.ToString() ); // defense chance increase ~1_val~%

			if ( (prop = m_Attributes.BonusDex) != 0 )
				list.Add( 1060409, prop.ToString() ); // dexterity bonus ~1_val~

			if ( (prop = m_Attributes.EnhancePotions) != 0 )
				list.Add( 1060411, prop.ToString() ); // enhance potions ~1_val~%

			if ( (prop = m_Attributes.CastRecovery) != 0 )
				list.Add( 1060412, prop.ToString() ); // faster cast recovery ~1_val~

			if ( (prop = m_Attributes.CastSpeed) != 0 )
				list.Add( 1060413, prop.ToString() ); // faster casting ~1_val~

			if ( (prop = m_Attributes.AttackChance) != 0 )
				list.Add( 1060415, prop.ToString() ); // hit chance increase ~1_val~%

			if ( (prop = m_Attributes.BonusHits) != 0 )
				list.Add( 1060431, prop.ToString() ); // hit point increase ~1_val~

			if ( (prop = m_Attributes.BonusInt) != 0 )
				list.Add( 1060432, prop.ToString() ); // intelligence bonus ~1_val~

			if ( (prop = m_Attributes.LowerManaCost) != 0 && MyServerSettings.LowerMana() > 0 )
			{
				if ( prop > MyServerSettings.LowerMana() ){ prop = MyServerSettings.LowerMana(); }
				list.Add( 1060433, prop.ToString() ); // lower mana cost ~1_val~%
			}

			if ( (prop = m_Attributes.LowerRegCost) != 0 && MyServerSettings.LowerReg() > 0 )
			{
				if ( prop > MyServerSettings.LowerReg() ){ prop = MyServerSettings.LowerReg(); }
				list.Add( 1060434, prop.ToString() ); // lower reagent cost ~1_val~%
			}

			if ( (prop = (GetLuckBonus() + m_Attributes.Luck)) != 0 )
				list.Add( 1060436, prop.ToString() ); // luck ~1_val~

			if ( (prop = m_Attributes.BonusMana) != 0 )
				list.Add( 1060439, prop.ToString() ); // mana increase ~1_val~

			if ( (prop = m_Attributes.RegenMana) != 0 )
				list.Add( 1060440, prop.ToString() ); // mana regeneration ~1_val~

			if ( (prop = m_Attributes.NightSight) != 0 )
				list.Add( 1060441 ); // night sight

			if ( (prop = m_Attributes.ReflectPhysical) != 0 )
				list.Add( 1060442, prop.ToString() ); // reflect physical damage ~1_val~%

			if ( (prop = m_Attributes.RegenStam) != 0 )
				list.Add( 1060443, prop.ToString() ); // stamina regeneration ~1_val~

			if ( (prop = m_Attributes.RegenHits) != 0 )
				list.Add( 1060444, prop.ToString() ); // hit point regeneration ~1_val~

			if ( (prop = m_Attributes.SpellDamage) != 0 )
				list.Add( 1060483, prop.ToString() ); // spell damage increase ~1_val~%

			if ( (prop = m_Attributes.BonusStam) != 0 )
				list.Add( 1060484, prop.ToString() ); // stamina increase ~1_val~

			if ( (prop = m_Attributes.BonusStr) != 0 )
				list.Add( 1060485, prop.ToString() ); // strength bonus ~1_val~

			if ( (prop = m_Attributes.WeaponSpeed) != 0 )
				list.Add( 1060486, prop.ToString() ); // swing speed increase ~1_val~%

			list.Add( 1061182, EquipLayerName( Layer ) );

			if ( (prop = m_LowerAmmoCost) > 0 )
				list.Add( 1075208, prop.ToString() ); // Lower Ammo Cost ~1_Percentage~%

			double weight = 0;

			if ( ammo != null )
				weight = ammo.Weight * ammo.Amount;

			list.Add( 1072241, "{0}\t{1}\t{2}\t{3}", Items.Count, DefaultMaxItems, (int) weight, DefaultMaxWeight ); // Contents: ~1_COUNT~/~2_MAXCOUNT items, ~3_WEIGHT~/~4_MAXWEIGHT~ stones

			if ( (prop = m_WeightReduction) != 0 )
				list.Add( 1072210, prop.ToString() ); // Weight reduction: ~1_PERCENTAGE~%	
		}
		
		private static void SetSaveFlag( ref SaveFlag flags, SaveFlag toSet, bool setIf )
		{
			if ( setIf )
				flags |= toSet;
		}

		private static bool GetSaveFlag( SaveFlag flags, SaveFlag toGet )
		{
			return ( (flags & toGet) != 0 );
		}

		[Flags]
		private enum SaveFlag
		{
			None				= 0x00000000,
			Attributes			= 0x00000001,
			DamageModifier		= 0x00000002,
			LowerAmmoCost		= 0x00000004,
			WeightReduction		= 0x00000008,
			Crafter				= 0x00000010,
			Quality				= 0x00000020,
			Capacity			= 0x00000040,
			DamageIncrease		= 0x00000080
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( 1 ); // version

			SaveFlag flags = SaveFlag.None;

			SetSaveFlag( ref flags, SaveFlag.Attributes,		!m_Attributes.IsEmpty );
			SetSaveFlag( ref flags, SaveFlag.LowerAmmoCost,		m_LowerAmmoCost != 0 );
			SetSaveFlag( ref flags, SaveFlag.WeightReduction,	m_WeightReduction != 0 );
			SetSaveFlag( ref flags, SaveFlag.DamageIncrease,	m_DamageIncrease != 0 );
			SetSaveFlag( ref flags, SaveFlag.Crafter,			m_BuiltBy != null );
			SetSaveFlag( ref flags, SaveFlag.Quality,			true );
			SetSaveFlag( ref flags, SaveFlag.Capacity,			m_Capacity > 0 );

			writer.WriteEncodedInt( (int) flags );

			if ( GetSaveFlag( flags, SaveFlag.Attributes ) )
				m_Attributes.Serialize( writer );

			if ( GetSaveFlag( flags, SaveFlag.LowerAmmoCost ) )
				writer.Write( (int) m_LowerAmmoCost );

			if ( GetSaveFlag( flags, SaveFlag.WeightReduction ) )
				writer.Write( (int) m_WeightReduction );

			if ( GetSaveFlag( flags, SaveFlag.DamageIncrease ) )
				writer.Write( (int) m_DamageIncrease );

			if ( GetSaveFlag( flags, SaveFlag.Crafter ) )
				writer.Write( (Mobile) m_BuiltBy );

			if ( GetSaveFlag( flags, SaveFlag.Quality ) )
				writer.Write( (int) m_Quality );

			if ( GetSaveFlag( flags, SaveFlag.Capacity ) )
				writer.Write( (int) m_Capacity );
		}

		public override void Deserialize( GenericReader reader )
		{
			Mobile nil = null;

			base.Deserialize( reader );

			int version = reader.ReadInt();

			SaveFlag flags = (SaveFlag) reader.ReadEncodedInt();

			if ( GetSaveFlag( flags, SaveFlag.Attributes ) )
				m_Attributes = new AosAttributes( this, reader );
			else
				m_Attributes = new AosAttributes( this );

			if ( GetSaveFlag( flags, SaveFlag.LowerAmmoCost ) )
				m_LowerAmmoCost = reader.ReadInt();

			if ( GetSaveFlag( flags, SaveFlag.WeightReduction ) )
				m_WeightReduction = reader.ReadInt();

			if ( GetSaveFlag( flags, SaveFlag.DamageIncrease ) )
				m_DamageIncrease = reader.ReadInt();

			if ( GetSaveFlag( flags, SaveFlag.Crafter ) && version < 1 )
				m_BuiltBy = reader.ReadMobile();
			else if ( GetSaveFlag( flags, SaveFlag.Crafter ) )
				nil = reader.ReadMobile();

			if ( GetSaveFlag( flags, SaveFlag.Quality ) )
				m_Quality = (ClothingQuality) reader.ReadInt();

			if ( GetSaveFlag( flags, SaveFlag.Capacity ) )
				m_Capacity = reader.ReadInt();

			if ( ItemID != 0x2B02 && ItemID != 0x2B03 && ItemID != 0x5770 ){ ItemID = 0x2B02; }
			Layer = Layer.Cloak;
			GumpID = 0x3D;
		}

		public virtual void AlterBowDamage( ref int phys, ref int fire, ref int cold, ref int pois, ref int nrgy, ref int chaos, ref int direct )
		{
		}

		public void InvalidateWeight()
		{
			if ( RootParent is Mobile )
			{
				Mobile m = (Mobile) RootParent;

				m.UpdateTotals();
			}
		}
		
		#region ICraftable
		public virtual int OnCraft( int quality, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue )
		{
			Quality = (ClothingQuality) quality;

			return quality;
		}
		#endregion
	}

	public class OrganizeQuiverEntry : ContextMenuEntry
	{
		private BaseQuiver m_Quiver;
		private Mobile m_From;

		public OrganizeQuiverEntry( BaseQuiver quiver, Mobile from ) : base( 0097, 1 ) 
		{
			m_Quiver = quiver;
			m_From = from;
		}

		public override void OnClick()
		{
			if ( m_Quiver == null || m_Quiver.Deleted || m_From == null || !m_From.Alive )
				return;

			if ( m_From.Backpack == null )
				return;

			Item currentAmmo = m_Quiver.Ammo;
			int capacity = m_Quiver.Capacity;
			int currentAmount = (currentAmmo != null && !currentAmmo.Deleted) ? currentAmmo.Amount : 0;
			int spaceLeft = capacity - currentAmount;

			if ( spaceLeft <= 0 )
			{
				m_From.SendMessage("Your quiver is already full.");
				return;
			}

			bool acceptArrows = (currentAmmo == null || currentAmmo is Arrow);
			bool acceptBolts = (currentAmmo == null || currentAmmo is Bolt);

			int added = 0;

			List<Item> foundAmmo = new List<Item>();
			GetAllAmmoInBackpack( m_From.Backpack, foundAmmo, acceptArrows, acceptBolts );

			for ( int i = 0; i < foundAmmo.Count && spaceLeft > 0; i++ )
			{
				Item item = foundAmmo[i];

				if ( item == null || item.Deleted )
					continue;

				int moveAmount = Math.Min( item.Amount, spaceLeft );

				Item toAdd;

				if ( item is Arrow )
					toAdd = new Arrow();
				else
					toAdd = new Bolt();

				toAdd.Amount = moveAmount;

				if ( m_Quiver.TryDropItem( m_From, toAdd, false ) )
				{
					spaceLeft -= moveAmount;
					added += moveAmount;
					item.Amount -= moveAmount;

					if ( item.Amount <= 0 )
						item.Delete();
				}
				else
				{
					toAdd.Delete(); 
				}
			}

			if ( added > 0 )
				m_From.SendMessage("You add {0} ammunition into your quiver.", added);
			else
				m_From.SendMessage("You have no suitable ammunition to organize.");
		}

		private void GetAllAmmoInBackpack( Container container, List<Item> list, bool acceptArrows, bool acceptBolts )
		{
			if ( container == null )
				return;

			foreach ( Item item in container.Items )
			{
				if ( item == null || item.Deleted )
					continue;

				if ( item is Container )
				{
					GetAllAmmoInBackpack( (Container)item, list, acceptArrows, acceptBolts );
				}
				else if ( (acceptArrows && item is Arrow) || (acceptBolts && item is Bolt) )
				{
					list.Add( item );
				}
			}
		}
	}
}
