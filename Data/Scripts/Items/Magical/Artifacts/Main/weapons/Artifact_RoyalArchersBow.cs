using System;
using Server;

namespace Server.Items
{
    public class Artifact_RoyalArchersBow : GiftBow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        [Constructable]
        public Artifact_RoyalArchersBow()
        {
            Name = "Royal Archer's Bow";
            Hue = 2101;
			ItemID = 0x13B2;
            WeaponAttributes.HitDispel = 23;
            WeaponAttributes.HitLowerAttack = 23;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 10;
            Attributes.WeaponDamage = 20;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

        public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
        {
            phys = 50;
            cold = 10;
            fire = 10;
            nrgy = 10;
            pois = 20;
            chaos = 0;
            direct = 0;
        }
        public Artifact_RoyalArchersBow( Serial serial )
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
