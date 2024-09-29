using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class Critter : BaseCreature
	{
		[Constructable]
		public Critter() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a rat";
			Body = 238;
			BaseSoundID = 0xCC;

			SetStr( 4 );
			SetDex( 12 );
			SetInt( 2 );

			SetHits( 6 );
			SetMana( 0 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Physical, 5, 10 );

			SetSkill( SkillName.MagicResist, 4.0 );
			SetSkill( SkillName.Tactics, 4.0 );
			SetSkill( SkillName.FistFighting, 4.0 );

			Fame = 0;
			Karma = 0;

			VirtualArmor = 1;
		}

        public override void OnAfterSpawn()
        {
			Morph();
			base.OnAfterSpawn();
		}

		public override Poison HitPoison{ get{ return (Body == 817 ? Poison.Lesser : null); } }

		public void Morph()
		{
			int setup = Utility.RandomMinMax( 1, 5 );

			if ( Terrain == Terrain.Forest )
				setup = Utility.RandomList( 1, 2, 5 );
			else if ( Terrain == Terrain.Sand )
				setup = Utility.RandomList( 1, 4, 5 );
			else if ( Terrain == Terrain.Jungle )
				setup = Utility.RandomList( 1, 2, 3, 5 );
			else if ( Terrain == Terrain.Grass )
				setup = Utility.RandomList( 2, 5 );
			else if ( Terrain == Terrain.Snow )
				Delete();
			else if ( Terrain == Terrain.Swamp )
				setup = Utility.RandomList( 1, 2, 3 );
			else if ( Terrain == Terrain.Dirt )
				setup = Utility.RandomList( 2 );

			switch ( setup ) 
			{
				case 1: Name = "a lizard";		Body = 382;		break;
				case 2: Name = "a beetle";		Body = 383;		break;
				case 3: Name = "a frog";		Body = 816;		break;
				case 4: Name = "a scorpion";	Body = 817;		break;
				case 5: Name = "a spider";		Body = 829;		break;
			}

			if ( Body == 382 || Body == 816 )
				Hue = Utility.RandomList( 0x7D1, 0x7D2, 0x7D3, 0x7D4, 0x7D5, 0x7D6, 0x7D7, 0x7D8, 0x7D9, 0x7DA, 0x7DB, 0x7DC );
		}

		public override bool OnBeforeDeath()
		{
			if ( Body == 382 )
				PackItem( new RawRibs() );
			else if ( Body == 383 )
				PackItem( new BeetleShell() );
			else if ( Body == 816 && Utility.RandomBool() )
				PackItem( new EyeOfToad() );
			else if ( Body == 816 )
				PackItem( new DriedToad() );
			else if ( Body == 817 )
			{
				Item Venom = new VenomSack();
				Venom.Name = "lesser venom sack";
				PackItem( Venom );
			}
			else if ( Body == 829 )
				PackItem( new SilverWidow() );

			return base.OnBeforeDeath();
		}

		public Critter(Serial serial) : base(serial)
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