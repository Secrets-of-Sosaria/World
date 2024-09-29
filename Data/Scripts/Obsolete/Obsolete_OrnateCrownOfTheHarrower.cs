using System;
using Server;

namespace Server.Items
{
	public class OrnateCrownOfTheHarrower : BoneHelm
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1061095; } } // Ornate Crown of the Harrower

		public override int BasePoisonResistance{ get{ return 17; } }

		[Constructable]
		public OrnateCrownOfTheHarrower()
		{
			Hue = 0x4F6;
			Attributes.RegenHits = 2;
			Attributes.RegenStam = 3;
			Attributes.WeaponDamage = 25;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public OrnateCrownOfTheHarrower( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_OrnateCrownOfTheHarrower(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if ( version < 1 )
			{
				if ( Hue == 0x55A )
					Hue = 0x4F6;

				PoisonBonus = 0;
			}
		}
	}
}