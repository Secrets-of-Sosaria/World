using System;
using Server;
using Server.Mobiles;

namespace Server.Items 
{ 
	public class BaseCaged : Item 
	{
		public string AnimalType;
		[CommandProperty(AccessLevel.Owner)]
		public string Animal_Type { get { return AnimalType; } set { AnimalType = value; InvalidateProperties(); } }

		[Constructable] 
		public BaseCaged() : base( 0x570B ) 
		{
			AnimalType = "Rabbit";
			Name = "cage rabbit";
			Weight = 50.0;
		}

		public override void OnDoubleClick( Mobile from )
		{
			ProcessCage( from );
		}

		public bool ProcessCage( Mobile from )
		{
			Type animalType = ScriptCompiler.FindTypeByName( AnimalType );
			Mobile animal = (Mobile)Activator.CreateInstance( animalType );
			BaseCreature pet = (BaseCreature)animal;

			if ( (from.Followers + pet.ControlSlots) > from.FollowersMax )
			{
				from.SendMessage("You have too many followers to open this cage!");
				return false;
			}
			else
			{
				if ( ItemID == 0x570F )
					from.PlaySound(0x056);
				else
					from.PlaySound(0x02F);

				pet.Controlled = true;
				pet.ControlMaster = from;
				pet.MoveToWorld( from.Location, from.Map );
				pet.ControlTarget = from;
				pet.Tamable = true;

				if ( pet.MinTameSkill > 29.0 ){ pet.MinTameSkill = 29.1; }
				else if ( pet.MinTameSkill <= 0.0 ){ pet.MinTameSkill = 29.1; }
				
				pet.ControlOrder = OrderType.Follow;

				this.Delete();
			}
			return true;
		}

		public static int Cage( string size )
		{
			int item = 0;

			if ( size == "large" ){ item = 0x570F; }
			else if ( size == "medium" ){ item = Utility.RandomList(0x570B,0x570C); }
			else { item = Utility.RandomList(0x570D,0x570E); }

			return item;
		}

		public BaseCaged( Serial serial ) : base( serial ) 
		{ 
		}

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 0 ); 
			writer.Write( AnimalType );
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt(); 
			AnimalType = reader.ReadString();
		} 
	}

	public class CagedRabbit : BaseCaged 
	{
		[Constructable] 
		public CagedRabbit()
		{
			AnimalType = "Rabbit";
			Name = "rabbit";
			ItemID = Cage( "small" );
		}

		public CagedRabbit( Serial serial ) : base( serial ) 
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

	public class CagedHorse : BaseCaged 
	{
		[Constructable] 
		public CagedHorse()
		{
			AnimalType = "Horse";
			Name = "horse";
			ItemID = Cage( "medium" );
		}

		public CagedHorse( Serial serial ) : base( serial ) 
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

	public class CagedAlligator : BaseCaged
	{
		[Constructable] 
		public CagedAlligator()
		{
			AnimalType = "Alligator";
			Name = "alligator";
			ItemID = Cage( "medium" );
		}

		public CagedAlligator( Serial serial ) : base( serial ) 
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

	public class CagedApe : BaseCaged
	{
		[Constructable] 
		public CagedApe()
		{
			AnimalType = "Ape";
			Name = "ape";
			ItemID = Cage( "medium" );
		}

		public CagedApe( Serial serial ) : base( serial ) 
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

	public class CagedBlackBear : BaseCaged
	{
		[Constructable] 
		public CagedBlackBear()
		{
			AnimalType = "BlackBear";
			Name = "black bear";
			ItemID = Cage( "medium" );
		}

		public CagedBlackBear( Serial serial ) : base( serial ) 
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

	public class CagedBlackWolf : BaseCaged
	{
		[Constructable] 
		public CagedBlackWolf()
		{
			AnimalType = "BlackWolf";
			Name = "black wolf";
			ItemID = Cage( "medium" );
		}

		public CagedBlackWolf( Serial serial ) : base( serial ) 
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

	public class CagedBoar : BaseCaged
	{
		[Constructable] 
		public CagedBoar()
		{
			AnimalType = "Boar";
			Name = "boar";
			ItemID = Cage( "small" );
		}

		public CagedBoar( Serial serial ) : base( serial ) 
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

	public class CagedBobcat : BaseCaged
	{
		[Constructable] 
		public CagedBobcat()
		{
			AnimalType = "Bobcat";
			Name = "bobcat";
			ItemID = Cage( "small" );
		}

		public CagedBobcat( Serial serial ) : base( serial ) 
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

	public class CagedBrownBear : BaseCaged
	{
		[Constructable] 
		public CagedBrownBear()
		{
			AnimalType = "BrownBear";
			Name = "brown bear";
			ItemID = Cage( "medium" );
		}

		public CagedBrownBear( Serial serial ) : base( serial ) 
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

	public class CagedBull : BaseCaged
	{
		[Constructable] 
		public CagedBull()
		{
			AnimalType = "Bull";
			Name = "bull";
			ItemID = Cage( "medium" );
		}

		public CagedBull( Serial serial ) : base( serial ) 
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

	public class CagedCat : BaseCaged
	{
		[Constructable] 
		public CagedCat()
		{
			AnimalType = "Cat";
			Name = "cat";
			ItemID = Cage( "small" );
		}

		public CagedCat( Serial serial ) : base( serial ) 
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

	public class CagedCaveBearRiding : BaseCaged
	{
		[Constructable] 
		public CagedCaveBearRiding()
		{
			AnimalType = "CaveBearRiding";
			Name = "cave bear";
			ItemID = Cage( "large" );
		}

		public CagedCaveBearRiding( Serial serial ) : base( serial ) 
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

	public class CagedChicken : BaseCaged
	{
		[Constructable] 
		public CagedChicken()
		{
			AnimalType = "Chicken";
			Name = "chicken";
			ItemID = Cage( "small" );
		}

		public CagedChicken( Serial serial ) : base( serial ) 
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

	public class CagedTurkey : BaseCaged
	{
		[Constructable] 
		public CagedTurkey()
		{
			AnimalType = "Turkey";
			Name = "turkey";
			ItemID = Cage( "small" );
		}

		public CagedTurkey( Serial serial ) : base( serial ) 
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

	public class CagedCougar : BaseCaged
	{
		[Constructable] 
		public CagedCougar()
		{
			AnimalType = "Cougar";
			Name = "cougar";
			ItemID = Cage( "small" );
		}

		public CagedCougar( Serial serial ) : base( serial ) 
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

	public class CagedCow : BaseCaged
	{
		[Constructable] 
		public CagedCow()
		{
			AnimalType = "Cow";
			Name = "cow";
			ItemID = Cage( "medium" );
		}

		public CagedCow( Serial serial ) : base( serial ) 
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

	public class CagedDesertOstard : BaseCaged
	{
		[Constructable] 
		public CagedDesertOstard()
		{
			AnimalType = "DesertOstard";
			Name = "desert ostard";
			ItemID = Cage( "medium" );
		}

		public CagedDesertOstard( Serial serial ) : base( serial ) 
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

	public class CagedDireBear : BaseCaged
	{
		[Constructable] 
		public CagedDireBear()
		{
			AnimalType = "DireBear";
			Name = "dire bear";
			ItemID = Cage( "medium" );
		}

		public CagedDireBear( Serial serial ) : base( serial ) 
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

	public class CagedDireBoar : BaseCaged
	{
		[Constructable] 
		public CagedDireBoar()
		{
			AnimalType = "DireBoar";
			Name = "dire boar";
			ItemID = Cage( "small" );
		}

		public CagedDireBoar( Serial serial ) : base( serial ) 
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

	public class CagedDog : BaseCaged
	{
		[Constructable] 
		public CagedDog()
		{
			AnimalType = "Dog";
			Name = "dog";
			ItemID = Cage( "small" );
		}

		public CagedDog( Serial serial ) : base( serial ) 
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

	public class CagedEagle : BaseCaged
	{
		[Constructable] 
		public CagedEagle()
		{
			AnimalType = "Eagle";
			Name = "eagle";
			ItemID = Cage( "small" );
		}

		public CagedEagle( Serial serial ) : base( serial ) 
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

	public class CagedElderBlackBearRiding : BaseCaged
	{
		[Constructable] 
		public CagedElderBlackBearRiding()
		{
			AnimalType = "ElderBlackBearRiding";
			Name = "elder black bear";
			ItemID = Cage( "large" );
		}

		public CagedElderBlackBearRiding( Serial serial ) : base( serial ) 
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

	public class CagedElderBrownBearRiding : BaseCaged
	{
		[Constructable] 
		public CagedElderBrownBearRiding()
		{
			AnimalType = "ElderBrownBearRiding";
			Name = "elder brown bear";
			ItemID = Cage( "large" );
		}

		public CagedElderBrownBearRiding( Serial serial ) : base( serial ) 
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

	public class CagedElderPolarBearRiding : BaseCaged
	{
		[Constructable] 
		public CagedElderPolarBearRiding()
		{
			AnimalType = "ElderPolarBearRiding";
			Name = "elder polar bear";
			ItemID = Cage( "large" );
		}

		public CagedElderPolarBearRiding( Serial serial ) : base( serial ) 
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

	public class CagedElephant : BaseCaged
	{
		[Constructable] 
		public CagedElephant()
		{
			AnimalType = "Elephant";
			Name = "elephant";
			ItemID = Cage( "large" );
		}

		public CagedElephant( Serial serial ) : base( serial ) 
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

	public class CagedMastadon : BaseCaged
	{
		[Constructable] 
		public CagedMastadon()
		{
			AnimalType = "Mastadon";
			Name = "mastadon";
			ItemID = Cage( "large" );
		}

		public CagedMastadon( Serial serial ) : base( serial ) 
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

	public class CagedFerret : BaseCaged
	{
		[Constructable] 
		public CagedFerret()
		{
			AnimalType = "Ferret";
			Name = "ferret";
			ItemID = Cage( "small" );
		}

		public CagedFerret( Serial serial ) : base( serial ) 
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

	public class CagedForestOstard : BaseCaged
	{
		[Constructable] 
		public CagedForestOstard()
		{
			AnimalType = "ForestOstard";
			Name = "forest ostard";
			ItemID = Cage( "medium" );
		}

		public CagedForestOstard( Serial serial ) : base( serial ) 
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

	public class CagedFox : BaseCaged
	{
		[Constructable] 
		public CagedFox()
		{
			AnimalType = "Fox";
			Name = "fox";
			ItemID = Cage( "small" );
		}

		public CagedFox( Serial serial ) : base( serial ) 
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

	public class CagedFrog : BaseCaged
	{
		[Constructable] 
		public CagedFrog()
		{
			AnimalType = "Frog";
			Name = "frog";
			ItemID = Cage( "small" );
		}

		public CagedFrog( Serial serial ) : base( serial ) 
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

	public class CagedGiantHawk : BaseCaged
	{
		[Constructable] 
		public CagedGiantHawk()
		{
			AnimalType = "GiantHawk";
			Name = "giant hawk";
			ItemID = Cage( "large" );
		}

		public CagedGiantHawk( Serial serial ) : base( serial ) 
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

	public class CagedGiantLizard : BaseCaged
	{
		[Constructable] 
		public CagedGiantLizard()
		{
			AnimalType = "GiantLizard";
			Name = "giant lizard";
			ItemID = Cage( "medium" );
		}

		public CagedGiantLizard( Serial serial ) : base( serial ) 
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

	public class CagedGiantRat : BaseCaged
	{
		[Constructable] 
		public CagedGiantRat()
		{
			AnimalType = "GiantRat";
			Name = "giant rat";
			ItemID = Cage( "small" );
		}

		public CagedGiantRat( Serial serial ) : base( serial ) 
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

	public class CagedGiantRaven : BaseCaged
	{
		[Constructable] 
		public CagedGiantRaven()
		{
			AnimalType = "GiantRaven";
			Name = "giant raven";
			ItemID = Cage( "large" );
		}

		public CagedGiantRaven( Serial serial ) : base( serial ) 
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

	public class CagedGiantSerpent : BaseCaged
	{
		[Constructable] 
		public CagedGiantSerpent()
		{
			AnimalType = "GiantSerpent";
			Name = "giant serpent";
			ItemID = Cage( "medium" );
		}

		public CagedGiantSerpent( Serial serial ) : base( serial ) 
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

	public class CagedGiantSnake : BaseCaged
	{
		[Constructable] 
		public CagedGiantSnake()
		{
			AnimalType = "GiantSnake";
			Name = "giant snake";
			ItemID = Cage( "medium" );
		}

		public CagedGiantSnake( Serial serial ) : base( serial ) 
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

	public class CagedGiantToad : BaseCaged
	{
		[Constructable] 
		public CagedGiantToad()
		{
			AnimalType = "GiantToad";
			Name = "giant toad";
			ItemID = Cage( "medium" );
		}

		public CagedGiantToad( Serial serial ) : base( serial ) 
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

	public class CagedGoat : BaseCaged
	{
		[Constructable] 
		public CagedGoat()
		{
			AnimalType = "Goat";
			Name = "goat";
			ItemID = Cage( "medium" );
		}

		public CagedGoat( Serial serial ) : base( serial ) 
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

	public class CagedGorilla : BaseCaged
	{
		[Constructable] 
		public CagedGorilla()
		{
			AnimalType = "Gorilla";
			Name = "gorilla";
			ItemID = Cage( "medium" );
		}

		public CagedGorilla( Serial serial ) : base( serial ) 
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

	public class CagedGreatBear : BaseCaged
	{
		[Constructable] 
		public CagedGreatBear()
		{
			AnimalType = "GreatBear";
			Name = "great bear";
			ItemID = Cage( "medium" );
		}

		public CagedGreatBear( Serial serial ) : base( serial ) 
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

	public class CagedGreyWolf : BaseCaged
	{
		[Constructable] 
		public CagedGreyWolf()
		{
			AnimalType = "GreyWolf";
			Name = "grey wolf";
			ItemID = Cage( "small" );
		}

		public CagedGreyWolf( Serial serial ) : base( serial ) 
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

	public class CagedGrizzlyBearRiding : BaseCaged
	{
		[Constructable] 
		public CagedGrizzlyBearRiding()
		{
			AnimalType = "GrizzlyBearRiding";
			Name = "grizzly bear";
			ItemID = Cage( "medium" );
		}

		public CagedGrizzlyBearRiding( Serial serial ) : base( serial ) 
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

	public class CagedHawk : BaseCaged
	{
		[Constructable] 
		public CagedHawk()
		{
			AnimalType = "Hawk";
			Name = "hawk";
			ItemID = Cage( "small" );
		}

		public CagedHawk( Serial serial ) : base( serial ) 
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

	public class CagedHugeLizard : BaseCaged
	{
		[Constructable] 
		public CagedHugeLizard()
		{
			AnimalType = "HugeLizard";
			Name = "huge lizard";
			ItemID = Cage( "medium" );
		}

		public CagedHugeLizard( Serial serial ) : base( serial ) 
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

	public class CagedJackal : BaseCaged
	{
		[Constructable] 
		public CagedJackal()
		{
			AnimalType = "Jackal";
			Name = "jackal";
			ItemID = Cage( "small" );
		}

		public CagedJackal( Serial serial ) : base( serial ) 
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

	public class CagedJaguar : BaseCaged
	{
		[Constructable] 
		public CagedJaguar()
		{
			AnimalType = "Jaguar";
			Name = "jaguar";
			ItemID = Cage( "small" );
		}

		public CagedJaguar( Serial serial ) : base( serial ) 
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

	public class CagedKodiakBear : BaseCaged
	{
		[Constructable] 
		public CagedKodiakBear()
		{
			AnimalType = "KodiakBear";
			Name = "kodiak";
			ItemID = Cage( "medium" );
		}

		public CagedKodiakBear( Serial serial ) : base( serial ) 
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

	public class CagedLionRiding : BaseCaged
	{
		[Constructable] 
		public CagedLionRiding()
		{
			AnimalType = "LionRiding";
			Name = "lion";
			ItemID = Cage( "medium" );
		}

		public CagedLionRiding( Serial serial ) : base( serial ) 
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

	public class CagedManticoreRiding : BaseCaged
	{
		[Constructable] 
		public CagedManticoreRiding()
		{
			AnimalType = "ManticoreRiding";
			Name = "manticore";
			ItemID = Cage( "large" );
		}

		public CagedManticoreRiding( Serial serial ) : base( serial ) 
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

	public class CagedMouse : BaseCaged
	{
		[Constructable] 
		public CagedMouse()
		{
			AnimalType = "Mouse";
			Name = "mouse";
			ItemID = Cage( "small" );
		}

		public CagedMouse( Serial serial ) : base( serial ) 
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

	public class CagedPackBear : BaseCaged
	{
		[Constructable] 
		public CagedPackBear()
		{
			AnimalType = "PackBear";
			Name = "pack bear";
			ItemID = Cage( "medium" );
		}

		public CagedPackBear( Serial serial ) : base( serial ) 
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

	public class CagedPackHorse : BaseCaged
	{
		[Constructable] 
		public CagedPackHorse()
		{
			AnimalType = "PackHorse";
			Name = "pack horse";
			ItemID = Cage( "medium" );
		}

		public CagedPackHorse( Serial serial ) : base( serial ) 
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

	public class CagedPackLlama : BaseCaged
	{
		[Constructable] 
		public CagedPackLlama()
		{
			AnimalType = "PackLlama";
			Name = "pack llama";
			ItemID = Cage( "medium" );
		}

		public CagedPackLlama( Serial serial ) : base( serial ) 
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

	public class CagedPackMule : BaseCaged
	{
		[Constructable] 
		public CagedPackMule()
		{
			AnimalType = "PackMule";
			Name = "pack mule";
			ItemID = Cage( "medium" );
		}

		public CagedPackMule( Serial serial ) : base( serial ) 
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

	public class CagedPackStegosaurus : BaseCaged
	{
		[Constructable] 
		public CagedPackStegosaurus()
		{
			AnimalType = "PackStegosaurus";
			Name = "stegosaurus";
			ItemID = Cage( "giant" );
		}

		public CagedPackStegosaurus( Serial serial ) : base( serial ) 
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

	public class CagedPackTurtle : BaseCaged
	{
		[Constructable] 
		public CagedPackTurtle()
		{
			AnimalType = "PackTurtle";
			Name = "pack turtle";
			ItemID = Cage( "large" );
		}

		public CagedPackTurtle( Serial serial ) : base( serial ) 
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

	public class CagedPandaRiding : BaseCaged
	{
		[Constructable] 
		public CagedPandaRiding()
		{
			AnimalType = "PandaRiding";
			Name = "panda";
			ItemID = Cage( "medium" );
		}

		public CagedPandaRiding( Serial serial ) : base( serial ) 
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

	public class CagedPanther : BaseCaged
	{
		[Constructable] 
		public CagedPanther()
		{
			AnimalType = "Panther";
			Name = "panther";
			ItemID = Cage( "small" );
		}

		public CagedPanther( Serial serial ) : base( serial ) 
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

	public class CagedPig : BaseCaged
	{
		[Constructable] 
		public CagedPig()
		{
			AnimalType = "Pig";
			Name = "pig";
			ItemID = Cage( "small" );
		}

		public CagedPig( Serial serial ) : base( serial ) 
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

	public class CagedPolarBear : BaseCaged
	{
		[Constructable] 
		public CagedPolarBear()
		{
			AnimalType = "PolarBear";
			Name = "polar bear";
			ItemID = Cage( "medium" );
		}

		public CagedPolarBear( Serial serial ) : base( serial ) 
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

	public class CagedRaptorRiding : BaseCaged
	{
		[Constructable] 
		public CagedRaptorRiding()
		{
			AnimalType = "RaptorRiding";
			Name = "raptor";
			ItemID = Cage( "medium" );
		}

		public CagedRaptorRiding( Serial serial ) : base( serial ) 
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

	public class CagedRat : BaseCaged
	{
		[Constructable] 
		public CagedRat()
		{
			AnimalType = "Rat";
			Name = "rat";
			ItemID = Cage( "small" );
		}

		public CagedRat( Serial serial ) : base( serial ) 
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

	public class CagedRidableLlama : BaseCaged
	{
		[Constructable] 
		public CagedRidableLlama()
		{
			AnimalType = "RidableLlama";
			Name = "llama";
			ItemID = Cage( "medium" );
		}

		public CagedRidableLlama( Serial serial ) : base( serial ) 
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

	public class CagedRidgeback : BaseCaged
	{
		[Constructable] 
		public CagedRidgeback()
		{
			AnimalType = "Ridgeback";
			Name = "stegladon";
			ItemID = Cage( "large" );
		}

		public CagedRidgeback( Serial serial ) : base( serial ) 
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

	public class CagedSheep : BaseCaged
	{
		[Constructable] 
		public CagedSheep()
		{
			AnimalType = "Sheep";
			Name = "sheep";
			ItemID = Cage( "small" );
		}

		public CagedSheep( Serial serial ) : base( serial ) 
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

	public class CagedSnowOstard : BaseCaged
	{
		[Constructable] 
		public CagedSnowOstard()
		{
			AnimalType = "SnowOstard";
			Name = "snow ostard";
			ItemID = Cage( "medium" );
		}

		public CagedSnowOstard( Serial serial ) : base( serial ) 
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

	public class CagedSwampDragon : BaseCaged
	{
		[Constructable] 
		public CagedSwampDragon()
		{
			AnimalType = "SwampDragon";
			Name = "swamp lizard";
			ItemID = Cage( "large" );
		}

		public CagedSwampDragon( Serial serial ) : base( serial ) 
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

	public class CagedTigerRiding : BaseCaged
	{
		[Constructable] 
		public CagedTigerRiding()
		{
			AnimalType = "TigerRiding";
			Name = "tiger";
			ItemID = Cage( "medium" );
		}

		public CagedTigerRiding( Serial serial ) : base( serial ) 
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

	public class CagedTimberWolf : BaseCaged
	{
		[Constructable] 
		public CagedTimberWolf()
		{
			AnimalType = "TimberWolf";
			Name = "timber wolf";
			ItemID = Cage( "small" );
		}

		public CagedTimberWolf( Serial serial ) : base( serial ) 
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

	public class CagedWhiteWolf : BaseCaged
	{
		[Constructable] 
		public CagedWhiteWolf()
		{
			AnimalType = "WhiteWolf";
			Name = "white wolf";
			ItemID = Cage( "medium" );
		}

		public CagedWhiteWolf( Serial serial ) : base( serial ) 
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

	public class CagedWolfDire : BaseCaged
	{
		[Constructable] 
		public CagedWolfDire()
		{
			AnimalType = "WolfDire";
			Name = "dire wolf";
			ItemID = Cage( "medium" );
		}

		public CagedWolfDire( Serial serial ) : base( serial ) 
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

	public class CagedZebraRiding : BaseCaged
	{
		[Constructable] 
		public CagedZebraRiding()
		{
			AnimalType = "ZebraRiding";
			Name = "zebra";
			ItemID = Cage( "medium" );
		}

		public CagedZebraRiding( Serial serial ) : base( serial ) 
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

	public class CagedGriffonRiding : BaseCaged
	{
		[Constructable] 
		public CagedGriffonRiding()
		{
			AnimalType = "GriffonRiding";
			Name = "griffon";
			ItemID = Cage( "large" );
		}

		public CagedGriffonRiding( Serial serial ) : base( serial ) 
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

	public class CagedHippogriffRiding : BaseCaged
	{
		[Constructable] 
		public CagedHippogriffRiding()
		{
			AnimalType = "HippogriffRiding";
			Name = "hippogriff";
			ItemID = Cage( "large" );
		}

		public CagedHippogriffRiding( Serial serial ) : base( serial ) 
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

	public class CagedPackNecroSpider : BaseCaged
	{
		[Constructable] 
		public CagedPackNecroSpider()
		{
			AnimalType = "PackNecroSpider";
			Name = "pack spider";
			ItemID = Cage( "medium" );
		}

		public CagedPackNecroSpider( Serial serial ) : base( serial ) 
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

	public class CagedPackNecroHound : BaseCaged
	{
		[Constructable] 
		public CagedPackNecroHound()
		{
			AnimalType = "PackNecroHound";
			Name = "pack hound";
			ItemID = Cage( "large" );
		}

		public CagedPackNecroHound( Serial serial ) : base( serial ) 
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