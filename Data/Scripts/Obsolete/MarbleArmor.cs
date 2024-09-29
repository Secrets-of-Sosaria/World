using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class MarblePlateLegs : PlateLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public MarblePlateLegs()
		{
			Name = "Marble Leggings";
			Hue = CraftResources.GetHue( CraftResource.MarbleBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateMarble("armors") );
		}

		public MarblePlateLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.MarbleBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class MarblePlateGloves : PlateGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public MarblePlateGloves()
		{
			Name = "Marble Gauntlets";
			Hue = CraftResources.GetHue( CraftResource.MarbleBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateMarble("armors") );
		}

		public MarblePlateGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.MarbleBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class MarblePlateGorget : PlateGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public MarblePlateGorget()
		{
			Name = "Marble Gorget";
			Hue = CraftResources.GetHue( CraftResource.MarbleBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateMarble("armors") );
		}

		public MarblePlateGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.MarbleBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class MarblePlateArms : PlateArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public MarblePlateArms()
		{
			Name = "Marble Arms";
			Hue = CraftResources.GetHue( CraftResource.MarbleBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateMarble("armors") );
		}

		public MarblePlateArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.MarbleBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class MarblePlateChest : PlateChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public MarblePlateChest()
		{
			Name = "Marble Tunic";
			Hue = CraftResources.GetHue( CraftResource.MarbleBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateMarble("armors") );
		}

		public MarblePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.MarbleBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class MarbleFemalePlateChest : FemalePlateChest /////////////////////////////////////////
	{
		[Constructable]
		public MarbleFemalePlateChest()
		{
			Name = "Marble Female Tunic";
			Hue = CraftResources.GetHue( CraftResource.MarbleBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateMarble("armors") );
		}

		public MarbleFemalePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.MarbleBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class MarbleShields : HeaterShield /////////////////////////////////////////////////////////
	{
		[Constructable]
		public MarbleShields()
		{
			Name = "Marble Shield";
			Hue = CraftResources.GetHue( CraftResource.MarbleBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateMarble("armors") );
		}

		public MarbleShields( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.MarbleBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class MarblePlateHelm : PlateHelm ///////////////////////////////////////////////////////
	{
		[Constructable]
		public MarblePlateHelm()
		{
			Name = "Marble Helm";
			Hue = CraftResources.GetHue( CraftResource.MarbleBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateMarble("armors") );
		}

		public MarblePlateHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.MarbleBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}