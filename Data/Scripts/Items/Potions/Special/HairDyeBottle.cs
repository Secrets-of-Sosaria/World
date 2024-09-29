using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
    public class HairDyeBottle : Item
	{
		public override string DefaultDescription{ get{ return "These mixtures need to be dyed a color, before using it on your hair. If you do not dye the contents, and instead leave it a neutral color, then your hair color will return to what it previously was."; } }

		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

        [Constructable]
        public HairDyeBottle() : base(0xE0F)
		{
            Name = "hair dye mixture";
			Hue = 0;
			Built = true;
        }

        public override void OnDoubleClick(Mobile from)
		{
			if ( from.RaceID > 0 )
			{
				from.SendMessage( "You don't find this really useful." );
				return;
			}
			else if ( !IsChildOf( from.Backpack ) ) 
			{
				from.SendMessage( "This must be in your backpack to use." );
				return;
			}
			else if ( this.Hue == 0 )
			{
				from.HairHue = from.RecordHairColor;
				from.FacialHairHue = from.RecordBeardColor;
				from.SendMessage("You use the neutral dye to color your hair back to normal.");
				from.PlaySound( 0x5A4 );
			}
			else
			{
				from.HairHue = this.Hue;
				from.FacialHairHue = this.Hue;
				from.SendMessage("You dye your hair a new color.");
				from.PlaySound( 0x5A4 );
			}
			this.Delete();
        }

        public HairDyeBottle( Serial serial ) : base( serial )
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
			Built = true;
	    }
    }
}