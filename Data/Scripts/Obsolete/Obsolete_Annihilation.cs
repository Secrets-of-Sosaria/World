using System;
using Server;

namespace Server.Items
{
    public class Annihilation : Bardiche
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        [Constructable]
        public Annihilation()
        {
            Name = "Annihilation";
			Hue = 1154;
            Attributes.WeaponDamage = 20;
            Attributes.AttackChance = 15;
            Attributes.DefendChance = 5;
            WeaponAttributes.HitLeechHits = 35;
            WeaponAttributes.HitLightning = 20;
            WeaponAttributes.SelfRepair = 3;
            Attributes.Luck = 50;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 25;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
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
        public Annihilation( Serial serial )
            : base( serial )
        {
        }
        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int)0 );
        }
        private void Cleanup( object state ){ Item item = new Artifact_Annihilation(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
            int version = reader.ReadInt();
        }
    }
}
