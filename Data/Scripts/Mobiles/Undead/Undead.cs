using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an undead corpse" )]
	public class Undead : BaseCreature
	{
		[Constructable]
		public Undead() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a frail skeleton";
			Body = Utility.RandomList( 50, 56, 167 );
			BaseSoundID = 0x48D;

			int undead = Utility.RandomMinMax( 1, 10 );
			switch( undead )
			{
				case 1:
					Name = "a skeleton";
					Body = Utility.RandomList( 57, 168, 170, 50, 56, 167 );
					BaseSoundID = 451;
				break;
				case 2:
					Body = Utility.RandomList( 3, 728 );
					BaseSoundID = 471;
					switch( Utility.RandomMinMax( 0, 9 ) )
					{
						case 0: Name = "a zombie";			break;
						case 1: Name = "a walking dead";	break;
						case 2: Name = "a corpse";			break;
						case 3: Name = "a rotten corpse";	break;
						case 4: Name = "an undead corpse";	break;
						case 5: Name = "a rotting zombie";	break;
						case 6: Name = "a zombie";			break;
						case 7: Name = "a decaying zombie";	break;
						case 8: Name = "a decaying corpse";	break;
						case 9: Name = "a walking corpse";	break;
					}

					Hue = 0xB97;
					switch( Utility.RandomMinMax( 0, 12 ) )
					{
						case 0: Hue = 0x83B;	break;
						case 1: Hue = 0x89F;	break;
						case 2: Hue = 0x8A0;	break;
						case 3: Hue = 0x8A1;	break;
						case 4: Hue = 0x8A2;	break;
						case 5: Hue = 0x8A3;	break;
						case 6: Hue = 0x8A4;	break;
					}
				break;
				case 3:
					Name = "a ghoul";
					Body = 181;
					BaseSoundID = 471;
				break;
				case 4:
					Name = "a mummy";
					Body = 154;
					BaseSoundID = 471;
				break;
				case 5:
					Name = "a wight";
					Body = 307;
					BaseSoundID = 471;
				break;
				case 6:
					Name = "a shade";
					Body = 26;
					Hue = 0x4001;
					BaseSoundID = 0x482;
				break;
				case 7:
					Name = "a spectre";
					Body = 26;
					BaseSoundID = 0x482;
				break;
				case 8:
					Name = "a spirit";
					Body = 84;
					BaseSoundID = 0x482;
					Hue = 0x47E;
				break;
				case 9:
					Name = "a vampyre";
					Body = 124;
					BaseSoundID = 0x47D;
				break;
				case 10:
					Name = "a wraith";
					Body = 84;
					Hue = 0x9C2;
					BaseSoundID = 0x482;
				break;
			}

			if ( undead == 1 )
			{
				int[] list = new int[]
					{
						0x1B11, 0x1B12, 0x1B13, 0x1B14, 0x1B15, 0x1B16, 0x1B19, 0x1B1A, // bone parts
						0x1AE0, 0x1AE1, 0x1AE2, 0x1AE3, 0x1AE4, // skulls
						0x1B17, 0x1B18, 0x1B1B, 0x1B1C, // ribs and spines
						0x1B09, 0x1B0A, 0x1B0B, 0x1B0C, 0x1B0D, 0x1B0E, 0x1B0F, 0x1B10, // bone piles
						0xECA, 0xECB, 0xECC, 0xECD, 0xECE, 0xECF, 0xED0, 0xED1, 0xED2 // bones
					};

				PackItem( new BodyPart( Utility.RandomList( list ) ) );
			}
			else if ( undead < 6 )
			{
				int[] list = new int[]
					{
						0x1CF0, 0x1CEF, 0x1CEE, 0x1CED, 0x1CE9, 0x1DA0, 0x1DAE, // pieces
						0x1CEC, 0x1CE5, 0x1CE2, 0x1CDD, 0x1AE4, 0x1DA1, 0x1DA2, 0x1DA4, 0x1DAF, 0x1DB0, 0x1DB1, 0x1DB2, // limbs
						0x1CE8, 0x1CE0, 0x1D9F, 0x1DAD // torsos
					};

				PackItem( new BodyPart( Utility.RandomList( list ) ) );
			}

			SetStr( 26, 40 );
			SetDex( 26, 35 );
			SetInt( 6, 10 );

			SetHits( 24, 38 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 25, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 5, 15 );

			SetSkill( SkillName.MagicResist, 45.1, 60.0 );
			SetSkill( SkillName.Tactics, 45.1, 60.0 );
			SetSkill( SkillName.FistFighting, 45.1, 55.0 );

			Fame = 200;
			Karma = -200;

			VirtualArmor = 4;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }

		public Undead( Serial serial ) : base( serial )
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