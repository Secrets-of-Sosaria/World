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
}