using System;
using Server;

namespace Server.Items
{
	public class PegasusFeather : Item
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Reagent; } }

		public override string DefaultDescription{ get{ return "These items are very rare, and are sometimes sought after with a given quest. They are sometimes required for rituals or potion ingredients as well."; } }

		[Constructable]
		public PegasusFeather() : this( 1 )
		{
		}

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public PegasusFeather( int amount ) : base( 0x4CCD )
		{
			Name = "pegasus feather";
			Stackable = true;
			Amount = amount;
			Hue = 0xB5C;
		}

		public PegasusFeather( Serial serial ) : base( serial )
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
		}
	}
}