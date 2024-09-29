using System;
using Server;
using Server.Misc;
using Server.Mobiles;

namespace Server.Items
{
	public class MagicQuiver : BaseQuiver
	{
		[Constructable]
		public MagicQuiver()
		{
			Name = "quiver";
			ColorText1 = RandomThings.MagicItemAdj( "start", false, false, ItemID ) + " " + Name;
			ColorHue1 = "5DAFE1";
			Hue = Utility.RandomColor(0);
		}

		public MagicQuiver( Serial serial ) : base( serial )
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