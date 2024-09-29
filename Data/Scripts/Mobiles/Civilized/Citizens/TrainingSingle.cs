using System;
using Server;
using Server.ContextMenus;
using System.Collections;
using System.Collections.Generic;
using Server.Network;
using System.Text;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	public class TrainingSingle : Citizens
	{
		[Constructable]
		public TrainingSingle()
		{
			Blessed = true;
			CantWalk = true;
			AI = AIType.AI_Melee;
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
		}

		public override void OnThink()
		{
			if ( DateTime.Now >= m_NextTalk )
			{
				foreach ( Item dummy in this.GetItemsInRange( 1 ) )
				{
					if ( dummy is TrainingDummy || dummy is TrainingDaemon )
					{
						dummy.OnDoubleClick( this );

						if ( dummy is TrainingDummy )
						{
							if ( dummy.X == X ){ dummy.ItemID = 0x1070; } else { dummy.ItemID = 0x1074; }
						}
						else
						{
							if ( dummy.X == X ){ dummy.ItemID = 0x56B1; } else { dummy.ItemID = 0x56AB; }
						}

						m_NextTalk = (DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 2, 5 ) ));
					}
				}
			}
		}

		public TrainingSingle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}