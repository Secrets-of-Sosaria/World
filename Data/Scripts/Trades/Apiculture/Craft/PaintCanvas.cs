using System;
using Server;

namespace Server.Items
{
	public class PaintCanvas : Item
	{
		public override string DefaultDescription{ get{ return "These can be handed to an artist, where the will create a painting of you to hang in your home. Painting portraits is not an easy endeavor, so make sure you bring plenty of gold for their services."; } }

		[Constructable]
		public PaintCanvas() : base( 0xA6C )
		{
			Name = "painting canvas";
			Hue = 0x47E;
		}

		public PaintCanvas( Serial serial ) : base( serial )
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