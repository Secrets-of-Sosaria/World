using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArcaneCap : GiftLeatherCap
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ArcaneCap()
		{
			Name = "Arcane Cap";
			Hue = 0x556;
			Attributes.NightSight = 1;
			Attributes.DefendChance = 6;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 3;
			Attributes.LowerRegCost = 3;
			Attributes.SpellDamage = 3;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_ArcaneCap( Serial serial ) : base( serial )
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