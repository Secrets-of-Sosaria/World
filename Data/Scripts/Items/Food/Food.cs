using System;
using System.Collections;
using Server.Network;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Misc;
using Server.Regions;
using Server.Mobiles;

namespace Server.Items
{
	public abstract class Food : Item
	{
		public override string DefaultDescription{ get{ return "Food can be used to satisfy your hunger. It can also be used in various cooking recipes. There are some single click menus available. If you are hungry, you can 'Eat' it, but if you want to eat as much of it as you can, you can always 'Eat Up'."; } }

		private Mobile m_Poisoner;
		private Poison m_Poison;
		private int m_FillFactor;

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Poisoner
		{
			get { return m_Poisoner; }
			set { m_Poisoner = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Poison Poison
		{
			get { return m_Poison; }
			set { m_Poison = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int FillFactor
		{
			get { return m_FillFactor; }
			set { m_FillFactor = value; }
		}

		public static Poison PoisonLevel()
		{
			Poison poison = Poison.Lethal;
			int var = Utility.Random(51);

			if ( var < 20 ){ poison = Poison.Lesser; }
			else if ( var < 35 ){ poison = Poison.Regular; }
			else if ( var < 45 ){ poison = Poison.Greater; }
			else if ( var < 50 ){ poison = Poison.Deadly; }

			return poison;
		}

		public override bool OnDroppedToMobile( Mobile from, Mobile target )
		{
			if ( target is PlayerMobile )
			{
				base.OnDroppedToMobile( from, target );
			}
			else if ( target is SherryTheMouse || ( target is BaseCreature && ((BaseCreature)target).CheckFoodPreference( this ) ) )
			{
				return true;
			}
			else if ( target is BaseVendor && target.Region.IsPartOf( typeof( VillageRegion ) ) && Poison != null )
			{
				if ( Poison == Poison.Lesser ) { target.ApplyPoison( from, PoisonImpl.Lesser ); }
				else if ( Poison == Poison.Regular ) { target.ApplyPoison( from, PoisonImpl.Regular ); }
				else if ( Poison == Poison.Greater ) { target.ApplyPoison( from, PoisonImpl.Greater ); }
				else if ( Poison == Poison.Deadly ) { target.ApplyPoison( from, PoisonImpl.Deadly ); }
				else { target.ApplyPoison( from, PoisonImpl.Lethal ); }

				target.Say( "Poison!");

				target.PlaySound( target.Female ? 813 : 1087 );
				if ( !target.Mounted ) 
					target.Animate( 32, 5, 1, true, false, 0 );                     
				Puke puke = new Puke(); 
				puke.Map = target.Map; 
				puke.Location = target.Location;

				this.Delete();
			}
			else if ( target.Body == 0x191 || target.Body == 0x190 || target.Body == 606 || target.Body == 605 )
			{
				from.AddToBackpack ( this );
				target.Say( "That doesn't look good.");
			}
			else
			{
				from.AddToBackpack ( this );
				from.PrivateOverheadMessage(MessageType.Regular, 1150, false, "They don't seem to want that.", from.NetState);
			}

			return true;
		}

		public override bool StackWith( Mobile from, Item dropped, bool playSound )
		{
			if ( dropped is Food && dropped.Stackable && Stackable && dropped.GetType() == GetType() && dropped.ItemID == ItemID && dropped.Hue == Hue && dropped.Name == Name && (dropped.Amount + Amount) <= 60000 )
			{
				Food food = (Food)dropped;

				if ( LootType != dropped.LootType )
					LootType = LootType.Regular;

				Amount += dropped.Amount;

				if ( food.Poisoner != null )
					Poisoner = food.Poisoner;

				if ( food.Poison != null )
					Poison = food.Poison;

				dropped.Delete();

				if ( playSound && from != null )
				{
					int soundID = GetDropSound();

					if ( soundID == -1 )
						soundID = 0x42;

					from.SendSound( soundID, GetWorldLocation() );
				}

				return true;
			}

			return false;
		}

		public Food( int itemID ) : this( 1, itemID )
		{
		}

		public Food( int amount, int itemID ) : base( itemID )
		{
			Stackable = true;
			Amount = amount;
			m_FillFactor = 1;
		}

		public Food( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			if ( from.Alive )
			{
				list.Add( new ContextMenus.EatEntry( from, this ) );

				if ( Amount > 1 )
					list.Add( new ContextMenus.EatMaxEntry( from, this ) );
			}
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
            list.Add( 1049644, "Hunger: " + m_FillFactor + "" );
        }

		public override void OnDoubleClick( Mobile from )
		{
			if ( !Movable )
				return;

			if ( from.InRange( this.GetWorldLocation(), 1 ) )
			{
				Eat( from, true );
			}
		}

		public virtual bool Eat( Mobile from, bool msg  )
		{
			// Fill the Mobile with FillFactor
			if ( FillHunger( from, m_FillFactor, msg ) )
			{
				// Play a random "eat" sound
				from.PlaySound( Utility.Random( 0x3A, 3 ) );

				if ( from.Body.IsHuman && !from.Mounted )
					from.Animate( 34, 5, 1, true, false, 0 );

				if ( m_Poison != null )
					from.ApplyPoison( m_Poisoner, m_Poison );

				Consume();

				int iHeal = (int)from.Skills[SkillName.Tasting].Value;
				int iHurt = from.HitsMax - from.Hits;

				if ( iHurt > 0 )
				{
					if ( iHeal > iHurt )
					{
						iHeal = iHurt;
					}

					from.Hits = from.Hits + iHeal;

					if ( from.Poisoned )
					{
						if ( (int)from.Skills[SkillName.Tasting].Value >= Utility.RandomMinMax( 1, 100 ) )
						{
							from.CurePoison( from );
							from.SendLocalizedMessage( 1010059 ); // You have been cured of all poisons.
						}
					}
				}

				return true;
			}

			return false;
		}

		static public bool FillHunger( Mobile from, int fillFactor, bool msg )
		{
			if ( from.Hunger >= 20 )
			{
				from.SendLocalizedMessage( 500867 ); // You are simply too full to eat any more!
				return false;
			}
			else if ( Server.Items.BaseRace.BloodDrinker( from.RaceID ) || Server.Items.BaseRace.BrainEater( from.RaceID ) )
			{
				from.SendMessage( "This does not look very good to you." );
				return false;
			}

			int iEaten = 0;
			int iHunger = from.Hunger + fillFactor;

			if ( iHunger >= 20 )
			{
				iEaten = 1;
				from.Hunger = 20;
				if ( msg )
					from.SendLocalizedMessage( 500872 ); // You manage to eat the food, but you are stuffed!
			}
			else
			{
				iEaten = 1;
				from.Hunger = iHunger;

				if ( msg )
				{
					if ( iHunger < 5 )
						from.SendLocalizedMessage( 500868 ); // You eat the food, but are still extremely hungry.
					else if ( iHunger < 10 )
						from.SendLocalizedMessage( 500869 ); // You eat the food, and begin to feel more satiated.
					else if ( iHunger < 15 )
						from.SendLocalizedMessage( 500870 ); // After eating the food, you feel much less hungry.
					else
						from.SendLocalizedMessage( 500871 ); // You feel quite full after consuming the food.
				}
			}

			if ( iEaten > 0 )
			{
				int iHeal = (int)from.Skills[SkillName.Tasting].Value;
				int iHurt = from.HitsMax - from.Hits;

				if ( iHurt > 0 )
				{
					if ( iHeal > iHurt )
					{
						iHeal = iHurt;
					}

					from.Hits = from.Hits + iHeal;

					if ( from.Poisoned )
					{
						if ( (int)from.Skills[SkillName.Tasting].Value >= Utility.RandomMinMax( 1, 100 ) )
						{
							from.CurePoison( from );
							from.SendLocalizedMessage( 1010059 ); // You have been cured of all poisons.
						}
					}
				}
			}

			return true;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 4 ); // version

			writer.Write( m_Poisoner );

			Poison.Serialize( m_Poison, writer );
			writer.Write( m_FillFactor );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					switch ( reader.ReadInt() )
					{
						case 0: m_Poison = null; break;
						case 1: m_Poison = Poison.Lesser; break;
						case 2: m_Poison = Poison.Regular; break;
						case 3: m_Poison = Poison.Greater; break;
						case 4: m_Poison = Poison.Deadly; break;
					}

					break;
				}
				case 2:
				{
					m_Poison = Poison.Deserialize( reader );
					break;
				}
				case 3:
				{
					m_Poison = Poison.Deserialize( reader );
					m_FillFactor = reader.ReadInt();
					break;
				}
				case 4:
				{
					m_Poisoner = reader.ReadMobile();
					goto case 3;
				}
			}
		}

		public static Item ModifyFood( Item food, Mobile m )
		{
			if ( food is Food )
			{
				Item item = null;

				if ( BaseRace.BloodDrinker( m.RaceID ) ){ item = new BloodyDrink(); }
				else if ( BaseRace.BrainEater( m.RaceID ) ){ item = new FreshBrain(); }
				else if ( Worlds.isSciFiRegion( m ) )
				{
					if ( food is Apple ){ item = new CubedFruit(); }
					else if ( food is Banana ){ item = new CubedFruit(); }
					else if ( food is Cabbage ){ item = new CubedFruit(); }
					else if ( food is Cantaloupe ){ item = new CubedFruit(); }
					else if ( food is Carrot ){ item = new CubedFruit(); }
					else if ( food is Grapes ){ item = new CubedFruit(); }
					else if ( food is GreenGourd ){ item = new CubedFruit(); }
					else if ( food is HoneydewMelon ){ item = new CubedFruit(); }
					else if ( food is Lemon ){ item = new CubedFruit(); }
					else if ( food is Lettuce ){ item = new CubedFruit(); }
					else if ( food is Lime ){ item = new CubedFruit(); }
					else if ( food is Onion ){ item = new CubedFruit(); }
					else if ( food is Peach ){ item = new CubedFruit(); }
					else if ( food is Pear ){ item = new CubedFruit(); }
					else if ( food is Pumpkin ){ item = new CubedFruit(); }
					else if ( food is Squash ){ item = new CubedFruit(); }
					else if ( food is Watermelon ){ item = new CubedFruit(); }
					else if ( food is YellowGourd ){ item = new CubedFruit(); }

					else if ( food is Muffins ){ item = new CubedGrain(); }
					else if ( food is BreadLoaf ){ item = new CubedGrain(); }
					else if ( food is CheeseWedge ){ item = new CubedGrain(); }
					else if ( food is CheeseWheel ){ item = new CubedGrain(); }
					else if ( food is FrenchBread ){ item = new CubedGrain(); }

					else if ( food is CheeseWedge ){ item = new CubedMeat(); }
					else if ( food is CheeseWheel ){ item = new CubedMeat(); }
					else if ( food is ChickenLeg ){ item = new CubedMeat(); }
					else if ( food is CookedBird ){ item = new CubedMeat(); }
					else if ( food is FishSteak ){ item = new CubedMeat(); }
					else if ( food is Ham ){ item = new CubedMeat(); }
					else if ( food is LambLeg ){ item = new CubedMeat(); }
					else if ( food is Ribs ){ item = new CubedMeat(); }
					else if ( food is Sausage ){ item = new CubedMeat(); }
					else if ( food is BaseBeverage )
					{
						if ( Utility.Random( 20 ) == 0 )
							item = new RomulanAle();
						else
							item = new Canteen();
					}
				}

				if ( item != null )
				{
					food.Delete();
					food = item;
				}
			}
			return food;
		}
	}

	public class BreadLoaf : Food
	{
		[Constructable]
		public BreadLoaf() : this( 1 )
		{
		}

		[Constructable]
		public BreadLoaf( int amount ) : base( amount, 0x103B )
		{
			this.Weight = 1.0;
			this.FillFactor = 3;
		}

		public BreadLoaf( Serial serial ) : base( serial )
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
	}

	public class Bacon : Food
	{
		[Constructable]
		public Bacon() : this( 1 )
		{
		}

		[Constructable]
		public Bacon( int amount ) : base( amount, 0x979 )
		{
			this.Weight = 1.0;
			this.FillFactor = 1;
		}

		public Bacon( Serial serial ) : base( serial )
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
	}

	public class SlabOfBacon : Food
	{
		[Constructable]
		public SlabOfBacon() : this( 1 )
		{
		}

		[Constructable]
		public SlabOfBacon( int amount ) : base( amount, 0x976 )
		{
			this.Weight = 1.0;
			this.FillFactor = 3;
		}

		public SlabOfBacon( Serial serial ) : base( serial )
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
	}

	public class FishSteak : Food
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public FishSteak() : this( 1 )
		{
		}

		[Constructable]
		public FishSteak( int amount ) : base( amount, 0x97B )
		{
			this.FillFactor = 3;
		}

		public FishSteak( Serial serial ) : base( serial )
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
	}

	public class CheeseWheel : Food
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public CheeseWheel() : this( 1 )
		{
		}

		[Constructable]
		public CheeseWheel( int amount ) : base( amount, 0x97E )
		{
			this.FillFactor = 3;
		}

		public CheeseWheel( Serial serial ) : base( serial )
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
	}

	public class CheeseWedge : Food
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public CheeseWedge() : this( 1 )
		{
		}

		[Constructable]
		public CheeseWedge( int amount ) : base( amount, 0x97D )
		{
			this.FillFactor = 3;
		}

		public CheeseWedge( Serial serial ) : base( serial )
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
	}

	public class CheeseSlice : Food
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public CheeseSlice() : this( 1 )
		{
		}

		[Constructable]
		public CheeseSlice( int amount ) : base( amount, 0x97C )
		{
			this.FillFactor = 1;
		}

		public CheeseSlice( Serial serial ) : base( serial )
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
	}

	public class FrenchBread : Food
	{
		[Constructable]
		public FrenchBread() : this( 1 )
		{
		}

		[Constructable]
		public FrenchBread( int amount ) : base( amount, 0x98C )
		{
			this.Weight = 2.0;
			this.FillFactor = 3;
		}

		public FrenchBread( Serial serial ) : base( serial )
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
	}

	public class FriedEggs : Food
	{
		[Constructable]
		public FriedEggs() : this( 1 )
		{
		}

		[Constructable]
		public FriedEggs( int amount ) : base( amount, 0x9B6 )
		{
			this.Weight = 1.0;
			this.FillFactor = 4;
		}

		public FriedEggs( Serial serial ) : base( serial )
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
	}

	public class CookedBird : Food
	{
		[Constructable]
		public CookedBird() : this( 1 )
		{
		}

		[Constructable]
		public CookedBird( int amount ) : base( amount, 0x9B7 )
		{
			this.Weight = 1.0;
			this.FillFactor = 5;
		}

		public CookedBird( Serial serial ) : base( serial )
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
	}

	public class RoastPig : Food
	{
		[Constructable]
		public RoastPig() : this( 1 )
		{
		}

		[Constructable]
		public RoastPig( int amount ) : base( amount, 0x9BB )
		{
			this.Weight = 45.0;
			this.FillFactor = 20;
		}

		public RoastPig( Serial serial ) : base( serial )
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
	}

	public class Sausage : Food
	{
		[Constructable]
		public Sausage() : this( 1 )
		{
		}

		[Constructable]
		public Sausage( int amount ) : base( amount, 0x9C0 )
		{
			this.Weight = 1.0;
			this.FillFactor = 4;
		}

		public Sausage( Serial serial ) : base( serial )
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
	}

	public class Ham : Food
	{
		[Constructable]
		public Ham() : this( 1 )
		{
		}

		[Constructable]
		public Ham( int amount ) : base( amount, 0x9C9 )
		{
			this.Weight = 1.0;
			this.FillFactor = 5;
		}

		public Ham( Serial serial ) : base( serial )
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
	}

	public class Cake : Food
	{
		[Constructable]
		public Cake() : base( 0x9E9 )
		{
			Stackable = false;
			this.Weight = 1.0;
			this.FillFactor = 10;
		}

		public Cake( Serial serial ) : base( serial )
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
	}

	public class Ribs : Food
	{
		[Constructable]
		public Ribs() : this( 1 )
		{
		}

		[Constructable]
		public Ribs( int amount ) : base( amount, 0x9F2 )
		{
			this.Weight = 1.0;
			this.FillFactor = 5;
		}

		public Ribs( Serial serial ) : base( serial )
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
	}

	public class Cookies : Food
	{
		[Constructable]
		public Cookies() : base( 0x160b )
		{
			Stackable = Core.ML;
			this.Weight = 1.0;
			this.FillFactor = 4;
		}

		public Cookies( Serial serial ) : base( serial )
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
	}

	public class Muffins : Food
	{
		[Constructable]
		public Muffins() : base( 0x9eb )
		{
			Stackable = false;
			this.Weight = 1.0;
			this.FillFactor = 4;
		}

		public Muffins( Serial serial ) : base( serial )
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
	}

	[TypeAlias( "Server.Items.Pizza" )]
	public class CheesePizza : Food
	{
		public override int LabelNumber{ get{ return 1044516; } } // cheese pizza

		[Constructable]
		public CheesePizza() : base( 0x1040 )
		{
			Stackable = false;
			this.Weight = 1.0;
			this.FillFactor = 6;
		}

		public CheesePizza( Serial serial ) : base( serial )
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
	}

	public class SausagePizza : Food
	{
		public override int LabelNumber{ get{ return 1044517; } } // sausage pizza

		[Constructable]
		public SausagePizza() : base( 0x1040 )
		{
			Stackable = false;
			this.Weight = 1.0;
			this.FillFactor = 6;
		}

		public SausagePizza( Serial serial ) : base( serial )
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
	}

#if false
	public class Pizza : Food
	{
		[Constructable]
		public Pizza() : base( 0x1040 )
		{
			Stackable = false;
			this.Weight = 1.0;
			this.FillFactor = 6;
		}

		public Pizza( Serial serial ) : base( serial )
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
	}
#endif

	public class FruitPie : Food
	{
		public override int LabelNumber{ get{ return 1041346; } } // baked fruit pie

		[Constructable]
		public FruitPie() : base( 0x1041 )
		{
			Stackable = false;
			this.Weight = 1.0;
			this.FillFactor = 5;
		}

		public FruitPie( Serial serial ) : base( serial )
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
	}

	public class MeatPie : Food
	{
		public override int LabelNumber{ get{ return 1041347; } } // baked meat pie

		[Constructable]
		public MeatPie() : base( 0x1041 )
		{
			Stackable = false;
			this.Weight = 1.0;
			this.FillFactor = 5;
		}

		public MeatPie( Serial serial ) : base( serial )
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
	}

	public class PumpkinPie : Food
	{
		public override int LabelNumber{ get{ return 1041348; } } // baked pumpkin pie

		[Constructable]
		public PumpkinPie() : base( 0x1041 )
		{
			Stackable = false;
			this.Weight = 1.0;
			this.FillFactor = 5;
		}

		public PumpkinPie( Serial serial ) : base( serial )
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
	}

	public class ApplePie : Food
	{
		public override int LabelNumber{ get{ return 1041343; } } // baked apple pie

		[Constructable]
		public ApplePie() : base( 0x1041 )
		{
			Stackable = false;
			this.Weight = 1.0;
			this.FillFactor = 5;
		}

		public ApplePie( Serial serial ) : base( serial )
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
	}

	public class PeachCobbler : Food
	{
		public override int LabelNumber{ get{ return 1041344; } } // baked peach cobbler

		[Constructable]
		public PeachCobbler() : base( 0x1041 )
		{
			Stackable = false;
			this.Weight = 1.0;
			this.FillFactor = 5;
		}

		public PeachCobbler( Serial serial ) : base( serial )
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
	}

	public class Quiche : Food
	{
		public override int LabelNumber{ get{ return 1041345; } } // baked quiche

		[Constructable]
		public Quiche() : base( 0x1041 )
		{
			Stackable = Core.ML;
			this.Weight = 1.0;
			this.FillFactor = 5;
		}

		public Quiche( Serial serial ) : base( serial )
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
	}

	public class LambLeg : Food
	{
		[Constructable]
		public LambLeg() : this( 1 )
		{
		}

		[Constructable]
		public LambLeg( int amount ) : base( amount, 0x160a )
		{
			this.Weight = 2.0;
			this.FillFactor = 5;
		}

		public LambLeg( Serial serial ) : base( serial )
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
	}

	public class ChickenLeg : Food
	{
		[Constructable]
		public ChickenLeg() : this( 1 )
		{
		}

		[Constructable]
		public ChickenLeg( int amount ) : base( amount, 0x1608 )
		{
			this.Weight = 1.0;
			this.FillFactor = 4;
		}

		public ChickenLeg( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0xC74, 0xC75 )]
	public class HoneydewMelon : Food
	{
		[Constructable]
		public HoneydewMelon() : this( 1 )
		{
		}

		[Constructable]
		public HoneydewMelon( int amount ) : base( amount, 0xC74 )
		{
			this.Weight = 1.0;
			this.FillFactor = 1;
		}

		public HoneydewMelon( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0xC64, 0xC65 )]
	public class YellowGourd : Food
	{
		[Constructable]
		public YellowGourd() : this( 1 )
		{
		}

		[Constructable]
		public YellowGourd( int amount ) : base( amount, 0xC64 )
		{
			this.Weight = 1.0;
			this.FillFactor = 1;
		}

		public YellowGourd( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0xC66, 0xC67 )]
	public class GreenGourd : Food
	{
		[Constructable]
		public GreenGourd() : this( 1 )
		{
		}

		[Constructable]
		public GreenGourd( int amount ) : base( amount, 0xC66 )
		{
			this.Weight = 1.0;
			this.FillFactor = 1;
		}

		public GreenGourd( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 0xC7F, 0xC81 )]
	public class EarOfCorn : Food
	{
		[Constructable]
		public EarOfCorn() : this( 1 )
		{
		}

		[Constructable]
		public EarOfCorn( int amount ) : base( amount, 0xC81 )
		{
			this.Weight = 1.0;
			this.FillFactor = 1;
		}

		public EarOfCorn( Serial serial ) : base( serial )
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
	}

	public class Turnip : Food
	{
		[Constructable]
		public Turnip() : this( 1 )
		{
		}

		[Constructable]
		public Turnip( int amount ) : base( amount, 0xD3A )
		{
			this.Weight = 1.0;
			this.FillFactor = 1;
		}

		public Turnip( Serial serial ) : base( serial )
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
	}

	public class SheafOfHay : Item
	{
		[Constructable]
		public SheafOfHay() : base( 0xF36 )
		{
			this.Weight = 10.0;
		}

		public SheafOfHay( Serial serial ) : base( serial )
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
	}

	public class FoodBeefJerky : Food
	{
		[Constructable]
		public FoodBeefJerky() : this( 1 )
		{
		}

		[Constructable]
		public FoodBeefJerky( int amount ) : base( amount, 0x979 )
		{
			this.Name = "beef jerky";
			this.Hue = 2430;
			this.Weight = 1.0;
			this.FillFactor = 3;
		}

		public FoodBeefJerky( Serial serial ) : base( serial )
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
	}

	public class FoodToadStool : Food
	{
		[Constructable]
		public FoodToadStool() : this( 1 )
		{
		}

		[Constructable]
		public FoodToadStool( int amount ) : base( amount, 0xB4D )
		{
			this.Name = "toad stool";
			this.Weight = 1.0;
			this.FillFactor = 1;
		}

		public FoodToadStool( Serial serial ) : base( serial )
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
	}

	public class FoodPotato : Food
	{
		[Constructable]
		public FoodPotato() : this( 1 )
		{
		}

		[Constructable]
		public FoodPotato( int amount ) : base( amount, 0x9D2 )
		{
			this.Name = "potato";
			this.Hue = 0xB98;
			this.Weight = 1.0;
			this.FillFactor = 2;
		}

		public FoodPotato( Serial serial ) : base( serial )
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
			Name = "potato";
		}
	}

	public class FoodImpBerry : Food
	{
		[Constructable]
		public FoodImpBerry() : this( 1 )
		{
		}

		[Constructable]
		public FoodImpBerry( int amount ) : base( amount, 0xF7A )
		{
			this.Name = "imp berry";
			this.Hue = 0x48E;
			this.Weight = 1.0;
			this.FillFactor = 1;
		}

		public FoodImpBerry( Serial serial ) : base( serial )
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
	}

	public class Acorn : Food
	{
		[Constructable]
		public Acorn() : this( 1 )
		{
		}

		[Constructable]
		public Acorn( int amount ) : base( amount, 0x0A54 )
		{
			this.Name = "acorn";
			this.Weight = 1.0;
			this.FillFactor = 1;
		}

		public Acorn( Serial serial ) : base( serial )
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
	}

	public class CubedGrain : Food
	{
		public override int Hue{ get{ return 0xAE6; } }

		[Constructable]
		public CubedGrain() : this( 1 )
		{
		}

		[Constructable]
		public CubedGrain( int amount ) : base( amount, 0x3166 )
		{
			Name = "cubed grain";
			this.Weight = 1.0;
			this.FillFactor = 3;
		}

		public CubedGrain( Serial serial ) : base( serial )
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
	}

	public class CubedMeat : Food
	{
		public override int Hue{ get{ return 0xB01; } }

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public CubedMeat() : this( 1 )
		{
		}

		[Constructable]
		public CubedMeat( int amount ) : base( amount, 0x3166 )
		{
			Name = "cubed meat";
			this.Weight = 1.0;
			this.FillFactor = 3;
		}

		public CubedMeat( Serial serial ) : base( serial )
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
	}

	public class CubedFruit : Food
	{
		public override int Hue{ get{ return 0x94B; } }

		[Constructable]
		public CubedFruit() : this( 1 )
		{
		}

		[Constructable]
		public CubedFruit( int amount ) : base( amount, 0x3166 )
		{
			Name = "cubed fruit";
			this.Weight = 1.0;
			this.FillFactor = 1;
		}

		public CubedFruit( Serial serial ) : base( serial )
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
	}

    class DrinkingFunctions
    {
		public static bool CheckWaterTarget( int id )
		{
			bool isWater = false;

			isWater = ( id== 4090 || id== 0x21F2 || id== 0x1519 || id== 0x1534 || id== 0x65CE || id== 0x65CF || 
				id== 0x22A1 || id== 0x22A2 || id== 0x22A3 || 
				id== 0x22A4 || id== 0x22A5 || id== 0x22A6 || 
				id== 0x21F3 || id== 0x21F4 || id== 0x21F5 || 
				( id >= 0x4CCF && id <= 0x4CD9 ) || 
				id== 0x2C04 || id== 0x2C05 || id== 0x2C0A || id== 0x2C0B || id== 0x2C0C || id== 0x2C0D || 
				id== 0x2CAE || id== 0x2CAF || id== 0x2CB0 || id== 0x2CB1 || id== 0x2CB2 || id== 0x2CB3 || 
				id== 0xFFA || id== 0xB41 || id== 0xB42 || id== 0x0F33 || 
				id== 0xB43 || id== 0xB44 || id== 0xE7B || id== 0x154D || 
				id== 3707 || id== 5453 || id== 2882 || id== 2881 || 
				id== 13422 || id== 2883 || id== 2884 );

			return isWater;
		}

		public static void CheckWater( Mobile from, int range, out bool soaked )
		{
			soaked = false;

			Map map = from.Map;

			if ( map == null )
				return;

			IPooledEnumerable eable = map.GetItemsInRange( from.Location, range );

			foreach ( Item item in eable )
			{
				Type type = item.GetType();

				bool isWater = CheckWaterTarget( item.ItemID );

				if ( isWater )
				{
					if ( (from.Z + 16) < item.Z || (item.Z + 16) < from.Z || !from.InLOS( item ) )
						continue;

					soaked = soaked || isWater;

					if ( soaked )
						break;
				}
			}

			eable.Free();

			for ( int x = -range; (!soaked) && x <= range; ++x )
			{
				for ( int y = -range; (!soaked) && y <= range; ++y )
				{
					StaticTile[] tiles = map.Tiles.GetStaticTiles( from.X+x, from.Y+y, true );

					for ( int i = 0; (!soaked) && i < tiles.Length; ++i )
					{
						int id = tiles[i].ID;

						bool isWater = CheckWaterTarget( id );

						if ( isWater )
						{
							if ( (from.Z + 16) < tiles[i].Z || (tiles[i].Z + 16) < from.Z || !from.InLOS( new Point3D( from.X+x, from.Y+y, tiles[i].Z + (tiles[i].Height/2) + 1 ) ) )
								continue;

							soaked = soaked || isWater;
						}
					}
				}
			}
		}

		public static void OnDrink( Item drink, Mobile from )
		{
			if ( !drink.IsChildOf( from.Backpack ) ) 
			{
				from.SendMessage( "This must be in your backpack to drink." );
				return;
			}
			else if ( Server.Items.BaseRace.BloodDrinker( from.RaceID ) || Server.Items.BaseRace.BrainEater( from.RaceID ) )
			{
				from.SendMessage( "This does not look very good to you." );
				return;
			}
			else
			{
				// increase characters thirst value based on type of drink
				if ( from.Thirst < 20 )
				{
					from.Thirst += 5;
					// Send message to character about their current thirst value
					int iThirst = from.Thirst;
					if ( iThirst < 5 )
						from.SendMessage( "You drink the liquid but are still extremely thirsty" );
					else if ( iThirst < 10 )
						from.SendMessage( "You drink the liquid and feel less thirsty" );
					else if ( iThirst < 15 )
						from.SendMessage( "You drink the liquid and feel much less thirsty" ); 
					else
						from.SendMessage( "You drink the liquid and are no longer thirsty" );

					if ( drink is RomulanAle )
					{
						from.BAC += 2;

						if( from.BAC > 60 )
							from.BAC = 60;

						BaseBeverage.CheckHeaveTimer( from );
						from.AddToBackpack( new Bottle() );
					}

					drink.Consume();

					from.PlaySound( Utility.RandomList( 0x30, 0x2D6 ) );

					Server.Items.DrinkingFunctions.DrinkBenefits( from );
				}
				else
				{
					from.SendMessage( "You are simply too quenched to drink anymore" );
					from.Thirst = 20;
				}
			}
		}

		public static void DrinkBenefits( Mobile from )
		{
			int iHeal = (int)from.Skills[SkillName.Tasting].Value;
			int iHurt = from.StamMax - from.Stam;

			if ( iHurt > 0 )
			{
				if ( iHeal > iHurt )
				{
					iHeal = iHurt;
				}

				from.Stam = from.Stam + iHeal;

				if ( from.Poisoned )
				{
					if ( (int)from.Skills[SkillName.Tasting].Value >= Utility.RandomMinMax( 1, 100 ) )
					{
						from.CurePoison( from );
						from.SendLocalizedMessage( 1010059 ); // You have been cured of all poisons.
					}
				}
			}
		}
	}
}