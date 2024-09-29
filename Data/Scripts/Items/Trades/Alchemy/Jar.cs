using System;

namespace Server.Items
{
	public class Jar : Item
	{
		public override string DefaultDescription{ get{ return "These jars are often used by druids and witches to store their brews."; } }

		[Constructable]
		public Jar() : this( 1 )
		{
		}

		[Constructable]
		public Jar( int amount ) : base( 0x10B4 )
		{
			Name = "jar";
			Stackable = true;
			Weight = 1.0;
			Amount = amount;
			Built = true;
		}

		public Jar( Serial serial ) : base( serial )
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
			ItemID = 0x10B4;
			Built = true;
		}
	}
}