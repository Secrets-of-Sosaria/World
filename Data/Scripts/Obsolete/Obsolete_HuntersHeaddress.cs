using System;
using Server;

namespace Server.Items
{
	public class HuntersHeaddress : DeerMask
	{
		public override int LabelNumber{ get{ return 1061595; } } // Hunter's Headdress

		public override int BaseColdResistance{ get{ return 23; } }

		[Constructable]
		public HuntersHeaddress()
		{
			Hue = 0x594;

			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 20 );

			Attributes.BonusDex = 8;
			Attributes.NightSight = 1;
			Attributes.AttackChance = 15;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public HuntersHeaddress( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_HuntersHeaddress(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();
			switch ( version )
			{
				case 0:
				{
					Resistances.Cold = 0;
					break;
				}
			}
		}
	}
}