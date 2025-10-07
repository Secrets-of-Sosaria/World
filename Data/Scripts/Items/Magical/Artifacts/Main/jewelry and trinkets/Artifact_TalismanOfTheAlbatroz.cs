using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
    public class Artifact_TalismanOfTheAlbatroz : GiftTalismanLeather
	{
		[Constructable]
		public Artifact_TalismanOfTheAlbatroz()
		{
			Name = "Talisman of the Albatroz";
			ItemID = 12120;
			Hue = 2263;
			Resistances.Cold = 10;
			SkillBonuses.SetValues(0, SkillName.Seafaring, 20);
			SkillBonuses.SetValues(1, SkillName.Cartography, 10);
			Attributes.Luck = 100;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}
		
		public Artifact_TalismanOfTheAlbatroz( Serial serial ) :  base( serial )
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