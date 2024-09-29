using System;
using Server;

namespace Server.Items
{
	public class Oyster : Item
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Gem; } }
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Oyster() : this( 1 )
		{
		}

		[Constructable]
		public Oyster( int amount ) : base( 0x3196 )
		{
			Name = "pearl";
			Stackable = true;
			Amount = amount;
			Light = LightType.Circle150;
		}

		public Oyster( Serial serial ) : base( serial )
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
			Light = LightType.Circle150;
		}
	}
}