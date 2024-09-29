using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class JadePlateLegs : PlateLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public JadePlateLegs()
		{
			Name = "Jade Leggings";
			Hue = CraftResources.GetHue( CraftResource.JadeBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateJade("armors") );
		}

		public JadePlateLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.JadeBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class JadePlateGloves : PlateGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public JadePlateGloves()
		{
			Name = "Jade Gauntlets";
			Hue = CraftResources.GetHue( CraftResource.JadeBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateJade("armors") );
		}

		public JadePlateGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.JadeBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class JadePlateGorget : PlateGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public JadePlateGorget()
		{
			Name = "Jade Gorget";
			Hue = CraftResources.GetHue( CraftResource.JadeBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateJade("armors") );
		}

		public JadePlateGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.JadeBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class JadePlateArms : PlateArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public JadePlateArms()
		{
			Name = "Jade Arms";
			Hue = CraftResources.GetHue( CraftResource.JadeBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateJade("armors") );
		}

		public JadePlateArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.JadeBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class JadePlateChest : PlateChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public JadePlateChest()
		{
			Name = "Jade Tunic";
			Hue = CraftResources.GetHue( CraftResource.JadeBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateJade("armors") );
		}

		public JadePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.JadeBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class JadeFemalePlateChest : FemalePlateChest /////////////////////////////////////////
	{
		[Constructable]
		public JadeFemalePlateChest()
		{
			Name = "Jade Female Tunic";
			Hue = CraftResources.GetHue( CraftResource.JadeBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateJade("armors") );
		}

		public JadeFemalePlateChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.JadeBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class JadeShield : HeaterShield ////////////////////////////////////////////////////////
	{
		[Constructable]
		public JadeShield()
		{
			Name = "Jade Shield";
			Hue = CraftResources.GetHue( CraftResource.JadeBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateJade("armors") );
		}

		public JadeShield( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.JadeBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class JadePlateHelm : PlateHelm ///////////////////////////////////////////////////////
	{
		[Constructable]
		public JadePlateHelm()
		{
			Name = "Jade Helm";
			Hue = CraftResources.GetHue( CraftResource.JadeBlock );
			// MorphingItem.MorphMyItem( this, "IGNORED", "IGNORED", "IGNORED", MorphingTemplates.TemplateJade("armors") );
		}

		public JadePlateHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.JadeBlock;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}