using System;
using Server;

namespace Server.Items
{
	public class BloodyDrink : Item
	{
		public override int Hue { get { return 0xB1E; } }

		[Constructable]
		public BloodyDrink() : this( 1 )
		{
		}

		[Constructable]
		public BloodyDrink( int amount ) : base( 0x180F )
		{
			Weight = 0.1;
			Stackable = true;
			Name = "fresh blood";
			Amount = amount;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !Server.Items.BaseRace.BloodDrinker( from.RaceID ) )
			{
				from.SendMessage( "This looks like something vampires would drink." );
				return;
			}
			if ( !IsChildOf( from.Backpack ) && Server.Items.BaseRace.BloodDrinker( from.RaceID ) ) 
			{
				from.SendMessage( "This must be in your backpack to drink." );
				return;
			}
			else if ( Server.Items.BaseRace.BloodDrinker( from.RaceID ) )
			{
				if ( from.Hunger < 20 )
				{
					from.Hunger += 3;
					from.Thirst += 3;

					if ( from.Hunger < 5 )
						from.SendMessage( "You drink the blood, but still need more." );
					else if ( from.Hunger < 10 )
						from.SendMessage( "You drink the blood, but still desire more." );
					else if ( from.Hunger < 15 )
						from.SendMessage( "You drink the blood, but could still induldge yourself." );
					else
						from.SendMessage( "You drink the blood, but have indulged in enough." );

					from.PlaySound( 0x2D6 );

					if ( from.Body.IsHuman && !from.Mounted )
						from.Animate( 34, 5, 1, true, false, 0 );

					this.Consume();

					Misc.Titles.AwardKarma( from, -50, true );
				}
				else
				{
					from.SendMessage( "You have indulged in enough blood for now." );
					from.Hunger = 20;
					from.Thirst = 20;
				}
			}
		}

		public BloodyDrink( Serial serial ) : base( serial )
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
}