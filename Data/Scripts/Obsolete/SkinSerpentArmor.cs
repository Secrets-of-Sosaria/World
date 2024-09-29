using System;
using Server;

namespace Server.Items
{
	public class SkinSerpentLegs : LeatherLegs ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SkinSerpentLegs()
		{
			Name = "Serpent Skin Leggings";
			Hue = CraftResources.GetHue( CraftResource.SnakeSkin );

			ArmorAttributes.DurabilityBonus = 20;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = 3;
			Attributes.LowerManaCost = 0;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 0;
			Attributes.Luck = 10;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 1;
			Attributes.BonusInt = 0;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 0;

			PhysicalBonus = 0;
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 0;
			PoisonBonus = 5;
		}

		public SkinSerpentLegs( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SnakeSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SkinSerpentGloves : LeatherGloves ///////////////////////////////////////////////////
	{
		[Constructable]
		public SkinSerpentGloves()
		{
			Name = "Serpent Skin Gloves";
			Hue = CraftResources.GetHue( CraftResource.SnakeSkin );

			ArmorAttributes.DurabilityBonus = 20;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = 3;
			Attributes.LowerManaCost = 0;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 0;
			Attributes.Luck = 10;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 1;
			Attributes.BonusInt = 0;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 0;

			PhysicalBonus = 0;
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 0;
			PoisonBonus = 5;
		}

		public SkinSerpentGloves( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SnakeSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SkinSerpentGorget : LeatherGorget ///////////////////////////////////////////////////
	{
		[Constructable]
		public SkinSerpentGorget()
		{
			Name = "Serpent Skin Gorget";
			Hue = CraftResources.GetHue( CraftResource.SnakeSkin );

			ArmorAttributes.DurabilityBonus = 20;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = 3;
			Attributes.LowerManaCost = 0;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 0;
			Attributes.Luck = 10;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 1;
			Attributes.BonusInt = 0;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 0;

			PhysicalBonus = 0;
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 0;
			PoisonBonus = 5;
		}

		public SkinSerpentGorget( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SnakeSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SkinSerpentArms : LeatherArms ///////////////////////////////////////////////////////
	{
		[Constructable]
		public SkinSerpentArms()
		{
			Name = "Serpent Skin Arms";
			Hue = CraftResources.GetHue( CraftResource.SnakeSkin );

			ArmorAttributes.DurabilityBonus = 20;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = 3;
			Attributes.LowerManaCost = 0;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 0;
			Attributes.Luck = 10;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 1;
			Attributes.BonusInt = 0;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 0;

			PhysicalBonus = 0;
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 0;
			PoisonBonus = 5;
		}

		public SkinSerpentArms( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SnakeSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SkinSerpentChest : LeatherChest /////////////////////////////////////////////////////
	{
		[Constructable]
		public SkinSerpentChest()
		{
			Name = "Serpent Skin Tunic";
			Hue = CraftResources.GetHue( CraftResource.SnakeSkin );

			ArmorAttributes.DurabilityBonus = 20;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = 3;
			Attributes.LowerManaCost = 0;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 0;
			Attributes.Luck = 10;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 1;
			Attributes.BonusInt = 0;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 0;

			PhysicalBonus = 0;
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 0;
			PoisonBonus = 5;
		}

		public SkinSerpentChest( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SnakeSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
	public class SkinSerpentHelm : LeatherCap /////////////////////////////////////////
	{
		[Constructable]
		public SkinSerpentHelm()
		{
			Name = "Serpent Skin Cap";
			Hue = CraftResources.GetHue( CraftResource.SnakeSkin );

			ArmorAttributes.DurabilityBonus = 20;
			ArmorAttributes.LowerStatReq = 0;
			ArmorAttributes.MageArmor = 1;

			Attributes.SpellDamage = 0;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = 3;
			Attributes.LowerManaCost = 0;
			Attributes.LowerRegCost = 0;
			Attributes.ReflectPhysical = 0;
			Attributes.Luck = 10;
			Attributes.NightSight = 0;
			Attributes.BonusDex = 1;
			Attributes.BonusInt = 0;
			Attributes.BonusStr = 0;
			Attributes.RegenHits = 0;
			Attributes.RegenMana = 0;
			Attributes.RegenStam = 0;

			PhysicalBonus = 0;
			ColdBonus = 0;
			EnergyBonus = 0;
			FireBonus = 0;
			PoisonBonus = 5;
		}

		public SkinSerpentHelm( Serial serial ) : base( serial )
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
			((BaseArmor)item).Resource = CraftResource.SnakeSkin;
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}