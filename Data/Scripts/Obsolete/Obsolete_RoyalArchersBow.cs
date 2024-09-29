using System;
using Server;

namespace Server.Items
{
    public class RoyalArchersBow : Bow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        [Constructable]
        public RoyalArchersBow()
        {
            Name = "Royal Archer's Bow";
            Hue = 2101;
            WeaponAttributes.HitDispel = 25;
            WeaponAttributes.HitLightning = 35;
            WeaponAttributes.HitLowerAttack = 25;
            WeaponAttributes.SelfRepair = 10;
            Attributes.BonusHits = 15;
            Attributes.ReflectPhysical = 25;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 20;
            Attributes.WeaponDamage = 30;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
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
        public RoyalArchersBow( Serial serial )
            : base( serial )
        {
        }
        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int)0 );
        }
        private void Cleanup( object state ){ Item item = new Artifact_RoyalArchersBow(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
            int version = reader.ReadInt();
        }
    }
}
