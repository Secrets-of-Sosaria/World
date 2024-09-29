using System;
using Server;

namespace Server.Items
{
	public class HuntersGorget : LeatherGorget
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1061595; } } // Hunter's Gorget

		public override int BaseColdResistance{ get{ return 20; } }

		[Constructable]
		public HuntersGorget()
		{
			Name = "Hunter's Gorget";
			Hue = 0x594;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 5 );
			Attributes.BonusDex = 6;
			Attributes.NightSight = 1;
			Attributes.AttackChance = 10;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public HuntersGorget( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_HuntersGorget(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
			switch ( version )
			{
				case 0:
				{
					ColdBonus = 0;
					break;
				}
			}
		}
	}
}