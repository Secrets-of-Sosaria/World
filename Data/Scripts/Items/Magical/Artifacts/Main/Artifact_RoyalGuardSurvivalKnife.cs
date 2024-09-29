using System;
using Server;

namespace Server.Items
{
	public class Artifact_RoyalGuardSurvivalKnife : GiftDagger
	{
		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public Artifact_RoyalGuardSurvivalKnife()
		{
			Name = "Royal Guard Survival Knife";
			Attributes.SpellChanneling = 1;
			Attributes.Luck = 140;
			Attributes.EnhancePotions = 25;
			ItemID = 0x2674;

			WeaponAttributes.UseBestSkill = 1;
			WeaponAttributes.LowerStatReq = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 4, "" );
		}

		public Artifact_RoyalGuardSurvivalKnife( Serial serial ) : base( serial )
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
