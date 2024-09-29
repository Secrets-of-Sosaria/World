using System;
using Server;

namespace Server.Items
{
	public class BladeOfInsanity : Katana
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1061088; } } // Blade of Insanity

		[Constructable]
		public BladeOfInsanity()
		{
			Hue = 0x76D;
			WeaponAttributes.HitLeechStam = 100;
			Attributes.RegenStam = 2;
			Attributes.WeaponSpeed = 30;
			Attributes.WeaponDamage = 50;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public BladeOfInsanity( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_BladeOfInsanity(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if ( Hue == 0x44F )
				Hue = 0x76D;
		}
	}
}