using System;
using Server;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Items;
using Server.Regions;
using Server.Spells;
using Server.Network;
using Server.Multis;
using Server.Misc;
using System.Collections;

namespace Server.Items 
{
	public class TenFootPole : Item
	{
		public override void ResourceChanged( CraftResource resource )
		{
			if ( !ResourceCanChange() )
				return;

			ResourceMods.Modify( this, true );
			m_Resource = resource;
			Hue = CraftResources.GetHue(m_Resource);
			Name = CraftResources.GetTradeItemFullName( this, m_Resource, false, false, "ten foot pole" );
			ResourceMods.Modify( this, false );
			InvalidateProperties();
		}

		public override CraftResource DefaultResource{ get{ return CraftResource.RegularWood; } }

		public override string DefaultDescription{ get{ return "This heavy wooden pole allows you to trap the floor ahead of you to maybe detect a trap before you trigger it. It will also tap containers before you try to open them, also in the hopes of avoiding a trap. You need only keep the pole in your bag, as it will passively be used as you explore areas."; } }

		private int m_Tap;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Tap
		{
			get{ return m_Tap; }
			set{ m_Tap = value; InvalidateProperties(); }
		}

		[Constructable]
		public TenFootPole( ) : base( 0xE8A )
		{		
			Weight = 40.0; 
			Name = "ten foot pole";
			LimitsMax = 20;
			Limits = 20;
			LimitsName = "Uses";
			LimitsDelete = true;
			m_Tap = 50;
			CoinPrice = 20;
		}

		public static void Material( Item pole, int level )
		{
			TenFootPole stick = (TenFootPole)pole;
			int pick = Utility.RandomMinMax(1,level) + 2;

			if ( pick < 2 )
				stick.Resource = CraftResource.RegularWood;
			else if ( pick > 14 )
				stick.Resource = CraftResource.ElvenTree;

			switch( pick )
			{
				case 1: stick.Resource = CraftResource.AshTree;			break;
				case 2: stick.Resource = CraftResource.CherryTree;		break;
				case 3: stick.Resource = CraftResource.EbonyTree;		break;
				case 4: stick.Resource = CraftResource.GoldenOakTree;	break;
				case 5: stick.Resource = CraftResource.HickoryTree;		break;
				case 6: stick.Resource = CraftResource.MahoganyTree;	break;
				case 7: stick.Resource = CraftResource.DriftwoodTree;	break;
				case 8: stick.Resource = CraftResource.OakTree;			break;
				case 9: stick.Resource = CraftResource.PineTree;		break;
				case 10: stick.Resource = CraftResource.GhostTree;		break;
				case 11: stick.Resource = CraftResource.RosewoodTree;	break;
				case 12: stick.Resource = CraftResource.WalnutTree;		break;
				case 13: stick.Resource = CraftResource.PetrifiedTree;	break;
				case 14: stick.Resource = CraftResource.ElvenTree;		break;
			}
		}

		public TenFootPole( Serial serial ) : base( serial )
		{ 
		} 
		
		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 1 ); // version
			writer.Write( (int) m_Tap );
		} 
		
		public override void Deserialize(GenericReader reader) 
		{
			int nul = 0;

			base.Deserialize( reader ); 
			int version = reader.ReadInt();

			if ( version > 0 )
			{
				m_Tap = (int)reader.ReadInt();
			}
			if ( version < 1 )
			{
				nul = (int)reader.ReadInt();
				LimitsMax = nul;
				Limits = nul;
				LimitsName = "Uses";
				LimitsDelete = true;

				if ( Weight == 39.0 ){			Resource = CraftResource.AshTree; }
				else if ( Weight == 38.0 ){		Resource = CraftResource.CherryTree; }
				else if ( Weight == 37.0 ){		Resource = CraftResource.EbonyTree; }
				else if ( Weight == 36.0 ){		Resource = CraftResource.GoldenOakTree; }
				else if ( Weight == 35.0 ){		Resource = CraftResource.HickoryTree; }
				else if ( Weight == 34.0 ){		Resource = CraftResource.MahoganyTree; }
				else if ( Weight == 33.0 ){		Resource = CraftResource.DriftwoodTree; }
				else if ( Weight == 32.0 ){		Resource = CraftResource.OakTree; }
				else if ( Weight == 31.0 ){		Resource = CraftResource.PineTree; }
				else if ( Weight == 30.0 ){		Resource = CraftResource.GhostTree; }
				else if ( Weight == 29.0 ){		Resource = CraftResource.RosewoodTree; }
				else if ( Weight == 28.0 ){		Resource = CraftResource.WalnutTree; }
				else if ( Weight == 27.0 ){		Resource = CraftResource.PetrifiedTree; }
				else if ( Weight == 26.0 ){		Resource = CraftResource.ElvenTree; }
				else { 							Resource = CraftResource.RegularWood; }
			}
		}
	}
}