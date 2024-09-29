using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class KamiNarisIndestructableDoubleAxe : DoubleAxe
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public KamiNarisIndestructableDoubleAxe()
		{
          Name = "Kami-Naris Indestructable Axe";
          Hue = 1161;
		  WeaponAttributes.DurabilityBonus = 100;
		  WeaponAttributes.HitFireArea = 25;
		  WeaponAttributes.HitHarm = 100;
		  WeaponAttributes.HitLeechHits = 15;
		  WeaponAttributes.HitLeechStam = 15;
		  WeaponAttributes.HitLightning = 15;
		  WeaponAttributes.SelfRepair = 5;
		  Attributes.WeaponDamage = 50;
		  Attributes.WeaponSpeed = 20;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public KamiNarisIndestructableDoubleAxe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_KamiNarisIndestructableDoubleAxe(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}
