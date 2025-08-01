using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Targeting;
using Server.Items;
using Server.Network;
using Server.Spells.Seventh;
using Server.Spells.Fifth;
using Server.Spells.Necromancy;
using Server.Spells;
using Server.Spells.Ninjitsu;
using Server.Misc;
using Server.Systems;

namespace Server.SkillHandlers
{
	public class Stealing
	{
		private static Dictionary<Mobile, DateTime> _lastStealTime = new Dictionary<Mobile, DateTime>();
		public static void Initialize()
		{
			SkillInfo.Table[33].Callback = new SkillUseCallback(OnUse);
		}

		public static readonly bool ClassicMode = false;
		public static readonly bool SuspendOnMurder = false;

		public static bool IsInGuild( Mobile m )
		{
			return ( m is PlayerMobile && ((PlayerMobile)m).NpcGuild == NpcGuild.ThievesGuild );
		}

		public static bool IsInnocentTo( Mobile from, Mobile to )
		{
			return ( Notoriety.Compute( from, (Mobile)to ) == Notoriety.Innocent );
		}

		private class StealingTarget : Target
		{
			private Mobile m_Thief;

			public StealingTarget( Mobile thief ) : base ( 1, false, TargetFlags.None )
			{
				m_Thief = thief;

				AllowNonlocal = true;
			}

			private Item TryStealItem( Item toSteal, ref bool caught )
			{
				Item stolen = null;

				object root = toSteal.RootParent;

				if ( m_Thief.Blessed )
				{
					m_Thief.SendMessage( "You cannot steal that while in this state." );
					return null;
				}

				StealableArtifactsSpawner.StealableInstance si = null;
				if ( toSteal.Parent == null || !toSteal.Movable )
					si = StealableArtifactsSpawner.GetStealableInstance( toSteal );

				int rogue = 0;

				if ( si != null )
				{
					if ( (si.Item).GetType() == typeof( RockArtifact ) ){ 					rogue = 1; }
					else if ( (si.Item).GetType() == typeof( SkullCandleArtifact ) ){ 		rogue = 2; }
					else if ( (si.Item).GetType() == typeof( BottleArtifact ) ){ 			rogue = 3; }
					else if ( (si.Item).GetType() == typeof( DamagedBooksArtifact ) ){ 		rogue = 4; }
					else if ( (si.Item).GetType() == typeof( StretchedHideArtifact ) ){ 	rogue = 5; }
					else if ( (si.Item).GetType() == typeof( BrazierArtifact ) ){ 			rogue = 6; }
					else if ( (si.Item).GetType() == typeof( LampPostArtifact ) ){ 			rogue = 7; }
					else if ( (si.Item).GetType() == typeof( BooksNorthArtifact ) ){ 		rogue = 8; }
					else if ( (si.Item).GetType() == typeof( BooksWestArtifact ) ){ 		rogue = 9; }
					else if ( (si.Item).GetType() == typeof( BooksFaceDownArtifact ) ){ 	rogue = 10; }
					else if ( (si.Item).GetType() == typeof( StuddedLeggingsArtifact ) ){ 	rogue = 11; }
					else if ( (si.Item).GetType() == typeof( EggCaseArtifact ) ){ 			rogue = 12; }
					else if ( (si.Item).GetType() == typeof( SkinnedGoatArtifact ) ){ 		rogue = 13; }
					else if ( (si.Item).GetType() == typeof( GruesomeStandardArtifact ) ){ 	rogue = 14; }
					else if ( (si.Item).GetType() == typeof( BloodyWaterArtifact ) ){ 		rogue = 15; }
					else if ( (si.Item).GetType() == typeof( TarotCardsArtifact ) ){ 		rogue = 16; }
					else if ( (si.Item).GetType() == typeof( BackpackArtifact ) ){ 			rogue = 17; }
					else if ( (si.Item).GetType() == typeof( StuddedTunicArtifact ) ){ 		rogue = 18; }
					else if ( (si.Item).GetType() == typeof( CocoonArtifact ) ){ 			rogue = 19; }
					else if ( (si.Item).GetType() == typeof( SkinnedDeerArtifact ) ){ 		rogue = 20; }
					else if ( (si.Item).GetType() == typeof( SaddleArtifact ) ){ 			rogue = 21; }
					else if ( (si.Item).GetType() == typeof( LeatherTunicArtifact ) ){ 		rogue = 22; }
					else if ( (si.Item).GetType() == typeof( RuinedPaintingArtifact ) ){ 	rogue = 23; }

					if ( PlayerSettings.GetArtyConfig( m_Thief, rogue ) && !MySettings.S_DecoArtySteal )
					{
						si = null;
						m_Thief.PrivateOverheadMessage(MessageType.Regular, 1150, false, "I have already stolen that item!", m_Thief.NetState);
					}
				}

				if ( toSteal is DungeonChest )
				{
					DungeonChest dBox = (DungeonChest)toSteal;

					if ( m_Thief.Blessed )
					{
						m_Thief.SendMessage( "You cannot steal while in this state." );
					}
					else if ( dBox.ItemID == 0x3582 || dBox.ItemID == 0x3583 || dBox.ItemID == 0x35AD || dBox.ItemID == 0x3868 || ( dBox.ItemID >= 0x4B5A && dBox.ItemID <= 0x4BAB ) || ( dBox.ItemID >= 0xECA && dBox.ItemID <= 0xED2 ) )
					{
						m_Thief.SendMessage( "It is best to leave the dead be." );
					}
					else if ( dBox.ItemID == 0x3564 || dBox.ItemID == 0x3565 )
					{
						m_Thief.SendMessage( "You have not use for this broken golem thing." );
					}
					else
					{
						if ( m_Thief.CheckSkill( SkillName.Stealing, 0, 125 ) )
						{
							m_Thief.SendMessage( "You dump out the entire contents while stealing the item." );
							StolenChest sBox = new StolenChest();
							int dValue = 0;

							dValue = (dBox.ContainerLevel + 1) * (int)(50 * (MyServerSettings.GetGoldCutRate() * .01));
							sBox.Container_ID = dBox.ContainerID;
							sBox.Container_Gump = dBox.ContainerGump;
							sBox.Resource = dBox.Resource;
							sBox.Container_Hue = dBox.ContainerHue;
							sBox.Container_Flip = dBox.ContainerFlip;
							sBox.Container_Weight = dBox.ContainerWeight;
							sBox.Container_Name = dBox.ContainerName;
							sBox.Container_Value = dValue;

							Item iBox = (Item)sBox;

							iBox.ItemID = sBox.ContainerID;
							iBox.Hue = sBox.ContainerHue;
							iBox.Weight = sBox.ContainerWeight;
							iBox.Name = sBox.ContainerName;

							Bag oBox = (Bag)iBox;

							oBox.GumpID = sBox.ContainerGump;

							m_Thief.AddToBackpack( oBox );

							LoggingFunctions.LogStandard( m_Thief, "has stolen a " + iBox.Name + "" );
						}
						else
						{
							m_Thief.SendMessage( "You were not quick enough to steal it." );
							m_Thief.RevealingAction(); // REVEALING ONLY WHEN FAILED
						}

						Item spawnBox = new DungeonChestSpawner( dBox.ContainerLevel, (double)(Utility.RandomMinMax( 45, 105 )) );
						spawnBox.MoveToWorld (new Point3D(dBox.X, dBox.Y, dBox.Z), dBox.Map);

						toSteal.Delete();
					}
				}
				else if ( toSteal is LandChest && LandChest.isBody ( toSteal.ItemID ) )
				{
					m_Thief.SendMessage( "It is best to leave the dead be." );
				}
				else if ( toSteal is LandChest && !LandChest.isBody ( toSteal.ItemID ) )
				{
					m_Thief.SendMessage( "You would be quite foolish looking stealing a wagon." );
				}
				else if ( toSteal is SunkenShip )
				{
					m_Thief.SendMessage( "You are just not that strong." );
				}
				else if ( root is Mobile && ((Mobile)root).Player && IsInnocentTo( m_Thief, (Mobile)root ) && !IsInGuild( m_Thief ) )
				{
					m_Thief.SendLocalizedMessage( 1005596 ); // You must be in the thieves guild to steal from other players.
				}
				else if ( toSteal is Coffer )
				{
					Coffer coffer = (Coffer)toSteal;
					bool Pilfer = true;

					if ( m_Thief.Backpack.FindItemByType( typeof ( ThiefNote ) ) != null )
					{
						Item mail = m_Thief.Backpack.FindItemByType( typeof ( ThiefNote ) );
						ThiefNote envelope = (ThiefNote)mail;

						if ( envelope.NoteOwner == m_Thief )
						{
							if ( envelope.NoteItemArea == Server.Misc.Worlds.GetRegionName( m_Thief.Map, m_Thief.Location ) && envelope.NoteItemGot == 0 && envelope.NoteItemCategory == coffer.CofferType )
							{
								envelope.NoteItemGot = 1;
								m_Thief.LocalOverheadMessage(MessageType.Emote, 1150, true, "You found " + envelope.NoteItem + ".");
								m_Thief.SendSound( 0x3D );
								envelope.InvalidateProperties();
								Pilfer = false;
							}
						}
					}

					if ( Pilfer )
					{
						if ( coffer.CofferGold < 1 )
						{
							m_Thief.SendMessage( "There seems to be no gold in the coffer." );
						}
						else if ( m_Thief.CheckSkill( SkillName.Stealing, 0, 100 ) )
						{
							m_Thief.SendMessage( "You slip out " + coffer.CofferGold + " gold from the coffer." );
							m_Thief.SendSound( 0x2E6 );
							m_Thief.AddToBackpack ( new Gold( coffer.CofferGold ) );

							Titles.AwardFame( m_Thief, coffer.CofferGold, true );
							Titles.AwardKarma( m_Thief, -coffer.CofferGold, true );

							coffer.CofferRobbed = 1;
							coffer.CofferRobber = m_Thief.Name + " the " + Server.Misc.GetPlayerInfo.GetSkillTitle( m_Thief );
							coffer.CofferGold = 0;

							LoggingFunctions.LogStandard( m_Thief, "has stolen " + coffer.CofferGold + " gold from a " + coffer.CofferType + " in " + Server.Misc.Worlds.GetRegionName( m_Thief.Map, m_Thief.Location ) + "" );
						}
						else
						{
							m_Thief.SendMessage( "You fingers slip, causing you to get noticed!" );
							m_Thief.RevealingAction(); // REVEALING ONLY WHEN FAILED

							if ( !m_Thief.CheckSkill( SkillName.Snooping, 0, 150 ) )
							{
								List<Mobile> spotters = new List<Mobile>();
								foreach ( Mobile m in m_Thief.GetMobilesInRange( 10 ) )
								{
									if ( m is BaseVendor && m.CanSee( m_Thief ) && m.InLOS( m_Thief ) )
									{
										m_Thief.CriminalAction( false );
										m.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format ( "Stop! Thief!" ) ); 
									}
								}
							}
						}
					}
				}
				else if ( root is BaseVendor && ((BaseVendor)root).IsInvulnerable )
				{
					m_Thief.SendLocalizedMessage( 1005598 ); // You can't steal from shopkeepers.
				}
				else if ( root is PlayerVendor || root is PlayerBarkeeper )
				{
					m_Thief.SendLocalizedMessage( 502709 ); // You can't steal from vendors.
				}
				else if ( !m_Thief.CanSee( toSteal ) )
				{
					m_Thief.SendLocalizedMessage( 500237 ); // Target can not be seen.
				}
				else if ( m_Thief.Backpack == null || !m_Thief.Backpack.CheckHold( m_Thief, toSteal, false, true ) )
				{
					m_Thief.SendLocalizedMessage( 1048147 ); // Your backpack can't hold anything else.
				}
				else if ( si == null && ( toSteal.Parent == null || !toSteal.Movable ) )
				{
					m_Thief.SendLocalizedMessage( 502710 ); // You can't steal that!
				}
				else if ( toSteal.LootType == LootType.Newbied || toSteal.CheckBlessed( root ) )
				{
					m_Thief.SendLocalizedMessage( 502710 ); // You can't steal that!
				}
				else if ( Core.AOS && si == null && toSteal is Container )
				{
					m_Thief.SendLocalizedMessage( 502710 ); // You can't steal that!
				}
				else if ( !m_Thief.InRange( toSteal.GetWorldLocation(), 1 ) )
				{
					m_Thief.SendLocalizedMessage( 502703 ); // You must be standing next to an item to steal it.
				}
				else if ( si != null && m_Thief.Skills[SkillName.Stealing].Value < 100.0 )
				{
					m_Thief.SendLocalizedMessage( 1060025, "", 0x66D ); // You're not skilled enough to attempt the theft of this item.
				}
				else if ( toSteal.Parent is Mobile )
				{
					m_Thief.SendLocalizedMessage( 1005585 ); // You cannot steal items which are equipped.
				}
				else if ( root == m_Thief )
				{
					m_Thief.SendLocalizedMessage( 502704 ); // You catch yourself red-handed.
				}
				else if ( root is Mobile && ((Mobile)root).AccessLevel > AccessLevel.Player )
				{
					m_Thief.SendLocalizedMessage( 502710 ); // You can't steal that!
				}
				else if ( root is Mobile && !m_Thief.CanBeHarmful( (Mobile)root ) )
				{
				}
				else if ( root is Corpse )
				{
					m_Thief.SendLocalizedMessage( 502710 ); // You can't steal that!
				}
				else
				{
					double w = toSteal.Weight + toSteal.TotalWeight;

					if ( w > 10 )
					{
						m_Thief.SendMessage( "That is too heavy to steal." );
					}
					else
					{
						if ( toSteal.Stackable && toSteal.Amount > 1 )
						{
							int maxAmount = (int)((m_Thief.Skills[SkillName.Stealing].Value / 10.0) / toSteal.Weight);

							if ( maxAmount < 1 )
								maxAmount = 1;
							else if ( maxAmount > toSteal.Amount )
								maxAmount = toSteal.Amount;

							int amount = Utility.RandomMinMax( 1, maxAmount );

							if ( amount >= toSteal.Amount )
							{
								int pileWeight = (int)Math.Ceiling( toSteal.Weight * toSteal.Amount );
								pileWeight *= 10;

								if ( m_Thief.CheckTargetSkill( SkillName.Stealing, toSteal, pileWeight - 22.5, pileWeight + 27.5 ) )
									stolen = toSteal;
							}
							else
							{
								int pileWeight = (int)Math.Ceiling( toSteal.Weight * amount );
								pileWeight *= 10;

								if ( m_Thief.CheckTargetSkill( SkillName.Stealing, toSteal, pileWeight - 22.5, pileWeight + 27.5 ) )
								{
									stolen = Mobile.LiftItemDupe( toSteal, toSteal.Amount - amount );

									if ( stolen == null )
										stolen = toSteal;
								}
							}
						}
						else
						{
							int iw = (int)Math.Ceiling( w );
							iw *= 10;

							if ( m_Thief.CheckTargetSkill( SkillName.Stealing, toSteal, iw - 22.5, iw + 27.5 ) )
								stolen = toSteal;
						}

						if ( stolen != null )
						{
							m_Thief.SendLocalizedMessage( 502724 ); // You successfully steal the item.

							Titles.AwardKarma( m_Thief, -60, true );

							if ( si != null )
							{
								toSteal.Movable = true;
								si.Item = null;
							}
						}
						else
						{
							m_Thief.SendLocalizedMessage( 502723 ); // You fail to steal the item.
							m_Thief.RevealingAction(); // REVEALING ONLY WHEN FAILED
						}

						caught = ( m_Thief.Skills[SkillName.Stealing].Value < Utility.Random( 150 ) );
					}
				}

				if ( rogue > 0 && stolen != null )
					PlayerSettings.SetArtyConfig( m_Thief, rogue );

				return stolen;
			}

			protected override void OnTarget( Mobile from, object target )
			{
				//from.RevealingAction(); // NO REVEALING ON THIS SERVER

				Item stolen = null;
				object root = null;
				bool caught = false;

				if ( target is Item )
				{
					root = ((Item)target).RootParent;
					stolen = TryStealItem( (Item)target, ref caught );
				} 
				
				else if ( target is Mobile )
				{
				    Mobile victim = (Mobile)target;
				    Container pack = victim.Backpack;				

				    BaseCreature bc = victim as BaseCreature;
				    bool isCreature = (bc != null);
				    bool isValidNpc = isCreature && !bc.Controlled && !bc.Summoned;				

				    if (isValidNpc && pack != null && pack.Items.Count > 0)
				    {
				        if (_lastStealTime.ContainsKey(from))
				        {
							DateTime last = (DateTime)_lastStealTime[from];
   							DateTime nextAllowedTime = last + TimeSpan.FromMinutes(1);
   							if (DateTime.UtcNow < nextAllowedTime)
   							{
   							    TimeSpan remaining = nextAllowedTime - DateTime.UtcNow;
   							    int secondsLeft = (int)remaining.TotalSeconds;
								from.PublicOverheadMessage(MessageType.Regular, 0x3B2, false, string.Format("You must wait {0} seconds before you can attempt to steal again.", secondsLeft));
   							    from.SendMessage(string.Format("You must wait {0} seconds before you can attempt to steal again.", secondsLeft));
   							    return;
   							}
				        }				

				        _lastStealTime[from] = DateTime.UtcNow;				

				        int fame = victim.Fame;
				        int gold = 0;				

				        if (fame < 100) gold = Utility.RandomMinMax(2, 5);
				        else if (fame < 500) gold = Utility.RandomMinMax(2, 12);
				        else if (fame < 1000) gold = Utility.RandomMinMax(4, 32);
				        else if (fame < 2500) gold = Utility.RandomMinMax(8, 62);
				        else if (fame < 5000) gold = Utility.RandomMinMax(16, 102);
				        else if (fame < 7500) gold = Utility.RandomMinMax(32, 162);
				        else if (fame < 10000) gold = Utility.RandomMinMax(48, 242);
				        else if (fame < 14999) gold = Utility.RandomMinMax(80, 362);
				        else gold = Utility.RandomMinMax(160, 442);				

				        // Success roll
				        if (from.CheckSkill(SkillName.Stealing, 0, 100))
				        {
				            Gold stolenGold = new Gold(gold);
				            from.AddToBackpack(stolenGold);
							from.PublicOverheadMessage(MessageType.Regular, 0x3B2, false, string.Format("You successfully stole {0} gold.", gold));
							from.SendMessage(string.Format("You successfully stole {0} gold.", gold));
				            Titles.AwardKarma(from, -60, true);
				            from.PlaySound(0x2E6); // Coin sound				

				            // Contraband check
				            ContrabandSystem.TryGiveContraband(from, victim);
				        }
				        else
				        {
							from.PublicOverheadMessage(MessageType.Regular, 0x3B2, false, "You failed to steal anything.");
							from.SendMessage(string.Format("You failed to steal anything."));
				            from.RevealingAction();
				            caught = true;
				        }				

				        return;
				    }				
					// fallback - mostly for pet stealing for macroing
				    if (pack != null && pack.Items.Count > 0)
				    {
				        int randomIndex = Utility.Random(pack.Items.Count);				

				        root = target;
				        stolen = TryStealItem(pack.Items[randomIndex], ref caught);
				    }
				} 
				else 
				{
					m_Thief.SendLocalizedMessage( 502710 ); // You can't steal that!
				}

				if ( stolen != null )
				{
					from.AddToBackpack( stolen );

					StolenItem.Add( stolen, m_Thief, root as Mobile );
					//contraband boxes can only be found if the thief suceeded at stealing something
					Mobile m = target as Mobile;
					if (m != null && !m.Player)
					{
						BaseCreature creature = m as BaseCreature;
						if(creature == null || (!creature.Controlled && !creature.Summoned))
					    ContrabandSystem.TryGiveContraband(from, m);
					}
				}

				if ( caught )
				{
					if ( root == null )
					{
						m_Thief.CriminalAction( false );
					}
					else if ( root is Corpse && ((Corpse)root).IsCriminalAction( m_Thief ) )
					{
						m_Thief.CriminalAction( false );
					}
					else if ( root is Mobile )
					{
						Mobile mobRoot = (Mobile)root;

						if ( !IsInGuild( mobRoot ) && IsInnocentTo( m_Thief, mobRoot ) )
							m_Thief.CriminalAction( false );

						string message = String.Format( "You notice {0} trying to steal from {1}.", m_Thief.Name, mobRoot.Name );
						m_Thief.RevealingAction(); // REVEALING ONLY WHEN NOTICED
						Server.Items.DisguiseTimers.RemoveDisguise( m_Thief );
						foreach ( NetState ns in m_Thief.GetClientsInRange( 8 ) )
						{
							if ( ns.Mobile != m_Thief )
								ns.Mobile.SendMessage( message );
						}
					}
				}
				else if ( root is Corpse && ((Corpse)root).IsCriminalAction( m_Thief ) )
				{
					m_Thief.CriminalAction( false );
				}

				if ( root is Mobile && ((Mobile)root).Player && m_Thief is PlayerMobile && IsInnocentTo( m_Thief, (Mobile)root ) && !IsInGuild( (Mobile)root ) )
				{
					PlayerMobile pm = (PlayerMobile)m_Thief;

					pm.PermaFlags.Add( (Mobile)root );
					pm.Delta( MobileDelta.Noto );
				}
			}
		}

		public static TimeSpan OnUse( Mobile m )
		{
				m.Target = new Stealing.StealingTarget( m );
				m.SendLocalizedMessage( 502698 ); // Which item do you want to steal?
				return TimeSpan.FromSeconds( 5.0 );
		}
	}

	public class StolenItem
	{
		public static readonly TimeSpan StealTime = TimeSpan.FromMinutes( 2.0 );

		private Item m_Stolen;
		private Mobile m_Thief;
		private Mobile m_Victim;
		private DateTime m_Expires;

		public Item Stolen{ get{ return m_Stolen; } }
		public Mobile Thief{ get{ return m_Thief; } }
		public Mobile Victim{ get{ return m_Victim; } }
		public DateTime Expires{ get{ return m_Expires; } }

		public bool IsExpired{ get{ return ( DateTime.Now >= m_Expires ); } }

		public StolenItem( Item stolen, Mobile thief, Mobile victim )
		{
			m_Stolen = stolen;
			m_Thief = thief;
			m_Victim = victim;

			m_Expires = DateTime.Now + StealTime;
		}

		private static Queue m_Queue = new Queue();

		public static void Add( Item item, Mobile thief, Mobile victim )
		{
			Clean();

			m_Queue.Enqueue( new StolenItem( item, thief, victim ) );
		}

		public static bool IsStolen( Item item )
		{
			Mobile victim = null;

			return IsStolen( item, ref victim );
		}

		public static bool IsStolen( Item item, ref Mobile victim )
		{
			Clean();

			foreach ( StolenItem si in m_Queue )
			{
				if ( si.m_Stolen == item && !si.IsExpired )
				{
					victim = si.m_Victim;
					return true;
				}
			}

			return false;
		}

		public static void ReturnOnDeath( Mobile killed, Container corpse )
		{
			Clean();

			foreach ( StolenItem si in m_Queue )
			{
				if ( si.m_Stolen.RootParent == corpse && si.m_Victim != null && !si.IsExpired )
				{
					if ( si.m_Victim.AddToBackpack( si.m_Stolen ) )
						si.m_Victim.SendLocalizedMessage( 1010464 ); // the item that was stolen is returned to you.
					else
						si.m_Victim.SendLocalizedMessage( 1010463 ); // the item that was stolen from you falls to the ground.

					si.m_Expires = DateTime.Now; // such a hack
				}
			}
		}

		public static void Clean()
		{
			while ( m_Queue.Count > 0 )
			{
				StolenItem si = (StolenItem) m_Queue.Peek();

				if ( si.IsExpired )
					m_Queue.Dequeue();
				else
					break;
			}
		}
	}
}