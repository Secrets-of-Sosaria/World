using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class GarnetPlateLegs : PlateLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public GarnetPlateLegs()
		{
			Name = "Garnet Leggings";
			Hue = CraftResources.GetHue( CraftResource.GarnetBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateGarnet("armors") );
		}

		public GarnetPlateLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.GarnetBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class GarnetPlateGloves : PlateGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public GarnetPlateGloves()
		{
			Name = "Garnet Gauntlets";
			Hue = CraftResources.GetHue( CraftResource.GarnetBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateGarnet("armors") );
		}

		public GarnetPlateGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.GarnetBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class GarnetPlateGorget : PlateGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public GarnetPlateGorget()
		{
			Name = "Garnet Gorget";
			Hue = CraftResources.GetHue( CraftResource.GarnetBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateGarnet("armors") );
		}

		public GarnetPlateGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.GarnetBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class GarnetPlateArms : PlateArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public GarnetPlateArms()
		{
			Name = "Garnet Arms";
			Hue = CraftResources.GetHue( CraftResource.GarnetBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateGarnet("armors") );
		}

		public GarnetPlateArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.GarnetBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class GarnetPlateChest : PlateChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public GarnetPlateChest()
		{
			Name = "Garnet Tunic";
			Hue = CraftResources.GetHue( CraftResource.GarnetBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateGarnet("armors") );
		}

		public GarnetPlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.GarnetBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class GarnetFemalePlateChest : FemalePlateChest /////////////////////////////////////////
	{
		[Constructable]
		public GarnetFemalePlateChest()
		{
			Name = "Garnet Female Tunic";
			Hue = CraftResources.GetHue( CraftResource.GarnetBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateGarnet("armors") );
		}

		public GarnetFemalePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.GarnetBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class GarnetShield : HeaterShield //////////////////////////////////////////////////////
	{
		[Constructable]
		public GarnetShield()
		{
			Name = "Garnet Shield";
			Hue = CraftResources.GetHue( CraftResource.GarnetBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateGarnet("armors") );
		}

		public GarnetShield( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.GarnetBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class GarnetPlateHelm : PlateHelm ///////////////////////////////////////////////////////
	{
		[Constructable]
		public GarnetPlateHelm()
		{
			Name = "Garnet Helm";
			Hue = CraftResources.GetHue( CraftResource.GarnetBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateGarnet("armors") );
		}

		public GarnetPlateHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.GarnetBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}