using System;
using Server;

namespace Server.Items
{
	public class Artifact_OblivionsNeedle : GiftDagger
	{
		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public Artifact_OblivionsNeedle()
		{
			Name = "Oblivion Needle";
			ItemID = 0xF52;
			Attributes.BonusStam = 20;
			Attributes.AttackChance = 20;
			Attributes.DefendChance = -20;
			Attributes.WeaponDamage = 40;

			WeaponAttributes.HitLeechStam = 50;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

		public Artifact_OblivionsNeedle( Serial serial ) : base( serial )
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
