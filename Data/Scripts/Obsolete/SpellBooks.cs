using System;
using Server;
using System.Collections.Generic;
using Server.Commands;
using Server.Engines.Craft;
using Server.Network;
using Server.Spells;
using Server.Targeting;
using Server.Items;

namespace Server.Items
{
	public class MyNecromancerSpellbook : NecromancerSpellbook
	{
		[Constructable]
		public MyNecromancerSpellbook()
		{
		}

		public MyNecromancerSpellbook( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 15.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new NecromancerSpellbook();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}

	public class MyElementalSpellbook : ElementalSpellbook ////////////////////////////////////////////////////////////////////////////////////////////////////////////
	{
		[Constructable]
		public MyElementalSpellbook()
		{
		}

		public MyElementalSpellbook( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 15.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new ElementalSpellbook();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}

	public class MySpellbook : Spellbook ////////////////////////////////////////////////////////////////////////////////////////////////////////////
	{
		[Constructable]
		public MySpellbook()
		{
		}

		public MySpellbook( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 15.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new Spellbook();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}

	public class MySongbook : SongBook //////////////////////////////////////////////////////////////////////////////////////////////////////////////
	{
		[Constructable]
		public MySongbook()
		{
		}

		public MySongbook( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 15.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new SongBook();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}