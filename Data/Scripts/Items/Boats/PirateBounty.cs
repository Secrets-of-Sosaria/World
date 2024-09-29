using System;
using Server;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class PirateBounty : Item
	{
		public int BountyValue;
		public string BountyWho;

		[CommandProperty(AccessLevel.Owner)]
		public int Bounty_Value { get { return BountyValue; } set { BountyValue = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public string Bounty_Who { get { return BountyWho; } set { BountyWho = value; InvalidateProperties(); } }

		[Constructable]
		public PirateBounty() : base( 0x0DEB )
		{
			Name = "Pirate Bounty";
			Weight = 1.0;
			ItemID = Utility.RandomList( 0x0DEB, 0x0DED );
			BountyWho = NameList.RandomName("male") + " the pirate";
			BountyValue = Utility.RandomMinMax( 1000, 3000 );
				BountyValue = (int)(BountyValue * (MyServerSettings.GetGoldCutRate() * .01));
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "For " + BountyWho + "");
        }
    
		public override void OnDoubleClick( Mobile from )
		{
			if ( from.InRange( this.GetWorldLocation(), 4 ) )
			{
				from.CloseGump( typeof( BountyGump ) );
				from.SendGump( new BountyGump( from, this ) );
			}
		}

		public class BountyGump : Gump
		{
			public BountyGump( Mobile from, PirateBounty bounty ): base( 50, 50 )
			{
				from.PlaySound( 0x249 );
				string color = "#89afe8";
				string value = "#d7ba6e";

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 7020, Server.Misc.PlayerSettings.GetGumpHue( from ));

				AddHtml( 13, 13, 466, 20, @"<BODY><BASEFONT Color=" + color + ">" + bounty.BountyWho + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(492, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);
				AddHtml( 14, 106, 246, 234, @"<BODY><BASEFONT Color=" + color + ">Bounties are often placed on famous pirates that sail the high seas and create havoc in their pursuit for booty. Giving this bounty contract to a town guard will reward you with the listed gold.</BASEFONT></BODY>", (bool)false, (bool)false);
				AddImage(269, 42, 10888);
				AddHtml( 18, 57, 65, 20, @"<BODY><BASEFONT Color=" + color + ">Bounty:</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 94, 56, 161, 20, @"<BODY><BASEFONT Color=" + value + ">" + bounty.BountyValue + " Gold</BASEFONT></BODY>", (bool)false, (bool)false);
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				Mobile from = state.Mobile; 
				from.PlaySound( 0x249 );
			}
		}

		public PirateBounty( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
            writer.Write( BountyValue );
            writer.Write( BountyWho );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            BountyValue = reader.ReadInt();
			BountyWho = reader.ReadString();
		}
	}
}