using System;
using Server;

namespace Server.Items
{
	public class SciFiJunk : Item
	{
		public override int Hue{ get{ return 0; } }

		[Constructable]
		public SciFiJunk() : base( 0x27FE )
		{
			Name = "broken plastic bottle";
			Technology = true;
			Weight = 1.0 * Utility.RandomMinMax(1,5);
			Resource = CraftResource.Iron;
			SubResource = ResourceMods.SciFiResource( CraftResource.Iron );

			CoinPrice = Utility.RandomMinMax(60,520);

			switch( Utility.RandomMinMax( 1, 60 ) )
			{
				case 1: ItemID = 0x3562; Name = "binoculars";  break;
				case 2: ItemID = 0x2021; Name = "bolt";  break;
				case 3: ItemID = 0x2022; Name = "bulb";  break;
				case 4: ItemID = 0x2023; Name = "can";  break;
				case 5: ItemID = 0x2024; Name = "chips";  break;
				case 6: ItemID = 0x346D; Name = "circuit board";  break;
				case 7: ItemID = 0x33FF; Name = "coil";  break;
				case 8: ItemID = 0x2025; Name = "communicator";  break;
				case 9: ItemID = 0x2026; Name = "conduit";  break;
				case 10: ItemID = 0x2027; Name = "connector";  break;
				case 11: ItemID = 0x2029; Name = "coupler";  break;
				case 12: ItemID = 0x3A75; Name = "data card";  break;
				case 13: ItemID = 0x27FB; Name = "data pad";  break;
				case 14: ItemID = 0x34BC; Name = "deck plate";  break;
				case 15: ItemID = 0x34C1; Name = "engine";  break;
				case 16: ItemID = 0x34C6; Name = "expansion board";  break;
				case 17: ItemID = 0x34D6; Name = "filter";  break;
				case 18: ItemID = 0x3563; Name = "fire extinguisher";  break;
				case 19: ItemID = 0x34D7; Name = "fuel can";  break;
				case 20: ItemID = 0x3542; Name = "gas mask";  break;
				case 21: ItemID = 0x202C; Name = "gear";  break;
				case 22: ItemID = 0x202D; Name = "gear";  break;
				case 23: ItemID = 0x202E; Name = "gear";  break;
				case 24: ItemID = 0x2FB8; Name = "goggles";  break;
				case 25: ItemID = 0x34D8; Name = "hull plate";  break;
				case 26: ItemID = 0x202F; Name = "lense";  break;
				case 27: ItemID = 0x2028; Name = "levers";  break;
				case 28: ItemID = 0x27FD; Name = "medical case";  break;
				case 29: ItemID = 0x3461; Name = "meter";  break;
				case 30: ItemID = 0x2030; Name = "hex nuts";  break;
				case 31: ItemID = 0x3543; Name = "oil can";  break;
				case 32: ItemID = 0x2031; Name = "phaser";  break;
				case 33: ItemID = 0x96F; Name = "plasma grenade";  break;
				case 34: ItemID = 0x27FE; Name = "plastic bottle"; break;
				case 35: ItemID = 0x2032; Name = "plug";  break;
				case 36: ItemID = 0x2033; Name = "processor";  break;
				case 37: ItemID = 0x202B; Name = "puzzle cube";  break;
				case 38: ItemID = 0x2034; Name = "relay";  break;
				case 39: ItemID = 0x2035; Name = "remote";  break;
				case 40: ItemID = 0x2036; Name = "rivet";  break;
				case 41: ItemID = 0x343A; Name = "roll of tape";  break;
				case 42: ItemID = 0x270F; Name = "saw";  break;
				case 43: ItemID = 0x2A2F; Name = "screwdriver";  break;
				case 44: ItemID = 0x3544; Name = "sheet metal";  break;
				case 45: ItemID = 0x27FF; Name = "syringe";  break;
				case 46: ItemID = 0x3446; Name = "transistor";  break;
				case 47: ItemID = 0x344D; Name = "tube";  break;
				case 48: ItemID = 0x3458; Name = "washers";  break;
				case 49: ItemID = 0x2D86; Name = "welder";  break;
				case 50: ItemID = 0x2D0D; Name = "wire";  break;
				case 51: ItemID = 0x3467; Name = "wire";  break;
				case 52: ItemID = 0x3545; Name = "wrench";  break;
				case 53: ItemID = 0x3EA2; Name = "landmine";  break;
				case 54: ItemID = 0x48E4; Name = "canteen";  break;
				case 55: ItemID = 0x3F65; Name = "bowcaster";  break;
				case 56: ItemID = 0x3F8F; Name = "bowcaster";  break;
				case 57: ItemID = 0x4C14; Name = "detonator";  break;
				case 58: ItemID = 0x4C13; Name = "machine";  break;
				case 59: ItemID = Utility.RandomMinMax( 0x5408, 0x5409 ); Name = "chainsaw";  break;
				case 60: ItemID = Utility.RandomMinMax( 0x540A, 0x540B ); Name = "portable smelter";  break;
			}

			Name = RandomCondition() + " " + Name;
		}

		public SciFiJunk( Serial serial ) : base( serial )
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

		public static string RandomCondition()
		{
			string condition = "broken";
			switch( Utility.RandomMinMax( 1, 6 ) )
			{
				case 1: condition = "broken";		break;
				case 2: condition = "ruined";		break;
				case 3: condition = "busted";		break;
				case 4: condition = "damaged";		break;
				case 5: condition = "defective";	break;
				case 6: condition = "wrecked";		break;
			}

			return condition;
		}
	}
}