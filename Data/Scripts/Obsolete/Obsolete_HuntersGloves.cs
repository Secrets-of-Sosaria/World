using System;
using Server;

namespace Server.Items
{
	public class HuntersGloves : LeatherGloves
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1061595; } } // Hunter's Gloves

		public override int BaseColdResistance{ get{ return 15; } }

		[Constructable]
		public HuntersGloves()
		{
			Name = "Hunter's Gloves";
			Hue = 0x594;
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 5 );
			Attributes.BonusDex = 4;
			Attributes.NightSight = 1;
			Attributes.AttackChance = 10;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public HuntersGloves( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_HuntersGloves(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

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