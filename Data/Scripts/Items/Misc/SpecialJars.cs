using System;
using Server;

namespace Server.Items
{
	public class SpecialJars : Item
	{
		[Constructable]
		public SpecialJars() : base( 0x6583 )
		{
			switch ( Utility.RandomMinMax( 0, 5 ) )
			{
				case 0:		ItemID = 0x657B;	Name = "candle in a bottle";	Light = LightType.Circle150;	break;
				case 1:		ItemID = 0x657E;	Name = "fireflies";				Light = LightType.Circle150;	break;
				case 2:		ItemID = 0x6583;	Name = "bottled flowers";										break;
				case 3:		ItemID = 0x6584;	Name = "bottled flowers";										break;
				case 4:		ItemID = 0x6585;	Name = "bottled flowers";										break;
				case 5:		ItemID = 0x6586;	Name = "bottled flowers";										break;
			}

			Hue = 0;
			Weight = 1.0;
		}

		public SpecialJars( Serial serial ) : base( serial )
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

			if ( Name == "candle in a bottle" ){ Light = LightType.Circle150; }
			else if ( Name == "fireflies" ){ Light = LightType.Circle150; }
		}
	}
}