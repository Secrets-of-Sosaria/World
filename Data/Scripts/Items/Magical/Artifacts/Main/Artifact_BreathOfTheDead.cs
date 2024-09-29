using System;
using Server;

namespace Server.Items
{
	public class Artifact_BreathOfTheDead : GiftBoneHarvester
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_BreathOfTheDead()
		{
			Name = "Breath of the Dead";
			Hue = 0x455;
			WeaponAttributes.HitLeechHits = 100;
			WeaponAttributes.HitHarm = 25;
			Attributes.SpellDamage = 5;
			Attributes.WeaponDamage = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 9, "" );
		}

		public Artifact_BreathOfTheDead( Serial serial ) : base( serial )
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