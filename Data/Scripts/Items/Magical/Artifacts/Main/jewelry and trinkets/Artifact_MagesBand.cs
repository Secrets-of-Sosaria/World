using System;
using Server;

namespace Server.Items
{
    public class Artifact_MagesBand : GiftGoldRing
    {
        [Constructable]
        public Artifact_MagesBand()
        {
            Name = "Mage's Band";
            Hue = 1170;
			ItemID = 0x6731;
            Attributes.LowerRegCost = 15;
            Attributes.LowerManaCost = 7;
            Attributes.CastSpeed = 2;
            Attributes.CastRecovery = 2;
            Attributes.BonusMana = 15;
            Attributes.RegenMana = 7;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

        public Artifact_MagesBand( Serial serial )
            : base( serial )
        {
        }
        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int)0 );
        }
        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
			ArtifactLevel = 2;
            int version = reader.ReadInt();
        }
    }
}
