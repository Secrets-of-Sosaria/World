using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class RubyPlateLegs : PlateLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public RubyPlateLegs()
		{
			Name = "Ruby Leggings";
			Hue = CraftResources.GetHue( CraftResource.RubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateRuby("armors") );
		}

		public RubyPlateLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.RubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class RubyPlateGloves : PlateGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public RubyPlateGloves()
		{
			Name = "Ruby Gauntlets";
			Hue = CraftResources.GetHue( CraftResource.RubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateRuby("armors") );
		}

		public RubyPlateGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.RubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class RubyPlateGorget : PlateGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public RubyPlateGorget()
		{
			Name = "Ruby Gorget";
			Hue = CraftResources.GetHue( CraftResource.RubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateRuby("armors") );
		}

		public RubyPlateGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.RubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class RubyPlateArms : PlateArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public RubyPlateArms()
		{
			Name = "Ruby Arms";
			Hue = CraftResources.GetHue( CraftResource.RubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateRuby("armors") );
		}

		public RubyPlateArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.RubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class RubyPlateChest : PlateChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public RubyPlateChest()
		{
			Name = "Ruby Tunic";
			Hue = CraftResources.GetHue( CraftResource.RubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateRuby("armors") );
		}

		public RubyPlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.RubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class RubyFemalePlateChest : FemalePlateChest /////////////////////////////////////////
	{
		[Constructable]
		public RubyFemalePlateChest()
		{
			Name = "Ruby Female Tunic";
			Hue = CraftResources.GetHue( CraftResource.RubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateRuby("armors") );
		}

		public RubyFemalePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.RubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class RubyShield : HeaterShield /////////////////////////////////////////
	{
		[Constructable]
		public RubyShield()
		{
			Name = "Ruby Shield";
			Hue = CraftResources.GetHue( CraftResource.RubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateRuby("armors") );
		}

		public RubyShield( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.RubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class RubyPlateHelm : PlateHelm ///////////////////////////////////////////////////////
	{
		[Constructable]
		public RubyPlateHelm()
		{
			Name = "Ruby Helm";
			Hue = CraftResources.GetHue( CraftResource.RubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateRuby("armors") );
		}

		public RubyPlateHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.RubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}