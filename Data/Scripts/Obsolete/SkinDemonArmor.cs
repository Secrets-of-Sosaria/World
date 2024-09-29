using System;
using Server;

namespace Server.Items
{
	public class SkinDemonLegs : LeatherLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SkinDemonLegs()
		{
			Name = "Demon Skin Leggings";
			Hue = CraftResources.GetHue( CraftResource.DemonSkin );

			ArmorAttributes.DurabilityBonus = 50;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 3;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = 0;
			Attributes.LowerManaCost = 2;
			Attributes.LowerRegCost = 2;
			Attributes.ReflectPhysical = 2;
			Attributes.Luck = 0;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 1;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 3;
			Attributes.RegenStam = 0;

			PhysicalBonus = 1;
			ColdBonus = 0;
			EnergyBonus = 1;
			FireBonus = 2;
			PoisonBonus = 0;
		}

		public SkinDemonLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.DemonSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SkinDemonGloves : LeatherGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public SkinDemonGloves()
		{
			Name = "Demon Skin Gloves";
			Hue = CraftResources.GetHue( CraftResource.DemonSkin );

			ArmorAttributes.DurabilityBonus = 50;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 3;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = 0;
			Attributes.LowerManaCost = 2;
			Attributes.LowerRegCost = 2;
			Attributes.ReflectPhysical = 2;
			Attributes.Luck = 0;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 1;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 3;
			Attributes.RegenStam = 0;

			PhysicalBonus = 1;
			ColdBonus = 0;
			EnergyBonus = 1;
			FireBonus = 2;
			PoisonBonus = 0;
		}

		public SkinDemonGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.DemonSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SkinDemonGorget : LeatherGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public SkinDemonGorget()
		{
			Name = "Demon Skin Gorget";
			Hue = CraftResources.GetHue( CraftResource.DemonSkin );

			ArmorAttributes.DurabilityBonus = 50;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 3;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = 0;
			Attributes.LowerManaCost = 2;
			Attributes.LowerRegCost = 2;
			Attributes.ReflectPhysical = 2;
			Attributes.Luck = 0;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 1;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 3;
			Attributes.RegenStam = 0;

			PhysicalBonus = 1;
			ColdBonus = 0;
			EnergyBonus = 1;
			FireBonus = 2;
			PoisonBonus = 0;
		}

		public SkinDemonGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.DemonSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SkinDemonArms : LeatherArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SkinDemonArms()
		{
			Name = "Demon Skin Arms";
			Hue = CraftResources.GetHue( CraftResource.DemonSkin );

			ArmorAttributes.DurabilityBonus = 50;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 3;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = 0;
			Attributes.LowerManaCost = 2;
			Attributes.LowerRegCost = 2;
			Attributes.ReflectPhysical = 2;
			Attributes.Luck = 0;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 1;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 3;
			Attributes.RegenStam = 0;

			PhysicalBonus = 1;
			ColdBonus = 0;
			EnergyBonus = 1;
			FireBonus = 2;
			PoisonBonus = 0;
		}

		public SkinDemonArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.DemonSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SkinDemonChest : LeatherChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public SkinDemonChest()
		{
			Name = "Demon Skin Tunic";
			Hue = CraftResources.GetHue( CraftResource.DemonSkin );

			ArmorAttributes.DurabilityBonus = 50;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 3;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = 0;
			Attributes.LowerManaCost = 2;
			Attributes.LowerRegCost = 2;
			Attributes.ReflectPhysical = 2;
			Attributes.Luck = 0;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 1;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 3;
			Attributes.RegenStam = 0;

			PhysicalBonus = 1;
			ColdBonus = 0;
			EnergyBonus = 1;
			FireBonus = 2;
			PoisonBonus = 0;
		}

		public SkinDemonChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.DemonSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SkinDemonHelm : LeatherCap /////////////////////////////////////////
	{
		[Constructable]
		public SkinDemonHelm()
		{
			Name = "Demon Skin Cap";
			Hue = CraftResources.GetHue( CraftResource.DemonSkin );

			ArmorAttributes.DurabilityBonus = 50;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 3;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = 0;
			Attributes.LowerManaCost = 2;
			Attributes.LowerRegCost = 2;
			Attributes.ReflectPhysical = 2;
			Attributes.Luck = 0;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 0;
			Attributes.BonusInt = 1;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 3;
			Attributes.RegenStam = 0;

			PhysicalBonus = 1;
			ColdBonus = 0;
			EnergyBonus = 1;
			FireBonus = 2;
			PoisonBonus = 0;
		}

		public SkinDemonHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.DemonSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}