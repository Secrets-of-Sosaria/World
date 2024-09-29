using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class SilvanisFeywoodBow : ElvenCompositeLongbow
	{
		public override int LabelNumber{ get{ return 1072955; } } // Silvani's Feywood Bow

		[Constructable]
		public SilvanisFeywoodBow()
		{
			Hue = 0x1A;
			Name = "Silvani's Feywood Bow";

			Attributes.SpellChanneling = 1;
			Attributes.AttackChance = 12;
			Attributes.WeaponSpeed = 30;
			Attributes.WeaponDamage = 35;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = cold = pois = chaos = direct = 0;
			nrgy = 100;
		}

		public SilvanisFeywoodBow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_SilvanisFeywoodBow(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}