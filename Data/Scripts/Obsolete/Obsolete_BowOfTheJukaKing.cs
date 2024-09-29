using System;
using Server;

namespace Server.Items
{
	public class BowOfTheJukaKing : Bow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1070636; } }

		[Constructable]
		public BowOfTheJukaKing()
		{
			Hue = 0x460;
			WeaponAttributes.HitMagicArrow = 25;
			Slayer = SlayerName.ReptilianDeath;
			Attributes.AttackChance = 15;
			Attributes.WeaponDamage = 40;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public BowOfTheJukaKing( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_BowOfTheJukaKing(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
		}
	}
}