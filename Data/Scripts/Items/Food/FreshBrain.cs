using System;
using Server;

namespace Server.Items
{
	public class FreshBrain : Item
	{
		[Constructable]
		public FreshBrain() : this( 1 )
		{
		}

		[Constructable]
		public FreshBrain( int amount ) : base( 0x64B8 )
		{
			Weight = 0.1;
			Stackable = true;
			Name = "fresh brain";
			Amount = amount;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !Server.Items.BaseRace.BrainEater( from.RaceID ) )
			{
				from.SendMessage( "This looks like something zombies would eat." );
				return;
			}
			if ( !IsChildOf( from.Backpack ) && Server.Items.BaseRace.BrainEater( from.RaceID ) ) 
			{
				from.SendMessage( "This must be in your backpack to eat." );
				return;
			}
			else if ( Server.Items.BaseRace.BrainEater( from.RaceID ) )
			{
				from.Thirst = 20;
				if ( from.Hunger < 20 )
				{
					from.Hunger += 3;

					if ( from.Hunger < 5 )
						from.SendMessage( "You eat the brains, but still need more." );
					else if ( from.Hunger < 10 )
						from.SendMessage( "You eat the brains, but still desire more." );
					else if ( from.Hunger < 15 )
						from.SendMessage( "You eat the brains, but could still induldge yourself." );
					else
						from.SendMessage( "You eat the brains, but have indulged in enough." );

					from.PlaySound( Utility.Random( 0x3A, 3 ) );

					if ( from.Body.IsHuman && !from.Mounted )
						from.Animate( 34, 5, 1, true, false, 0 );

					this.Consume();

					Misc.Titles.AwardKarma( from, -50, true );
				}
				else
				{
					from.SendMessage( "You have indulged in enough brains for now." );
					from.Hunger = 20;
					from.Thirst = 20;
				}
			}
		}

		public FreshBrain( Serial serial ) : base( serial )
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