using System;
using Server;

namespace Server.Items
{
	public class ArcticDeathDealer : WarMace
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1063481; } }

		[Constructable]
		public ArcticDeathDealer()
		{
			Hue = 0x480;
			WeaponAttributes.HitHarm = 33;
			WeaponAttributes.HitLowerAttack = 40;
			Attributes.WeaponSpeed = 20;
			Attributes.WeaponDamage = 40;
			WeaponAttributes.ResistColdBonus = 10;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			cold = 50;
			phys = 50;

			pois = fire = nrgy = chaos = direct = 0;
		}

		public ArcticDeathDealer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_ArcticDeathDealer(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}