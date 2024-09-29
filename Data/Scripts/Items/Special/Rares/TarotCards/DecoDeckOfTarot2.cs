using System;
using Server;
using Server.Network;
using Server.Gumps;

namespace Server.Items
{
	public class DecoDeckOfTarot2 : Item
	{
		[Constructable]
		public DecoDeckOfTarot2() : base( 0x12Ac )
		{
			Movable = true;
			Stackable = false;
			Name = "tarot cards";
		}

        public override void OnDoubleClick(Mobile from)
        {
            if (!from.InRange(this.GetWorldLocation(), 4))
                from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.

            else
			{
				Server.Gumps.TarotCardsGump.SendGump( from, this );
			}
        }

		public DecoDeckOfTarot2( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
