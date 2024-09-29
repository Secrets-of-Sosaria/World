using System;
using Server;

namespace Server.Items
{
	public class Artifact_RobinHoodsFeatheredHat : GiftFeatheredHat
	{
		[Constructable]
		public Artifact_RobinHoodsFeatheredHat()
		{
			Hue = 0x114;
			Name = "Robin Hood's Feathered Hat";
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 10 );
			Attributes.Luck = 20;
			Attributes.BonusDex = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 4, "" );
		}

		public Artifact_RobinHoodsFeatheredHat( Serial serial ) : base( serial )
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