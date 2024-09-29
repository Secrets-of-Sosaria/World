using System;
using Server;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class AngelicEmbrace : PlateArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseColdResistance{ get{ return 9; } }
		public override int BaseEnergyResistance{ get{ return 10; } }        
		public override int BasePhysicalResistance{ get{ return 12; } }
		public override int BasePoisonResistance{ get{ return 11; } }      
		public override int BaseFireResistance{ get{ return 5; } }

        [Constructable]
        public AngelicEmbrace()
        {
            Name = "Angelic Embrace";
            Hue = 1150;
            Attributes.NightSight = 1;
            Attributes.DefendChance = 10;
            Attributes.WeaponDamage = 15;
            Attributes.WeaponSpeed = 5;
            Attributes.Luck = 150;
            Attributes.SpellDamage = 10;
            ArmorAttributes.MageArmor = 1;
            ArmorAttributes.SelfRepair = 3;
            Attributes.LowerManaCost = 5;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

        public AngelicEmbrace(Serial serial) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int) 0 );
        }

        private void Cleanup( object state ){ Item item = new Artifact_AngelicEmbrace(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
            int version = reader.ReadInt();
        }
    }
}
