using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Items
{
	public class MagicFurLegs : FurLegs /////////////////////////////////////////////////////////
	{
		[Constructable]
		public MagicFurLegs()
		{
		}

		public MagicFurLegs( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new LeatherLegs();
			item.Resource = CraftResource.FurryFabric;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}

	public class MagicFurArms : FurArms /////////////////////////////////////////////////////////
	{
		[Constructable]
		public MagicFurArms()
		{
		}

		public MagicFurArms( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new LeatherArms();
			item.Resource = CraftResource.FurryFabric;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class MagicFurChest : FurTunic ///////////////////////////////////////////////////////
	{
		[Constructable]
		public MagicFurChest()
		{
		}

		public MagicFurChest( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new LeatherChest();
			item.Resource = CraftResource.FurryFabric;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}