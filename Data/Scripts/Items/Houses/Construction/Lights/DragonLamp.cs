using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class DragonLamp : BaseLight
	{
		public override void ResourceChanged( CraftResource resource )
		{
			if ( !ResourceCanChange() )
				return;

			m_Resource = resource;
			Hue = CraftResources.GetHue(m_Resource);
			LampColor = CraftResources.GetName( m_Resource );
			InvalidateProperties();
		}

		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }

		public override int LitItemID{ get { return 0x488; } }
		public override int UnlitItemID{ get { return 0x11CD; } }

		public string LampName;

		[CommandProperty(AccessLevel.Owner)]
		public string Lamp_Name { get { return LampName; } set { LampName = value; InvalidateProperties(); } }

		public string LampColor;

		[CommandProperty(AccessLevel.Owner)]
		public string Lamp_Color { get { return LampColor; } set { LampColor = value; InvalidateProperties(); } }

		[Constructable]
		public DragonLamp() : base( 0x11CD )
		{
			Name = "dragon lamp";
			Duration = TimeSpan.Zero;
			BurntOut = false;
			Burning = false;
			Light = LightType.Circle225;
			Weight = 20.0;
			SetMaterial();
		}

		public void SetMaterial()
		{
			switch ( Utility.RandomMinMax( 0, 2 ) )
			{
				case 0: ResourceMods.SetRandomResource( false, false, this, CraftResource.Iron, true, null ); break;
				case 1: ResourceMods.SetRandomResource( false, false, this, CraftResource.RedScales, true, null ); break;
				case 2: ResourceMods.SetRandomResource( false, false, this, CraftResource.AmethystBlock, true, null ); break;
			}
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, LampColor);
            if ( LampName != null && LampName != "" )
				list.Add( 1049644, LampName);
        }

		public DragonLamp( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
            writer.Write( LampName );
            writer.Write( LampColor );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); 
			int version = reader.ReadInt();
			LampName = reader.ReadString();
			LampColor = reader.ReadString();
		}
	}
}