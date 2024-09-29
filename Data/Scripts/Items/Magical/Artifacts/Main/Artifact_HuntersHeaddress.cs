using System;
using Server;

namespace Server.Items
{
	public class Artifact_HuntersHeaddress : GiftDeerMask
	{
		public override int BaseColdResistance{ get{ return 23; } }

		[Constructable]
		public Artifact_HuntersHeaddress()
		{
			Hue = 0x594;
			Name = "Hunter's Headdress";
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 20 );

			Attributes.BonusDex = 8;
			Attributes.NightSight = 1;
			Attributes.AttackChance = 15;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 9, "" );
		}

		public Artifact_HuntersHeaddress( Serial serial ) : base( serial )
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