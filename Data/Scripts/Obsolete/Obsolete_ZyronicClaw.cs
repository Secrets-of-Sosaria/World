using System;
using Server;

namespace Server.Items
{
	public class ZyronicClaw : ExecutionersAxe
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1061593; } } // Zyronic Claw

		[Constructable]
		public ZyronicClaw()
		{
			Hue = 0x485;
			Slayer = SlayerName.ElementalBan;
			WeaponAttributes.HitLeechMana = 50;
			Attributes.AttackChance = 30;
			Attributes.WeaponDamage = 50;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			chaos = direct = 0;
			phys = fire = cold = pois = nrgy = 20;
		}

		public ZyronicClaw( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_ZyronicClaw(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if ( Slayer == SlayerName.None )
				Slayer = SlayerName.ElementalBan;
		}
	}
}