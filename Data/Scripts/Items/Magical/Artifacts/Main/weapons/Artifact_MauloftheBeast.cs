using System;
using Server;

namespace Server.Items
{
    public class Artifact_MauloftheBeast : GiftMaul
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        [Constructable]
        public Artifact_MauloftheBeast()
        {
            Name = "Maul of the Beast";
            Hue = 1779;
            Attributes.WeaponDamage = 33;
            WeaponAttributes.HitLeechHits = 40;
            WeaponAttributes.HitLeechMana = 40;
            WeaponAttributes.HitLeechStam = 40;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = -30;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
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
        public Artifact_MauloftheBeast( Serial serial )
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
