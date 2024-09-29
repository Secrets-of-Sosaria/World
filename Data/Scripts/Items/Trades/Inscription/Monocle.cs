using System;
using Server;
using Server.Engines.Harvest;

namespace Server.Items
{
	public class Monocle : BaseHarvestTool
	{
		public override string DefaultDescription{ get{ return "These librarian sets are used by scribes, to closely look over books and book shelves that litter the dungeons. You may find some items of worth, like books or scrolls."; } }

		public override HarvestSystem HarvestSystem { get { return Librarian.System; } }

		public override Catalogs DefaultCatalog{ get{ return Catalogs.Tool; } }

		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		[Constructable]
		public Monocle() : base( 0x316F )
		{
			Name = "librarian set";
			Weight = 1.0;
		}

		[Constructable]
		public Monocle( int uses ) : base( 0x316F )
		{
			Name = "librarian set";
			Weight = 1.0;
		}

		public Monocle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			ItemID = 0x316F;
		}
	}
}