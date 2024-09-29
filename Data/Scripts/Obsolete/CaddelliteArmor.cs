using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class CaddellitePlateLegs : PlateLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public CaddellitePlateLegs()
		{
			Resource = CraftResource.CaddelliteBlock;
		}

		public CaddellitePlateLegs( Serial serial ) : base( serial )
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
			Item item = new PlateLegs();
			((BaseArmor)item).Resource = CraftResource.CaddelliteBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class CaddellitePlateGloves : PlateGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public CaddellitePlateGloves()
		{
			Resource = CraftResource.CaddelliteBlock;
		}

		public CaddellitePlateGloves( Serial serial ) : base( serial )
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
			Item item = new PlateGloves();
			((BaseArmor)item).Resource = CraftResource.CaddelliteBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class CaddellitePlateGorget : PlateGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public CaddellitePlateGorget()
		{
			Resource = CraftResource.CaddelliteBlock;
		}

		public CaddellitePlateGorget( Serial serial ) : base( serial )
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
			Item item = new PlateGorget();
			((BaseArmor)item).Resource = CraftResource.CaddelliteBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class CaddellitePlateArms : PlateArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public CaddellitePlateArms()
		{
			Resource = CraftResource.CaddelliteBlock;
		}

		public CaddellitePlateArms( Serial serial ) : base( serial )
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
			Item item = new PlateArms();
			((BaseArmor)item).Resource = CraftResource.CaddelliteBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class CaddellitePlateChest : PlateChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public CaddellitePlateChest()
		{
			Resource = CraftResource.CaddelliteBlock;
		}

		public CaddellitePlateChest( Serial serial ) : base( serial )
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
			Item item = new PlateChest();
			((BaseArmor)item).Resource = CraftResource.CaddelliteBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class CaddelliteFemalePlateChest : FemalePlateChest /////////////////////////////////////////
	{
		[Constructable]
		public CaddelliteFemalePlateChest()
		{
			Resource = CraftResource.CaddelliteBlock;
		}

		public CaddelliteFemalePlateChest( Serial serial ) : base( serial )
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
			Item item = new FemalePlateChest();
			((BaseArmor)item).Resource = CraftResource.CaddelliteBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class CaddelliteShield : HeaterShield /////////////////////////////////////////
	{
		[Constructable]
		public CaddelliteShield()
		{
			Resource = CraftResource.CaddelliteBlock;
		}

		public CaddelliteShield( Serial serial ) : base( serial )
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
			Item item = new HeaterShield();
			((BaseArmor)item).Resource = CraftResource.CaddelliteBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class CaddellitePlateHelm : PlateHelm ///////////////////////////////////////////////////////
	{
		[Constructable]
		public CaddellitePlateHelm()
		{
			Resource = CraftResource.CaddelliteBlock;
		}

		public CaddellitePlateHelm( Serial serial ) : base( serial )
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
			Item item = new PlateHelm();
			((BaseArmor)item).Resource = CraftResource.CaddelliteBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}