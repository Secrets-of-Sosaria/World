using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class IcePlateLegs : PlateLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public IcePlateLegs()
		{
			Name = "Ice Leggings";
			Hue = CraftResources.GetHue( CraftResource.IceBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateIce("armors") );
		}

		public IcePlateLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.IceBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class IcePlateGloves : PlateGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public IcePlateGloves()
		{
			Name = "Ice Gauntlets";
			Hue = CraftResources.GetHue( CraftResource.IceBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateIce("armors") );
		}

		public IcePlateGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.IceBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class IcePlateGorget : PlateGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public IcePlateGorget()
		{
			Name = "Ice Gorget";
			Hue = CraftResources.GetHue( CraftResource.IceBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateIce("armors") );
		}

		public IcePlateGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.IceBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class IcePlateArms : PlateArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public IcePlateArms()
		{
			Name = "Ice Arms";
			Hue = CraftResources.GetHue( CraftResource.IceBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateIce("armors") );
		}

		public IcePlateArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.IceBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class IcePlateChest : PlateChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public IcePlateChest()
		{
			Name = "Ice Tunic";
			Hue = CraftResources.GetHue( CraftResource.IceBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateIce("armors") );
		}

		public IcePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.IceBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class IceFemalePlateChest : FemalePlateChest /////////////////////////////////////////
	{
		[Constructable]
		public IceFemalePlateChest()
		{
			Name = "Ice Female Tunic";
			Hue = CraftResources.GetHue( CraftResource.IceBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateIce("armors") );
		}

		public IceFemalePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.IceBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class IceShield : HeaterShield /////////////////////////////////////////////////////////
	{
		[Constructable]
		public IceShield()
		{
			Name = "Ice Shield";
			Hue = CraftResources.GetHue( CraftResource.IceBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateIce("armors") );
		}

		public IceShield( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.IceBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class IcePlateHelm : PlateHelm ///////////////////////////////////////////////////////
	{
		[Constructable]
		public IcePlateHelm()
		{
			Name = "Ice Helm";
			Hue = CraftResources.GetHue( CraftResource.IceBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateIce("armors") );
		}

		public IcePlateHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.IceBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}