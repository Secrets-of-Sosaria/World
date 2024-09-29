using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class AmethystPlateLegs : PlateLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public AmethystPlateLegs()
		{
			Name = "Amethyst Leggings";
			Hue = CraftResources.GetHue( CraftResource.AmethystBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateAmethyst("armors") );
		}

		public AmethystPlateLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.AmethystBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class AmethystPlateGloves : PlateGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public AmethystPlateGloves()
		{
			Name = "Amethyst Gauntlets";
			Hue = CraftResources.GetHue( CraftResource.AmethystBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateAmethyst("armors") );
		}

		public AmethystPlateGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.AmethystBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class AmethystPlateGorget : PlateGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public AmethystPlateGorget()
		{
			Name = "Amethyst Gorget";
			Hue = CraftResources.GetHue( CraftResource.AmethystBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateAmethyst("armors") );
		}

		public AmethystPlateGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.AmethystBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class AmethystPlateArms : PlateArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public AmethystPlateArms()
		{
			Name = "Amethyst Arms";
			Hue = CraftResources.GetHue( CraftResource.AmethystBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateAmethyst("armors") );
		}

		public AmethystPlateArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.AmethystBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class AmethystPlateChest : PlateChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public AmethystPlateChest()
		{
			Name = "Amethyst Tunic";
			Hue = CraftResources.GetHue( CraftResource.AmethystBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateAmethyst("armors") );
		}

		public AmethystPlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.AmethystBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class AmethystFemalePlateChest : FemalePlateChest /////////////////////////////////////////
	{
		[Constructable]
		public AmethystFemalePlateChest()
		{
			Name = "Amethyst Female Tunic";
			Hue = CraftResources.GetHue( CraftResource.AmethystBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateAmethyst("armors") );
		}

		public AmethystFemalePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.AmethystBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class AmethystShield : HeaterShield /////////////////////////////////////////
	{
		[Constructable]
		public AmethystShield()
		{
			Name = "Amethyst Shield";
			Hue = CraftResources.GetHue( CraftResource.AmethystBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateAmethyst("armors") );
		}

		public AmethystShield( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.AmethystBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class AmethystPlateHelm : PlateHelm ///////////////////////////////////////////////////////
	{
		[Constructable]
		public AmethystPlateHelm()
		{
			Name = "Amethyst Helm";
			Hue = CraftResources.GetHue( CraftResource.AmethystBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateAmethyst("armors") );
		}

		public AmethystPlateHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.AmethystBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}