using System;
using System.Collections;
using Server.Targeting;
using Server.Items;
using Server.Misc;
using Server.Engines.Harvest;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
	public class FishingPole : BaseHarvestTool
	{
		public override HarvestSystem HarvestSystem{ get{ return Fishing.System; } }

		public override string DefaultDescription{ get{ return "When held in your hand, these fishing poles can be used, where you target a spot on the water you wish to fish. You may catch something. You will only get better at seafaring to a certain point, where you will eventually need to fish on the high seas from your ship."; } }

		public override CraftResource DefaultResource{ get{ return CraftResource.RegularWood; } }

		[Constructable]
		public FishingPole() : this( 50 )
		{
		}

		[Constructable]
		public FishingPole( int uses ) : base( uses, 0x6606 )
		{
			Name = "fishing pole";
			Weight = 8.0;
		}

		public FishingPole( Serial serial ) : base( serial )
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
			ItemID = 0x6606;

			if ( Resource == CraftResource.RegularWood )
				Hue = ResourceMods.DefaultItemHue( this );

			NeedsBothHands = false;
		}

		public static void RandomPole( FishingPole pole )
		{
			switch( Utility.RandomMinMax(1,14) )
			{
				case 1: pole.Resource = CraftResource.AshTree;			break;
				case 2: pole.Resource = CraftResource.CherryTree;		break;
				case 3: pole.Resource = CraftResource.EbonyTree;		break;
				case 4: pole.Resource = CraftResource.GoldenOakTree;	break;
				case 5: pole.Resource = CraftResource.HickoryTree;		break;
				case 6: pole.Resource = CraftResource.MahoganyTree;		break;
				case 7: pole.Resource = CraftResource.DriftwoodTree;	break;
				case 8: pole.Resource = CraftResource.OakTree;			break;
				case 9: pole.Resource = CraftResource.PineTree;			break;
				case 10: pole.Resource = CraftResource.GhostTree;		break;
				case 11: pole.Resource = CraftResource.RosewoodTree;	break;
				case 12: pole.Resource = CraftResource.WalnutTree;		break;
				case 13: pole.Resource = CraftResource.PetrifiedTree;	break;
				case 14: pole.Resource = CraftResource.ElvenTree;		break;
			}
		}
	}
}