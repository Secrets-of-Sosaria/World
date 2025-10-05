using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArcaneShield : GiftWoodenKiteShield
	{
		[Constructable]
		public Artifact_ArcaneShield()
		{
			Name = "Arcane Shield";
			ItemID = 0x1B78;
			Hue = 0x556;
			SkillBonuses.SetValues( 0, SkillName.Parry, 20 );
			Attributes.SpellChanneling = 1;
			Attributes.CastRecovery = 1;
			Attributes.DefendChance = 15;
			Attributes.SpellDamage = 9;
			Attributes.CastSpeed = 1;
			ArmorAttributes.SelfRepair = 7;
			Attributes.NightSight = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_ArcaneShield( Serial serial ) : base( serial )
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