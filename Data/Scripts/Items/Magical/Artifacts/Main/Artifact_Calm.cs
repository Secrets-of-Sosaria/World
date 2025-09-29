using System;
using Server;

namespace Server.Items
{
	public class Artifact_Calm : GiftHalberd
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public Artifact_Calm()
		{
			Name = "Calm";
			Hue = 0x2cb;
			ItemID = 0x143E;
			AccuracyLevel = WeaponAccuracyLevel.Supremely;
			DamageLevel = WeaponDamageLevel.Vanq;
			Attributes.WeaponSpeed = 22;
			WeaponAttributes.HitLeechMana = 50;
			Attributes.SpellChanneling = 1;
			WeaponAttributes.UseBestSkill = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_Calm( Serial serial ) : base( serial )
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
