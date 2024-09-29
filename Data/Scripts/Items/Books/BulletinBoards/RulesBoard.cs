using System;
using Server;
using Server.Misc;
using Server.Network;
using System.Text;
using System.IO;
using System.Threading;
using Server.Gumps;

namespace Server.Items
{
	[Flipable(0x577B, 0x577C)]
	public class RulesBoard : Item
	{
		[Constructable]
		public RulesBoard( ) : base( 0x577B )
		{
			Weight = 1.0;
			Name = "Laws of the Land";
			Hue = 0xB01;
		}

		public override void OnDoubleClick( Mobile e )
		{
			if ( e.InRange( this.GetWorldLocation(), 4 ) )
			{
				string rules = null;
				string path = "Info/Rules.txt";

				if ( File.Exists( path ))
				{
					StreamReader r = new StreamReader( path, System.Text.Encoding.Default, false );
					rules = r.ReadToEnd();
					r.Close();
					rules = rules.ToString();
				}
				e.CloseGump( typeof( BoardGump ) );
				e.SendGump( new BoardGump( e, "LAWS OF THE LAND", "" + rules + "", "#e97f76", false ) );
			}
			else
			{
				e.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public RulesBoard(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}