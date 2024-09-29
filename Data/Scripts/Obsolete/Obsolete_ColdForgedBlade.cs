using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class ColdForgedBlade : ElvenSpellblade
	{
		public override int LabelNumber{ get{ return 1072916; } } // Cold Forged Blade

		[Constructable]
		public ColdForgedBlade()
		{
			Name = "Cold Forged Blade";

			WeaponAttributes.HitHarm = 40;
			Attributes.SpellChanneling = 1;
			Attributes.NightSight = 1;
			Attributes.WeaponSpeed = 25;
			Attributes.WeaponDamage = 50;

			Hue = this.GetElementalDamageHue();
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = pois = nrgy = chaos = direct = 0;
			cold = 100;
		}

		public ColdForgedBlade( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_ColdForgedBlade(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}