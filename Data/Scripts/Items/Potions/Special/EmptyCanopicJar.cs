using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
    public class EmptyCanopicJar : Item
	{
		public override string DefaultDescription{ get{ return "These ancient jars once held the body parts of long dead pharaohs."; } }

        [Constructable]
        public EmptyCanopicJar() : base(0x2FEE)
		{
			ItemID = Utility.RandomList( 0x2FEE, 0x2FEF, 0x2FF0, 0x2FF1 );
			Weight = 5.0;
			CoinPrice = Utility.RandomMinMax( 80, 500 );
			Name = "canopic jar";

			string who = NameList.RandomName( "drakkul" );
			string title = "Pharaoh";
			string era = "First";

			switch ( Utility.RandomMinMax( 0, 4 ) )
			{
				case 0: title = "Pharaoh"; break;
				case 1: title = "King"; break;
				case 2: title = "Queen"; break;
				case 3: title = "Priest"; break;
				case 4: title = "Priestess"; break;
			}

			switch ( Utility.RandomMinMax( 0, 12 ) )
			{
				case 0: era = "first"; break;
				case 1: era = "second"; break;
				case 2: era = "third"; break;
				case 3: era = "fourth"; break;
				case 4: era = "fifth"; break;
				case 5: era = "sixth"; break;
				case 6: era = "seventh"; break;
				case 7: era = "eighth"; break;
				case 8: era = "ninth"; break;
				case 9: era = "tenth"; break;
				case 10: era = "eleventh"; break;
				case 11: era = "twelfth"; break;
				case 12: era = "thirteenth"; break;
			}

			ColorText1 = "Canopic Jar from the " + era + " Dynasty";
			ColorHue1 = "0080FF";
			ColorText2 = "belonged to " + who + " the " + title;
			ColorHue2 = "4AADFE";
			ColorText3 = "Worth " + CoinPrice + " Gold";
			ColorHue3 = "FDC844";
        }

        public EmptyCanopicJar( Serial serial ) : base( serial )
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

			if ( version < 1 )
			{
				ColorText2 = reader.ReadString();
				CoinPrice = reader.ReadInt();
				ColorText1 = Name;
				ColorText3 = "Worth " + CoinPrice + " Gold";
				ColorHue1 = "0080FF";
				ColorHue2 = "4AADFE";
				ColorHue3 = "FDC844";
				Name = "canopic jar";
			}
	    }
    }
}