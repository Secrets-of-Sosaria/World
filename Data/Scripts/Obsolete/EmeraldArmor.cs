using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class EmeraldPlateLegs : PlateLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public EmeraldPlateLegs()
		{
			Name = "Emerald Leggings";
			Hue = CraftResources.GetHue( CraftResource.EmeraldBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateEmerald("armors") );
		}

		public EmeraldPlateLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.EmeraldBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class EmeraldPlateGloves : PlateGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public EmeraldPlateGloves()
		{
			Name = "Emerald Gauntlets";
			Hue = CraftResources.GetHue( CraftResource.EmeraldBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateEmerald("armors") );
		}

		public EmeraldPlateGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.EmeraldBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class EmeraldPlateGorget : PlateGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public EmeraldPlateGorget()
		{
			Name = "Emerald Gorget";
			Hue = CraftResources.GetHue( CraftResource.EmeraldBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateEmerald("armors") );
		}

		public EmeraldPlateGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.EmeraldBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class EmeraldPlateArms : PlateArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public EmeraldPlateArms()
		{
			Name = "Emerald Arms";
			Hue = CraftResources.GetHue( CraftResource.EmeraldBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateEmerald("armors") );
		}

		public EmeraldPlateArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.EmeraldBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class EmeraldPlateChest : PlateChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public EmeraldPlateChest()
		{
			Name = "Emerald Tunic";
			Hue = CraftResources.GetHue( CraftResource.EmeraldBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateEmerald("armors") );
		}

		public EmeraldPlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.EmeraldBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class EmeraldFemalePlateChest : FemalePlateChest /////////////////////////////////////////
	{
		[Constructable]
		public EmeraldFemalePlateChest()
		{
			Name = "Emerald Female Tunic";
			Hue = CraftResources.GetHue( CraftResource.EmeraldBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateEmerald("armors") );
		}

		public EmeraldFemalePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.EmeraldBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class EmeraldShield : HeaterShield /////////////////////////////////////////
	{
		[Constructable]
		public EmeraldShield()
		{
			Name = "Emerald Shield";
			Hue = CraftResources.GetHue( CraftResource.EmeraldBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateEmerald("armors") );
		}

		public EmeraldShield( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.EmeraldBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class EmeraldPlateHelm : PlateHelm ///////////////////////////////////////////////////////
	{
		[Constructable]
		public EmeraldPlateHelm()
		{
			Name = "Emerald Helm";
			Hue = CraftResources.GetHue( CraftResource.EmeraldBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateEmerald("armors") );
		}

		public EmeraldPlateHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.EmeraldBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}