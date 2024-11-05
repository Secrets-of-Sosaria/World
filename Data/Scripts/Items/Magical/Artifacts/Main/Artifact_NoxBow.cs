using System;
using Server;

namespace Server.Items
{
    public class Artifact_NoxBow : GiftHeavyCrossbow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        [Constructable]
        public Artifact_NoxBow()
        {
            Name = "Nox Ranger's Light Crossbow";
            Attributes.WeaponDamage = 45;
            Hue = 267;
			ItemID = 0x13FD;
            WeaponAttributes.HitLeechHits = 20;
            WeaponAttributes.HitLeechMana = 20;
            WeaponAttributes.HitLeechStam = 20;
            WeaponAttributes.HitLightning = 5;
            WeaponAttributes.HitLowerAttack = 5;
            WeaponAttributes.HitPhysicalArea = 5;
            WeaponAttributes.LowerStatReq = 5;
            WeaponAttributes.SelfRepair = 2;
            Attributes.ReflectPhysical = 5;
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 10;
            Attributes.WeaponSpeed = 40;
			ArtifactLevel = 2;
			Server.Misc.Arty.ArtySetup( this, 14, "" );
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
        public Artifact_NoxBow( Serial serial )
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
