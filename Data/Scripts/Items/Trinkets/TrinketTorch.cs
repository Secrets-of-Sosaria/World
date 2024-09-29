using System;
using Server;
using Server.Misc;
using Server.Mobiles;

namespace Server.Items
{
	public class TrinketTorch : BaseTrinket
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Trinket; } }

		[Constructable]
		public TrinketTorch() : base( 0xF6B ) 
		{
			Resource = CraftResource.None;
			Name = "torch";
			Hue = Utility.RandomColor(0);
			Light = LightType.Circle300;
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
			from.PlaySound( 0x54 );
			this.ItemID = 0xA12;
			this.GraphicID = 0xA12;
			return base.OnEquip( from );
		}

		public override void OnRemoved( object parent )
		{
			if ( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.PlaySound( 0x4BB );
			}
			this.ItemID = 0xF6B;
			this.GraphicID = 0xF6B;
			base.OnRemoved( parent );
		}

		public TrinketTorch( Serial serial ) : base( serial )
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