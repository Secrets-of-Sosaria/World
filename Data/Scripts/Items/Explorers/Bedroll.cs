using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Regions;
using Server.Mobiles;

namespace Server.Items
{
	[FlipableAttribute( 0xA58, 0xA59 )]
	public class Bedroll : Item
	{
		public override string DefaultDescription
		{
			get
			{
				if ( Technology )
					return "Sleeping bags can be used by adventurers, to recovery health and stamina much quicker. There cannot be any enemies nearby and only the one who places the sleeping bag will benefit from the effects. It requires someone proficient in camping.";

				return "Bedrolls can be used by adventurers, to recovery health and stamina much quicker. There cannot be any enemies nearby and only the one who places the bedroll will benefit from the effects. It requires someone proficient in camping.";
			}
		}

		[Constructable]
		public Bedroll() : base( 0xA58 )
		{
			Weight = 5.0;
			Utility.RandomMinMax( 0xA58, 0xA59 );
		}

		public Bedroll( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
		}

		private bool BedsNearby( Mobile from )
		{
			foreach( Item i in GetItemsInRange( 20 ) )
			{
				if ( i is BedrolledOut )
				{
					BedrolledOut bed = (BedrolledOut)i;

					if ( bed.Owner == from )
						return true;
				}
			}

			return false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from is PlayerMobile )
			{
				PlayerMobile pm = (PlayerMobile)from;

                if ( from.Region is PublicRegion || from.Region is ProtectedRegion || from.Region is SafeRegion )
                {
                    from.SendMessage("You don't need to use a bedroll here!");
                }
                else if ( BedsNearby( from ) )
				{
					from.SendMessage( "You already have a bedroll laid out!" );
				}
				else if ( Server.Items.Kindling.EnemiesNearby( from ) )
				{
					from.SendMessage( "It is not safe enough to setup camp!" );
				}
				else if ( DateTime.Now >= pm.Bedroll )
				{
					if ( !this.VerifyMove( from ) )
						return;

					if ( !from.InRange( this.GetWorldLocation(), 2 ) )
					{
						from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
						return;
					}
					else if ( !from.CheckSkill( SkillName.Camping, 0.0, 125.0 ) )
					{
						Server.Items.Kindling.RaiseCamping( from );
						from.SendLocalizedMessage( 1017379 ); // You seem to be struggling with your bedroll.
					}
					else
					{
						Server.Items.Kindling.RaiseCamping( from );

						Point3D bedLocation = GetBedLocation( from );

						if ( bedLocation == Point3D.Zero )
						{
							from.SendMessage( "There is no spot nearby to place your bedroll." );
						}
						else
						{
							if ( !this.Deleted && this.Parent == null )
								from.PlaceInBackpack( this );

							new BedrolledOut( from ).MoveToWorld( bedLocation, from.Map );
							pm.Bedroll = DateTime.Now + TimeSpan.FromMinutes( 10.0 );
							this.Delete();
						}
					}
				}
				else
				{
					from.SendMessage( "You can only lay out a bedroll every 10 minutes!" );
				}
			}
		}

		private Point3D GetBedLocation( Mobile from )
		{
			if ( !Kindling.CampAllowed( from ) )
				return Point3D.Zero;

			if ( this.Parent == null )
				return this.Location;

			ArrayList list = new ArrayList( 4 );

			AddOffsetLocation( from,  0, -1, list );
			AddOffsetLocation( from, -1,  0, list );
			AddOffsetLocation( from,  0,  1, list );
			AddOffsetLocation( from,  1,  0, list );

			if ( list.Count == 0 )
				return Point3D.Zero;

			int idx = Utility.Random( list.Count );
			return (Point3D) list[idx];
		}

		private void AddOffsetLocation( Mobile from, int offsetX, int offsetY, ArrayList list )
		{
			Map map = from.Map;

			int x = from.X + offsetX;
			int y = from.Y + offsetY;

			Point3D loc = new Point3D( x, y, from.Z );

			if ( map.CanFit( loc, 1 ) && from.InLOS( loc ) )
			{
				list.Add( loc );
			}
			else
			{
				loc = new Point3D( x, y, map.GetAverageZ( x, y ) );

				if ( map.CanFit( loc, 1 ) && from.InLOS( loc ) )
					list.Add( loc );
			}
		}
	}
}