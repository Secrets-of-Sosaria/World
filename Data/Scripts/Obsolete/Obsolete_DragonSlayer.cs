using System;
using Server;

namespace Server.Items
{
    public class NordicVikingSword : VikingSword
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        [Constructable]
        public NordicVikingSword()
        {
            Name = "Dragon Slayer";
            Hue = 741;
            Attributes.WeaponDamage = 50;
            Attributes.WeaponSpeed = 20;
            WeaponAttributes.HitLightning = 50;
            Attributes.BonusHits = 30;
            Slayer = SlayerName.DragonSlaying;
			ItemID = 0x13B9;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
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
        public NordicVikingSword( Serial serial )
            : base( serial )
        {
        }
        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int)0 );
        }
        private void Cleanup( object state ){ Item item = new Artifact_NordicVikingSword(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
            int version = reader.ReadInt();
        }
    }
}
