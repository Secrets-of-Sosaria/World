using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;

namespace Server.Items
{
	public class EverlastingBottle : Item
	{
		public override double DefaultWeight
		{
			get { return 1.0; }
		}

		[Constructable]
		public EverlastingBottle() : base( 0x2827 )
		{
			Hue = 0x849;
			Name = "Everlasting Bottle";
			ArtifactLevel = 2;
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.Thirst = 20;
			from.SendMessage( "You take a healthy drink from the bottle...and it magically refills." );
			from.PlaySound( Utility.RandomList( 0x30, 0x2D6 ) );
		}

		public EverlastingBottle( Serial serial ) : base( serial )
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
			ItemID = 0x2827;
			Hue = 0x849;
			ArtifactLevel = 2;
		}
	}
}