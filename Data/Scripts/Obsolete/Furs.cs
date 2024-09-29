using System;
using Server.Network;
using Server.Items;
using System.Collections.Generic;

namespace Server.Items
{
	// [Flipable( 0x230C, 0x230B )]
	public class FurSarong : Kilt
	{
		[Constructable]
		public FurSarong() : base( 0x230C )
		{
			Name = "fur sarong";
			Weight = 3.0;
			Hue = 0x907;
			Resistances.Cold = 10;
		}

		public FurSarong( Serial serial ) : base( serial )
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
			Item item = new Kilt();
			item.Resource = CraftResource.FurryFabric;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	// [Flipable( 0x2B76, 0x316D )]
	public class FurCape : Cloak
	{
		[Constructable]
		public FurCape() : base( 0x2B76 )
		{
			Name = "fur cape";
			Hue = 0x907;
			Weight = 4.0;
			Resistances.Cold = 15;
		}

		public FurCape( Serial serial ) : base( serial )
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
			Item item = new Cloak();
			item.Resource = CraftResource.FurryFabric;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}

	public class FurBoots : Boots
	{
		[Constructable]
		public FurBoots() : base( 0x2307 )
		{
			Resource = CraftResource.None;
			Name = "fur boots";
			Weight = 3.0;
			Hue = 0x907;
			Resistances.Cold = 5;
			ItemID = 0x2307;
		}

		public FurBoots( Serial serial ) : base( serial )
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
			Item item = new Boots();
			item.Resource = CraftResource.FurryFabric;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}

	public class Furs : Item
	{
		[Constructable]
		public Furs() : this( 1 )
		{
		}

        [Constructable]
		public Furs( int amount ) : base( 0x11F4 )
		{
		}

        public Furs(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new FurryFabric();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class FursWhite : Item
	{
		[Constructable]
		public FursWhite() : this( 1 )
		{
		}

        [Constructable]
		public FursWhite( int amount ) : base( 0x11F4 )
		{
		}

        public FursWhite(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new WoolyFabric();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	[Flipable( 0x2B76, 0x316D )]
	public class WhiteFurCape : Cloak
	{
		[Constructable]
		public WhiteFurCape() : base( 0x2B76 )
		{
			Name = "fur cape";
			Hue = 0x481;
			Weight = 4.0;
			Resistances.Cold = 15;
		}

		public WhiteFurCape( Serial serial ) : base( serial )
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
			Item item = new Cloak();
			item.Resource = CraftResource.FurryFabric;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}