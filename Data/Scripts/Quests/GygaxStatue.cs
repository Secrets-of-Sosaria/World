using System;
using Server;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Items
{
	public class GygaxStatue : Item
	{
		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Stone; } }

		public override void ResourceChanged( CraftResource resource )
		{
			m_Resource = resource;
			Hue = CraftResources.GetHue(m_Resource);
		}

		[Constructable]
		public GygaxStatue( ) : base( 0x4CC2 )
		{
			Weight = 1.0;
			Name = "scroll of Gygax";
			Hue = 0xB01;
			ItemID = Utility.RandomList( 0x4CC2, 0x4CC3 );
			Resource = CraftResource.Iron;
			ResourceMods.SetRandomResource( false, false, this, Resource, false, null );
		}

		public class GygaxGump : Gump
		{
			public GygaxGump( Mobile from ): base( 50, 50 )
			{
				from.SendSound( 0x4A ); 
				string color = "#f5dbb1";

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 7019, Server.Misc.PlayerSettings.GetGumpHue( from ));
				AddHtml( 13, 13, 308, 20, @"<BODY><BASEFONT Color=" + color + ">THE STATUE OF GYGAX</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(349, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);

				AddHtml( 13, 44, 361, 197, @"<BODY><BASEFONT Color=" + color + "><BR><BR>The Black Knight has stolen the Statue of Gygax, but you can claim it as your own if you can find it within his vault. You must first collect the items shown below and have those when you are near the it. While standing there, read this scroll to take the statue for yourself.</BASEFONT></BODY>", (bool)false, (bool)false);

				AddItem(4, 248, 12358);
				AddItem(4, 281, 12319);
				AddItem(4, 316, 12318);
				AddHtml( 48, 260, 185, 20, @"<BODY><BASEFONT Color=" + color + ">Dungeon Masters Guide</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 48, 290, 152, 20, @"<BODY><BASEFONT Color=" + color + ">Players Handbook</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 48, 320, 152, 20, @"<BODY><BASEFONT Color=" + color + ">Monster Manual</BASEFONT></BODY>", (bool)false, (bool)false);

				AddItem(235, 260, 12316);
				AddItem(236, 293, 12312);
				AddItem(236, 321, 12313);
				AddItem(309, 259, 12315);
				AddItem(310, 291, 12317);
				AddItem(310, 323, 12314);
				AddHtml( 265, 260, 27, 20, @"<BODY><BASEFONT Color=" + color + ">D4</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 265, 290, 27, 20, @"<BODY><BASEFONT Color=" + color + ">D6</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 265, 320, 27, 20, @"<BODY><BASEFONT Color=" + color + ">D8</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 335, 260, 43, 20, @"<BODY><BASEFONT Color=" + color + ">D10</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 335, 290, 43, 20, @"<BODY><BASEFONT Color=" + color + ">D12</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 335, 320, 43, 20, @"<BODY><BASEFONT Color=" + color + ">D20</BASEFONT></BODY>", (bool)false, (bool)false);
			}

			public override void OnResponse(NetState state, RelayInfo info)
			{
				Mobile from = state.Mobile;
				from.SendSound( 0x4A ); 
			}
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
            list.Add( 1049644, "Double Click To Ignite");
        }

		public override void OnDoubleClick( Mobile e )
		{
			int pieces = 0;

			if ( e.Backpack.FindItemByType( typeof ( Dice4 ) ) != null ){ pieces++; }
			if ( e.Backpack.FindItemByType( typeof ( Dice6 ) ) != null ){ pieces++; }
			if ( e.Backpack.FindItemByType( typeof ( Dice8 ) ) != null ){ pieces++; }
			if ( e.Backpack.FindItemByType( typeof ( Dice10 ) ) != null ){ pieces++; }
			if ( e.Backpack.FindItemByType( typeof ( Dice12 ) ) != null ){ pieces++; }
			if ( e.Backpack.FindItemByType( typeof ( Dice20 ) ) != null ){ pieces++; }
			if ( e.Backpack.FindItemByType( typeof ( DungeonMastersGuide ) ) != null ){ pieces++; }
			if ( e.Backpack.FindItemByType( typeof ( PlayersHandbook ) ) != null ){ pieces++; }
			if ( e.Backpack.FindItemByType( typeof ( MonsterManual ) ) != null ){ pieces++; }

			if ( !IsChildOf( e.Backpack ) ) 
			{
				e.SendMessage( "This must be in your backpack to use." );
				return;
			}
			else if ( e.Map == Map.Lodor && e.X >= 6261 && e.Y >= 40 && e.X <= 6279 && e.Y <= 60 && pieces > 8 )
			{
				e.Backpack.FindItemByType( typeof ( Dice4 ) ).Delete();
				e.Backpack.FindItemByType( typeof ( Dice6 ) ).Delete();
				e.Backpack.FindItemByType( typeof ( Dice8 ) ).Delete();
				e.Backpack.FindItemByType( typeof ( Dice10 ) ).Delete();
				e.Backpack.FindItemByType( typeof ( Dice12 ) ).Delete();
				e.Backpack.FindItemByType( typeof ( Dice20 ) ).Delete();
				e.Backpack.FindItemByType( typeof ( DungeonMastersGuide ) ).Delete();
				e.Backpack.FindItemByType( typeof ( PlayersHandbook ) ).Delete();
				e.Backpack.FindItemByType( typeof ( MonsterManual ) ).Delete();

				StatueGygaxAddonDeed relic = new StatueGygaxAddonDeed();
				relic.Hue = this.Hue;
				relic.RelicColor = this.Hue;
				relic.Name = "Statue of Gygax";
				relic.CoinPrice = Utility.RandomMinMax( 120, 200 ) * 100;
				relic.CoinPrice = (int)(relic.CoinPrice * (MyServerSettings.GetGoldCutRate() * .01));

				e.AddToBackpack( relic );

				PlayerSettings.SetKeys( e, "Gygax", true );

				e.LocalOverheadMessage(MessageType.Emote, 1150, true, "You claim the Statue of Gygax!");
				e.SendSound( 0x3D );

				this.Delete();
			}
			else
			{
				e.CloseGump( typeof( GygaxGump ) );
				e.SendGump( new GygaxGump( e ) );
				e.PlaySound( 0x249 );
			}
		}

		public GygaxStatue(Serial serial) : base(serial)
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

	public class StatueGygaxAddon : BaseAddon
	{
		public int RelicGoldValue;
		public int RelicColor;
		
		[CommandProperty(AccessLevel.Owner)]
		public int Relic_Value { get { return RelicGoldValue; } set { RelicGoldValue = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public int Relic_Color { get { return RelicColor; } set { RelicColor = value; InvalidateProperties(); } }

		public override BaseAddonDeed Deed
		{
			get
			{
				return new StatueGygaxAddonDeed( Relic_Value, Relic_Color );
			}
		}

		[Constructable]
		public StatueGygaxAddon() : this( 0, 0 )
		{
		}

		[ Constructable ]
		public StatueGygaxAddon( int RelCost, int RelHue )
		{
			AddComplexComponent( (BaseAddon) this, 21416, 0, 0, 10, RelHue, -1, "Statue of Gygax", 1);
			RelicGoldValue = RelCost;
			RelicColor = RelHue;
		}

		public override void OnComponentUsed( AddonComponent ac, Mobile from )
		{
			if ( ac.ItemID == 0x53A8 ){ ac.ItemID = 0x53A9; ac.Light = LightType.Circle300; from.SendSound( 0x208 ); }
			else if ( ac.ItemID == 0x53A9 ){ ac.ItemID = 0x53A8; ac.Light = LightType.Empty; from.SendSound( 0x3be ); }
		}

		public StatueGygaxAddon( Serial serial ) : base( serial )
		{
		}

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource)
        {
            AddComplexComponent(addon, item, xoffset, yoffset, zoffset, hue, lightsource, null, 1);
        }

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource, string name, int amount)
        {
            AddonComponent ac;
            ac = new AddonComponent(item);
            if (name != null && name.Length > 0)
                ac.Name = name;
            if (hue != 0)
                ac.Hue = hue;
            if (amount > 1)
            {
                ac.Stackable = true;
                ac.Amount = amount;
            }
            if (lightsource != -1)
                ac.Light = (LightType) lightsource;
            addon.AddComponent(ac, xoffset, yoffset, zoffset);
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
            writer.Write( RelicGoldValue );
            writer.Write( RelicColor );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            RelicGoldValue = reader.ReadInt();
            RelicColor = reader.ReadInt();
		}
	}

	public class StatueGygaxAddonDeed : BaseAddonDeed
	{
		public int RelicColor;

		[CommandProperty(AccessLevel.Owner)]
		public int Relic_Color { get { return RelicColor; } set { RelicColor = value; InvalidateProperties(); } }

		public override BaseAddon Addon
		{
			get
			{
				return new StatueGygaxAddon( CoinPrice, Hue );
			}
		}

		[Constructable]
		public StatueGygaxAddonDeed() : this( 0, 0 )
		{
		}

		[Constructable]
		public StatueGygaxAddonDeed( int RelCost, int RelHue )
		{
			Weight = 30;
			CoinPrice = RelCost;
			ItemID = 0x53C1;
			RelicColor = RelHue;
			Hue = RelHue;
			Name = "Gygax Statue";
		}

		public StatueGygaxAddonDeed( Serial serial ) : base( serial )
		{
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
            list.Add( 1049644, "Double Click To Place In Your Home");
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 1 ); // Version
            writer.Write( RelicColor );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( version < 1 )
				CoinPrice = reader.ReadInt();

            RelicColor = reader.ReadInt();
		}
	}
}