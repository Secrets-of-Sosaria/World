using System;
using Server; 
using System.Collections;
using Server.ContextMenus;
using System.Collections.Generic;
using Server.Misc;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using System.Globalization;
using Server.Regions;

namespace Server.Items
{
	[FlipableAttribute( 0x4C2D, 0x4C33 )]
	public class DragonPedStatue : Item
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		public override void ResourceChanged( CraftResource resource )
		{
			if ( !ResourceCanChange() )
				return;

			m_Resource = resource;
			Hue = CraftResources.GetHue(m_Resource);
			StatueColor = CraftResources.GetName( m_Resource );
			InvalidateProperties();
		}

		public string StatueName;

		[CommandProperty(AccessLevel.Owner)]
		public string Statue_Name { get { return StatueName; } set { StatueName = value; InvalidateProperties(); } }

		public string StatueColor;

		[CommandProperty(AccessLevel.Owner)]
		public string Statue_Color { get { return StatueColor; } set { StatueColor = value; InvalidateProperties(); } }

		[Constructable]
		public DragonPedStatue() : base( 0x4C2D )
		{
			Name = "dragon statue";
			Light = LightType.Circle225;
			Weight = 20.0;
			SetMaterial();
		}

		public void SetMaterial()
		{
			switch ( Utility.RandomMinMax( 0, 2 ) )
			{
				case 0: ResourceMods.SetRandomResource( false, false, this, CraftResource.Iron, false, null ); break;
				case 1: ResourceMods.SetRandomResource( false, false, this, CraftResource.RedScales, false, null ); break;
				case 2: ResourceMods.SetRandomResource( false, false, this, CraftResource.AmethystBlock, false, null ); break;
			}
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, StatueColor);
            if ( StatueName != null && StatueName != "" ){ list.Add( 1049644, StatueName); }
        }

		public DragonPedStatue( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
            writer.Write( StatueName );
            writer.Write( StatueColor );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            StatueName = reader.ReadString();
            StatueColor = reader.ReadString();
		}
	}
}