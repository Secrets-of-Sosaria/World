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
	public class MountingBase : Item
	{
		[Constructable]
		public MountingBase() : base( 0x65B5 )
		{
			Weight = 10.0;
			Name = "mounting base";
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
			list.Add( new MountingGump( from, this ) );
		} 

		public class MountingGump : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private MountingBase m_Trophy;
			
			public MountingGump( Mobile from, MountingBase trophy ) : base( 6132, 3 )
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
					m_Mobile.SendMessage("What corpse do you want to mount?");
					m_Mobile.Target = new CorpseTarget( m_Trophy );
				}
            }
        }

		public override void OnDoubleClick( Mobile from )
		{
			from.SendGump(new SpeechGump( from, "Mount the Hunted", SpeechFunctions.SpeechText( from, from, "Stuff" ) ));
		}

		private class CorpseTarget : Target
		{
			private MountingBase m_Trophy;

			public CorpseTarget( MountingBase boards ) : base( 3, false, TargetFlags.None )
			{
				m_Trophy = boards;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Trophy.Deleted )
					return;

				if ( !(targeted is Corpse) )
				{
					from.SendMessage("That cannot be mounted as a trophy!");
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
							int thishue = 0;

							if ( typeof( YoungRoc ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x6566,0x6566); }
							else if ( typeof( Roc ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x6566,0x6566); }
							else if ( typeof( GiantHawk ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x65B3,0x65B4); thishue = c.Hue; }
							else if ( typeof( GiantRaven ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x65B3,0x65B4); thishue = c.Hue; }
							else if ( typeof( Phoenix ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x65B3,0x65B4); thishue = c.Hue; }

							else if ( typeof( Jormungandr ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x4D0A,0x4D0B); }
							else if ( typeof( Basilosaurus ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x655C,0x655D); thishue = 0xB70; }
							else if ( typeof( GiantEel ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x655C,0x655D); thishue = c.Hue; }
							else if ( typeof( SeaSerpent ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x655C,0x655D); thishue = c.Hue; }
							else if ( typeof( DeepSeaSerpent ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x655C,0x655D); thishue = c.Hue; }

							else if ( typeof( GiantToad ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x6556,0x6557); }
							else if ( typeof( BullFrog ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x65AF,0x65B0); thishue = c.Hue; }
							else if ( typeof( Frog ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x65AF,0x65B0); thishue = c.Hue; }
							else if ( typeof( Toad ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x65AF,0x65B0); thishue = c.Hue; }
							else if ( typeof( IceToad ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x65AF,0x65B0); thishue = c.Hue; }
							else if ( typeof( PoisonFrog ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x65AF,0x65B0); thishue = c.Hue; }
							else if ( typeof( FireToad ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x65AF,0x65B0); thishue = c.Hue; }

							else if ( typeof( Kraken ) == c.Owner.GetType() ){ stuffed = 0x6555; }
							else if ( typeof( GiantSquid ) == c.Owner.GetType() ){ stuffed = 0x65AC; thishue = c.Hue; }
							else if ( typeof( SandSquid ) == c.Owner.GetType() ){ stuffed = 0x65AC; thishue = c.Hue; }
							else if ( typeof( Leviathan ) == c.Owner.GetType() ){ stuffed = 0x65AC; thishue = c.Hue; }
							else if ( typeof( RottingSquid ) == c.Owner.GetType() ){ stuffed = 0x65AC; thishue = c.Hue; }

							else if ( typeof( AbyssCrawler ) == c.Owner.GetType() ){ stuffed = 0x65AB; thishue = 0xB01; }
							else if ( typeof( Arachnar ) == c.Owner.GetType() ){ stuffed = 0x65AB; thishue = 0xB02; }
							else if ( typeof( DreadSpider ) == c.Owner.GetType() ){ stuffed = 0x65AB; thishue = 0xAEA; }
							else if ( typeof( FrostSpider ) == c.Owner.GetType() ){ stuffed = 0x65AB; thishue = 0xB33; }
							else if ( typeof( GiantBlackWidow ) == c.Owner.GetType() ){ stuffed = 0x6544; }
							else if ( typeof( GiantSpider ) == c.Owner.GetType() ){ stuffed = 0x65AB; thishue = 0xAE8; }
							else if ( typeof( LargeSpider ) == c.Owner.GetType() ){ stuffed = 0x65AB; thishue = 0xAE8; }
							else if ( typeof( MonstrousSpider ) == c.Owner.GetType() ){ stuffed = 0x6544; }
							else if ( typeof( PhaseSpider ) == c.Owner.GetType() ){ stuffed = 0x65AB; thishue = 0xAF8; }
							else if ( typeof( SandSpider ) == c.Owner.GetType() ){ stuffed = 0x65AB; thishue = 0xB1B; }
							else if ( typeof( ShadowRecluse ) == c.Owner.GetType() ){ stuffed = 0x6544; }
							else if ( typeof( Tarantula ) == c.Owner.GetType() ){ stuffed = 0x65AB; thishue = 0xAE8; }
							else if ( typeof( WaterStrider ) == c.Owner.GetType() ){ stuffed = 0x65AB; thishue = c.Hue; }
							else if ( typeof( ZombieSpider ) == c.Owner.GetType() ){ stuffed = 0x65AB; thishue = 0xB07; }

							else if ( typeof( SabretoothBearRiding ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x656B,0x656C); thishue = 0x786; }
							else if ( typeof( BrownBear ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x656B,0x656C); thishue = 0x840; }
							else if ( typeof( SabreclawCub ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x656B,0x656C); thishue = 443; }
							else if ( typeof( BlackBear ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x656B,0x656C); thishue = 0xAB1; }
							else if ( typeof( GreatBear ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x656B,0x656C); thishue = 0x840; }
							else if ( typeof( KodiakBear ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x656B,0x656C); thishue = 0xAB1; }
							else if ( typeof( PolarBear ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x655A,0x655B); }
							else if ( typeof( GrizzlyBearRiding ) == c.Owner.GetType() ){ stuffed = 0x569D; }
							else if ( typeof( DireBear ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x656B,0x656C); thishue = 0x92B; }

							else if ( typeof( ElderBrownBearRiding ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x656B,0x656C); thishue = 0x840; }
							else if ( typeof( SabretoothBearRiding ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x656B,0x656C); thishue = 0x786; }
							else if ( typeof( ElderPolarBearRiding ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x655A,0x655B); }
							else if ( typeof( ElderBlackBearRiding ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x656B,0x656C); thishue = 0xAB1; }
							else if ( typeof( CaveBearRiding ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x656B,0x656C); thishue = 0x855; }

							else if ( typeof( Scorpion ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x4FBB,0x4FBC); thishue = 0xB2F; }
							else if ( typeof( DeadlyScorpion ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x4FBB,0x4FBC); thishue = 0xB4F; }

							else if ( typeof( Gorilla ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x6558,0x6559); }
							else if ( typeof( Ape ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x6558,0x6559); }
							else if ( typeof( Gorakong ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x6558,0x6559); }
							else if ( typeof( Yeti ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x65B1,0x65B2); thishue = 0xB4D; }
							else if ( typeof( Infected ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x65B1,0x65B2); thishue = 0xB01; }

							else if ( typeof( LesserSeaSnake ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x65B6,0x65B7); thishue = 0xB00; }
							else if ( typeof( SeaSnake ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x5391,0x5392); }

							else if ( typeof( RavenousRiding ) == c.Owner.GetType() ){ stuffed = Utility.RandomList(0x4FA4,0x4FA5); thishue = 0x851; }
							else if ( typeof( RaptorRiding ) == c.Owner.GetType() )
							{
								if ( c.Amount == 116 ){ stuffed = Utility.RandomList(0x4FA4,0x4FA5); thishue = 0x796; }
								else if ( c.Amount == 117 ){ stuffed = Utility.RandomList(0x4FA4,0x4FA5); thishue = 0xB01; }
								else { stuffed = Utility.RandomList(0x4FA4,0x4FA5); thishue = 0xB51; }
							}

							if ( stuffed > 0 )
							{
								StuffedBear trophy = new StuffedBear();
								trophy.Hue = thishue;
								trophy.Name = "mounted trophy of " + trophyName;
								trophy.ItemID = stuffed;
								trophy.Weight = 10.0;
								trophy.AnimalWhere = "From " + Server.Misc.Worlds.GetRegionName( from.Map, from.Location );
								if ( c.m_Killer != null && c.m_Killer is PlayerMobile )
								{
									string trophyKiller = c.m_Killer.Name + " the " + Server.Misc.GetPlayerInfo.GetSkillTitle( c.m_Killer );
									trophy.AnimalKiller = "Slain by " + trophyKiller;
								}
								from.AddToBackpack( trophy );
								from.SendMessage("You mount the corpse.");
								c.VisitedByTaxidermist = true;
								m_Trophy.Delete();
							}
							else
							{
								from.SendMessage("That cannot be mounted as a trophy!");
								return;
							}
						}
					}
					else
					{
						from.SendMessage("That cannot seem to mount this as a trophy!");
						return;
					}
				}
			}
		}

		public MountingBase( Serial serial ) : base( serial )
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