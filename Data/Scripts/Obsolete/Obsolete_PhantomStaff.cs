using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class PhantomStaff : WildStaff
	{
		public override int LabelNumber{ get{ return 1072919; } } // Phantom Staff

		[Constructable]
		public PhantomStaff()
		{
			Hue = 0x1;
			Name = "Phantom Staff";
			Attributes.RegenHits = 2;
			Attributes.NightSight = 1;
			Attributes.WeaponSpeed = 20;
			Attributes.WeaponDamage = 60;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = nrgy = chaos = direct = 0;
			cold = pois = 50;
		}

		public PhantomStaff( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_PhantomStaff(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}