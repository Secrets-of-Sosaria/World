using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	public class ElementalSteed : BaseMount
	{
		public override bool DeleteCorpseOnDeath { get { return true; } }
		public override bool DeleteOnRelease{ get{ return true; } }

		[Constructable]
		public ElementalSteed() : this( "a steed" )
		{
		}

		[Constructable]
		public ElementalSteed( string name ) : base( name, 0xE2, 0x3EA0, AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4 )
		{
			Blessed = true;
			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 29.1;
		}

		public ElementalSteed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class AirDragonElementalSteed : ElementalSteed
	{
		[Constructable]
		public AirDragonElementalSteed() : this("an air dragon")
		{
		}
	
		[Constructable]
		public AirDragonElementalSteed( string name ) : base(name)
		{
			Body = 596;
			Hue = 0x9A3;
			BaseSoundID = 362;
			ItemID = 596;
		}

		public AirDragonElementalSteed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class BearElementalSteed : ElementalSteed
	{
		[Constructable]
		public BearElementalSteed() : this("a bear")
		{
		}
	
		[Constructable]
		public BearElementalSteed( string name ) : base(name)
		{
			Body = 23;
			Hue = 0;
			BaseSoundID = 0xA3;
			ItemID = 23;
		}

		public BearElementalSteed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class PhoenixElementalSteed : ElementalSteed
	{
		[Constructable]
		public PhoenixElementalSteed() : this("a phoenix")
		{
		}
	
		[Constructable]
		public PhoenixElementalSteed( string name ) : base(name)
		{
			Body = 243;
			Hue = 0xB73;
			BaseSoundID = 0x8F;
			ItemID = 0x3E94;
		}

		public PhoenixElementalSteed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class WaterBeetleElementalSteed : ElementalSteed
	{
		[Constructable]
		public WaterBeetleElementalSteed() : this("a water beetle")
		{
		}
	
		[Constructable]
		public WaterBeetleElementalSteed( string name ) : base(name)
		{
			Body = 0xA9;
			Hue = 0x555;
			BaseSoundID = 0x388;
			ItemID = 0x3E95;
		}

		public WaterBeetleElementalSteed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}