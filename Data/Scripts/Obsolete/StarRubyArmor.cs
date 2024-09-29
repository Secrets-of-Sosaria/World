using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class StarRubyPlateLegs : PlateLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public StarRubyPlateLegs()
		{
			Name = "Star Ruby Leggings";
			Hue = CraftResources.GetHue( CraftResource.StarRubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateStarRuby("armors") );
		}

		public StarRubyPlateLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.StarRubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class StarRubyPlateGloves : PlateGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public StarRubyPlateGloves()
		{
			Name = "Star Ruby Gauntlets";
			Hue = CraftResources.GetHue( CraftResource.StarRubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateStarRuby("armors") );
		}

		public StarRubyPlateGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.StarRubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class StarRubyPlateGorget : PlateGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public StarRubyPlateGorget()
		{
			Name = "Star Ruby Gorget";
			Hue = CraftResources.GetHue( CraftResource.StarRubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateStarRuby("armors") );
		}

		public StarRubyPlateGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.StarRubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class StarRubyPlateArms : PlateArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public StarRubyPlateArms()
		{
			Name = "Star Ruby Arms";
			Hue = CraftResources.GetHue( CraftResource.StarRubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateStarRuby("armors") );
		}

		public StarRubyPlateArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.StarRubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class StarRubyPlateChest : PlateChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public StarRubyPlateChest()
		{
			Name = "Star Ruby Tunic";
			Hue = CraftResources.GetHue( CraftResource.StarRubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateStarRuby("armors") );
		}

		public StarRubyPlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.StarRubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class StarRubyFemalePlateChest : FemalePlateChest /////////////////////////////////////////
	{
		[Constructable]
		public StarRubyFemalePlateChest()
		{
			Name = "Star Ruby Female Tunic";
			Hue = CraftResources.GetHue( CraftResource.StarRubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateStarRuby("armors") );
		}

		public StarRubyFemalePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.StarRubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class StarRubyShield : HeaterShield /////////////////////////////////////////
	{
		[Constructable]
		public StarRubyShield()
		{
			Name = "Star Ruby Shield";
			Hue = CraftResources.GetHue( CraftResource.StarRubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateStarRuby("armors") );
		}

		public StarRubyShield( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.StarRubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class StarRubyPlateHelm : PlateHelm ///////////////////////////////////////////////////////
	{
		[Constructable]
		public StarRubyPlateHelm()
		{
			Name = "Star Ruby Helm";
			Hue = CraftResources.GetHue( CraftResource.StarRubyBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateStarRuby("armors") );
		}

		public StarRubyPlateHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.StarRubyBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}