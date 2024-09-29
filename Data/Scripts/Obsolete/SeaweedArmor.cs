using System;
using Server;

namespace Server.Items
{
	public class SeaweedLegs : LeatherLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SeaweedLegs()
		{
			Name = "Seaweed Leggings";

			Resource = CraftResource.None;
			Hue = CraftResources.GetHue( CraftResource.Seaweed );

			ArmorAttributes.LowerStatReq = 50;
			ArmorAttributes.MageArmor = 1;
			Attributes.LowerRegCost = 8;
			Attributes.Luck = 100;
			Attributes.RegenHits = 3;
			PhysicalBonus = 5;
			ColdBonus = 3;
			EnergyBonus = 3;
			FireBonus = 3;
			PoisonBonus = 3;
		}

		public SeaweedLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.Seaweed;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SeaweedGloves : LeatherGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public SeaweedGloves()
		{
			Name = "Seaweed Gloves";

			Resource = CraftResource.None;
			Hue = CraftResources.GetHue( CraftResource.Seaweed );

			ArmorAttributes.LowerStatReq = 50;
			ArmorAttributes.MageArmor = 1;
			Attributes.LowerRegCost = 8;
			Attributes.Luck = 100;
			Attributes.RegenHits = 3;
			PhysicalBonus = 5;
			ColdBonus = 3;
			EnergyBonus = 3;
			FireBonus = 3;
			PoisonBonus = 3;
		}

		public SeaweedGloves( Serial serial ) : base( serial )
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
			Item item = new LeatherGloves();
			((BaseArmor)item).Resource = CraftResource.Seaweed;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SeaweedGorget : LeatherGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public SeaweedGorget()
		{
			Name = "Seaweed Gorget";

			Resource = CraftResource.None;
			Hue = CraftResources.GetHue( CraftResource.Seaweed );

			ArmorAttributes.LowerStatReq = 50;
			ArmorAttributes.MageArmor = 1;
			Attributes.LowerRegCost = 8;
			Attributes.Luck = 100;
			Attributes.RegenHits = 3;
			PhysicalBonus = 5;
			ColdBonus = 3;
			EnergyBonus = 3;
			FireBonus = 3;
			PoisonBonus = 3;
		}

		public SeaweedGorget( Serial serial ) : base( serial )
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
			Item item = new LeatherGorget();
			((BaseArmor)item).Resource = CraftResource.Seaweed;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SeaweedArms : LeatherArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SeaweedArms()
		{
			Name = "Seaweed Arms";

			Resource = CraftResource.None;
			Hue = CraftResources.GetHue( CraftResource.Seaweed );

			ArmorAttributes.LowerStatReq = 50;
			ArmorAttributes.MageArmor = 1;
			Attributes.LowerRegCost = 8;
			Attributes.Luck = 100;
			Attributes.RegenHits = 3;
			PhysicalBonus = 5;
			ColdBonus = 3;
			EnergyBonus = 3;
			FireBonus = 3;
			PoisonBonus = 3;
		}

		public SeaweedArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.Seaweed;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SeaweedChest : LeatherChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public SeaweedChest()
		{
			Name = "Seaweed Tunic";

			Resource = CraftResource.None;
			Hue = CraftResources.GetHue( CraftResource.Seaweed );

			ArmorAttributes.LowerStatReq = 50;
			ArmorAttributes.MageArmor = 1;
			Attributes.LowerRegCost = 8;
			Attributes.Luck = 100;
			Attributes.RegenHits = 3;
			PhysicalBonus = 5;
			ColdBonus = 3;
			EnergyBonus = 3;
			FireBonus = 3;
			PoisonBonus = 3;
		}

		public SeaweedChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.Seaweed;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SeaweedHelm : LeatherCap /////////////////////////////////////////
	{
		[Constructable]
		public SeaweedHelm()
		{
			Name = "Seaweed Cap";
			Hue = CraftResources.GetHue( CraftResource.Seaweed );
			Resource = CraftResource.None;

			ArmorAttributes.LowerStatReq = 50;
			ArmorAttributes.MageArmor = 1;
			Attributes.LowerRegCost = 8;
			Attributes.Luck = 100;
			Attributes.RegenHits = 3;
			PhysicalBonus = 5;
			ColdBonus = 3;
			EnergyBonus = 3;
			FireBonus = 3;
			PoisonBonus = 3;
		}

		public SeaweedHelm( Serial serial ) : base( serial )
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
			Item item = new LeatherCap();
			((BaseArmor)item).Resource = CraftResource.Seaweed;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}