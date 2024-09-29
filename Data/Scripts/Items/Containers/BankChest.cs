using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	[Flipable(0x436, 0x437)]
    public class BankChest : Item
	{
        [Constructable]
        public BankChest() : base(0x436)
		{
            Name = "Bank Vault";
        }

        public override void OnDoubleClick(Mobile from)
		{
			if ( from.InRange( this.GetWorldLocation(), 4 ) )
			{
				BankBox box = from.BankBox;
				if (box != null)
				{
					box.Open();
				}
			}
			else
			{
				from.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
        }

        public BankChest( Serial serial ) : base( serial )
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