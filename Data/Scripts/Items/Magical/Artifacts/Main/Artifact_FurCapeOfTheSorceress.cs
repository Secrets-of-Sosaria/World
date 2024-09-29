using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_FurCapeOfTheSorceress : GiftCloak
	{
		[Constructable]
		public Artifact_FurCapeOfTheSorceress()
		{
			Name = "Fur Cape Of The Sorceress";
			Hue = 1266;
			Attributes.BonusInt = 5;
			Attributes.BonusMana = 10;
			Attributes.LowerManaCost = 5;
			Attributes.LowerRegCost = 10;
			Attributes.SpellDamage = 15;
			Attributes.BonusMana = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_FurCapeOfTheSorceress( Serial serial ) : base( serial )
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
