using System;
using Server.Items;

namespace Server.Items
{
	public class LevelShinobiRobe : LevelLeatherRobe
	{
		[Constructable]
		public LevelShinobiRobe()
		{
			ItemID = 0x5C10;
			Name = "leather shinobi robe";
			Weight = 6.0;
			Layer = Layer.OuterTorso;
			ResourceMods.DefaultItemHue( this );
		}

		public LevelShinobiRobe( Serial serial ) : base( serial )
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

	public class LevelShinobiHood : LevelLeatherCap
	{
		[Constructable]
		public LevelShinobiHood()
		{
			ItemID = 0x5C11;
			Weight = 2.0;
			Name = "leather shinobi hood";
			Layer = Layer.Helm;
			ResourceMods.DefaultItemHue( this );
		}

		public LevelShinobiHood( Serial serial ) : base( serial )
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

	public class LevelShinobiMask : LevelLeatherCap
	{
		[Constructable]
		public LevelShinobiMask()
		{
			ItemID = 0x5C12;
			Weight = 2.0;
			Name = "leather shinobi mask";
			Layer = Layer.Helm;
			ResourceMods.DefaultItemHue( this );
		}

		public LevelShinobiMask( Serial serial ) : base( serial )
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

	public class LevelShinobiCowl : LevelLeatherCap
	{
		[Constructable]
		public LevelShinobiCowl()
		{
			ItemID = 0x5C13;
			Weight = 2.0;
			Name = "leather shinobi cowl";
			Layer = Layer.Helm;
			ResourceMods.DefaultItemHue( this );
		}

		public LevelShinobiCowl( Serial serial ) : base( serial )
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