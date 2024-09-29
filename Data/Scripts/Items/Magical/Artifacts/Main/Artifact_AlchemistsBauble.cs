using System;
using Server;

namespace Server.Items
{
	public class Artifact_AlchemistsBauble : GiftTalismanLeather
	{
		[Constructable]
		public Artifact_AlchemistsBauble()
		{
			Name = "Alchemist's Bauble";
			ItemID = 0x2C90;
			Hue = Utility.RandomColor(0);
			SkillBonuses.SetValues( 0, SkillName.Alchemy, 25.0 );
			SkillBonuses.SetValues( 1, SkillName.Cooking, 25.0 );
			Attributes.EnhancePotions = 30;
			Attributes.LowerRegCost = 20;
			Resistances.Poison = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}
		
		public Artifact_AlchemistsBauble( Serial serial ) : base( serial )
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