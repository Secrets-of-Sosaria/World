using System;
using Server;
using Server.Misc;
using Server.Mobiles;

namespace Server.Items
{
	public class TrinketLantern : BaseTrinket
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Trinket; } }

		[Constructable]
		public TrinketLantern() : base( 0xA18 ) 
		{
			Resource = CraftResource.None;
			Name = "lantern";
			Hue = Utility.RandomColor(0);
			Light = LightType.Circle300;
			Weight = 2.0;
			Layer = Layer.TwoHanded;
            Attributes.NightSight = 1;
		}

		public override bool AllowEquipedCast( Mobile from )
		{
			return true;
		}

		public override bool OnEquip( Mobile from )
		{
			from.PlaySound( 0x47 );
			this.ItemID = 0xA15;
			this.GraphicID = 0xA15;
			return base.OnEquip( from );
		}

		public override void OnRemoved( object parent )
		{
			if ( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.PlaySound( 0x4BB );
			}
			this.ItemID = 0xA18;
			this.GraphicID = 0xA18;
			base.OnRemoved( parent );
		}

		public TrinketLantern( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}