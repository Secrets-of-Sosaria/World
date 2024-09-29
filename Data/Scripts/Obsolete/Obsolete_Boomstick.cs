using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class Boomstick : WildStaff
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1075032; } } // Boomstick

		[Constructable]
		public Boomstick() : base()
		{
			Name = "Boomstick";
			Hue = 0x25;
			
			Attributes.SpellChanneling = 1;
			Attributes.RegenMana = 3;
			Attributes.CastSpeed = 1;
			Attributes.LowerRegCost = 20;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			chaos = fire = cold = pois = nrgy = direct = 0;
			phys = 100;
		}

		public Boomstick( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_Boomstick(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}
