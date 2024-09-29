using System;
using Server;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class Artifact_AngelicEmbrace : GiftPlateArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 9; } }
		public override int BaseEnergyResistance{ get{ return 10; } }        
		public override int BasePhysicalResistance{ get{ return 12; } }
		public override int BasePoisonResistance{ get{ return 11; } }      
		public override int BaseFireResistance{ get{ return 5; } }

        [Constructable]
        public Artifact_AngelicEmbrace()
        {
            Name = "Angelic Embrace";
            Hue = 1150;
			ItemID = 0x1410;
            Attributes.NightSight = 1;
            Attributes.DefendChance = 10;
            Attributes.WeaponDamage = 15;
            Attributes.WeaponSpeed = 5;
            Attributes.Luck = 150;
            Attributes.SpellDamage = 10;
            ArmorAttributes.MageArmor = 1;
            ArmorAttributes.SelfRepair = 3;
            Attributes.LowerManaCost = 5;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 12, "" );
		}

        public Artifact_AngelicEmbrace(Serial serial) : base( serial )
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
