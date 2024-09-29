using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a snake corpse" )]
	public class Snake : BaseCreature
	{
		[Constructable]
		public Snake() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a snake";
			Body = Utility.RandomList( 52, 950, 963 );
			Hue = Utility.RandomSnakeHue();
			BaseSoundID = 0xDB;

			SetStr( 22, 34 );
			SetDex( 16, 25 );
			SetInt( 6, 10 );

			SetHits( 15, 19 );
			SetMana( 0 );

			SetDamage( 1, 4 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Poison, 20, 30 );

			SetSkill( SkillName.Poisoning, 50.1, 70.0 );
			SetSkill( SkillName.MagicResist, 15.1, 20.0 );
			SetSkill( SkillName.Tactics, 19.3, 34.0 );
			SetSkill( SkillName.FistFighting, 19.3, 34.0 );

			Fame = 300;
			Karma = -300;

			VirtualArmor = 16;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 59.1;

			Item Venom = new VenomSack();
				Venom.Name = "lesser venom sack";
				AddItem( Venom );

			if ( Body == 963 )
			{
				Hue = 0;
				MinTameSkill = 62.1;
				Fame = 350;
				Karma = -350;
				VirtualArmor = 18;
				SetStr( 32, 44 );
				SetDex( 26, 45 );
				SetHits( 25, 29 );
				SetDamage( 3, 7 );
			}
			else if ( Body == 950 )
			{
				MinTameSkill = 66.1;
				Fame = 400;
				Karma = -400;
				VirtualArmor = 20;
				SetStr( 42, 54 );
				SetDex( 36, 35 );
				SetHits( 35, 39 );
				SetDamage( 5, 9 );
			}
		}

		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }
		public override Poison HitPoison{ get{ return Poison.Lesser; } }
		public override bool DeathAdderCharmable{ get{ return true; } }
		public override int Hides{ get{ return 1; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Eggs; } }

		public Snake(Serial serial) : base(serial)
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
}