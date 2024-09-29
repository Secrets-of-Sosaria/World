using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;

namespace Server.Items
{
	public class SkeletonsKey : Item
	{
		public override string DefaultDescription
		{
			get
			{
				if ( Technology )
					return "These access cards can open many technological doors or containers. Use the access card and select locked item to see if it works.";

				return "These keys can open many doors or containers. Use the key and select locked item to see if it works.";
			}
		}

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public SkeletonsKey() : base( 0x410A )
		{
			Name = "skeleton key";
		}

		public override void OnDoubleClick( Mobile from )
		{
			Target t;

			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1060640 ); // The item must be in your backpack to use it.
			}
			else
			{
				from.SendMessage( "What locked container or door do you want to use the key on?" );
				t = new UnlockTarget( this );
				from.Target = t;
			}
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1049644, "Open most locked containers or doors" );
		}

		private class UnlockTarget : Target
		{
			private SkeletonsKey m_Key;

			public UnlockTarget( SkeletonsKey key ) : base( 1, false, TargetFlags.None )
			{
				m_Key = key;
				CheckLOS = true;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( !m_Key.IsChildOf( from.Backpack ) )
				{
					from.SendLocalizedMessage( 1060640 ); // The item must be in your backpack to use it.
				}
				else if ( targeted == m_Key )
				{
					from.SendMessage( "This key is to unlock certain containers." );
				}
				else if ( targeted is BaseHouseDoor )  // house door check
				{
					from.SendMessage( "This key is to unlock certain containers." );
				}
				else if ( targeted is Item && ((Item)targeted).VirtualContainer )
				{
					from.SendMessage( "This key is to unlock almost any container." );
				}
				else if ( targeted is BaseDoor )
				{
					if ( Server.Items.DoorType.IsSpaceshipDoor( (BaseDoor)targeted ) && m_Key.ItemID != 0x3A75 )
					{
						from.SendMessage( "This doesn't have a key hole, but it does have a card slot." );
					}
					else if ( !(Server.Items.DoorType.IsSpaceshipDoor( (BaseDoor)targeted )) && m_Key.ItemID == 0x3A75 )
					{
						from.SendMessage( "This doesn't have a card slot, but it does have a key hole." );
					}
					else if ( Server.Items.DoorType.IsSpaceshipDoor( (BaseDoor)targeted ) && m_Key.ItemID == 0x3A75 )
					{
						if ( ((BaseDoor)targeted).Locked == false )
							from.SendMessage( "That does not need to be unlocked." );
						else
						{
							((BaseDoor)targeted).Locked = false;
							Server.Items.DoorType.UnlockDoors( (BaseDoor)targeted );
							from.RevealingAction();
							from.PlaySound( 0x54B );
							m_Key.Consume();
						}
					}
					else if ( Server.Items.DoorType.IsDungeonDoor( (BaseDoor)targeted ) && m_Key.ItemID != 0x3A75 )
					{
						if ( ((BaseDoor)targeted).Locked == false )
							from.SendMessage( "That does not need to be unlocked." );
						else
						{
							((BaseDoor)targeted).Locked = false;
							Server.Items.DoorType.UnlockDoors( (BaseDoor)targeted );
							from.RevealingAction();
							from.PlaySound( 0x241 );
							m_Key.Consume();
						}
					}
					else
						from.SendMessage( "That does not need to be unlocked." );
				}
				else if ( targeted is ILockable )
				{
					ILockable o = (ILockable)targeted;
					LockableContainer cont2 = (LockableContainer)o;

					if ( Multis.BaseHouse.CheckSecured( cont2 ) ) 
						from.SendLocalizedMessage( 503098 ); // You cannot cast this on a secure item.
					else if ( !cont2.Locked )
						from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 503101 ); // That did not need to be unlocked.
					else if ( cont2.LockLevel == 0 )
						from.SendLocalizedMessage( 501666 ); // You can't unlock that!
					else if ( cont2.Catalog == Catalogs.SciFi && o.Locked && m_Key.ItemID != 0x3A75 )
					{
						from.SendMessage( "This doesn't have a key hole, but it does have a card slot." );
					}
					else if ( cont2.Catalog != Catalogs.SciFi && o.Locked && m_Key.ItemID == 0x3A75 )
					{
						from.SendMessage( "This doesn't have a card slot, but it does have a key hole." );
					}
					else if ( cont2.Catalog == Catalogs.SciFi && o.Locked && m_Key.ItemID == 0x3A75 )
					{
						int neededMod = Server.Difficult.GetDifficulty( from.Location, from.Map ) * 5;
							if ( neededMod < 1 ){ neededMod = 0; }
						int neededSkill = 51 + neededMod;

						if ( cont2.RequiredSkill < neededSkill )
						{
							o.Locked = false;

							if ( o is LockableContainer )
							{
								LockableContainer cont = (LockableContainer)o;
								if ( cont.LockLevel == -255 )
								{
									cont.LockLevel = cont.RequiredSkill - 10;
									if ( cont.LockLevel == 0 )
										cont.LockLevel = -1;
								}

								cont.Picker = from;  // sets "lockpicker" to the user.
							}

							if ( targeted is Item )
							{
								Item item = (Item)targeted;
								from.SendMessage( "You swipe the key card to open the lock, but also wearing it out from further use." );
							}

							from.RevealingAction();
							from.PlaySound( 0x54B );
							m_Key.Consume();
						}
						else 
						{
							from.SendMessage( "The lock seems too secure for this key card." );
						}
					}
					else if ( o.Locked && m_Key.ItemID != 0x3A75 )
					{
						if ( o is BaseDoor && !((BaseDoor)o).UseLocks() )  // this seems to check house doors also
						{
							from.SendMessage( "This key is to unlock certain containers." );
						}
						else if ( ( cont2.RequiredSkill < 51 ) && !( targeted is TreasureMapChest ) && !( targeted is PirateChest ) && !( targeted is ParagonChest ) )
						{
							o.Locked = false;

							if ( o is LockableContainer )
							{
								LockableContainer cont = (LockableContainer)o;
								if ( cont.LockLevel == -255 )
								{
									cont.LockLevel = cont.RequiredSkill - 10;
									if ( cont.LockLevel == 0 )
										cont.LockLevel = -1;
								}

								cont.Picker = from;  // sets "lockpicker" to the user.
							}

							if ( targeted is Item )
							{
								Item item = (Item)targeted;
								from.SendMessage( "The key opens the lock, wearing the key out from further use." );
							}

							from.RevealingAction();
							from.PlaySound( 0x241 );
							m_Key.Consume();
						}
						else 
						{
							from.SendMessage( "The lock seems too complicated for this key." );
						}
					}
					else
					{
						from.SendMessage( "You don't need to use this key on that." );
					}
				}
				else
				{
					from.SendMessage( "This key is to unlock certain containers." );
				}
			}
		}

		public SkeletonsKey( Serial serial ) : base( serial )
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