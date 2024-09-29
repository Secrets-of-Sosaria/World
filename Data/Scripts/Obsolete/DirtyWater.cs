using System;
using System.Collections;
using Server.Network;
using Server.Prompts;
using Server.Targeting;

namespace Server.Items
{
	public class DirtyWaterskin : Item
	{
		[Constructable]
		public DirtyWaterskin() : base( 0x98F )
		{
			Hue = 0xB97;
			Name = "old waterskin";
			Weight = 1.0;
		}

		public override void OnDoubleClick( Mobile from )
		{
			bool soaked;
			Server.Items.DrinkingFunctions.CheckWater( from, 3, out soaked );

			if ( !IsChildOf( from.Backpack ) ) 
			{
				from.SendMessage( "This must be in your backpack to use." );
				return;
			}

			else if ( soaked )
			{
				from.SendMessage( "You fill the container with fresh water." );
				from.PlaySound( 0x240 );
				this.Consume();
				Item flask = new Waterskin();
				flask.ItemID = this.ItemID;
				flask.Name = "waterskin";
					if ( this.ItemID == 0x48E4 ){ flask.Name = "canteen"; }
				flask.Weight = 2.0;
				from.AddToBackpack( flask );
			}
			else if ( Server.Items.BaseRace.BloodDrinker( from.RaceID ) || Server.Items.BaseRace.BrainEater( from.RaceID ) )
			{
				from.SendMessage( "This does not look very good to you." );
			}
			else if ( from.Thirst < 20 )
			{
				from.Thirst += 5;
				// Send message to character about their current thirst value
				int iThirst = from.Thirst;
				if ( iThirst < 5 )
					from.SendMessage( "You drink the dirty water but are still extremely thirsty" );
				else if ( iThirst < 10 )
					from.SendMessage( "You drink the dirty water and feel less thirsty" );
				else if ( iThirst < 15 )
					from.SendMessage( "You drink the dirty water and feel much less thirsty" ); 
				else
					from.SendMessage( "You drink the dirty water and are no longer thirsty" );

				this.Consume();

				if ( from.Body.IsHuman && !from.Mounted )
					from.Animate( 34, 5, 1, true, false, 0 );

				from.PlaySound( Utility.RandomList( 0x30, 0x2D6 ) );

				Item flask = new Waterskin();
				flask.Weight = 1.0;
				flask.ItemID = 0xA21;
				flask.Name = "empty waterskin";
					if ( this.ItemID == 0x48E4 ){ flask.ItemID = 0x48E4; flask.Name = "empty canteen"; }
				from.AddToBackpack( flask );

				Server.Items.DrinkingFunctions.DrinkBenefits( from );

				// CHECK FOR ANY DUNGEON FOOD ILLNESSES //////////////////////////////////////
				if ( from.CheckSkill( SkillName.Tasting, 0, 100 ) )
				{
				}
				else if ( Utility.RandomMinMax( 1, 100 ) > 70 )
				{
					int nPoison = Utility.RandomMinMax( 0, 10 );
					from.Say( "Poison!" );
					if ( nPoison > 9 ) { from.ApplyPoison( from, Poison.Deadly ); }
					else if ( nPoison > 7 ) { from.ApplyPoison( from, Poison.Greater ); }
					else if ( nPoison > 4 ) { from.ApplyPoison( from, Poison.Regular ); }
					else { from.ApplyPoison( from, Poison.Lesser ); }
					from.SendMessage( "Poison!");
				}
			}
			else
			{
				from.SendMessage( "You are simply too quenched to drink any more!" );
				from.Thirst = 20;
			}
		}

		public DirtyWaterskin( Serial serial ) : base( serial )
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
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new Waterskin();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}