using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class TinkersTools : BaseTool
	{
		public override CraftSystem CraftSystem { get { return DefTinkering.CraftSystem; } }

		[Constructable]
		public TinkersTools()
			: base(0x1EBC)
		{
			Weight = 1.0;
		}

		[Constructable]
		public TinkersTools(int uses)
			: base(uses, 0x1EBC)
		{
			Weight = 1.0;
		}

		public TinkersTools(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new TinkerTools();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}

	public class Saw : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefCarpentry.CraftSystem; } }

		[Constructable]
		public Saw() : base( 0x1034 )
		{
			Weight = 2.0;
		}

		[Constructable]
		public Saw( int uses ) : base( uses, 0x1034 )
		{
			Weight = 2.0;
		}

		public Saw( Serial serial ) : base( serial )
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
			Item item = new CarpenterTools();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}