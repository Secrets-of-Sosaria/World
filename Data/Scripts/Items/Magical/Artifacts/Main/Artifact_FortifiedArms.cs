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

            Attributes.AttackChance = 5;
            Attributes.BonusDex = 5;
            Attributes.DefendChance = 10;
            Attributes.EnhancePotions = 20;
            Attributes.NightSight = 1;
            ArmorAttributes.SelfRepair = 5;

            ColdBonus = 10;
            EnergyBonus = 5;
            FireBonus = 8;
            PhysicalBonus = 9;
            PoisonBonus = 5;
            StrBonus = 10;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 14, "" );
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