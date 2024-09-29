using System;
using Server;

namespace Server.Items
{
	public class LegacyOfTheDreadLord : Bardiche
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1060860; } } // Legacy of the Dread Lord

		[Constructable]
		public LegacyOfTheDreadLord()
		{
			Hue = 0x676;
			Attributes.SpellChanneling = 1;
			Attributes.CastRecovery = 3;
			Attributes.WeaponSpeed = 30;
			Attributes.WeaponDamage = 50;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public LegacyOfTheDreadLord( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_LegacyOfTheDreadLord(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if ( Attributes.CastSpeed == 3 )
				Attributes.CastRecovery = 3;

			if ( Hue == 0x4B9 )
				Hue = 0x676;
		}
	}
}