using System;
using Server;

namespace Server.Items
{
	public class Artifact_SamaritanRobe : GiftRobe
	{
		[Constructable]
		public Artifact_SamaritanRobe()
		{
			Name = "Good Samaritan Robe";
			Hue = 0x2a3;
			Attributes.Luck = 400;
			Resistances.Physical = 10;
			SkillBonuses.SetValues(0, SkillName.Knightship, 20);
			Attributes.ReflectPhysical = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_SamaritanRobe( Serial serial ) : base( serial )
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
