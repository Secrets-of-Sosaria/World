using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class TopazPlateLegs : PlateLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public TopazPlateLegs()
		{
			Name = "Topaz Leggings";
			Hue = CraftResources.GetHue( CraftResource.TopazBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateTopaz("armors") );
		}

		public TopazPlateLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.TopazBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class TopazPlateGloves : PlateGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public TopazPlateGloves()
		{
			Name = "Topaz Gauntlets";
			Hue = CraftResources.GetHue( CraftResource.TopazBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateTopaz("armors") );
		}

		public TopazPlateGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.TopazBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class TopazPlateGorget : PlateGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public TopazPlateGorget()
		{
			Name = "Topaz Gorget";
			Hue = CraftResources.GetHue( CraftResource.TopazBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateTopaz("armors") );
		}

		public TopazPlateGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.TopazBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class TopazPlateArms : PlateArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public TopazPlateArms()
		{
			Name = "Topaz Arms";
			Hue = CraftResources.GetHue( CraftResource.TopazBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateTopaz("armors") );
		}

		public TopazPlateArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.TopazBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class TopazPlateChest : PlateChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public TopazPlateChest()
		{
			Name = "Topaz Tunic";
			Hue = CraftResources.GetHue( CraftResource.TopazBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateTopaz("armors") );
		}

		public TopazPlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.TopazBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class TopazFemalePlateChest : FemalePlateChest /////////////////////////////////////////
	{
		[Constructable]
		public TopazFemalePlateChest()
		{
			Name = "Topaz Female Tunic";
			Hue = CraftResources.GetHue( CraftResource.TopazBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateTopaz("armors") );
		}

		public TopazFemalePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.TopazBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class TopazPlateHelm : PlateHelm ///////////////////////////////////////////////////////
	{
		[Constructable]
		public TopazPlateHelm()
		{
			Name = "Topaz Helm";
			Hue = CraftResources.GetHue( CraftResource.TopazBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateTopaz("armors") );
		}

		public TopazPlateHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.TopazBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class TopazShield : HeaterShield ///////////////////////////////////////////////////////
	{
		[Constructable]
		public TopazShield()
		{
			Name = "Topaz Shield";
			Hue = CraftResources.GetHue( CraftResource.TopazBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateTopaz("armors") );
		}

		public TopazShield( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.TopazBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}