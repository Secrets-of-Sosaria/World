using System;
using Server;

namespace Server.Items
{
    public class Artifact_NordicVikingSword : GiftClaymore
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        [Constructable]
        public Artifact_NordicVikingSword()
        {
            Name = "Nordic Dragon Blade";
            Hue = 741;
			ItemID = 0x568F;
            Attributes.WeaponDamage = 50;
            Attributes.WeaponSpeed = 20;
            WeaponAttributes.HitLightning = 50;
            Attributes.BonusHits = 30;
            Slayer = SlayerName.DragonSlaying;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

        public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
        {
            phys = 40;
            cold = 0;
            fire = 20;
            nrgy = 40;
            pois = 0;
            chaos = 0;
            direct = 0;
        }
        public Artifact_NordicVikingSword( Serial serial ): base( serial )
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
