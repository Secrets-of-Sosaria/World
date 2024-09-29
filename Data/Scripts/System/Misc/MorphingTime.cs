using Server.Accounting;
using Server.Commands.Generic;
using Server.Commands;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Regions;
using Server;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System;

namespace Server.Misc
{
    class MorphingTime
    {
		public static void SetGender( Mobile m )
		{
			if ( m.Body == 400 || m.Body == 605 ){ m.Female = false; }
			else if ( m.Body == 401 || m.Body == 606 ){ m.Female = true; }
		}

		public static void VampireDressUp( Mobile m, int body )
		{
			int Hue1 = Utility.RandomMinMax( 2401, 2412 ); // BLACK
			int Hue2 = Utility.RandomList( 2117, 2118, 1640, 1641, 1642, 1643, 1644, 1645, 1650, 1651, 1652, 1653, 1654, 1157, 1194 ); // RED

			if ( Utility.RandomMinMax( 1, 2 ) == 1 )
			{
				Hue1 = Utility.RandomList( 2117, 2118, 1640, 1641, 1642, 1643, 1644, 1645, 1650, 1651, 1652, 1653, 1654, 1157, 1194 ); // RED
				Hue2 = Utility.RandomMinMax( 2401, 2412 ); // BLACK
			}

			if ( body != 606 && ( Utility.RandomMinMax( 1, 2 ) == 1 || body == 605 ) ) // MALE
			{
				m.Body = 605;
				m.Name = NameList.RandomName( "dark_elf_prefix_male" ) + NameList.RandomName( "dark_elf_suffix_male" );
				m.BaseSoundID = 0x47D;
				if ( Utility.RandomMinMax( 1, 2 ) == 1 ){ Utility.AssignRandomHair( m ); } else { m.HairItemID = 0; }

				switch ( Utility.RandomMinMax( 1, 4 ) )
				{
					case 1:
						FancyShirt m_shirt = new FancyShirt(); m_shirt.Hue = Hue1; m.AddItem( m_shirt );
						LongPants m_pant = new LongPants(); m_pant.Hue = Hue1; m.AddItem( m_pant );
						break;
					case 2:
						Shirt m_shirts = new Shirt(); m_shirts.Hue = Hue1; m.AddItem( m_shirts );
						ShortPants m_pants = new ShortPants(); m_pants.Hue = Hue1; m.AddItem( m_pants );
						break;
					case 3:
						Robe m_robe = new Robe(); m_robe.Hue = Hue1; m.AddItem( m_robe );
						break;
					case 4:
						Robe m_robes = new Robe(); m_robes.Hue = Hue1; m.AddItem( m_robes );
						break;
				}
			}
			else
			{
				m.Body = 606;
				m.Female = true;
				m.Name = NameList.RandomName( "dark_elf_prefix_female" ) + NameList.RandomName( "dark_elf_suffix_female" );
				m.BaseSoundID = 0x257;
				Utility.AssignRandomHair( m );
				m.AddItem( new FancyDress(0x5B5) );

				switch ( Utility.RandomMinMax( 1, 5 ) )
				{
					case 1:
						FancyShirt f_shirt = new FancyShirt(); f_shirt.Hue = Hue1; m.AddItem( f_shirt );
						Skirt f_pant = new Skirt(); f_pant.Hue = Hue1; m.AddItem( f_pant );
						break;
					case 2:
						Shirt f_shirts = new Shirt(); f_shirts.Hue = Hue1; m.AddItem( f_shirts );
						Kilt f_pants = new Kilt(); f_pants.Hue = Hue1; m.AddItem( f_pants );
						break;
					case 3:
						PlainDress f_robe = new PlainDress(); f_robe.Hue = Hue1; m.AddItem( f_robe );
						break;
					case 4:
						PlainDress f_robes = new PlainDress(); f_robes.Hue = Hue1; m.AddItem( f_robes );
						break;
					case 5:
						FancyDress f_dress = new FancyDress(); f_dress.Hue = Hue1; m.AddItem( f_dress );
						break;
				}
			}

			if ( Utility.RandomMinMax( 1, 4 ) > 1 ){ m.AddItem( new Cloak(Hue2) ); }
			if ( Utility.RandomMinMax( 1, 2 ) == 1 ){ LeatherGloves gloves = new LeatherGloves(); gloves.Hue = Hue2; m.AddItem( gloves ); }
			Boots boots = new Boots(); boots.Hue = Hue2; boots.ItemID = 12228; m.AddItem( boots );
			m.Hue = 0xB70;
			m.HairHue = 0x497;

			BlessMyClothes( m );
		}

		public static void RebuildEquipment( Mobile m )
		{
			if ( m.FindItemOnLayer( Layer.OuterTorso ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.OuterTorso ) ); }
			if ( m.FindItemOnLayer( Layer.MiddleTorso ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.MiddleTorso ) ); }
			if ( m.FindItemOnLayer( Layer.OneHanded ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.OneHanded ) ); }
			if ( m.FindItemOnLayer( Layer.TwoHanded ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.TwoHanded ) ); }
			if ( m.FindItemOnLayer( Layer.Bracelet ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.Bracelet ) ); }
			if ( m.FindItemOnLayer( Layer.Ring ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.Ring ) ); }
			if ( m.FindItemOnLayer( Layer.Helm ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.Helm ) ); }
			if ( m.FindItemOnLayer( Layer.Arms ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.Arms ) ); }
			if ( m.FindItemOnLayer( Layer.OuterLegs ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.OuterLegs ) ); }
			if ( m.FindItemOnLayer( Layer.Neck ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.Neck ) ); }
			if ( m.FindItemOnLayer( Layer.Gloves ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.Gloves ) ); }
			if ( m.FindItemOnLayer( Layer.Trinket ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.Trinket ) ); }
			if ( m.FindItemOnLayer( Layer.Shoes ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.Shoes ) ); }
			if ( m.FindItemOnLayer( Layer.Cloak ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.Cloak ) ); }
			if ( m.FindItemOnLayer( Layer.FirstValid ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.FirstValid ) ); }
			if ( m.FindItemOnLayer( Layer.Waist ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.Waist ) ); }
			if ( m.FindItemOnLayer( Layer.InnerLegs ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.InnerLegs ) ); }
			if ( m.FindItemOnLayer( Layer.InnerTorso ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.InnerTorso ) ); }
			if ( m.FindItemOnLayer( Layer.Pants ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.Pants ) ); }
			if ( m.FindItemOnLayer( Layer.Shirt ) != null ) { FixEquipment( m.FindItemOnLayer( Layer.Shirt ) ); }
		}

		public static void FixEquipment( Item item )
		{
			if ( item is BaseWeapon ){ ((BaseWeapon)item).HitPoints = ((BaseWeapon)item).MaxHitPoints; }
			else if ( item is BaseArmor ){ ((BaseArmor)item).HitPoints = ((BaseArmor)item).MaxHitPoints; }
			else if ( item is BaseClothing ){ ((BaseClothing)item).HitPoints = ((BaseClothing)item).MaxHitPoints; }
		}

		public static void RemoveMyClothes( Mobile m )
		{
			if ( m.FindItemOnLayer( Layer.OuterTorso ) != null ) { m.FindItemOnLayer( Layer.OuterTorso ).Delete(); }
			if ( m.FindItemOnLayer( Layer.MiddleTorso ) != null ) { m.FindItemOnLayer( Layer.MiddleTorso ).Delete(); }
			if ( m.FindItemOnLayer( Layer.OneHanded ) != null ) { m.FindItemOnLayer( Layer.OneHanded ).Delete(); }
			if ( m.FindItemOnLayer( Layer.TwoHanded ) != null ) { m.FindItemOnLayer( Layer.TwoHanded ).Delete(); }
			if ( m.FindItemOnLayer( Layer.Bracelet ) != null ) { m.FindItemOnLayer( Layer.Bracelet ).Delete(); }
			if ( m.FindItemOnLayer( Layer.Ring ) != null ) { m.FindItemOnLayer( Layer.Ring ).Delete(); }
			if ( m.FindItemOnLayer( Layer.Helm ) != null ) { m.FindItemOnLayer( Layer.Helm ).Delete(); }
			if ( m.FindItemOnLayer( Layer.Arms ) != null ) { m.FindItemOnLayer( Layer.Arms ).Delete(); }
			if ( m.FindItemOnLayer( Layer.OuterLegs ) != null ) { m.FindItemOnLayer( Layer.OuterLegs ).Delete(); }
			if ( m.FindItemOnLayer( Layer.Neck ) != null ) { m.FindItemOnLayer( Layer.Neck ).Delete(); }
			if ( m.FindItemOnLayer( Layer.Gloves ) != null ) { m.FindItemOnLayer( Layer.Gloves ).Delete(); }
			if ( m.FindItemOnLayer( Layer.Trinket ) != null ) { m.FindItemOnLayer( Layer.Trinket ).Delete(); }
			if ( m.FindItemOnLayer( Layer.Shoes ) != null ) { m.FindItemOnLayer( Layer.Shoes ).Delete(); }
			if ( m.FindItemOnLayer( Layer.Cloak ) != null ) { m.FindItemOnLayer( Layer.Cloak ).Delete(); }
			if ( m.FindItemOnLayer( Layer.FirstValid ) != null ) { m.FindItemOnLayer( Layer.FirstValid ).Delete(); }
			if ( m.FindItemOnLayer( Layer.Waist ) != null ) { m.FindItemOnLayer( Layer.Waist ).Delete(); }
			if ( m.FindItemOnLayer( Layer.InnerLegs ) != null ) { m.FindItemOnLayer( Layer.InnerLegs ).Delete(); }
			if ( m.FindItemOnLayer( Layer.InnerTorso ) != null ) { m.FindItemOnLayer( Layer.InnerTorso ).Delete(); }
			if ( m.FindItemOnLayer( Layer.Pants ) != null ) { m.FindItemOnLayer( Layer.Pants ).Delete(); }
			if ( m.FindItemOnLayer( Layer.Shirt ) != null ) { m.FindItemOnLayer( Layer.Shirt ).Delete(); }
		}

		public static int ColorMeRandom( int rndm, int hue )
		{
			if ( rndm == 1 ){ hue = Utility.RandomEvilHue(); }

			return hue;
		}

		public static void ColorMixClothes( Mobile m )
		{
			if ( m.FindItemOnLayer( Layer.OuterTorso ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.OuterTorso ) ) ) { if ( !( m.FindItemOnLayer( Layer.OuterTorso ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.OuterTorso ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.OuterTorso ) ); }
			if ( m.FindItemOnLayer( Layer.MiddleTorso ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.MiddleTorso ) ) ) { if ( !( m.FindItemOnLayer( Layer.MiddleTorso ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.MiddleTorso ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.MiddleTorso ) ); }
			if ( m.FindItemOnLayer( Layer.Bracelet ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Bracelet ) ) ) { if ( !( m.FindItemOnLayer( Layer.Bracelet ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Bracelet ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Bracelet ) ); }
			if ( m.FindItemOnLayer( Layer.Ring ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Ring ) ) ) { if ( !( m.FindItemOnLayer( Layer.Ring ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Ring ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Ring ) ); }
			if ( m.FindItemOnLayer( Layer.Helm ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Helm ) ) ) { if ( !( m.FindItemOnLayer( Layer.Helm ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Helm ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Helm ) ); }
			if ( m.FindItemOnLayer( Layer.Arms ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Arms ) ) ) { if ( !( m.FindItemOnLayer( Layer.Arms ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Arms ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Arms ) ); }
			if ( m.FindItemOnLayer( Layer.OuterLegs ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.OuterLegs ) ) ) { if ( !( m.FindItemOnLayer( Layer.OuterLegs ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.OuterLegs ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.OuterLegs ) ); }
			if ( m.FindItemOnLayer( Layer.Neck ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Neck ) ) ) { if ( !( m.FindItemOnLayer( Layer.Neck ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Neck ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Neck ) ); }
			if ( m.FindItemOnLayer( Layer.Gloves ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Gloves ) ) ) { if ( !( m.FindItemOnLayer( Layer.Gloves ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Gloves ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Gloves ) ); }
			if ( m.FindItemOnLayer( Layer.Trinket ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Trinket ) ) ) { if ( !( m.FindItemOnLayer( Layer.Trinket ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Trinket ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Trinket ) ); }
			if ( m.FindItemOnLayer( Layer.Shoes ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Shoes ) ) ) { if ( !( m.FindItemOnLayer( Layer.Shoes ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Shoes ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Shoes ) ); }
			if ( m.FindItemOnLayer( Layer.Cloak ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Cloak ) ) ) { if ( !( m.FindItemOnLayer( Layer.Cloak ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Cloak ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Cloak ) ); }
			if ( m.FindItemOnLayer( Layer.Waist ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Waist ) ) ) { if ( !( m.FindItemOnLayer( Layer.Waist ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Waist ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Waist ) ); }
			if ( m.FindItemOnLayer( Layer.InnerLegs ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.InnerLegs ) ) ) { if ( !( m.FindItemOnLayer( Layer.InnerLegs ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.InnerLegs ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.InnerLegs ) ); }
			if ( m.FindItemOnLayer( Layer.InnerTorso ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.InnerTorso ) ) ) { if ( !( m.FindItemOnLayer( Layer.InnerTorso ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.InnerTorso ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.InnerTorso ) ); }
			if ( m.FindItemOnLayer( Layer.Pants ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Pants ) ) ) { if ( !( m.FindItemOnLayer( Layer.Pants ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Pants ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Pants ) ); }
			if ( m.FindItemOnLayer( Layer.Shirt ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Shirt ) ) ) { if ( !( m.FindItemOnLayer( Layer.Shirt ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Shirt ).Hue = Utility.RandomColor(0); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Shirt ) ); }
		}

		public static void ColorOnlyClothes( Mobile m, int hue, int rndm )
		{
			if ( m.FindItemOnLayer( Layer.OuterTorso ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.OuterTorso ) ) ) { if ( !( m.FindItemOnLayer( Layer.OuterTorso ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.OuterTorso ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.OuterTorso ) ); }
			if ( m.FindItemOnLayer( Layer.MiddleTorso ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.MiddleTorso ) ) ) { if ( !( m.FindItemOnLayer( Layer.MiddleTorso ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.MiddleTorso ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.MiddleTorso ) ); }
			if ( m.FindItemOnLayer( Layer.Bracelet ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Bracelet ) ) ) { if ( !( m.FindItemOnLayer( Layer.Bracelet ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Bracelet ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Bracelet ) ); }
			if ( m.FindItemOnLayer( Layer.Ring ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Ring ) ) ) { if ( !( m.FindItemOnLayer( Layer.Ring ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Ring ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Ring ) ); }
			if ( m.FindItemOnLayer( Layer.Helm ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Helm ) ) ) { if ( !( m.FindItemOnLayer( Layer.Helm ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Helm ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Helm ) ); }
			if ( m.FindItemOnLayer( Layer.Arms ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Arms ) ) ) { if ( !( m.FindItemOnLayer( Layer.Arms ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Arms ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Arms ) ); }
			if ( m.FindItemOnLayer( Layer.OuterLegs ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.OuterLegs ) ) ) { if ( !( m.FindItemOnLayer( Layer.OuterLegs ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.OuterLegs ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.OuterLegs ) ); }
			if ( m.FindItemOnLayer( Layer.Neck ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Neck ) ) ) { if ( !( m.FindItemOnLayer( Layer.Neck ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Neck ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Neck ) ); }
			if ( m.FindItemOnLayer( Layer.Gloves ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Gloves ) ) ) { if ( !( m.FindItemOnLayer( Layer.Gloves ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Gloves ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Gloves ) ); }
			if ( m.FindItemOnLayer( Layer.Trinket ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Trinket ) ) ) { if ( !( m.FindItemOnLayer( Layer.Trinket ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Trinket ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Trinket ) ); }
			if ( m.FindItemOnLayer( Layer.Shoes ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Shoes ) ) ) { if ( !( m.FindItemOnLayer( Layer.Shoes ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Shoes ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Shoes ) ); }
			if ( m.FindItemOnLayer( Layer.Cloak ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Cloak ) ) ) { if ( !( m.FindItemOnLayer( Layer.Cloak ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Cloak ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Cloak ) ); }
			if ( m.FindItemOnLayer( Layer.Waist ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Waist ) ) ) { if ( !( m.FindItemOnLayer( Layer.Waist ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Waist ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Waist ) ); }
			if ( m.FindItemOnLayer( Layer.InnerLegs ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.InnerLegs ) ) ) { if ( !( m.FindItemOnLayer( Layer.InnerLegs ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.InnerLegs ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.InnerLegs ) ); }
			if ( m.FindItemOnLayer( Layer.InnerTorso ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.InnerTorso ) ) ) { if ( !( m.FindItemOnLayer( Layer.InnerTorso ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.InnerTorso ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.InnerTorso ) ); }
			if ( m.FindItemOnLayer( Layer.Pants ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Pants ) ) ) { if ( !( m.FindItemOnLayer( Layer.Pants ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Pants ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Pants ) ); }
			if ( m.FindItemOnLayer( Layer.Shirt ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Shirt ) ) ) { if ( !( m.FindItemOnLayer( Layer.Shirt ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Shirt ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Shirt ) ); }
		}

		public static void ColorMyClothes( Mobile m, int hue, int rndm )
		{
			if ( m.FindItemOnLayer( Layer.OuterTorso ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.OuterTorso ) ) ) { if ( !( m.FindItemOnLayer( Layer.OuterTorso ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.OuterTorso ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.OuterTorso ) ); }
			if ( m.FindItemOnLayer( Layer.MiddleTorso ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.MiddleTorso ) ) ) { if ( !( m.FindItemOnLayer( Layer.MiddleTorso ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.MiddleTorso ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.MiddleTorso ) ); }
			if ( m.FindItemOnLayer( Layer.OneHanded ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.OneHanded ) ) ) { if ( !( m.FindItemOnLayer( Layer.OneHanded ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.OneHanded ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.OneHanded ) ); }
			if ( m.FindItemOnLayer( Layer.TwoHanded ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.TwoHanded ) ) ) { if ( !( m.FindItemOnLayer( Layer.TwoHanded ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.TwoHanded ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.TwoHanded ) ); }
			if ( m.FindItemOnLayer( Layer.Bracelet ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Bracelet ) ) ) { if ( !( m.FindItemOnLayer( Layer.Bracelet ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Bracelet ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Bracelet ) ); }
			if ( m.FindItemOnLayer( Layer.Ring ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Ring ) ) ) { if ( !( m.FindItemOnLayer( Layer.Ring ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Ring ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Ring ) ); }
			if ( m.FindItemOnLayer( Layer.Helm ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Helm ) ) ) { if ( !( m.FindItemOnLayer( Layer.Helm ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Helm ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Helm ) ); }
			if ( m.FindItemOnLayer( Layer.Arms ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Arms ) ) ) { if ( !( m.FindItemOnLayer( Layer.Arms ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Arms ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Arms ) ); }
			if ( m.FindItemOnLayer( Layer.OuterLegs ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.OuterLegs ) ) ) { if ( !( m.FindItemOnLayer( Layer.OuterLegs ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.OuterLegs ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.OuterLegs ) ); }
			if ( m.FindItemOnLayer( Layer.Neck ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Neck ) ) ) { if ( !( m.FindItemOnLayer( Layer.Neck ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Neck ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Neck ) ); }
			if ( m.FindItemOnLayer( Layer.Gloves ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Gloves ) ) ) { if ( !( m.FindItemOnLayer( Layer.Gloves ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Gloves ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Gloves ) ); }
			if ( m.FindItemOnLayer( Layer.Trinket ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Trinket ) ) ) { if ( !( m.FindItemOnLayer( Layer.Trinket ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Trinket ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Trinket ) ); }
			if ( m.FindItemOnLayer( Layer.Shoes ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Shoes ) ) ) { if ( !( m.FindItemOnLayer( Layer.Shoes ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Shoes ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Shoes ) ); }
			if ( m.FindItemOnLayer( Layer.Cloak ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Cloak ) ) ) { if ( !( m.FindItemOnLayer( Layer.Cloak ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Cloak ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Cloak ) ); }
			if ( m.FindItemOnLayer( Layer.FirstValid ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.FirstValid ) ) ) { if ( !( m.FindItemOnLayer( Layer.FirstValid ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.FirstValid ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.FirstValid ) ); }
			if ( m.FindItemOnLayer( Layer.Waist ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Waist ) ) ) { if ( !( m.FindItemOnLayer( Layer.Waist ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Waist ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Waist ) ); }
			if ( m.FindItemOnLayer( Layer.InnerLegs ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.InnerLegs ) ) ) { if ( !( m.FindItemOnLayer( Layer.InnerLegs ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.InnerLegs ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.InnerLegs ) ); }
			if ( m.FindItemOnLayer( Layer.InnerTorso ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.InnerTorso ) ) ) { if ( !( m.FindItemOnLayer( Layer.InnerTorso ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.InnerTorso ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.InnerTorso ) ); }
			if ( m.FindItemOnLayer( Layer.Pants ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Pants ) ) ) { if ( !( m.FindItemOnLayer( Layer.Pants ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Pants ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Pants ) ); }
			if ( m.FindItemOnLayer( Layer.Shirt ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.Shirt ) ) ) { if ( !( m.FindItemOnLayer( Layer.Shirt ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.Shirt ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.Shirt ) ); }
		}

		public static void ColorMyArms( Mobile m, int hue, int rndm )
		{
			if ( m.FindItemOnLayer( Layer.OneHanded ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.OneHanded ) ) ) { if ( !( m.FindItemOnLayer( Layer.OneHanded ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.OneHanded ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.OneHanded ) ); }
			if ( m.FindItemOnLayer( Layer.TwoHanded ) != null && MyServerSettings.AlterArtifact( m.FindItemOnLayer( Layer.TwoHanded ) ) ) { if ( !( m.FindItemOnLayer( Layer.TwoHanded ) is WornHumanDeco ) ){ m.FindItemOnLayer( Layer.TwoHanded ).Hue = ColorMeRandom( rndm, hue ); } Server.Misc.Arty.setArtifact( m.FindItemOnLayer( Layer.TwoHanded ) ); }
		}

		public static void BlessMyClothes( Mobile m )
		{
			if ( m.FindItemOnLayer( Layer.OuterTorso ) != null ) { m.FindItemOnLayer( Layer.OuterTorso ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.MiddleTorso ) != null ) { m.FindItemOnLayer( Layer.MiddleTorso ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.OneHanded ) != null ) { m.FindItemOnLayer( Layer.OneHanded ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.TwoHanded ) != null ) { m.FindItemOnLayer( Layer.TwoHanded ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.Bracelet ) != null ) { m.FindItemOnLayer( Layer.Bracelet ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.Ring ) != null ) { m.FindItemOnLayer( Layer.Ring ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.Helm ) != null ) { m.FindItemOnLayer( Layer.Helm ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.Arms ) != null ) { m.FindItemOnLayer( Layer.Arms ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.OuterLegs ) != null ) { m.FindItemOnLayer( Layer.OuterLegs ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.Neck ) != null ) { m.FindItemOnLayer( Layer.Neck ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.Gloves ) != null ) { m.FindItemOnLayer( Layer.Gloves ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.Trinket ) != null ) { m.FindItemOnLayer( Layer.Trinket ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.Shoes ) != null ) { m.FindItemOnLayer( Layer.Shoes ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.Cloak ) != null ) { m.FindItemOnLayer( Layer.Cloak ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.FirstValid ) != null ) { m.FindItemOnLayer( Layer.FirstValid ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.Waist ) != null ) { m.FindItemOnLayer( Layer.Waist ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.InnerLegs ) != null ) { m.FindItemOnLayer( Layer.InnerLegs ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.InnerTorso ) != null ) { m.FindItemOnLayer( Layer.InnerTorso ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.Pants ) != null ) { m.FindItemOnLayer( Layer.Pants ).LootType = LootType.Blessed; }
			if ( m.FindItemOnLayer( Layer.Shirt ) != null ) { m.FindItemOnLayer( Layer.Shirt ).LootType = LootType.Blessed; }
		}

		public static void CheckMorph( Mobile from )
		{
			if ( from is EpicCharacter || from is Citizens )
				return;

			if ( CheckGargoyle( from ) )
				return;

			if ( CheckRavendark( from ) )
				return;

			if ( CheckNecromancer( from ) )
				return;

			if ( CheckBarbarian( from ) )
				return;

			if ( CheckOrk( from ) )
				return;

			if ( CheckPirate( from ) )
				return;

			if ( CheckLunar( from ) )
				return;

			CheckElf( from );
		}

		public static bool CheckLunar( Mobile from )
		{
			if ( !from.Region.IsPartOf( "the Lunar City of Dawn" ) )
				return false;

				TurnToMage( from );

			return true;
		}

		public static bool CheckOrk( Mobile from )
		{
			if ( from is OrkMonks || from is OrkRogue || from is OrkMage || from is OrkWarrior )
			{
				TurnToOrk( from );
				return true;
			}

			Map map = from.Map;

			if ( map != Map.SavagedEmpire )
				return false;

			if ( from.Region.IsPartOf( "the Cimmeran Mines" ) )
				return false;

			if ( from.Region.IsPartOf( "the Enchanted Pass" ) )
				return false;

			if ( from.Region.IsPartOf( "the Hedge Maze" ) )
				return false;

				TurnToOrk( from );

			return true;
		}

		public static bool CheckElf( Mobile from )
		{
			Map map = from.Map;

			if ( ( map != Map.Lodor ) && ( !from.Region.IsPartOf( "the Enchanted Pass" ) ) )
				return false;

			// BARD'S TALE
			if ( from.Region.IsPartOf( typeof( BardTownRegion ) ) )
				return false;

			if ( 
				from.Region.IsPartOf( "the Ethereal Plane" ) || 
				from.Region.IsPartOf( "the Ranger Outpost" ) || 
				from.Region.IsPartOf( "the Glowing Pond" ) || 
				from.Region.IsPartOf( "the Altar of Golden Rangers" ) || 
				from.Region.IsPartOf( "the Weary Camper Tavern" )
			)
				return false;

				TurnToElf( from );

			return true;
		}

		public static bool CheckGargoyle( Mobile from )
		{
			Map map = from.Map;

			if ( ( map != Map.SerpentIsland ) )
				return false;

			if ( from.Region.IsPartOf( "Serpent Sail Docks" ) )
				return false;

				TurnToGargoyle( from );

			return true;
		}

		public static bool CheckBarbarian( Mobile from )
		{
			Map map = from.Map;

			if ( ( map != Map.IslesDread ) && ( !from.Region.IsPartOf( "the Cimmeran Mines" ) ) )
				return false;

			if ( from.Region.IsPartOf( "the Forgotten Lighthouse" ) )
				return false;

				TurnToBarbarian( from );

			return true;
		}

		public static bool CheckPirate( Mobile from )
		{
			if ( !from.Region.IsPartOf( "the Forgotten Lighthouse" ) )
				return false;

				TurnToPirate( from );

			return true;
		}

		public static bool CheckNecromancer( Mobile from )
		{
			Map map = from.Map;

			if ( Worlds.IsCrypt( from.Location, from.Map ) && from.Hue != 0x83E8 )
			{
				TurnToNecromancer( from );
				return true;
			}

			return false;
		}

		public static bool CheckNecro( Mobile from )
		{
			Map map = from.Map;

			if ( from.Region.IsPartOf( "the Undercity of Umbra" ) || from.Region.IsPartOf( "the Black Magic Guild" ) || from.Region.IsPartOf( "the Island of Dracula" ) || from.Region.IsPartOf( "the Village of Ravendark" ) || from.Region.IsPartOf( "Ravendark Woods" ) )
				return true;

			return false;
		}

		public static bool CheckRavendark( Mobile from )
		{
			Map map = from.Map;

			if ( from.Region.IsPartOf( typeof( NecromancerRegion ) ) )
			{
				if ( from is Citizens ){ TurnToNecromancer( from ); }
				else { TurnToRavendark( from ); }
				return true;
			}

			return false;
		}

		public static int GetRandomNecromancerHue()
		{
			return Utility.RandomList(1476, 2342, 2056, 2944, 2817, 2915, 2906, 2875, 1790, 1779, 1909, 2085, 2092, 2089, 2796, 2338, 2380, 1989, 2845, 2379, 1484, 1489, 1995, 2167, 2928, 1470, 1939, 2227, 1141, 1157, 1158, 1175, 1254, 1509, 2118, 2224, 1105, 0xB80, 0xB5E, 0xB39, 0xB3A, 0xA9F, 0x99E, 0x997, 0x8D9, 0x8DA, 0x8DB, 0x8DC, 0x8B9, 2117, 2118, 1640, 1641, 1642, 1643, 1644, 1645, 1650, 1651, 1652, 1653, 1654, 1157, 1194, 2401, 2412);
		}

		public static void TurnToUndead( Mobile from )
		{
			if ( from is Humanoid )
				return;

			from.Female = false;
			BaseCreature bc = (BaseCreature)from;
			from.CantWalk = false;
			from.RaceMakeSounds = true;

			if ( from is WarriorGuildmaster )
			{
				from.Name = NameList.RandomName( "ork_male" );
				Server.Items.NPCRace.CreateRace( from, 65, 0 );
				bc.SetSkill( SkillName.Knightship, 100.0 );
			}
			else if ( Utility.RandomMinMax(1,10) == 1 && from is BaseVendor )
			{
				if ( from is Elementalist || from is Mage || from is Scribe || from is Healer || from is Sage || from is Alchemist || from is Herbalist )
				{
					from.Name = NameList.RandomName( "author" );
					Server.Items.NPCRace.CreateRace( from, Utility.RandomList( 810, 125, 724, 24, 110 ), 0 );
					if ( bc.RangeHome < 1 ){ bc.RangeHome = 2; }
				}
				else if ( from is Shipwright || from is Fisherman )
				{
					from.Name = NameList.RandomName( "author" );
					Server.Items.NPCRace.CreateRace( from, 304, 0 );
					if ( bc.RangeHome < 1 ){ bc.RangeHome = 2; }
				}
				else if ( Utility.RandomMinMax(1,20) == 1 )
				{
					from.Name = NameList.RandomName( "author" );
					Server.Items.NPCRace.CreateRace( from, Utility.RandomList( 124, 181, 307, 728, 50 ), 0 );
					if ( bc.RangeHome < 1 ){ bc.RangeHome = 2; }
				}
			}
		}

		public static void TurnToNecromancer( Mobile from )
		{
			if ( from is Humanoid )
				return;

			if ( from is TownGuards )
			{
				from.Female = false;

				if ( Utility.RandomBool() )
				{
					from.Name = NameList.RandomName( "greek" );
					Server.Items.NPCRace.CreateRace( from, 57, 0 );
				}
				else
				{
					from.Name = NameList.RandomName( "greek" );
					Server.Items.NPCRace.CreateRace( from, 170, 0 );
				}
			}
			else
			{
				int mainColor = GetRandomNecromancerHue();
				int armorColor = GetRandomNecromancerHue();
				int hairColor = Utility.RandomList( 0, 0x497 );

				if ( !(from is TownGuards) )
				{
					for ( int i = 0; i < from.Items.Count; ++i )
					{
						Item item = from.Items[i];

						if ( item is BaseShoes )
							item.Hue = GetRandomNecromancerHue();
						else if ( item is BaseClothing )
							item.Hue = mainColor;
						else if ( item is BaseArmor )
							item.Hue = armorColor;
						else if ( item is BaseWeapon || item is BaseTool )
							item.Hue = GetRandomNecromancerHue();
					}
				}

				from.HairHue = hairColor;
				from.FacialHairHue = hairColor;

				if ( from is Citizens ){ from.Karma = -1; }

				from.Hue = 0xB70;

				TurnToUndead( from );
			}
		}

		public static void TurnToRavendark( Mobile from )
		{
			if ( from is Humanoid )
				return;

			RemoveMyClothes( from );

			int color = GetRandomNecromancerHue();

			switch ( Utility.Random( 7 ) )
			{
				case 0: from.AddItem( new NecromancerRobe( color ) ); break;
				case 1: from.AddItem( new AssassinRobe( color ) ); break;
				case 2: from.AddItem( new MagistrateRobe( color ) ); break;
				case 3: from.AddItem( new OrnateRobe( color ) ); break;
				case 4: from.AddItem( new SorcererRobe( color ) ); break;
				case 5: from.AddItem( new SpiderRobe( color ) ); break;
				case 6: from.AddItem( new VagabondRobe( color ) ); break;
			}

			switch ( Utility.Random( 5 ) )
			{
				case 0: from.AddItem( new ClothHood( color ) ); break;
				case 1: from.AddItem( new ClothCowl( color ) ); break;
				case 2: from.AddItem( new FancyHood( color ) ); break;
				case 3: from.AddItem( new WizardHood( color ) ); break;
				case 4: from.AddItem( new HoodedMantle( color ) ); break;
			}

			from.AddItem( new Boots() );
			from.HairHue = 0;
			from.FacialHairHue = 0;
			from.HairItemID = 0;
			from.FacialHairItemID = 0;
			from.Hue = 0;
			from.Blessed = true;

			TurnToUndead( from );

			from.NameHue = Utility.RandomOrangeHue();
		}

		public static void TurnToBarbarian( Mobile from )
		{
			if ( from is Humanoid )
				return;

			for ( int i = 0; i < from.Items.Count; ++i )
			{
				Item item = from.Items[i];

				if ( item is Hair || item is Beard )
				{
					item.Hue = 0x455;
				}
				else if ( ( ( item is BasePants ) || ( item is BaseOuterLegs ) ) && ( !(from is TownGuards) ) )
				{
					item.Delete();
					from.AddItem( new Kilt(Utility.RandomYellowHue()) );
				}
				else if ( ( item is BaseClothing || item is BaseWeapon || item is BaseArmor || item is BaseTool ) && ( !(from is TownGuards) ) )
				{
					item.Hue = Utility.RandomYellowHue();
				}
			}

			from.HairHue = 0x455;
			from.FacialHairHue = 0x455;

			if ( from.Female )
			{
				from.Name = NameList.RandomName( "barb_female" );
			}
			else
			{
				from.Name = NameList.RandomName( "barb_male" );
			}
		}

		public static void TurnToOrk( Mobile from )
		{
			if ( from is Humanoid )
				return;

			if ( from.Female ){ from.Body = 606; }
			else { from.Body = 605; }

			if ( from.Hue == 0x1C4 || from.Hue == 0x1C5 || from.Hue == 0x1C6 || from.Hue == 0x1C7 || from.Hue == 0x1C9 || from.Hue == 0x1CA || from.Hue == 0x1CB || from.Hue == 0x1CC || from.Hue == 0x1CE || from.Hue == 0x1CF || from.Hue == 0x1D0 || from.Hue == 0x1D1 )
			{
				// THEY ARE ALREADY AN ORK
			}
			else
			{
				if ( !( from is TownGuards || from is OrkMonks || from is OrkRogue || from is OrkMage || from is OrkWarrior ) )
				{
					for ( int i = 0; i < from.Items.Count; ++i )
					{
						Item item = from.Items[i];

						if ( item is BaseClothing || item is BaseWeapon || item is BaseArmor || item is BaseTool )
							item.Hue = Utility.RandomYellowHue();
					}
				}

				from.Hue = Utility.RandomList( 0x1C4, 0x1C5, 0x1C6, 0x1C7, 0x1C9, 0x1CA, 0x1CB, 0x1CC, 0x1CE, 0x1CF, 0x1D0, 0x1D1 );
				from.HairHue = 0x455;
				from.FacialHairHue = from.HairHue;

				if ( from.Female )
				{
					from.Name = NameList.RandomName( "ork_female" );
				}
				else
				{
					from.Name = NameList.RandomName( "ork_male" );
				}

				if ( from.Region.IsPartOf( "the Azure Castle" ) )
				{
					from.Title = from.Title.Replace("the ork ", "");
				}
				else if ( from.Title != null && from.Title != "" )
				{
					from.Title = from.Title.Replace("the ork ", "the ");
					from.Title = from.Title.Replace("the ", "the ork ");
				}
			}
		}

		public static void TurnToMage( Mobile from )
		{
			if ( from is Humanoid )
				return;

			if ( from is Priest || 
				from is DruidGuildmaster || 
				from is Druid || 
				from is HealerGuildmaster || 
				from is Healer || 
				from is MageGuildmaster || 
				from is Mage || 
				from is NecromancerGuildmaster || 
				from is Witches || 
				from is Undertaker || 
				from is Necromancer || 
				from is EvilHealer || 
				from is WanderingHealer || 
				from is Enchanter || 
				from is TownGuards || 
				from is DruidTree || 
				from is Genie || 
				from is GypsyLady || 
				from is Sage )
			{
				// DON'T MORPH THESE TYPES
			}
			else
			{
				RemoveMyClothes( from );

				int robeHue = Utility.RandomColor( Utility.RandomMinMax( 0, 12 ) );

				if ( ( from.Body == 0x191 || from.Body == 606 ) && Utility.RandomBool() )
				{
					switch ( Utility.RandomMinMax( 1, 3 ) )
					{
						case 1: from.AddItem( new PlainDress( robeHue ) ); break;
						case 2: from.AddItem( new GildedDress( robeHue ) ); break;
						case 3: from.AddItem( new FancyDress( robeHue ) ); break;
					}
				}
				else
				{
					switch ( Utility.RandomMinMax( 1, 14 ) )
					{
						case 1: from.AddItem( new FancyRobe( robeHue ) ); break;
						case 2: from.AddItem( new GildedRobe( robeHue ) ); break;
						case 3: from.AddItem( new OrnateRobe( robeHue ) ); break;
						case 4: from.AddItem( new MagistrateRobe( robeHue ) ); break;
						case 5: from.AddItem( new RoyalRobe( robeHue ) ); break;
						case 6: from.AddItem( new ExquisiteRobe( robeHue ) ); break;
						case 7: from.AddItem( new ProphetRobe( robeHue ) ); break;
						case 8: from.AddItem( new ElegantRobe( robeHue ) ); break;
						case 9: from.AddItem( new FormalRobe( robeHue ) ); break;
						case 10: from.AddItem( new ArchmageRobe( robeHue ) ); break;
						case 11: from.AddItem( new PriestRobe( robeHue ) ); break;
						case 12: from.AddItem( new CultistRobe( robeHue ) ); break;
						case 13: from.AddItem( new SageRobe( robeHue ) ); break;
						case 14: from.AddItem( new ScholarRobe( robeHue ) ); break;
					}
				}

				switch ( Utility.RandomMinMax( 1, 10 ) )
				{
					case 1: from.AddItem( new Boots( Utility.RandomNeutralHue() ) ); break;
					case 2: from.AddItem( new BarbarianBoots( Utility.RandomNeutralHue() ) ); break;
					case 3: from.AddItem( new Boots( Utility.RandomNeutralHue() ) ); break;
					case 4: from.AddItem( new ThighBoots( Utility.RandomNeutralHue() ) ); break;
					case 5: from.AddItem( new Shoes( Utility.RandomNeutralHue() ) ); break;
					case 6: from.AddItem( new Sandals( Utility.RandomNeutralHue() ) ); break;
					case 7: from.AddItem( new ElvenBoots( Utility.RandomNeutralHue() ) ); break;
					case 8: from.AddItem( new Boots( Utility.RandomNeutralHue() ) ); break;
					case 9: from.AddItem( new Shoes( Utility.RandomNeutralHue() ) ); break;
					case 10: from.AddItem( new ElvenBoots( Utility.RandomNeutralHue() ) ); break;
				}

				if ( Utility.RandomBool() )
				{ 
					int myHat = Utility.RandomMinMax( 0, 4 );
					if ( from.Body == 605 ){ myHat = 1; }
					switch ( myHat )
					{
						case 0: from.AddItem( new ClothCowl( robeHue ) ); break;
						case 1: from.AddItem( new ClothHood( robeHue ) ); break;
						case 2: from.AddItem( new FancyHood( robeHue ) ); break;
						case 3: from.AddItem( new WizardHood( robeHue ) ); break;
						case 4: from.AddItem( new HoodedMantle( robeHue ) ); break;
					}
				}
				else
				{
					if ( ( from.Body == 0x191 || from.Body == 606 ) && Utility.RandomBool() )
					{
						from.AddItem( new WitchHat( robeHue ) );
					}
					else
					{
						from.AddItem( new WizardsHat( robeHue ) );
					}
				}
			}
		}

		public static void TurnToPirate( Mobile from )
		{
			if ( from is Humanoid )
				return;

			switch( Utility.RandomMinMax( 1, 3 ) )
			{
				case 1: from.AddItem( new SkullCap(Utility.RandomYellowHue()) );	break;
				case 2: from.AddItem( new TricorneHat(Utility.RandomYellowHue()) );	break;
				case 3: from.AddItem( new PirateHat(Utility.RandomYellowHue()) );	break;
			}
		}

		public static void TurnToElf( Mobile from )
		{
			if ( from is Humanoid )
				return;

			for ( int i = 0; i < from.Items.Count; ++i )
			{
				Item item = from.Items[i];

				if ( item is Hair || item is Beard )
					item.Delete();
			}

			from.Race = Race.Elf;

			int hairHue = Utility.RandomHairHue();
			Utility.AssignRandomHair( from, hairHue );
			from.FacialHairItemID = 0;
			from.Hue = Utility.RandomSkinColor(); 

			if ( from.Female )
			{
				from.Name = NameList.RandomName( "elf_female" );
				from.Body = 606;
			}
			else
			{
				from.Name = NameList.RandomName( "elf_male" );
				from.Body = 605;
			}

			if ( from.Title != null && from.Title != "" )
			{
				from.Title = from.Title.Replace("the elf ", "the ");
				from.Title = from.Title.Replace("the ", "the elf ");
			}
		}

		public static void TurnToGargoyle( Mobile from )
		{
			if ( from is Humanoid )
				return;

			from.Female = false;
			from.RaceMakeSounds = true;

			if ( from is TownGuards ){
				if ( Utility.RandomBool() )
				{
					from.Name = NameList.RandomName( "goblin" );
					Server.Items.NPCRace.CreateRace( from, 195, 0 );
				}
				else
				{
					from.Name = NameList.RandomName( "orc" );
					Server.Items.NPCRace.CreateRace( from, 650, 0 );
				}
			}
			else if ( from is Herbalist ){
				from.Name = NameList.RandomName( "author" );
				Server.Items.NPCRace.CreateRace( from, Utility.RandomList( 341, 342 ), 0 );
			}
			else if ( from is Elementalist ){
				from.Name = NameList.RandomName( "gargoyle vendor" );
				Server.Items.NPCRace.CreateRace( from, 126, 0 );
			}
			else if ( from is Bard ){
				from.Name = NameList.RandomName( "greek" );
				Server.Items.NPCRace.CreateRace( from, 271, 0 );
			}
			else if ( from is Jeweler ){
				from.Name = NameList.RandomName( "drakkul" );
				Server.Items.NPCRace.CreateRace( from, 138, 0 );
			}
			else if ( from is AnimalTrainer ){
				from.Name = NameList.RandomName( "evil witch" );
				Server.Items.NPCRace.CreateRace( from, 689, 0 );
			}
			else if ( from is Mage ){
				from.Name = NameList.RandomName( "author" );
				Server.Items.NPCRace.CreateRace( from, 93, 0 );
			}
			else if ( from is WarriorGuildmaster ){
				from.Name = NameList.RandomName( "gargoyle vendor" );
				Server.Items.NPCRace.CreateRace( from, 127, 0 );
			}
			else if ( from is KeeperOfChivalry ){
				from.Name = NameList.RandomName( "ork_male" );
				Server.Items.NPCRace.CreateRace( from, 65, 0 );
			}
			else if ( from is Tailor ){
				from.Name = NameList.RandomName( "tokuno female" );
				Server.Items.NPCRace.CreateRace( from, 436, 0 );
			}
			else if ( from is Healer ){
				from.Name = NameList.RandomName( "gargoyle vendor" );
				Server.Items.NPCRace.CreateRace( from, 88, 0 );
			}
			else if ( from is Cook ){
				from.Name = NameList.RandomName( "evil mage" );
				Server.Items.NPCRace.CreateRace( from, 509, 0 );
			}
			else if ( from is LeatherWorker ){
				from.Name = NameList.RandomName( "gargoyle vendor" );
				Server.Items.NPCRace.CreateRace( from, 765, 0 );
			}
			else if ( from is Courier ){
				from.Name = NameList.RandomName( "centaur" );
				Server.Items.NPCRace.CreateRace( from, 101, 0 );
			}
			else if ( from is Sage ){
				from.Name = NameList.RandomName( "greek" );
				Server.Items.NPCRace.CreateRace( from, 770, 0 );
			}
			else if ( from is Alchemist ){
				from.Name = NameList.RandomName( "urk" );
				Server.Items.NPCRace.CreateRace( from, 172, 0 );
			}
			else if ( from is Blacksmith ){
				from.Name = NameList.RandomName( "greek" );
				Server.Items.NPCRace.CreateRace( from, 774, 0 );
			}
			else if ( from is TownHerald ){
				from.Name = NameList.RandomName( "imp" );
				Server.Items.NPCRace.CreateRace( from, Utility.RandomList( 202, 359 ), 0 );
			}
			else if ( from is Glassblower ){
				from.Name = NameList.RandomName( "gargoyle vendor" );
				Server.Items.NPCRace.CreateRace( from, 38, 0 );
			}
			else if ( from is Weaponsmith ){
				from.Name = NameList.RandomName( "gargoyle vendor" );
				Server.Items.NPCRace.CreateRace( from, 320, 0 );
			}
			else if ( from is Druid ){
				from.Name = NameList.RandomName( "trees" );
				Server.Items.NPCRace.CreateRace( from, 313, 0 );
			}
			else if ( from is Scribe ){
				from.Name = NameList.RandomName( "author" );
				Server.Items.NPCRace.CreateRace( from, 306, 0 );
			}
			else if ( from is Fisherman ){
				from.Name = NameList.RandomName( "pixie" );
				Server.Items.NPCRace.CreateRace( from, 194, 0 );
			}
			else if ( from is Mapmaker ){
				from.Name = NameList.RandomName( "drakkul" );
				Server.Items.NPCRace.CreateRace( from, 678, 0 );
			}
			else if ( from is Shipwright ){
				from.Name = NameList.RandomName( "ancient lich" );
				Server.Items.NPCRace.CreateRace( from, 764, 0 );
			}
			else if ( from is Miner ){
				from.Name = NameList.RandomName( "greek" );
				Server.Items.NPCRace.CreateRace( from, 485, 0 );
			}
			else
			{
				switch ( Utility.RandomMinMax(1,6) )
				{
					case 1: 	from.Name = NameList.RandomName( "imp" );				Server.Items.NPCRace.CreateRace( from, 359, 0 );		break;
					case 2: 	from.Name = NameList.RandomName( "imp" );				Server.Items.NPCRace.CreateRace( from, 202, 0 );		break;
					case 3: 	from.Name = NameList.RandomName( "gargoyle vendor" );	Server.Items.NPCRace.CreateRace( from, 4, 0 );			break;
					case 4: 	from.Name = NameList.RandomName( "gargoyle vendor" );	Server.Items.NPCRace.CreateRace( from, 257, 0 );		break;
					case 5: 	from.Name = NameList.RandomName( "gargoyle name" );		Server.Items.NPCRace.CreateRace( from, 257, 0 );		break;
					case 6: 	from.Name = NameList.RandomName( "gargoyle name" );		Server.Items.NPCRace.CreateRace( from, 158, 0 );		break;
				}
			}
		}

		public static void TurnToSomethingOnDeath( Mobile from )
		{
			if ( from.Hue == 0x1C4 || from.Hue == 0x1C5 || from.Hue == 0x1C6 || from.Hue == 0x1C7 || from.Hue == 0x1C9 || from.Hue == 0x1CA || from.Hue == 0x1CB || from.Hue == 0x1CC || from.Hue == 0x1CE || from.Hue == 0x1CF || from.Hue == 0x1D0 || from.Hue == 0x1D1 )
			{
				from.Body = 17; // ORC
			}
			else if ( from.Hue == 0x845 )
			{
				from.Body = 4; // GARGOYLE
			}
		}

		public static void CapitalizeTitle( Mobile from )
		{
			string title = from.Title;

			if ( title == null )
				return;

			string[] split = title.Split( ' ' );

			for ( int i = 0; i < split.Length; ++i )
			{
				if ( Insensitive.Equals( split[i], "the" ) )
					continue;

				if ( split[i].Length > 1 )
					split[i] = Char.ToUpper( split[i][0] ) + split[i].Substring( 1 );
				else if ( split[i].Length > 0 )
					split[i] = Char.ToUpper( split[i][0] ).ToString();
			}

			from.Title = String.Join( " ", split );
		}

		public static string CapitalizeWords( string txt )
		{
			string[] split = txt.Split( ' ' );

			for ( int i = 0; i < split.Length; ++i )
			{
				if ( split[i].Length > 1 )
					split[i] = Char.ToUpper( split[i][0] ) + split[i].Substring( 1 );
				else if ( split[i].Length > 0 )
					split[i] = Char.ToUpper( split[i][0] ).ToString();
			}

			txt = String.Join( " ", split );

			return txt;
		}
	}
}

namespace Server.Scripts.Commands 
{
    public class HueGear
    {
        public static void Initialize()
        {
            CommandSystem.Register("HueGear", AccessLevel.Counselor, new CommandEventHandler( HueGears ));
        }

		[Usage( "HueGear <hue>" )]
        [Description("Colors your worn gear to the selected hue.")]
		public static void HueGears( CommandEventArgs arg )
		{
			if ( arg.Length != 1 )
			{
				arg.Mobile.SendMessage( "HueGear <hue>" );
			}
			else
			{
				string val = arg.GetString(0);

				int hue = 0;

				if ( val.Contains("0x") )
				{
					hue = Convert.ToInt32(val, 16);
				}
				else
				{
					hue = Int32.Parse(val);
				}

				Mobile m = arg.Mobile;

				if ( m.FindItemOnLayer( Layer.OuterTorso ) != null ) { m.FindItemOnLayer( Layer.OuterTorso ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.MiddleTorso ) != null ) { m.FindItemOnLayer( Layer.MiddleTorso ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.OneHanded ) != null ) { m.FindItemOnLayer( Layer.OneHanded ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.TwoHanded ) != null ) { m.FindItemOnLayer( Layer.TwoHanded ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.Bracelet ) != null ) { m.FindItemOnLayer( Layer.Bracelet ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.Ring ) != null ) { m.FindItemOnLayer( Layer.Ring ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.Helm ) != null ) { m.FindItemOnLayer( Layer.Helm ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.Arms ) != null ) { m.FindItemOnLayer( Layer.Arms ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.OuterLegs ) != null ) { m.FindItemOnLayer( Layer.OuterLegs ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.Neck ) != null ) { m.FindItemOnLayer( Layer.Neck ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.Gloves ) != null ) { m.FindItemOnLayer( Layer.Gloves ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.Trinket ) != null ) { m.FindItemOnLayer( Layer.Trinket ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.Shoes ) != null ) { m.FindItemOnLayer( Layer.Shoes ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.Cloak ) != null ) { m.FindItemOnLayer( Layer.Cloak ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.FirstValid ) != null ) { m.FindItemOnLayer( Layer.FirstValid ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.Waist ) != null ) { m.FindItemOnLayer( Layer.Waist ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.InnerLegs ) != null ) { m.FindItemOnLayer( Layer.InnerLegs ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.InnerTorso ) != null ) { m.FindItemOnLayer( Layer.InnerTorso ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.Pants ) != null ) { m.FindItemOnLayer( Layer.Pants ).Hue = hue; }
				if ( m.FindItemOnLayer( Layer.Shirt ) != null ) { m.FindItemOnLayer( Layer.Shirt ).Hue = hue; }
			}
		}
	}
}