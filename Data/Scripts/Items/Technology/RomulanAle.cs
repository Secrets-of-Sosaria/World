using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;

namespace Server.Items
{
	public class RomulanAle : Item
	{
		public override string DefaultDescription{ get{ return "This strange, alien liquid can quench your thirst if you choose to drink it. You can, however, detect the strong odor of alchol in it. Each bottle contains a single drink for someone."; } }

		[Constructable]
		public RomulanAle() : base( 0xE0F )
		{
			Stackable = true;
			Technology = true;
			Name = "romulan ale";
			InfoText1 = "alien liquor";
			InfoText2 = "use to drink";
			Weight = 0.1;
			Hue = 0xB3D;
		}

		public override void OnDoubleClick( Mobile from )
		{
			Server.Items.DrinkingFunctions.OnDrink( this, from );
		}

		public RomulanAle( Serial serial ) : base( serial )
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