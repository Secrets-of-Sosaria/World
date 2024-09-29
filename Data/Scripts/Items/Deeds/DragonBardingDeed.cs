using System;
using Server;
using Server.Mobiles;
using Server.Targeting;
using Server.Engines.Craft;

namespace Server.Items
{
	[TypeAlias( "Server.Items.DragonBarding" )]
	public class DragonBardingDeed : Item, ICraftable
	{
		public override void ResourceChanged( CraftResource resource )
		{
			if ( !ResourceCanChange() )
				return;

			m_Resource = resource;
			Hue = CraftResources.GetHue(m_Resource);
			InvalidateProperties();
		}

		private bool m_Exceptional;

		public override int LabelNumber{ get{ return 1053012; } } // dragon barding deed

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Exceptional{ get{ return m_Exceptional; } set{ m_Exceptional = value; InvalidateProperties(); } }

		public DragonBardingDeed() : base( 0x14F0 )
		{
			Weight = 1.0;
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( m_Exceptional && m_BuiltBy != null )
				list.Add( 1050043, m_BuiltBy.Name ); // crafted by ~1_NAME~
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				from.BeginTarget( 6, false, TargetFlags.None, new TargetCallback( OnTarget ) );
				from.SendLocalizedMessage( 1053024 ); // Select the swamp dragon you wish to place the barding on.
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}

		public virtual void OnTarget( Mobile from, object obj )
		{
			if ( Deleted )
				return;

			SwampDragon pet = obj as SwampDragon;

			if ( pet == null || pet.HasBarding )
			{
				from.SendLocalizedMessage( 1053025 ); // That is not an unarmored swamp dragon.
			}
			else if ( !pet.Controlled || pet.ControlMaster != from )
			{
				from.SendLocalizedMessage( 1053026 ); // You can only put barding on a tamed swamp dragon that you own.
			}
			else if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1060640 ); // The item must be in your backpack to use it.
			}
			else
			{
				pet.BardingExceptional = this.Exceptional;
				pet.BardingCrafter = this.BuiltBy;
				pet.BardingHP = pet.BardingMaxHP;
				pet.BardingResource = this.Resource;
				pet.HasBarding = true;
				pet.Hue = this.Hue;

				this.Delete();

				from.SendLocalizedMessage( 1053027 ); // You place the barding on your swamp dragon.  Use a bladed item on your dragon to remove the armor.
			}
		}

		public DragonBardingDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 3 ); // version

			writer.Write( (bool) m_Exceptional );
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
				case 0:
				{
					m_Exceptional = reader.ReadBool();

					if ( version < 3 )
						m_BuiltBy = reader.ReadMobile();

					if ( version < 1 )
						reader.ReadInt();

					if ( version < 2 )
						m_Resource = (CraftResource) reader.ReadInt();

					break;
				}
			}
		}
		#region ICraftable Members

		public int OnCraft( int quality, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue )
		{
			Exceptional = ( quality >= 2 );

			Type resourceType = typeRes;

			if ( resourceType == null )
				resourceType = craftItem.Resources.GetAt( 0 ).ItemType;

			Resource = CraftResources.GetFromType( resourceType );

			CraftContext context = craftSystem.GetContext( from );

			if ( context != null && context.DoNotColor )
				Hue = 0;

			return quality;
		}

		#endregion
	}
}