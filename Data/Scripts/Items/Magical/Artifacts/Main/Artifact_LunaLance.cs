using System;
using Server;

namespace Server.Items
{
	public class Artifact_LunaLance : GiftLance
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_LunaLance()
		{
			Name = "Holy Lance";
			Hue = 0x47E;
			SkillBonuses.SetValues( 0, SkillName.Knightship, 10.0 );
			Attributes.BonusStr = 5;
			Attributes.WeaponSpeed = 20;
			Attributes.WeaponDamage = 35;
			WeaponAttributes.UseBestSkill = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_LunaLance( Serial serial ) : base( serial )
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