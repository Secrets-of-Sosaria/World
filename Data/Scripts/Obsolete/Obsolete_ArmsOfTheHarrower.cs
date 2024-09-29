using System;
using Server;

namespace Server.Items
{
	public class ArmsOfTheHarrower : BoneArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1061095; } } // Arms of the Harrower

		public override int BasePoisonResistance{ get{ return 15; } }

		[Constructable]
		public ArmsOfTheHarrower()
		{
			Name = "Arms of the Harrower";
			Hue = 0x4F6;
			Attributes.RegenHits = 3;
			Attributes.RegenStam = 2;
			Attributes.WeaponDamage = 15;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public ArmsOfTheHarrower( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_ArmsOfTheHarrower(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

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