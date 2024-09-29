using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class LevelTalismanLeather : LevelGoldRing
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Trinket; } }

		[Constructable]
		public LevelTalismanLeather()
		{
			ItemID = 0x2F58;
			Resource = CraftResource.None;
			Name = "talisman";
			Layer = Layer.Trinket;
			Weight = 1.0;
			Hue = Utility.RandomColor(0);
		}

		public LevelTalismanLeather( Serial serial ) : base( serial )
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
	//////////////////////////////////////////////////////////////////////
	public class LevelTalismanSnake : LevelGoldRing
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Trinket; } }

		[Constructable]
		public LevelTalismanSnake()
		{
			ItemID = 0x2F59;
			Resource = CraftResource.None;
			Name = "talisman";
			Layer = Layer.Trinket;
			Weight = 1.0;
			Hue = Utility.RandomColor(0);
		}

		public LevelTalismanSnake( Serial serial ) : base( serial )
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
	//////////////////////////////////////////////////////////////////////
	public class LevelTalismanTotem : LevelGoldRing
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Trinket; } }

		[Constructable]
		public LevelTalismanTotem()
		{
			ItemID = 0x2F5A;
			Resource = CraftResource.None;
			Name = "talisman";
			Layer = Layer.Trinket;
			Weight = 1.0;
			Hue = Utility.RandomColor(0);
		}

		public LevelTalismanTotem( Serial serial ) : base( serial )
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
	//////////////////////////////////////////////////////////////////////
	public class LevelTalismanHoly : LevelGoldRing
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Trinket; } }

		[Constructable]
		public LevelTalismanHoly()
		{
			ItemID = 0x2F5B;
			Resource = CraftResource.None;
			Name = "talisman";
			Layer = Layer.Trinket;
			Weight = 1.0;
			Hue = Utility.RandomColor(0);
		}

		public LevelTalismanHoly( Serial serial ) : base( serial )
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