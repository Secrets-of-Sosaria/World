using System;
using Server.Network;
using Server.Misc;
using Server.Regions;

namespace Server.Items
{
	public class MagicSextant : Sextant
	{
		public override string DefaultDescription{ get{ return "Sextants are used to gaze at the stars and determine your location. If you are carrying a sextant, and you examine items like a treasure map or a parchment with sextant coordinates on it, you may be able to open a world map to see the location. These maps will have a red pin for the location. If you are traveling in that world, you will see a blue pin to where you are. The one unique thing about these sextants, is that they are rumoured to work on oceans underground. That they can somehow see the stars through the cavern walls above."; } }

		[Constructable]
		public MagicSextant()
		{
			Name = "magic sextant";
			Weight = 4.0;
			ItemID = 0x26A0;
		}

		public MagicSextant( Serial serial ) : base( serial )
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