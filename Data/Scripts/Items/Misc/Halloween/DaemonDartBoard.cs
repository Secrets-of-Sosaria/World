using System;
using Server;
using Server.Network;

namespace Server.Items
{
	public class DaemonDartBoard : AddonComponent
	{
		public bool East{ get{ return this.ItemID == 0x56AB; } }

		[Constructable]
		public DaemonDartBoard() : this( true )
		{
		}

		[Constructable]
		public DaemonDartBoard( bool east ) : base( east ? 0x56AB : 0x56B1 )
		{
			Name = "daemon dart board";
		}

		public override void OnDoubleClick( Mobile from )
		{
			Direction dir;
			if ( from.Location != this.Location )
				dir = from.GetDirectionTo( this );
			else if ( this.East )
				dir = Direction.West;
			else
				dir = Direction.North;

			from.Direction = dir;

			bool canThrow = true;

			if ( ItemID != 0x56AB && ItemID != 0x56B1 )
				canThrow = false;
			else if ( !from.InRange( this, 4 ) || !from.InLOS( this ) )
				canThrow = false;
			else if ( this.East )
				canThrow = ( dir == Direction.Left || dir == Direction.West || dir == Direction.Up );
			else
				canThrow = ( dir == Direction.Up || dir == Direction.North || dir == Direction.Right );

			if ( canThrow )
				Throw( from );
			else
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
		}

		public void Throw( Mobile from )
		{
			BaseKnife knife = from.Weapon as BaseKnife;

			if ( knife == null )
			{
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 500751 ); // Try holding a knife...
				return;
			}

			if ( from.RaceID > 0 )
				from.Animate( 12, 5, 1, true, false, 0 );
			else
				from.Animate( from.Mounted ? 26 : 9, 7, 1, true, false, 0 );

			from.MovingEffect( this, knife.ItemID, 7, 1, false, false );
			from.PlaySound( Utility.RandomList( 0x238, 0x239, 0x23A ) );

			double rand = Utility.RandomDouble();

			int message;
			int nAnimate = 0;
			int nHit = 0;

			if ( rand < 0.05 ){
				nAnimate = 1;
				message = 500752; // BULLSEYE! 50 Points!
			}
			else if ( rand < 0.20 ){
				nAnimate = 1;
				message = 500753; // Just missed the center! 20 points.
			}
			else if ( rand < 0.45 ){
				nAnimate = 1;
				message = 500754; // 10 point shot.
			}
			else if ( rand < 0.70 ){
				nHit = 1;
				message = 500755; // 5 pointer.
			}
			else if ( rand < 0.85 ){
				nHit = 1;
				message = 500756; // 1 point.  Bad throw.
			}
			else
				message = 500757; // Missed.

			if ( nAnimate == 1 && ItemID >= 0x56AB && ItemID <= 0x56B0 ) { ItemID = 0x56AC; }
			else if ( nAnimate == 1 && ItemID >= 0x56B1 && ItemID <= 0x56B6 ) { ItemID = 0x56B2; }

			if ( nAnimate == 1 )
			{
				Timer.DelayCall( TimeSpan.FromSeconds( 0.8 ), new TimerCallback( OnDaemonReset ) );
				Timer.DelayCall( TimeSpan.FromSeconds( 0.2 ), new TimerCallback( OnDaemonHit ) );
			}
			else if ( nHit == 1 )
			{
				Timer.DelayCall( TimeSpan.FromSeconds( 0.2 ), new TimerCallback( OnDaemonNick ) );
			}

			PublicOverheadMessage( MessageType.Regular, 0x3B2, message );
		}

		public virtual void OnDaemonReset()
		{
			if ( ( ItemID >= 0x56AD && ItemID <= 0x56B0 ) || ( ItemID >= 0x56B3 && ItemID <= 0x56B6 ) ){ Timer.DelayCall( TimeSpan.FromSeconds( 0.1 ), new TimerCallback( OnDaemonReset ) ); }
			else if ( ItemID >= 0x56AB && ItemID <= 0x56B0 ) { ItemID = 0x56AB; }
			else { ItemID = 0x56B1; }
		}

		public virtual void OnDaemonHit()
		{
			Effects.PlaySound( Location, Map, 0x149 );
		}

		public virtual void OnDaemonNick()
		{
			Effects.PlaySound( Location, Map, 0x13A );
		}

		public DaemonDartBoard( Serial serial ) : base( serial )
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
	}

	public class DaemonDartBoardEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new DaemonDartBoardEastDeed(); } }

		public DaemonDartBoardEastAddon()
		{
			AddComponent( new DaemonDartBoard( true ), 0, 0, 0 );
		}

		public DaemonDartBoardEastAddon( Serial serial ) : base( serial )
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
	}

	public class DaemonDartBoardEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new DaemonDartBoardEastAddon(); } }

		[Constructable]
		public DaemonDartBoardEastDeed()
		{
			Name = "Daemon Dart Board (east)";
			Hue = 0xB01;
		}

		public DaemonDartBoardEastDeed( Serial serial ) : base( serial )
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
	}

	public class DaemonDartBoardSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new DaemonDartBoardSouthDeed(); } }

		public DaemonDartBoardSouthAddon()
		{
			AddComponent( new DaemonDartBoard( false ), 0, 0, 0 );
		}

		public DaemonDartBoardSouthAddon( Serial serial ) : base( serial )
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
	}

	public class DaemonDartBoardSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new DaemonDartBoardSouthAddon(); } }

		[Constructable]
		public DaemonDartBoardSouthDeed()
		{
			Name = "Daemon Dart Board (south)";
			Hue = 0xB01;
		}

		public DaemonDartBoardSouthDeed( Serial serial ) : base( serial )
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
	}
}