using System;
using Server.Items;

namespace Server.Items
{
	public class SongWovenMantle : LeatherArms
	{
		public override int LabelNumber{ get{ return 1072931; } } // Song Woven Mantle

		public override int BasePhysicalResistance{ get{ return 14; } }
		public override int BaseColdResistance{ get{ return 14; } }
		public override int BaseEnergyResistance{ get{ return 16; } }

		[Constructable]
		public SongWovenMantle()
		{
			Hue = 0x493;

			SkillBonuses.SetValues( 0, SkillName.Musicianship, 10.0 );

			Attributes.Luck = 100;
			Attributes.DefendChance = 5;
		}

		public SongWovenMantle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 );
		}

		private void Cleanup( object state ){ Item item = new Artifact_SongWovenMantle(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}