using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class Artifact_Fortifiedarms : GiftBoneArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        [Constructable]
        public Artifact_Fortifiedarms()
        {
			Hue = 1165;
			Name = "Fortified Arms";
            Attributes.BonusDex = 5;
            Attributes.EnhancePotions = 25;
            Attributes.NightSight = 1;
            ArmorAttributes.SelfRepair = 5;
            ColdBonus = 10;
            EnergyBonus = 7;
            FireBonus = 8;
            PhysicalBonus = 9;
            PoisonBonus = 8;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

        public Artifact_Fortifiedarms( Serial serial ) : base( serial )
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