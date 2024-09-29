using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a mammoth corpse" )]
	public class Mammoth : Elephant
	{
		[Constructable]
		public Mammoth()
		{
			Name = "a mammoth";
			Body = 997;
			Hue = 0xB3A;

			SetStr( 326, 355 );
			SetDex( 81, 105 );
			SetInt( 16, 40 );

			SetHits( 276, 293 );

			SetDamage( 14, 20 );

			Fame = 3000;

			VirtualArmor = 35;

			ControlSlots = 2;
			MinTameSkill = 89.1;
		}

		public override ClothType ClothType{ get{ return ClothType.Wooly; } }
		public override HideType HideType{ get{ return HideType.Frozen; } }
		public override int Cloths{ get{ return 16; } }
		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay | FoodType.FruitsAndVegies; } }

		public override void OnAfterSpawn()
		{
			Region reg = Region.Find( this.Location, this.Map );

			if ( reg.IsPartOf( "the Glacial Scar" ) )
			{
				AI = AIType.AI_Melee;
				FightMode = FightMode.Closest;
				Tamable = false;
				NameHue = 0x22;
			}

			base.OnAfterSpawn();
		}

		public Mammoth( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = 997;
			Hue = 0xB3A;
		}
	}
}