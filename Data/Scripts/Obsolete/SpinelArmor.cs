using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class SpinelPlateLegs : PlateLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SpinelPlateLegs()
		{
			Name = "Spinel Leggings";
			Hue = CraftResources.GetHue( CraftResource.SpinelBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSpinel("armors") );
		}

		public SpinelPlateLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SpinelBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SpinelPlateGloves : PlateGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public SpinelPlateGloves()
		{
			Name = "Spinel Gauntlets";
			Hue = CraftResources.GetHue( CraftResource.SpinelBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSpinel("armors") );
		}

		public SpinelPlateGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SpinelBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SpinelPlateGorget : PlateGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public SpinelPlateGorget()
		{
			Name = "Spinel Gorget";
			Hue = CraftResources.GetHue( CraftResource.SpinelBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSpinel("armors") );
		}

		public SpinelPlateGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SpinelBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SpinelPlateArms : PlateArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SpinelPlateArms()
		{
			Name = "Spinel Arms";
			Hue = CraftResources.GetHue( CraftResource.SpinelBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSpinel("armors") );
		}

		public SpinelPlateArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SpinelBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SpinelPlateChest : PlateChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public SpinelPlateChest()
		{
			Name = "Spinel Tunic";
			Hue = CraftResources.GetHue( CraftResource.SpinelBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSpinel("armors") );
		}

		public SpinelPlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SpinelBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SpinelFemalePlateChest : FemalePlateChest /////////////////////////////////////////
	{
		[Constructable]
		public SpinelFemalePlateChest()
		{
			Name = "Spinel Female Tunic";
			Hue = CraftResources.GetHue( CraftResource.SpinelBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSpinel("armors") );
		}

		public SpinelFemalePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SpinelBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SpinelShield : HeaterShield //////////////////////////////////////////////////////
	{
		[Constructable]
		public SpinelShield()
		{
			Name = "Spinel Shield";
			Hue = CraftResources.GetHue( CraftResource.SpinelBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSpinel("armors") );
		}

		public SpinelShield( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SpinelBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SpinelPlateHelm : PlateHelm ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SpinelPlateHelm()
		{
			Name = "Spinel Helm";
			Hue = CraftResources.GetHue( CraftResource.SpinelBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSpinel("armors") );
		}

		public SpinelPlateHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SpinelBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}