using System;
using Server;
using Server.Misc;
using Server.Mobiles;

namespace Server.Items
{
	public class Artifact_GrimReapersLantern : GiftLantern
	{
		[Constructable]
		public Artifact_GrimReapersLantern()
		{
			Name = "Grim Reaper's Lantern";
			Hue = 0x47E;
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.SpellDamage = 10;
			SkillBonuses.SetValues( 0, SkillName.Necromancy, 10 );
			SkillBonuses.SetValues( 1, SkillName.Spiritualism, 10 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_GrimReapersLantern( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}