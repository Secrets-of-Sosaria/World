using System;
using Server;

namespace Server.Items
{
	public class LavaSkinLegs : LeatherLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public LavaSkinLegs()
		{
			Name = "Lava Skin Leggings";
			Hue = CraftResources.GetHue( CraftResource.LavaSkin );

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
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 10;
			PoisonBonus = 0;
		}

		public LavaSkinLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.LavaSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class LavaSkinGloves : LeatherGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public LavaSkinGloves()
		{
			Name = "Lava Skin Gloves";
			Hue = CraftResources.GetHue( CraftResource.LavaSkin );

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
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 10;
			PoisonBonus = 0;
		}

		public LavaSkinGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.LavaSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class LavaSkinGorget : LeatherGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public LavaSkinGorget()
		{
			Name = "Lava Skin Gorget";
			Hue = CraftResources.GetHue( CraftResource.LavaSkin );

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
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 10;
			PoisonBonus = 0;
		}

		public LavaSkinGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.LavaSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class LavaSkinArms : LeatherArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public LavaSkinArms()
		{
			Name = "Lava Skin Arms";
			Hue = CraftResources.GetHue( CraftResource.LavaSkin );

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
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 10;
			PoisonBonus = 0;
		}

		public LavaSkinArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.LavaSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class LavaSkinChest : LeatherChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public LavaSkinChest()
		{
			Name = "Lava Skin Tunic";
			Hue = CraftResources.GetHue( CraftResource.LavaSkin );

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
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 10;
			PoisonBonus = 0;
		}

		public LavaSkinChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.LavaSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class LavaSkinHelm : LeatherCap /////////////////////////////////////////
	{
		[Constructable]
		public LavaSkinHelm()
		{
			Name = "Lava Skin Cap";
			Hue = CraftResources.GetHue( CraftResource.LavaSkin );

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
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 10;
			PoisonBonus = 0;
		}

		public LavaSkinHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.LavaSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}