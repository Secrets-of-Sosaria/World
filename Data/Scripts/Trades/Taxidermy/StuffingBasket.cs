using System;
using Server; 
using System.Collections;
using Server.ContextMenus;
using System.Collections.Generic;
using Server.Misc;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using System.Globalization;
using Server.Regions;
using Server.Targeting;

namespace Server.Items
{
	public class StuffingBasket : Item
	{
		[Constructable]
		public StuffingBasket() : base( 0x65B8 )
		{
			Weight = 3.0;
			Name = "stuffing basket";
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Double Click For Information");
            list.Add( 1049644, "Single Click To Use");
        }

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{ 
			base.GetContextMenuEntries( from, list ); 
			list.Add( new StuffingGump( from, this ) );
		} 

		public class StuffingGump : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private StuffingBasket m_Trophy;
			
			public StuffingGump( Mobile from, StuffingBasket trophy ) : base( 6132, 3 )
			{
				m_Mobile = from;
				m_Trophy = trophy;
			}

			public override void OnClick()
			{
			    if( !( m_Mobile is PlayerMobile ) )
				return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;
				{
					m_Mobile.SendMessage("What corpse do you want to stuff?");
					m_Mobile.Target = new CorpseTarget( m_Trophy );
				}
            }
        }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendGump(new SpeechGump( from, "Stuffing the Creature", SpeechFunctions.SpeechText( from, from, "Stuffing" ) ));
		}

		private class CorpseTarget : Target
		{
			private StuffingBasket m_Trophy;

			public CorpseTarget( StuffingBasket boards ) : base( 3, false, TargetFlags.None )
			{
				m_Trophy = boards;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Trophy.Deleted )
					return;

				if ( !(targeted is Corpse) )
				{
					from.SendMessage("That cannot be stuffed as a trophy!");
                    return;
				}
				else
				{
					Region reg = Region.Find( from.Location, from.Map );

					object obj = targeted;

					if ( obj is Corpse )
						obj = ((Corpse)obj).Owner;

                    if ( obj != null )
                    {
						Corpse c = (Corpse)targeted;

						string trophyName = c.Name;
							if ( c.m_Owner.Title != "" ){ trophyName = trophyName + " " + c.m_Owner.Title; }

						if ( c.VisitedByTaxidermist == true )
						{
							from.SendMessage("This has already been claimed as a trophy!");
							return;
						}
						else
						{
							int stuffed = 0;
							int bearhue = 0;

							if ( typeof( SabretoothBearRiding ) == c.Owner.GetType() ){ stuffed = 0x56A3; }
							else if ( typeof( BrownBear ) == c.Owner.GetType() ){ stuffed = 0x569B; }
							else if ( typeof( SabreclawCub ) == c.Owner.GetType() ){ stuffed = 0x569B; bearhue = 443; }
							else if ( typeof( BlackBear ) == c.Owner.GetType() ){ stuffed = 0x569B; bearhue = 0xB3A; }
							else if ( typeof( GreatBear ) == c.Owner.GetType() ){ stuffed = 0x569F; bearhue = 0xAC0; }
							else if ( typeof( KodiakBear ) == c.Owner.GetType() ){ stuffed = 0x569F; bearhue = 0xAB1; }
							else if ( typeof( PolarBear ) == c.Owner.GetType() ){ stuffed = 0x569F; }
							else if ( typeof( GrizzlyBearRiding ) == c.Owner.GetType() ){ stuffed = 0x569D; }
							else if ( typeof( DireBear ) == c.Owner.GetType() ){ stuffed = 0x569F; bearhue = 0x92B; }
							else if ( typeof( ElderBrownBearRiding ) == c.Owner.GetType() ){ stuffed = 0x56A3; }
							else if ( typeof( SabretoothBearRiding ) == c.Owner.GetType() ){ stuffed = 0x840; }
							else if ( typeof( ElderPolarBearRiding ) == c.Owner.GetType() ){ stuffed = 0x56A7; }
							else if ( typeof( ElderBlackBearRiding ) == c.Owner.GetType() ){ stuffed = 0x56A5; }
							else if ( typeof( CaveBearRiding ) == c.Owner.GetType() ){ stuffed = 0x56A9; }

							else if ( typeof( LionRiding ) == c.Owner.GetType() ){ stuffed = 0x56A1; }
							else if ( typeof( SnowLion ) == c.Owner.GetType() ){ stuffed = 0x56A1; bearhue = 0xB4D; }

							else if ( typeof( Grathek ) == c.Owner.GetType() ){ stuffed = 0x4D0C; bearhue = 0x77E; }
							else if ( typeof( Lizardman ) == c.Owner.GetType() ){ stuffed = 0x4D0C; bearhue = 0x77E; }
							else if ( typeof( LizardmanArcher ) == c.Owner.GetType() ){ stuffed = 0x4D0C; bearhue = 0x77E; }
							else if ( typeof( Reptalar ) == c.Owner.GetType() ){ stuffed = 0x4D0C; bearhue = 0x77E; }
							else if ( typeof( ReptalarChieftain ) == c.Owner.GetType() ){ stuffed = 0x4D0C; bearhue = 0x77E; }
							else if ( typeof( ReptalarShaman ) == c.Owner.GetType() ){ stuffed = 0x4D0C; bearhue = 0x77E; }
							else if ( typeof( Reptaur ) == c.Owner.GetType() ){ stuffed = 0x4D0C; bearhue = 0x77E; }
							else if ( typeof( Sakleth ) == c.Owner.GetType() ){ stuffed = 0x4D0C; bearhue = 0x77E; }
							else if ( typeof( SaklethArcher ) == c.Owner.GetType() ){ stuffed = 0x4D0C; bearhue = 0x77E; }
							else if ( typeof( SaklethMage ) == c.Owner.GetType() ){ stuffed = 0x4D0C; bearhue = 0x77E; }
							else if ( typeof( Sleestax ) == c.Owner.GetType() ){ stuffed = 0x4D0C; bearhue = 0x77E; }

							else if ( typeof( DeathAdder ) == c.Owner.GetType() ){ stuffed = 0x1A7F; bearhue = c.Hue; }
							else if ( typeof( JadeSerpent ) == c.Owner.GetType() ){ stuffed = 0x1A7F; bearhue = c.Hue; }
							else if ( typeof( GiantAdder ) == c.Owner.GetType() ){ stuffed = 0x1A7F; bearhue = c.Hue; }
							else if ( typeof( Titanoboa ) == c.Owner.GetType() ){ stuffed = 0x1A7F; bearhue = c.Hue; }
							else if ( typeof( RandomSerpent ) == c.Owner.GetType() ){ stuffed = 0x1A7F; bearhue = c.Hue; }
							else if ( typeof( LavaSnake ) == c.Owner.GetType() ){ stuffed = 0x1A7F; bearhue = c.Hue; }
							else if ( typeof( LavaSerpent ) == c.Owner.GetType() ){ stuffed = 0x1A7F; bearhue = c.Hue; }
							else if ( typeof( LargeSnake ) == c.Owner.GetType() ){ stuffed = 0x1A7F; bearhue = c.Hue; }
							else if ( typeof( JungleViper ) == c.Owner.GetType() ){ stuffed = 0x1A7F; bearhue = c.Hue; }
							else if ( typeof( IceSerpent ) == c.Owner.GetType() ){ stuffed = 0x1A7F; bearhue = c.Hue; }
							else if ( typeof( GiantSnake ) == c.Owner.GetType() ){ stuffed = 0x1A7F; bearhue = c.Hue; }
							else if ( typeof( GiantSerpent ) == c.Owner.GetType() ){ stuffed = 0x1A7F; bearhue = c.Hue; }
							else if ( typeof( GiantIceWorm ) == c.Owner.GetType() ){ stuffed = 0x1A7F; bearhue = c.Hue; }
							else if ( typeof( BloodSnake ) == c.Owner.GetType() ){ stuffed = 0x1A7F; bearhue = c.Hue; }
							else if ( typeof( GiantLamprey ) == c.Owner.GetType() ){ stuffed = 0x1A7F; bearhue = c.Hue; }

							else if ( typeof( TigerRiding ) == c.Owner.GetType() )
							{
								stuffed = 1; if ( Utility.RandomBool() ){ from.AddToBackpack( new TigerRugEastDeed() ); } else { from.AddToBackpack( new TigerRugSouthDeed() ); } 
							}
							else if ( typeof( SabretoothTigerRiding ) == c.Owner.GetType() )
							{
								stuffed = 1; if ( Utility.RandomBool() ){ from.AddToBackpack( new TigerRugEastDeed() ); } else { from.AddToBackpack( new TigerRugSouthDeed() ); } 
							}
							else if ( typeof( WhiteTigerRiding ) == c.Owner.GetType() )
							{
								stuffed = 1; if ( Utility.RandomBool() ){ from.AddToBackpack( new WhiteTigerRugEastDeed() ); } else { from.AddToBackpack( new WhiteTigerRugSouthDeed() ); } 
							}

							if ( stuffed == 1 )
							{
								from.SendMessage("You create a rug from the creature.");
								c.VisitedByTaxidermist = true;
								m_Trophy.Delete();
							}
							else if ( stuffed > 1 )
							{
								StuffedBear trophy = new StuffedBear();
								trophy.Hue = bearhue;
								trophy.Name = "stuffed trophy of " + trophyName;
								trophy.ItemID = stuffed;
								trophy.Weight = 7.0;
								trophy.AnimalWhere = "From " + Server.Misc.Worlds.GetRegionName( from.Map, from.Location );
								if ( c.m_Killer != null && c.m_Killer is PlayerMobile )
								{
									string trophyKiller = c.m_Killer.Name + " the " + Server.Misc.GetPlayerInfo.GetSkillTitle( c.m_Killer );
									trophy.AnimalKiller = "Slain by " + trophyKiller;
								}
								from.AddToBackpack( trophy );
								from.SendMessage("You stuff the corpse.");
								c.VisitedByTaxidermist = true;
								m_Trophy.Delete();
							}
							else if ( stuffed < 1 )
							{
								from.SendMessage("That cannot be stuffed as a trophy!");
								return;
							}
						}
					}
					else
					{
						from.SendMessage("That cannot seem to stuff this as a trophy!");
						return;
					}
				}
			}
		}

		public StuffingBasket( Serial serial ) : base( serial )
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