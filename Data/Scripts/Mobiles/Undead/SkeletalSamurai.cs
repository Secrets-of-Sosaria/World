using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a skeletal corpse" )]
	public class SkeletalSamurai : BaseCreature
	{
		[Constructable]
		public SkeletalSamurai() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a skeletal samurai";
			Body = 247;
			BaseSoundID = 451;

			SetStr( 196, 250 );
			SetDex( 76, 95 );
			SetInt( 36, 60 );

			SetHits( 118, 150 );

			SetDamage( 8, 18 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Cold, 60 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 85.1, 100.0 );
			SetSkill( SkillName.FistFighting, 85.1, 95.0 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 40;
			
			switch ( Utility.Random( 6 ) )
			{
				case 0: Item drop1 = new PlateArms(); 		drop1.Hue = 0x539;	drop1.ItemID = 0x2780; drop1.Name = "plate kote";		PackItem( drop1 );	break;
				case 1: Item drop2 = new PlateChest();		drop2.Hue = 0x539;	drop2.ItemID = 0x277D; drop2.Name = "plate do";			PackItem( drop2 );	break;
				case 2: Item drop3 = new PlateGloves();		drop3.Hue = 0x539;   														PackItem( drop3 );	break;
				case 3: Item drop4 = new PlateGorget();		drop4.Hue = 0x539;															PackItem( drop4 );	break;
				case 4: Item drop5 = new PlateLegs();		drop5.Hue = 0x539;	drop5.ItemID = 0x2788; drop5.Name = "plate suneate";	PackItem( drop5 );	break;
				case 5: Item drop6 = new PlateHelm();		drop6.Hue = 0x539;	drop6.ItemID = 0x2785; drop6.Name = "plate kabuto";		PackItem( drop6 );	break;
			}

			PackItem( new Katana() );
			PackItem( new Katana() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override int Skeletal{ get{ return Utility.Random(3); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Brittle; } }

		public SkeletalSamurai( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}