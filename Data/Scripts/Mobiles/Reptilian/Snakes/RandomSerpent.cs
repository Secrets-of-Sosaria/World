using System;
using Server;
using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName("an anaconda corpse")]
	public class RandomSerpent : BaseCreature
	{
		public static Poison m_Poison;
		public static int m_Treasure;

		[Constructable]
		public RandomSerpent() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Body = 21;
			BaseSoundID = 219;
			Name = "an anaconda";

			int difficulty = 0;

			switch ( Utility.RandomMinMax( 1, 5 ) )
			{
				case 1:	m_Poison = Poison.Lethal; 	difficulty = 60;	m_Treasure = Utility.RandomMinMax( 1, 5 );		Item Venom1 = new VenomSack(); Venom1.Name = "lethal venom sack"; AddItem( Venom1 );	break;
				case 2:	m_Poison = Poison.Deadly; 	difficulty = 45;	m_Treasure = Utility.RandomMinMax( 1, 4 );		Item Venom2 = new VenomSack(); Venom2.Name = "deadly venom sack"; AddItem( Venom2 );	break;
				case 3:	m_Poison = Poison.Greater; 	difficulty = 30;	m_Treasure = Utility.RandomMinMax( 1, 3 );		Item Venom3 = new VenomSack(); Venom3.Name = "greater venom sack"; AddItem( Venom3 );	break;
				case 4:	m_Poison = Poison.Regular; 	difficulty = 15;	m_Treasure = Utility.RandomMinMax( 1, 2 );		Item Venom4 = new VenomSack(); Venom4.Name = "venom sack"; AddItem( Venom4 );			break;
				case 5:	m_Poison = Poison.Lesser; 	difficulty = 0;		m_Treasure = Utility.RandomMinMax( 1, 1 );		Item Venom5 = new VenomSack(); Venom5.Name = "lesser venom sack"; AddItem( Venom5 );	break;
			}

			SetStr( (130+difficulty), (340+difficulty) );
			SetDex( (130+difficulty), (280+difficulty) );
			SetInt( (10+difficulty), (20+difficulty) );

			SetDamage( 5, 9 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Poison, 50 );

			SetResistance( ResistanceType.Physical, (10+difficulty) );
			SetResistance( ResistanceType.Fire, (5+((int)(difficulty/2))) );
			SetResistance( ResistanceType.Cold, (5+((int)(difficulty/2))) );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, (5+((int)(difficulty/2))) );

			SetSkill( SkillName.Poisoning, (40+difficulty) );
			SetSkill( SkillName.MagicResist, ((int)(difficulty/2)) );
			SetSkill( SkillName.Tactics, (40+difficulty) );
			SetSkill( SkillName.FistFighting, (40+difficulty));

			Fame = (1400 + (difficulty * 1000));
			Karma = -(1400 + (difficulty * 1000));

			VirtualArmor = (20+((int)(difficulty/2)));
		}

		public override void OnAfterSpawn()
		{
			Resource = CraftResource.MetallicScales;
			switch ( Utility.RandomMinMax( 0, 10 ) )
			{
				case 0: Resource = CraftResource.RedScales; break;
				case 1: Resource = CraftResource.YellowScales; break;
				case 2: Resource = CraftResource.BlackScales; break;
				case 3: Resource = CraftResource.GreenScales; break;
				case 4: Resource = CraftResource.WhiteScales; break;
				case 5: Resource = CraftResource.BlueScales; break;
				case 6: Resource = CraftResource.MetallicScales; break;
				case 7: Resource = CraftResource.BrazenScales; break;
				case 8: Resource = CraftResource.UmberScales; break;
				case 9: Resource = CraftResource.VioletScales; break;
				case 10: Resource = CraftResource.PlatinumScales; break;
			}

			Hue = CraftResources.GetClr(Resource);

			base.OnAfterSpawn();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, m_Treasure );
		}

		public override bool DeathAdderCharmable{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override Poison PoisonImmune{ get{ return m_Poison; } }
		public override Poison HitPoison{ get{ return m_Poison; } }
		public override int Hides{ get{ return 15; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override int Scales{ get{ return Utility.RandomMinMax( 2, 4 ); } }
		public override ScaleType ScaleType{ get{ return ResourceScales(); } }
		public override int Skin{ get{ return Utility.Random(3); } }
		public override SkinType SkinType{ get{ return SkinType.Snake; } }

		public RandomSerpent(Serial serial) : base(serial)
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

			if ( BaseSoundID == -1 )
				BaseSoundID = 219;
		}
	}
}