using System;
using Server;

namespace Server.Items
{
	public class Artifact_LieutenantOfTheBritannianRoyalGuard : GiftSash
	{
		[Constructable]
		public Artifact_LieutenantOfTheBritannianRoyalGuard()
		{
			Name = "Royal Guard Sash";
			Hue = 0xe8;

			Attributes.BonusInt = 5;
			Attributes.RegenMana = 2;
			Attributes.LowerRegCost = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 3, "" );
		}

		public Artifact_LieutenantOfTheBritannianRoyalGuard( Serial serial ) : base( serial )
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
