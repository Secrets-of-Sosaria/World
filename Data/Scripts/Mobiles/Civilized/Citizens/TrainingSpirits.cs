using System;
using Server;
using Server.ContextMenus;
using System.Collections;
using System.Collections.Generic;
using Server.Network;
using System.Text;
using Server.Items;
using Server.Mobiles;
using Server.Misc;

namespace Server.Mobiles
{
	public class TrainingSpirits : Citizens
	{
		[Constructable]
		public TrainingSpirits()
		{
			Blessed = true;
			CantWalk = true;
			AI = AIType.AI_Melee;
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
		}

		public override void OnThink()
		{
			if ( DateTime.Now >= m_NextTalk )
			{
				foreach ( Item shrine in this.GetItemsInRange( 6 ) )
				{
					if ( 	shrine is AnkhWest || shrine is AnkhNorth || shrine is AltarEvil || shrine is AltarDurama || shrine is AltarWizard || shrine is AltarGargoyle || 
							shrine is AltarDaemon || shrine is AltarSea || shrine is AltarStatue || shrine is AltarShrineSouth || shrine is AltarShrineEast || 
							shrine is AltarDryad || shrine is AltarGodsSouth || shrine is AltarGodsEast )
					{
						Point3D goal = shrine.Location;
						Direction d = this.GetDirectionTo( goal );
						this.Direction = d;

						int action = Utility.RandomMinMax(1,4);

						string name = "Spirits";
							if ( shrine is AltarDurama ){ name = "Durama"; }
							else if ( shrine is AltarGargoyle ){ name = "Sin'Vraal"; }
							else if ( shrine is AltarWizard ){ name = "Archmage"; }
							else if ( shrine is AltarDaemon )
							{
								name = "Azrael";
								if ( shrine.ItemID == 0x6393 || shrine.ItemID == 0x6394 ){ name = "Ktulu"; }
							}
							else if ( shrine is AltarSea )
							{
								name = "Amphitrite";
								if ( shrine.ItemID == 0x4FB1 || shrine.ItemID == 0x4FB2 ){ name = "Poseidon"; }
								else if ( shrine.ItemID == 0x6395 ){ name = "Neptune"; }
							}
							else if ( shrine is AltarStatue ){ name = "Goddess"; }
							else if ( shrine is AltarEvil ){ name = "Deathly Reaper"; }
							else if ( shrine is AltarDryad ){ name = "Ancient Dryad"; }

						if ( action == 1 )
						{
							this.Say( "*meditating*" );
							this.PlaySound( 0xF9 );
							this.Animate( 269, 5, 1, true, false, 0 );
						}
						else if ( action == 2 )
						{
							this.Animate( 269, 5, 1, true, false, 0 );
							string plead = "Oh Great Spirits";
							string resurrect = ", please resurrect";
							string who = NameList.RandomName( "male" ); 
								if ( Utility.RandomBool() ){ who = NameList.RandomName( "female" ); }
								if ( Utility.RandomBool() ){ who = who + " " + TavernPatrons.GetTitle(); }

							string dungeon = QuestCharacters.SomePlace( "tavern" );	
								if ( Utility.RandomBool() ){ dungeon = RandomThings.MadeUpDungeon(); }

							string died = "was killed";
							switch( Utility.RandomMinMax( 0, 5 ) )
							{
								case 1: died = "was slain";				break;
								case 2: died = "was bested";			break;
								case 3: died = "was murdered";			break;
								case 4: died = "has perished";			break;
								case 5: died = "has met their end";		break;
							}

							switch ( Utility.Random( 8 ) )
							{
								case 0: resurrect = ", please resurrect";				break;
								case 1: resurrect = ", please bring back";				break;
								case 2: resurrect = ", I humbly ask you to resurrect";	break;
								case 3: resurrect = ", I beg you to resurrect";			break;
								case 4: resurrect = ", I humbly ask you to bring back";	break;
								case 5: resurrect = ", I beg you to bring back";		break;
								case 6: resurrect = ", please give life back to";		break;
								case 7: resurrect = ", give life back to";				break;
							}

							switch ( Utility.Random( 7 ) )
							{
								case 0: plead = "Oh " + name + "";				break;
								case 1: plead = "Oh Great " + name + "";		break;
								case 2: plead = "Please " + name + "";			break;
								case 3: plead = "Please Great " + name + "";	break;
								case 4: plead = "" + name + "";					break;
								case 5: plead = "Great " + name + "";			break;
								case 6: plead = "Oh Great " + name + "";		break;
							}

							switch ( Utility.Random( 3 ) )
							{
								case 0: plead = plead + resurrect + " " + who + ".";											break;
								case 1: plead = plead + resurrect + " " + who + ", that " + died + ".";							break;
								case 2: plead = plead + resurrect + " " + who + ", that " + died + " in " + dungeon + ".";		break;
							}

							this.Say( plead );
						}
						else if ( action == 3 )
						{
							this.Animate( 230, 5, 1, true, false, 0 );
							this.PlaySound( 0x2E6 );
							string praise = "Oh Great Spirits";
							string gold = ", accept this gold as my";
							string give = " tribute.";

							switch ( Utility.Random( 6 ) )
							{
								case 0: give = " tribute.";		break;
								case 1: give = " gift.";		break;
								case 2: give = " praise.";		break;
								case 3: give = " devotion.";	break;
								case 4: give = " honor.";		break;
								case 5: give = " respect.";		break;
							}

							switch ( Utility.Random( 8 ) )
							{
								case 0: gold = ", accept this gold as my";				break;
								case 1: gold = ", I give this gold as my";				break;
								case 2: gold = ", I humbly offer this gold as my";		break;
								case 3: gold = ", I offer this gold as my";				break;
								case 4: gold = ", take this gold as my";				break;
								case 5: gold = ", I part with this gold as my";			break;
								case 6: gold = ", I humbly sacrifice this gold as my";	break;
								case 7: gold = ", I sacrifice this gold as my";			break;
							}

							switch ( Utility.Random( 7 ) )
							{
								case 0: praise = "Oh " + name + "";		break;
								case 1: praise = "Oh Great " + name + "";	break;
								case 2: praise = "Please " + name + "";	break;
								case 3: praise = "Please Great " + name + "";	break;
								case 4: praise = "" + name + "";	break;
								case 5: praise = "Great " + name + "";	break;
								case 6: praise = "Oh Great " + name + "";	break;
							}

							praise = praise + gold + give;
							this.Say( praise );
						}
						else
						{
							if ( this.Karma < 0 )
							{
								this.Say( "Xtee Mee Glau" );
								this.PlaySound( 0x481 );
							}
							else
							{
								this.Say( "Anh Mi Sah Ko" );
								this.PlaySound( 0x24A );
							}
							if ( Utility.RandomBool() )
							{
								if ( this.Karma < 0 )
								{
									this.FixedParticles( 0x3400, 1, 15, 9501, 2100, 4, EffectLayer.Waist );
								}
								else
								{
									this.FixedParticles( 0x376A, 9, 32, 5005, 0xB70, 0, EffectLayer.Waist );
								}
							}
							if ( Utility.RandomBool() )
							{
								this.Animate( 269, 5, 1, true, false, 0 );
							}
						}

						m_NextTalk = (DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 12, 20 ) ));
					}
				}
			}
		}

		public override void OnAfterSpawn()
		{
			base.OnAfterSpawn();
			Server.Misc.MorphingTime.CheckNecromancer( this );
		}

		public TrainingSpirits( Serial serial ) : base( serial )
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