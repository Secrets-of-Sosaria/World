using System;

namespace Server.Items
{
	public class Artifact_PendantOfTheMagi : GiftGoldNecklace
	{
		[Constructable]
		public Artifact_PendantOfTheMagi()
		{
			Name = "Pendant of the Magi";
			Hue = 0x48D;
			Attributes.BonusInt = 10;
			Attributes.RegenMana = 3;
			Attributes.SpellDamage = 5;
			Attributes.LowerManaCost = 10;
			Attributes.LowerRegCost = 30;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_PendantOfTheMagi( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			ArtifactLevel = 2;

			int version = reader.ReadEncodedInt();
		}
	}
}
