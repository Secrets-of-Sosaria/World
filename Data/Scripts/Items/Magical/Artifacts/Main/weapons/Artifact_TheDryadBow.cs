using System;
using Server;

namespace Server.Items
{
	public class Artifact_TheDryadBow : GiftBow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_TheDryadBow()
		{
			Name = "Dryad Bow";
			ItemID = 0x13B1;
			Hue = 0x48F;
			Attributes.WeaponSpeed = 15;
			WeaponAttributes.ResistPoisonBonus = 15;
			SkillBonuses.SetValues( 0, SkillName.Druidism, 20 );
			SkillBonuses.SetValues( 1, SkillName.Taming, 20 );
			SkillBonuses.SetValues( 2, SkillName.Veterinary, 20 );
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_TheDryadBow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;
			int version = reader.ReadInt();
		}
	}
}
