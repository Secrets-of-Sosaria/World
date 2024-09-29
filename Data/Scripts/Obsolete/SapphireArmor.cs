using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class SapphirePlateLegs : PlateLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SapphirePlateLegs()
		{
			Name = "Sapphire Leggings";
			Hue = CraftResources.GetHue( CraftResource.SapphireBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSapphire("armors") );
		}

		public SapphirePlateLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SapphireBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SapphirePlateGloves : PlateGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public SapphirePlateGloves()
		{
			Name = "Sapphire Gauntlets";
			Hue = CraftResources.GetHue( CraftResource.SapphireBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSapphire("armors") );
		}

		public SapphirePlateGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SapphireBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SapphirePlateGorget : PlateGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public SapphirePlateGorget()
		{
			Name = "Sapphire Gorget";
			Hue = CraftResources.GetHue( CraftResource.SapphireBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSapphire("armors") );
		}

		public SapphirePlateGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SapphireBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SapphirePlateArms : PlateArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SapphirePlateArms()
		{
			Name = "Sapphire Arms";
			Hue = CraftResources.GetHue( CraftResource.SapphireBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSapphire("armors") );
		}

		public SapphirePlateArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SapphireBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SapphirePlateChest : PlateChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public SapphirePlateChest()
		{
			Name = "Sapphire Tunic";
			Hue = CraftResources.GetHue( CraftResource.SapphireBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSapphire("armors") );
		}

		public SapphirePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SapphireBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SapphireFemalePlateChest : FemalePlateChest /////////////////////////////////////////
	{
		[Constructable]
		public SapphireFemalePlateChest()
		{
			Name = "Sapphire Female Tunic";
			Hue = CraftResources.GetHue( CraftResource.SapphireBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSapphire("armors") );
		}

		public SapphireFemalePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SapphireBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SapphireShield : HeaterShield ////////////////////////////////////////////////////
	{
		[Constructable]
		public SapphireShield()
		{
			Name = "Sapphire Shield";
			Hue = CraftResources.GetHue( CraftResource.SapphireBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSapphire("armors") );
		}

		public SapphireShield( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SapphireBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SapphirePlateHelm : PlateHelm ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SapphirePlateHelm()
		{
			Name = "Sapphire Helm";
			Hue = CraftResources.GetHue( CraftResource.SapphireBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateSapphire("armors") );
		}

		public SapphirePlateHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SapphireBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}