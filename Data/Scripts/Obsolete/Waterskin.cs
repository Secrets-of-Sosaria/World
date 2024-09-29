using System;
using System.Collections;
using Server.Network;
using Server.Prompts;
using Server.Targeting;

namespace Server.Items
{
	public class Waterskin : Item
	{
		[Constructable]
		public Waterskin() : base( 0xA21 )
		{
			Name = "empty waterskin";
			Weight = 1.0;
		}

		public override void OnDoubleClick( Mobile from )
		{
			bool soaked;
			Server.Items.DrinkingFunctions.CheckWater( from, 3, out soaked );

			if ( this.Weight < 1.95 && soaked ) // FILL IT IF NEAR WATER AND FLASK IS NOT FULL
			{
				if ( !IsChildOf( from.Backpack ) ) 
				{
					from.SendMessage( "This must be in your backpack to fill." );
					return;
				}
				else
				{
					from.PlaySound( 0x240 );
					if ( this.ItemID == 0x48E4 || this.ItemID == 0x4971 )
					{
						this.ItemID = 0x48E4;
						this.Name = "canteen";
					}
					else
					{
						this.ItemID = 0x98F;
						this.Name = "waterskin";
					}
					this.Weight = 2.0;
					this.InvalidateProperties();
				}
			}
			else if ( this.ItemID == 0xA21 || this.ItemID == 0x4971 ) // TOTALLY EMPTY
			{
				from.SendMessage( "You can only fill this at a water trough, tub, or barrel!" ); 
			}
			else
			{
				if ( !IsChildOf( from.Backpack ) ) 
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
							from.SendMessage( "You drink the water but are still extremely thirsty" );
						else if ( iThirst < 10 )
							from.SendMessage( "You drink the water and feel less thirsty" );
						else if ( iThirst < 15 )
							from.SendMessage( "You drink the water and feel much less thirsty" ); 
						else
							from.SendMessage( "You drink the water and are no longer thirsty" );

						if ( from.Body.IsHuman && !from.Mounted )
							from.Animate( 34, 5, 1, true, false, 0 );

						from.PlaySound( Utility.RandomList( 0x30, 0x2D6 ) );

						this.Weight = this.Weight - 0.1;

						if ( this.Weight <= 1.0 )
						{
							if ( this.ItemID == 0x48E4 || this.ItemID == 0x4971 )
							{
								this.ItemID = 0x4971;
								this.Name = "empty canteen";
							}
							else
							{
								this.ItemID = 0xA21;
								this.Name = "empty waterskin";
							}
							this.Weight = 1.0;
						}

						this.InvalidateProperties();

						Server.Items.DrinkingFunctions.DrinkBenefits( from );
					}
					else
					{
						from.SendMessage( "You are simply too quenched to drink any more!" );
						from.Thirst = 20;
					}
				}
			}
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			string drinks = "empty";

			if ( this.Weight >= 2.0 ){ drinks = "10 Drinks Remaining"; }
			else if ( this.Weight >= 1.85 ){ drinks = "9 Drinks Remaining"; }
			else if ( this.Weight >= 1.75 ){ drinks = "8 Drinks Remaining"; }
			else if ( this.Weight >= 1.65 ){ drinks = "7 Drinks Remaining"; }
			else if ( this.Weight >= 1.55 ){ drinks = "6 Drinks Remaining"; }
			else if ( this.Weight >= 1.45 ){ drinks = "5 Drinks Remaining"; }
			else if ( this.Weight >= 1.35 ){ drinks = "4 Drinks Remaining"; }
			else if ( this.Weight >= 1.25 ){ drinks = "3 Drinks Remaining"; }
			else if ( this.Weight >= 1.15 ){ drinks = "2 Drinks Remaining"; }
			else if ( this.Weight > 1.0 ){ drinks = "1 Drink Remaining"; }

			if ( drinks != "empty" ){ list.Add( 1070722, drinks ); }
		}

		public Waterskin( Serial serial ) : base( serial )
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
			Item item = new Pitcher( BeverageType.Water );
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}

}