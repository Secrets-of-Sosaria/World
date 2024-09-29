using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	[Flipable(0x4FEA, 0x4FEB)]
    public class InnChest : Item
	{
        [Constructable]
        public InnChest() : base(0x4FEA)
		{
            Name = "inn chest";
        }

        public override void OnDoubleClick(Mobile from)
		{
			InnRoom inn = from.InnRoom;

			if ( from.InRange( this.GetWorldLocation(), 4 ) )
			{
				inn = from.InnRoom;

				PlayerMobile pm = (PlayerMobile)(from);
				bool canOpen = false;
				BankBox cont = pm.FindBankNoCreate();

				if ( inn != null && cont != null )
				{
					if ( pm.InnTime > DateTime.Now )
						canOpen = true;
					else if ( cont.ConsumeTotal( typeof( Gold ), InnKeeper.RoomCost( pm ) ) )
					{
						canOpen = true;
						pm.InnTime = DateTime.Now + TimeSpan.FromDays( 7.0 );
					}
					else
					{
						pm.SendMessage( "You will need " + InnKeeper.RoomCost( pm ) + " gold for an inn room." );
						pm.SendMessage( "Give the innkeeper " + InnKeeper.RoomCost( pm ) + " gold, or put that amount in the bank." );
					}

					if ( canOpen )
						inn.Open();
				}
			}
			else
				from.SendLocalizedMessage( 502138 ); // That is too far away for you to use
        }

        public InnChest( Serial serial ) : base( serial )
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