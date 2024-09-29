using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class OnyxPlateLegs : PlateLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public OnyxPlateLegs()
		{
			Name = "Onyx Leggings";
			Hue = CraftResources.GetHue( CraftResource.OnyxBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateOnyx("armors") );
		}

		public OnyxPlateLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.OnyxBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class OnyxPlateGloves : PlateGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public OnyxPlateGloves()
		{
			Name = "Onyx Gauntlets";
			Hue = CraftResources.GetHue( CraftResource.OnyxBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateOnyx("armors") );
		}

		public OnyxPlateGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.OnyxBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class OnyxPlateGorget : PlateGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public OnyxPlateGorget()
		{
			Name = "Onyx Gorget";
			Hue = CraftResources.GetHue( CraftResource.OnyxBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateOnyx("armors") );
		}

		public OnyxPlateGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.OnyxBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class OnyxPlateArms : PlateArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public OnyxPlateArms()
		{
			Name = "Onyx Arms";
			Hue = CraftResources.GetHue( CraftResource.OnyxBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateOnyx("armors") );
		}

		public OnyxPlateArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.OnyxBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class OnyxPlateChest : PlateChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public OnyxPlateChest()
		{
			Name = "Onyx Tunic";
			Hue = CraftResources.GetHue( CraftResource.OnyxBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateOnyx("armors") );
		}

		public OnyxPlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.OnyxBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class OnyxFemalePlateChest : FemalePlateChest /////////////////////////////////////////
	{
		[Constructable]
		public OnyxFemalePlateChest()
		{
			Name = "Onyx Female Tunic";
			Hue = CraftResources.GetHue( CraftResource.OnyxBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateOnyx("armors") );
		}

		public OnyxFemalePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.OnyxBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class OnyxShield : HeaterShield ////////////////////////////////////////////////////////
	{
		[Constructable]
		public OnyxShield()
		{
			Name = "Onyx Shield";
			Hue = CraftResources.GetHue( CraftResource.OnyxBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateOnyx("armors") );
		}

		public OnyxShield( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.OnyxBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class OnyxPlateHelm : PlateHelm ///////////////////////////////////////////////////////
	{
		[Constructable]
		public OnyxPlateHelm()
		{
			Name = "Onyx Helm";
			Hue = CraftResources.GetHue( CraftResource.OnyxBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateOnyx("armors") );
		}

		public OnyxPlateHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.OnyxBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}