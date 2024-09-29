using System;
using Server;

namespace Server.Items
{
	public class Artifact_AchillesShield : GiftBronzeShield
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_AchillesShield()
		{
			Hue = 0xB1B;
			Name = "Achille's Shield";
			SkillBonuses.SetValues( 0, SkillName.Parry, 25 );
			ArmorAttributes.DurabilityBonus = 30;
			ArmorAttributes.LowerStatReq = 10;
			Attributes.DefendChance = 10;
			Attributes.ReflectPhysical = 5;
			PhysicalBonus = 25;
			Attributes.NightSight = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_AchillesShield( Serial serial ) : base( serial )
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