using System;
using Server;

namespace Server.Items
{
	public class SkinNightmareLegs : LeatherLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SkinNightmareLegs()
		{
			Name = "Nightmare Skin Leggings";
			Hue = CraftResources.GetHue( CraftResource.NightmareSkin );

			ArmorAttributes.DurabilityBonus = 10;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 0;
			Attributes.DefendChance = 0;
			Attributes.LowerManaCost = 2;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 0;
			Attributes.Luck = 20;
			Attributes.NightSight = 1;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 1;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 0;

			PhysicalBonus = 0;
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 3;
			PoisonBonus = 0;
		}

		public SkinNightmareLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.NightmareSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SkinNightmareGloves : LeatherGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public SkinNightmareGloves()
		{
			Name = "Nightmare Skin Gloves";
			Hue = CraftResources.GetHue( CraftResource.NightmareSkin );

			ArmorAttributes.DurabilityBonus = 10;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 0;
			Attributes.DefendChance = 0;
			Attributes.LowerManaCost = 2;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 0;
			Attributes.Luck = 20;
			Attributes.NightSight = 1;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 1;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 0;

			PhysicalBonus = 0;
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 3;
			PoisonBonus = 0;
		}

		public SkinNightmareGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.NightmareSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SkinNightmareGorget : LeatherGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public SkinNightmareGorget()
		{
			Name = "Nightmare Skin Gorget";
			Hue = CraftResources.GetHue( CraftResource.NightmareSkin );

			ArmorAttributes.DurabilityBonus = 10;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 0;
			Attributes.DefendChance = 0;
			Attributes.LowerManaCost = 2;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 0;
			Attributes.Luck = 20;
			Attributes.NightSight = 1;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 1;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 0;

			PhysicalBonus = 0;
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 3;
			PoisonBonus = 0;
		}

		public SkinNightmareGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.NightmareSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SkinNightmareArms : LeatherArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SkinNightmareArms()
		{
			Name = "Nightmare Skin Arms";
			Hue = CraftResources.GetHue( CraftResource.NightmareSkin );

			ArmorAttributes.DurabilityBonus = 10;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 0;
			Attributes.DefendChance = 0;
			Attributes.LowerManaCost = 2;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 0;
			Attributes.Luck = 20;
			Attributes.NightSight = 1;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 1;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 0;

			PhysicalBonus = 0;
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 3;
			PoisonBonus = 0;
		}

		public SkinNightmareArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.NightmareSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SkinNightmareChest : LeatherChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public SkinNightmareChest()
		{
			Name = "Nightmare Skin Tunic";
			Hue = CraftResources.GetHue( CraftResource.NightmareSkin );

			ArmorAttributes.DurabilityBonus = 10;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 0;
			Attributes.DefendChance = 0;
			Attributes.LowerManaCost = 2;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 0;
			Attributes.Luck = 20;
			Attributes.NightSight = 1;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 1;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 0;

			PhysicalBonus = 0;
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 3;
			PoisonBonus = 0;
		}

		public SkinNightmareChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.NightmareSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SkinNightmareHelm : LeatherCap /////////////////////////////////////////
	{
		[Constructable]
		public SkinNightmareHelm()
		{
			Name = "Nightmare Skin Cap";
			Hue = CraftResources.GetHue( CraftResource.NightmareSkin );

			ArmorAttributes.DurabilityBonus = 10;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 0;
			Attributes.DefendChance = 0;
			Attributes.LowerManaCost = 2;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 0;
			Attributes.Luck = 20;
			Attributes.NightSight = 1;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 1;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 0;

			PhysicalBonus = 0;
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 3;
			PoisonBonus = 0;
		}

		public SkinNightmareHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.NightmareSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}