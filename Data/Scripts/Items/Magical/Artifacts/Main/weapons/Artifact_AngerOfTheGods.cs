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
            Attributes.AttackChance = 11;
            Attributes.DefendChance = 5;
            WeaponAttributes.HitHarm = 20;
            WeaponAttributes.HitLeechMana = 15;
            WeaponAttributes.HitLowerAttack = 15;
            Hue = 1265;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
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
