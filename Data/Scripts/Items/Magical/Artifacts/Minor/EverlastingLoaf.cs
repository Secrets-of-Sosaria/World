using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;

namespace Server.Items
{
	public class EverlastingLoaf : Item
	{
		public override double DefaultWeight
		{
			get { return 1.0; }
		}

		[Constructable]
		public EverlastingLoaf() : base( 0x136F )
		{
			Hue = 0;
			Name = "Everlasting Loaf";
			ArtifactLevel = 2;
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.Hunger = 20;
			from.SendMessage( "You take a healthy bite from the bread...and it magically reforms." );

			// Play a random "eat" sound
			from.PlaySound( Utility.Random( 0x3A, 3 ) );

			if ( from.Body.IsHuman && !from.Mounted )
				from.Animate( 34, 5, 1, true, false, 0 );
		}

		public EverlastingLoaf( Serial serial ) : base( serial )
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
			ItemID = 0x136F;
			Hue = 0;
			ArtifactLevel = 2;
		}
	}
}