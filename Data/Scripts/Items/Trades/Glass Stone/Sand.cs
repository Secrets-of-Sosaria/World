using System;
using Server.Items;

namespace Server.Items
{
	public class Sand : Item
	{
		public override string DefaultDescription{ get{ return "This fine sand can be used by alchemists, to make items like bottles and flasks. You would use a glass blowing pipe with this."; } }

		public override int LabelNumber{ get{ return 1044626; } } // sand

		[Constructable]
		public Sand() : this( 1 )
		{
		}

		[Constructable]
		public Sand( int amount ) : base( 0xB2B )
		{
			Stackable = Core.ML;
			Weight = 1.0;
			Built = true;
		}

		public Sand( Serial serial ) : base( serial )
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

			if ( version == 0 && this.Name == "sand" )
				this.Name = null;

			Built = true;
		}
	}
}