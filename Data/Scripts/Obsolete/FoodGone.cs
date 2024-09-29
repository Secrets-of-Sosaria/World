using System;
using System.Collections;
using Server.Network;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
	public class FoodDriedBeef : Food
	{
		[Constructable]
		public FoodDriedBeef() : this( 1 )
		{
		}

		[Constructable]
		public FoodDriedBeef( int amount ) : base( amount, 0x979 )
		{
			this.Name = "dried beef";
			this.Hue = 2430;
			this.Weight = 1.0;
			this.FillFactor = 3;
		}

		public FoodDriedBeef( Serial serial ) : base( serial )
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
			Item item = new Ribs();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}

	public class FoodStaleBread : Food
	{
		[Constructable]
		public FoodStaleBread() : this( 1 )
		{
		}

		[Constructable]
		public FoodStaleBread( int amount ) : base( amount, 0x103B )
		{
			this.Name = "stale bread";
			this.Hue = 2415;
			this.Weight = 1.0;
			this.FillFactor = 3;
		}

		public FoodStaleBread( Serial serial ) : base( serial )
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
			Item item = new BreadLoaf();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}