using System;
using Server.Items;

namespace Server.Items
{
	public class GiftShinobiRobe : GiftLeatherRobe
	{
		[Constructable]
		public GiftShinobiRobe()
		{
			ItemID = 0x5C10;
			Name = "leather shinobi robe";
			Weight = 6.0;
			Layer = Layer.OuterTorso;
			ResourceMods.DefaultItemHue( this );
		}

		public GiftShinobiRobe( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class GiftShinobiHood : GiftLeatherCap
	{
		[Constructable]
		public GiftShinobiHood()
		{
			ItemID = 0x5C11;
			Weight = 2.0;
			Name = "leather shinobi hood";
			Layer = Layer.Helm;
			ResourceMods.DefaultItemHue( this );
		}

		public GiftShinobiHood( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class GiftShinobiMask : GiftLeatherCap
	{
		[Constructable]
		public GiftShinobiMask()
		{
			ItemID = 0x5C12;
			Weight = 2.0;
			Name = "leather shinobi mask";
			Layer = Layer.Helm;
			ResourceMods.DefaultItemHue( this );
		}

		public GiftShinobiMask( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class GiftShinobiCowl : GiftLeatherCap
	{
		[Constructable]
		public GiftShinobiCowl()
		{
			ItemID = 0x5C13;
			Weight = 2.0;
			Name = "leather shinobi cowl";
			Layer = Layer.Helm;
			ResourceMods.DefaultItemHue( this );
		}

		public GiftShinobiCowl( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}