using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
    public class NecroSkinPotion : Item
	{
		public override string DefaultDescription{ get{ return "Dumping this dust on yourself, will make your skin and hair ghostly white. Only a grandmaster necromancer is able to use this. If you already are ghostly white, and you use this dust again, you will have your skin and hair return to what it was."; } }

		public override Catalogs DefaultCatalog{ get{ return Catalogs.Potion; } }

        [Constructable]
        public NecroSkinPotion() : base(0x1006)
		{
            Name = "jar of skull dust";
			Built = true;
        }

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Will Turn A Grandmaster Necromancer's Skin & Hair Ghostly White");
			list.Add( 1049644, "Double Click To Eat The Dust");
        } 

        public override void OnDoubleClick(Mobile from)
		{
			if ( from.RaceID != 0 )
			{
				from.SendMessage( "You don't find this really useful." );
				return;
			}
			else if ( !IsChildOf( from.Backpack ) ) 
			{
				from.SendMessage( "This must be in your backpack to use." );
				return;
			}
			else if ( from.Hue == 0x47E || from.Hue == 0xB70 )
			{
				from.Hue = from.RecordSkinColor;
				from.HairHue = from.RecordHairColor;
				from.FacialHairHue = from.RecordBeardColor;
				from.SendMessage("Your body turns back to the colors of life.");
			}
			else if ( from.Skills[SkillName.Necromancy].Base >= 100 )
			{
				from.Hue = 0xB70;
				from.HairHue = Utility.RandomList( 0, 0x497 );
				from.FacialHairHue = from.HairHue;
				from.SendMessage("Your body turns a ghostly white.");
			}
			else
			{
				from.SendMessage("You eat the skull dust, leaving your mouth dry.");
				from.Thirst = 0;
			}
			this.Delete();
			from.AddToBackpack( new Jar() );
        }

        public NecroSkinPotion( Serial serial ) : base( serial )
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