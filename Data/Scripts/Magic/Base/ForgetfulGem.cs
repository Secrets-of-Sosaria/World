using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Gumps;
using Server.Misc;
using System.Collections; 
using Server.Network; 

namespace Server.Items
{
    public class ForgetfulGem : Item
	{
        [Constructable]
        public ForgetfulGem() : base(0x3D05)
		{
            Name = "magical crystal";
			Movable = false;
			Light = LightType.Circle300;
        }

        public override void OnDoubleClick(Mobile from)
		{
			if ( from.Skills[SkillName.Magery].Base > 0 || from.Skills[SkillName.Necromancy].Base > 0 || from.Skills[SkillName.Elementalism].Base > 0 )
			{
				from.CloseGump( typeof( CrystalGump ) );
				from.SendGump( new CrystalGump( from, 1 ) );
			}
			else
			{
				from.SendMessage("The crystal slightly vibrates and feels warm to the touch.");
			}
        }

		public class CrystalGump : Gump
		{
			public CrystalGump( Mobile from, int page ): base( 50, 50 )
			{
				from.SendSound( 0x5C9 );
				string color = "#51c8d5";

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 9582, Server.Misc.PlayerSettings.GetGumpHue( from ));
				AddButton(567, 11, 4017, 4017, 0, GumpButtonType.Reply, 0);
				AddHtml( 12, 14, 357, 20, @"<BODY><BASEFONT Color=" + color + ">CRYSTAL OF WIZARDRY</BASEFONT></BODY>", (bool)false, (bool)false);

				if ( page == 1 )
				{
					string where = "the Sorcerer Cave in Sosaria";
					if ( from.Map == Map.Sosaria ){ where = "the Conjurerer's Cave in Lodoria"; }
					AddHtml( 13, 43, 581, 333, @"<BODY><BASEFONT Color=" + color + ">There are only two crystals like this ever discovered. The one here and the other in " + where + ". Sages have figured out that these can affect the powers of magic within a spellcaster and even some magical items. Sometimes elementalists seek out these crystals to forget the magic they learned, so they can focus their studies on magery or necromancy. Sometimes a mage or necromancer wants to abandon their pursuits and study elemental magic. Since elemental magic interferes with that of necromancy and magery, as well as those two doing the same toward elementalism, the crystals in these caves help them learn the other. Use the arrow button below to navigate the crystal, and be sure of your choices before calling upon the crystal's power.</BASEFONT></BODY>", (bool)false, (bool)false);
					AddButton(567, 359, 4005, 4005, 2, GumpButtonType.Reply, 0);
				}
				else if ( page == 2 )
				{
					int y = 210;

					if ( from.Skills[SkillName.Elementalism].Base > 0 )
					{
						AddHtml( 136, y, 357, 20, @"<BODY><BASEFONT Color=" + color + ">Forget Elementalism</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(95, y, 4017, 4017, 50, GumpButtonType.Reply, 0);
						y=y+30;
					}
					if ( from.Skills[SkillName.Magery].Base > 0 )
					{
						AddHtml( 136, y, 357, 20, @"<BODY><BASEFONT Color=" + color + ">Forget Magery</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(95, y, 4017, 4017, 51, GumpButtonType.Reply, 0);
						y=y+30;
					}
					if ( from.Skills[SkillName.Necromancy].Base > 0 )
					{
						AddHtml( 136, y, 357, 20, @"<BODY><BASEFONT Color=" + color + ">Forget Necromancy</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(95, y, 4017, 4017, 52, GumpButtonType.Reply, 0);
						y=y+30;
					}

					y = y + 30;
					AddHtml( 136, y, 357, 20, @"<BODY><BASEFONT Color=" + color + ">Cancel</BASEFONT></BODY>", (bool)false, (bool)false);
					AddButton(95, y, 4020, 4020, 0, GumpButtonType.Reply, 0);

					AddHtml( 13, 43, 581, 134, @"<BODY><BASEFONT Color=" + color + ">This crystal emits a powerful magic that can make the most skilled spellcasters forget the knowledge they learned. Most visit this place to pursue a normal life, free from magic. Others choose to practice magic in schools that do not allow one with the other, so they seek out this place to wipe their minds and start anew.</BASEFONT></BODY>", (bool)false, (bool)false);

					AddButton(9, 358, 4014, 4014, 1, GumpButtonType.Reply, 0);
				}
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				Mobile from = state.Mobile; 
				from.SendSound( 0x5C9 );
				bool magicAct = false;
				Skill skill = from.Skills[SkillName.Necromancy];

				if ( info.ButtonID > 0 && info.ButtonID < 4 )
				{
					from.SendSound( 0x4A );
					int page = info.ButtonID;
					from.SendGump( new CrystalGump( from, page ) );
				}
				else if ( info.ButtonID == 50 )
				{
					skill = from.Skills[SkillName.Elementalism];
					magicAct = true;
				}
				else if ( info.ButtonID == 51 )
				{
					skill = from.Skills[SkillName.Magery];
					magicAct = true;
				}
				else if ( info.ButtonID == 52 )
				{
					skill = from.Skills[SkillName.Necromancy];
					magicAct = true;
				}

				if ( magicAct )
				{
					skill.BaseFixedPoint = 0;
					Effects.SendLocationEffect( from.Location, from.Map, 0x3039, 30, 10, 0, 0 );
					from.SendSound( 0x65C );
					if ( from.Skills[SkillName.Magery].Base > 0 || from.Skills[SkillName.Necromancy].Base > 0 || from.Skills[SkillName.Elementalism].Base > 0 )
						from.SendGump( new CrystalGump( from, 2 ) );
				}
			}
		}

        public ForgetfulGem( Serial serial ) : base( serial )
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