using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
    public class HairDyePotion : BasePotion
	{
		public override string DefaultDescription{ get{ return "These mixtures need to be dyed a color, before using it on your hair. If you do not dye the contents, and instead leave it a neutral color, then your hair color will return to what it previously was."; } }

        [Constructable]
        public HairDyePotion() : base( 0x180F, PotionEffect.HairDye )
		{
            Name = "hair dye potion";
			Hue = 0;
        }

		public void ConsumeCharge( HairDyePotion potion, Mobile from )
		{
			potion.Consume();
			from.RevealingAction();
			BasePotion.PlayDrinkEffect( from );
			from.PlaySound( Utility.RandomList( 0x30, 0x2D6 ) );
		}

        public override void Drink( Mobile from )
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
				from.SendMessage("Your hair changes color.");
				ConsumeCharge( this, from );
			}
			else
			{
				from.HairHue = this.Hue;
				from.FacialHairHue = this.Hue;
				from.SendMessage("Your hair changes color.");
				ConsumeCharge( this, from );
			}
        }

        public HairDyePotion( Serial serial ) : base( serial )
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