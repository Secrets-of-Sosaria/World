using System;
using Server;

namespace Server.Items
{
    public class Artifact_AngeroftheGods : GiftBroadsword
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        [Constructable]
        public Artifact_AngeroftheGods()
        {
            Name = "Anger of the Gods";
			ItemID = 0xF5E;
            Attributes.WeaponDamage = 35;
            Attributes.AttackChance = 10;
            Attributes.DefendChance = 15;
            WeaponAttributes.HitHarm = 50;
            WeaponAttributes.HitLeechMana = 15;
            WeaponAttributes.HitLowerAttack = 25;
            Attributes.CastSpeed = 1;
            Attributes.WeaponSpeed = 20;
            Hue = 1265;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 9, "" );
		}

        public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
        {
            phys = 25;
            cold = 25;
            fire = 0;
            nrgy = 50;
            pois = 0;
            chaos = 0;
            direct = 0;
        }

        public Artifact_AngeroftheGods( Serial serial ) : base( serial )
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
