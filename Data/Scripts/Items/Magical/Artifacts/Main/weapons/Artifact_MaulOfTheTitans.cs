using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_MaulOfTheTitans : GiftMaul
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

      [Constructable]
		public Artifact_MaulOfTheTitans()
		{
			Name = "Maul of the Titans";
			Hue = 0xB89;
			SkillBonuses.SetValues(1, SkillName.Bludgeoning, 20);
			MinDamage = MinDamage + 5;
			MaxDamage = MaxDamage + 10;
			Attributes.BonusStr = 12;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_MaulOfTheTitans( Serial serial ) : base( serial )
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
