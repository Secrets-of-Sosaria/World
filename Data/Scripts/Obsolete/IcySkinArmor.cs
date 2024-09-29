using System;
using Server;

namespace Server.Items
{
	public class IcySkinLegs : LeatherLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public IcySkinLegs()
		{
			Name = "Icy Skin Leggings";
			Hue = CraftResources.GetHue( CraftResource.IcySkin );

			ArmorAttributes.DurabilityBonus = 50;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 0;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 0;
			Attributes.DefendChance = 2;
			Attributes.LowerManaCost = 0;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 2;
			Attributes.Luck = 10;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 0;
			Attributes.BonusStr = 2;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 3;

			PhysicalBonus = 8;
			ColdBonus = 10;
			EnergyBonus = 0;
			FireBonus = 0;
			PoisonBonus = 0;
		}

		public IcySkinLegs( Serial serial ) : base( serial )
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
			Item item = new LeatherLegs();
			((BaseArmor)item).Resource = CraftResource.IcySkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class IcySkinGloves : LeatherGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public IcySkinGloves()
		{
			Name = "Icy Skin Gloves";
			Hue = CraftResources.GetHue( CraftResource.IcySkin );

			ArmorAttributes.DurabilityBonus = 50;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 0;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 0;
			Attributes.DefendChance = 2;
			Attributes.LowerManaCost = 0;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 2;
			Attributes.Luck = 10;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 0;
			Attributes.BonusStr = 2;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 3;

			PhysicalBonus = 8;
			ColdBonus = 10;
			EnergyBonus = 0;
			FireBonus = 0;
			PoisonBonus = 0;
		}

		public IcySkinGloves( Serial serial ) : base( serial )
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
			Item item = new LeatherGloves();
			((BaseArmor)item).Resource = CraftResource.IcySkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class IcySkinGorget : LeatherGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public IcySkinGorget()
		{
			Name = "Icy Skin Gorget";
			Hue = CraftResources.GetHue( CraftResource.IcySkin );

			ArmorAttributes.DurabilityBonus = 50;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 0;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 0;
			Attributes.DefendChance = 2;
			Attributes.LowerManaCost = 0;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 2;
			Attributes.Luck = 10;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 0;
			Attributes.BonusStr = 2;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 3;

			PhysicalBonus = 8;
			ColdBonus = 10;
			EnergyBonus = 0;
			FireBonus = 0;
			PoisonBonus = 0;
		}

		public IcySkinGorget( Serial serial ) : base( serial )
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
			Item item = new LeatherGorget();
			((BaseArmor)item).Resource = CraftResource.IcySkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class IcySkinArms : LeatherArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public IcySkinArms()
		{
			Name = "Icy Skin Arms";
			Hue = CraftResources.GetHue( CraftResource.IcySkin );

			ArmorAttributes.DurabilityBonus = 50;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 0;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 0;
			Attributes.DefendChance = 2;
			Attributes.LowerManaCost = 0;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 2;
			Attributes.Luck = 10;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 0;
			Attributes.BonusStr = 2;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 3;

			PhysicalBonus = 8;
			ColdBonus = 10;
			EnergyBonus = 0;
			FireBonus = 0;
			PoisonBonus = 0;
		}

		public IcySkinArms( Serial serial ) : base( serial )
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
			Item item = new LeatherArms();
			((BaseArmor)item).Resource = CraftResource.IcySkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class IcySkinChest : LeatherChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public IcySkinChest()
		{
			Name = "Icy Skin Tunic";
			Hue = CraftResources.GetHue( CraftResource.IcySkin );

			ArmorAttributes.DurabilityBonus = 50;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 0;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 0;
			Attributes.DefendChance = 2;
			Attributes.LowerManaCost = 0;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 2;
			Attributes.Luck = 10;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 0;
			Attributes.BonusStr = 2;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 3;

			PhysicalBonus = 8;
			ColdBonus = 10;
			EnergyBonus = 0;
			FireBonus = 0;
			PoisonBonus = 0;
		}

		public IcySkinChest( Serial serial ) : base( serial )
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
			Item item = new LeatherChest();
			((BaseArmor)item).Resource = CraftResource.IcySkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class IcySkinHelm : LeatherCap /////////////////////////////////////////
	{
		[Constructable]
		public IcySkinHelm()
		{
			Name = "Icy Skin Cap";
			Hue = CraftResources.GetHue( CraftResource.IcySkin );

			ArmorAttributes.DurabilityBonus = 50;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 0;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 0;
			Attributes.DefendChance = 2;
			Attributes.LowerManaCost = 0;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 2;
			Attributes.Luck = 10;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 0;
			Attributes.BonusStr = 2;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 3;

			PhysicalBonus = 8;
			ColdBonus = 10;
			EnergyBonus = 0;
			FireBonus = 0;
			PoisonBonus = 0;
		}

		public IcySkinHelm( Serial serial ) : base( serial )
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
			Item item = new LeatherCap();
			((BaseArmor)item).Resource = CraftResource.IcySkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}