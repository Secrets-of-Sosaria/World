using System;
using Server;

namespace Server.Items
{
    public class Artifact_Indecency : GiftStuddedChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        public override int BasePhysicalResistance{ get{ return 3; } }
        public override int BaseColdResistance{ get{ return 12; } }
        public override int BaseFireResistance{ get{ return 12; } }
        public override int BaseEnergyResistance{ get{ return 13; } }
        public override int BasePoisonResistance{ get{ return 18; } }

        [Constructable]
        public Artifact_Indecency()
        {
            Name = "Indecency";
            Hue = 2075;
            Attributes.BonusStr = 5;
            Attributes.BonusInt = 5;
            Attributes.BonusDex = 5;
            Attributes.Luck = 50;
            Attributes.AttackChance = 5;
            Attributes.DefendChance = 4;
            ArmorAttributes.MageArmor = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

        public Artifact_Indecency(Serial serial) : base( serial )
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
