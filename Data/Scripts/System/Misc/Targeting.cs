using System;
using Server;
using Server.Targeting;
using Server.Items;
using Server.Engines.Harvest;
using Server.Mobiles;
using Server.Commands;
using Server.Commands.Generic;

namespace Server.Targets
{
	public class BladedItemTarget : Target
	{
		private Item m_Item;

		public BladedItemTarget( Item item ) : base( 2, false, TargetFlags.None )
		{
			m_Item = item;
		}

		protected override void OnTargetOutOfRange( Mobile from, object targeted )
		{
			base.OnTargetOutOfRange (from, targeted);
		}

		protected override void OnTarget( Mobile from, object targeted )
		{
			if ( m_Item.Deleted )
				return;

			if ( targeted is ICarvable )
			{
				((ICarvable)targeted).Carve( from, m_Item );
			}
			else if ( targeted is Container )
			{
				Container body = (Container)targeted;

				if ( body.ItemID >= 0x4B5A && body.ItemID <= 0x4BAB )
				{
					body.ItemID = Utility.RandomList( 0xECA, 0xECB, 0xECC, 0xECD, 0xECE, 0xECF, 0xED0, 0xED1, 0xED2 );
					body.Hue = 0;
					((Container)targeted).GumpID = 0x2A73;
					((Container)targeted).DropSound = 0x48;

					from.CriminalAction( true );
					Misc.Titles.AwardKarma( from, -50, true );

					body.DropItem( new BodyPart( 0x1D9F ) );
					body.DropItem( new BodyPart( 0x1DA4 ) );
					body.DropItem( new BodyPart( 0x1DA2 ) );
					body.DropItem( new BodyPart( 0x1DA3 ) );
					body.DropItem( new BodyPart( 0x1DA1 ) );
					body.DropItem( new BodyPart( 0x1DA0 ) );

					from.SendMessage( "You hack up the body into bloody pieces." );
				}
			}
			else if ( targeted is SwampDragon && ((SwampDragon)targeted).HasBarding )
			{
				SwampDragon pet = (SwampDragon)targeted;

				if ( !pet.Controlled || pet.ControlMaster != from )
					from.SendLocalizedMessage( 1053022 ); // You cannot remove barding from a swamp dragon you do not own.
				else
					pet.HasBarding = false;
			}
			else
			{
				HarvestSystem system = Lumberjacking.System;
				HarvestDefinition def = Lumberjacking.System.Definition;

				int tileID;
				Map map;
				Point3D loc;

				if ( !system.GetHarvestDetails( from, m_Item, targeted, out tileID, out map, out loc ) )
				{
					from.SendLocalizedMessage( 500494 ); // You can't use a bladed item on that!
				}
				else if ( !def.Validate( tileID ) )
				{
					from.SendLocalizedMessage( 500494 ); // You can't use a bladed item on that!
				}
				else
				{
					HarvestBank bank = def.GetBank( map, loc.X, loc.Y );

					if ( bank == null )
						return;

					if ( bank.Current < 5 )
					{
						from.SendMessage( "There is not enough here to harvest." );
						//from.SendLocalizedMessage( 500493 ); // There's not enough wood here to harvest.
					}
					else
					{
						bank.Consume( 5, from );

						if ( tileID == 0x4D96 || tileID == 0x4D9A ) // apples
						{
							Item item = new Apple();

							if ( from.PlaceInBackpack( item ) )
							{
								from.SendMessage( "You put an apple into your backpack." );
							}
							else
							{
								from.SendMessage( "You can't place any apples into your backpack!" );
								item.Delete();
							}
						}
						else if ( tileID == 0x4DA6 || tileID == 0x4DAA ) // pears
						{
							Item item = new Pear();

							if ( from.PlaceInBackpack( item ) )
							{
								from.SendMessage( "You put a pear into your backpack." );
							}
							else
							{
								from.SendMessage( "You can't place any pears into your backpack!" );
								item.Delete();
							}
						}
						else if ( tileID == 0x4D9E || tileID == 0x4DA2 ) // peaches
						{
							Item item = new Peach();

							if ( from.PlaceInBackpack( item ) )
							{
								from.SendMessage( "You put a peach into your backpack." );
							}
							else
							{
								from.SendMessage( "You can't place any peaches into your backpack!" );
								item.Delete();
							}
						}
						else if ( tileID == 0x4CDA || tileID == 0x4CDB || tileID == 0x4CDC || tileID == 0x4CDD || tileID == 0x4CDE || tileID == 0x4CDF ) // acorns
						{
							Item item = new Acorn();

							if ( from.PlaceInBackpack( item ) )
							{
								from.SendMessage( "You put an acorn into your backpack." );
							}
							else
							{
								from.SendMessage( "You can't place any acorns into your backpack!" );
								item.Delete();
							}
						}
						else if ( tileID == 0x4CA8 || tileID == 0x4CAA || tileID == 0x4CAB ) // bananas
						{
							Item item = new Banana();

							if ( from.PlaceInBackpack( item ) )
							{
								from.SendMessage( "You put a banana into your backpack." );
							}
							else
							{
								from.SendMessage( "You can't place any bananas into your backpack!" );
								item.Delete();
							}
						}
						else if ( tileID == 0x4C95 || tileID == 26164 || 
								tileID == 26143 || tileID == 26144 || tileID == 26145 || tileID == 26146 || tileID == 26147 || tileID == 26148 || tileID == 26149 || 
								tileID == 26150 || tileID == 26151 || tileID == 26152 || tileID == 26153 || tileID == 26154 || tileID == 26155 || tileID == 26156 || 
								tileID == 26157 || tileID == 26158 || tileID == 26159 || tileID == 26160 || tileID == 26161 || tileID == 26162 || tileID == 26163 )
						{	// coconut
							Item item = new Coconut();

							if ( from.PlaceInBackpack( item ) )
							{
								from.SendMessage( "You put a coconut into your backpack." );
							}
							else
							{
								from.SendMessage( "You can't place any coconuts into your backpack!" );
								item.Delete();
							}
						}
						else if ( tileID == 0x4C96 ) // dates
						{
							Item item = new Dates();

							if ( from.PlaceInBackpack( item ) )
							{
								from.SendMessage( "You put some dates into your backpack." );
							}
							else
							{
								from.SendMessage( "You can't place any dates into your backpack!" );
								item.Delete();
							}
						}
						else
						{
							Item item = new Kindling();

							if ( from.PlaceInBackpack( item ) )
							{
								from.SendLocalizedMessage( 500491 ); // You put some kindling into your backpack.
								from.SendLocalizedMessage( 500492 ); // An axe would probably get you more wood.
							}
							else
							{
								from.SendLocalizedMessage( 500490 ); // You can't place any kindling into your backpack!

								item.Delete();
							}
						}
					}
				}
			}
		}
	}
}

namespace Server.Targets
{
	public class PickMoveTarget : Target
	{
		public PickMoveTarget() : base( -1, false, TargetFlags.None )
		{
		}

		protected override void OnTarget( Mobile from, object o )
		{
			if ( !BaseCommand.IsAccessible( from, o ) )
			{
				from.SendMessage( "That is not accessible." );
				return;
			}

			if ( o is Item || o is Mobile )
				from.Target = new MoveTarget( o );
		}
	}
}

namespace Server.Targets
{
	public class MoveTarget : Target
	{
		private object m_Object;

		public MoveTarget( object o ) : base( -1, true, TargetFlags.None )
		{
			m_Object = o;
		}

		protected override void OnTarget( Mobile from, object o )
		{
			IPoint3D p = o as IPoint3D;

			if ( p != null )
			{
				if ( !BaseCommand.IsAccessible( from, m_Object ) )
				{
					from.SendMessage( "That is not accessible." );
					return;
				}

				if ( p is Item )
					p = ((Item)p).GetWorldTop();

				CommandLogging.WriteLine( from, "{0} {1} moving {2} to {3}", from.AccessLevel, CommandLogging.Format( from ), CommandLogging.Format( m_Object ), new Point3D( p ) );

				if ( m_Object is Item )
				{
					Item item = (Item)m_Object;

					if ( !item.Deleted )
						item.MoveToWorld( new Point3D( p ), from.Map );
				}
				else if ( m_Object is Mobile )
				{
					Mobile m = (Mobile)m_Object;

					if ( !m.Deleted )
						m.MoveToWorld( new Point3D( p ), from.Map );
				}
			}
		}
	}
}