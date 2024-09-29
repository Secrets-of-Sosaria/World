using System;
using Server;

namespace Server.Items
{
    public class Artifact_LongShot : GiftCompositeBow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        [Constructable]
        public Artifact_LongShot()
        {
            Name = "Long Shot";
            Hue = 1195;
			ItemID = 0x13B2;
            Attributes.WeaponDamage = 30;
            Attributes.AttackChance = 35;
            WeaponAttributes.HitLightning = 45;
            WeaponAttributes.SelfRepair = 3;
            Attributes.RegenHits = 4;
            Attributes.SpellChanneling = 1;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 6, "" );
		}

        public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
        {
            phys = 100;
            cold = 0;
            fire = 0;
            nrgy = 0;
            pois = 0;
            chaos = 0;
            direct = 0;
        }
        public Artifact_LongShot( Serial serial )
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
