using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class QuartzPlateLegs : PlateLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public QuartzPlateLegs()
		{
			Name = "Quartz Leggings";
			Hue = CraftResources.GetHue( CraftResource.QuartzBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateQuartz("armors") );
		}

		public QuartzPlateLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.QuartzBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class QuartzPlateGloves : PlateGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public QuartzPlateGloves()
		{
			Name = "Quartz Gauntlets";
			Hue = CraftResources.GetHue( CraftResource.QuartzBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateQuartz("armors") );
		}

		public QuartzPlateGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.QuartzBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class QuartzPlateGorget : PlateGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public QuartzPlateGorget()
		{
			Name = "Quartz Gorget";
			Hue = CraftResources.GetHue( CraftResource.QuartzBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateQuartz("armors") );
		}

		public QuartzPlateGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.QuartzBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class QuartzPlateArms : PlateArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public QuartzPlateArms()
		{
			Name = "Quartz Arms";
			Hue = CraftResources.GetHue( CraftResource.QuartzBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateQuartz("armors") );
		}

		public QuartzPlateArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.QuartzBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class QuartzPlateChest : PlateChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public QuartzPlateChest()
		{
			Name = "Quartz Tunic";
			Hue = CraftResources.GetHue( CraftResource.QuartzBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateQuartz("armors") );
		}

		public QuartzPlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.QuartzBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class QuartzFemalePlateChest : FemalePlateChest /////////////////////////////////////////
	{
		[Constructable]
		public QuartzFemalePlateChest()
		{
			Name = "Quartz Female Tunic";
			Hue = CraftResources.GetHue( CraftResource.QuartzBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateQuartz("armors") );
		}

		public QuartzFemalePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.QuartzBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class QuartzShield : HeaterShield //////////////////////////////////////////////////////
	{
		[Constructable]
		public QuartzShield()
		{
			Name = "Quartz Shield";
			Hue = CraftResources.GetHue( CraftResource.QuartzBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateQuartz("armors") );
		}

		public QuartzShield( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.QuartzBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class QuartzPlateHelm : PlateHelm ///////////////////////////////////////////////////////
	{
		[Constructable]
		public QuartzPlateHelm()
		{
			Name = "Quartz Helm";
			Hue = CraftResources.GetHue( CraftResource.QuartzBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateQuartz("armors") );
		}

		public QuartzPlateHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.QuartzBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}