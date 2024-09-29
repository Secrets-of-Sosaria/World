using System;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Spells.Third;
using Server.Spells;
using Server.Misc;

namespace Server.Items
{
	public class Artifact_HelmOfBrilliance : GiftNorseHelm
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_HelmOfBrilliance()
		{
			Name = "Helm of Brilliance";
			Hue = 0xB54;
			Attributes.NightSight = 1;
			FireBonus = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "(Casts Fireballs) " );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Parent != from )
			{
				from.SendMessage( "You must be wearing the helm to unleash a fireball." );
			}
			else
			{
				new FireballSpell( from, this ).Cast();
			}
			return;
		}

		public Artifact_HelmOfBrilliance( Serial serial ) : base( serial )
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
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}