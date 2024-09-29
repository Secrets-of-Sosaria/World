using System;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Third;
using Server.Spells;
using Server.Misc;

namespace Server.Items
{
	public class Artifact_RobeOfTeleportation : GiftRobe
	{
		[Constructable]
		public Artifact_RobeOfTeleportation()
		{
			Name = "Robe Of Teleportation";
			Hue = Utility.RandomColor( 0 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "(Use to Teleport) " );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Parent != from )
			{
				from.SendMessage( "You must be wearing the robe to teleport." );
			}
			else
			{
				new TeleportSpell( from, this ).Cast();
			}
			return;
		}

		public Artifact_RobeOfTeleportation( Serial serial ) : base( serial )
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
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}
