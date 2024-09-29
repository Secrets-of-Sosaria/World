using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class SilverPlateLegs : PlateLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SilverPlateLegs()
		{
			Name = "Silver Leggings";
			Hue = CraftResources.GetHue( CraftResource.SilverBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSilver("armors") );
		}

		public SilverPlateLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SilverBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SilverPlateGloves : PlateGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public SilverPlateGloves()
		{
			Name = "Silver Gauntlets";
			Hue = CraftResources.GetHue( CraftResource.SilverBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSilver("armors") );
		}

		public SilverPlateGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SilverBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SilverPlateGorget : PlateGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public SilverPlateGorget()
		{
			Name = "Silver Gorget";
			Hue = CraftResources.GetHue( CraftResource.SilverBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSilver("armors") );
		}

		public SilverPlateGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SilverBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SilverPlateArms : PlateArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SilverPlateArms()
		{
			Name = "Silver Arms";
			Hue = CraftResources.GetHue( CraftResource.SilverBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSilver("armors") );
		}

		public SilverPlateArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SilverBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SilverPlateChest : PlateChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public SilverPlateChest()
		{
			Name = "Silver Tunic";
			Hue = CraftResources.GetHue( CraftResource.SilverBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSilver("armors") );
		}

		public SilverPlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SilverBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SilverFemalePlateChest : FemalePlateChest /////////////////////////////////////////
	{
		[Constructable]
		public SilverFemalePlateChest()
		{
			Name = "Silver Female Tunic";
			Hue = CraftResources.GetHue( CraftResource.SilverBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSilver("armors") );
		}

		public SilverFemalePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SilverBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SilverShield : HeaterShield //////////////////////////////////////////////////////
	{
		[Constructable]
		public SilverShield()
		{
			Name = "Silver Shield";
			Hue = CraftResources.GetHue( CraftResource.SilverBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSilver("armors") );
		}

		public SilverShield( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SilverBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SilverPlateHelm : PlateHelm ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SilverPlateHelm()
		{
			Name = "Silver Helm";
			Hue = CraftResources.GetHue( CraftResource.SilverBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSilver("armors") );
		}

		public SilverPlateHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SilverBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}