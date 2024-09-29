using System;
using Server;
using Server.Misc;
using Server.Mobiles;

namespace Server.Items
{
	public class TrinketCandle : BaseTrinket
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Trinket; } }

		[Constructable]
		public TrinketCandle() : base( 0xA28 ) 
		{
			Resource = CraftResource.None;
			Name = "candle";
			Hue = Utility.RandomColor(0);
			Light = LightType.Circle150;
			Weight = 1.0;
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
			this.ItemID = 0xA0F;
			this.GraphicID = 0xA0F;
			return base.OnEquip( from );
		}

		public override void OnRemoved( object parent )
		{
			if ( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.PlaySound( 0x4BB );
			}
			this.ItemID = 0xA28;
			this.GraphicID = 0xA28;
			base.OnRemoved( parent );
		}

		public TrinketCandle( Serial serial ) : base( serial )
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