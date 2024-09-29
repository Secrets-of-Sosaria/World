using System;
using Server;

namespace Server.Items
{
    public class Artifact_MagiciansIllusion : GiftDoubleBladedStaff
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        [Constructable]
        public Artifact_MagiciansIllusion()
        {
            Name = "Magician's Illusion";
            Hue = 1072;
			ItemID = 0x26BF;
            WeaponAttributes.HitLightning = 15;
            WeaponAttributes.HitLowerAttack = 15;
            WeaponAttributes.HitMagicArrow = 5;
            WeaponAttributes.SelfRepair = 2;
            SkillBonuses.SetValues( 0, SkillName.Magery, 5.0 );
            Attributes.BonusMana = 30;
            Attributes.ReflectPhysical = 15;
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 25;
            IntRequirement = 100;
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
        public Artifact_MagiciansIllusion( Serial serial )
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
