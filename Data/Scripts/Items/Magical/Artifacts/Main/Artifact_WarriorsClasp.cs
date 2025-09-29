using System;
using Server;

namespace Server.Items
{
    public class Artifact_WarriorsClasp : GiftGoldBracelet
    {
        [Constructable]
        public Artifact_WarriorsClasp()
        {
            Name = "Warrior's Clasp";
            Hue = 2117;
            SkillBonuses.SetValues( 0, SkillName.Tactics, 10.0 );
            Attributes.AttackChance = 10;
            Attributes.DefendChance = 10;
            Attributes.BonusMana = 9;
            Attributes.BonusHits = 9;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

        public Artifact_WarriorsClasp( Serial serial ) : base( serial )
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
