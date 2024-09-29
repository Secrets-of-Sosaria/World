using System;
using Server;

namespace Server.Items
{
    public class Artifact_MadmansHatchet : GiftHatchet
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }
 
		[Constructable]
        public Artifact_MadmansHatchet()
        {
            Name = "Madman's Hatchet";
            Hue = 1157;
			ItemID = 0xF43;
            Attributes.WeaponDamage = 50;
            WeaponAttributes.HitLeechHits = 35;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.WeaponSpeed = 10;
            WeaponAttributes.HitFireball = 20;
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
        public Artifact_MadmansHatchet( Serial serial )
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
