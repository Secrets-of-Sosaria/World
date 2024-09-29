using Server;
using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Misc;

namespace Server.Items
{
	public class MagicalDyes : Item
	{
		[Constructable]
		public MagicalDyes() : this( 1 )
		{
		}

		[Constructable]
		public MagicalDyes( int amount ) : base( 0xF7D )
		{
			Name = "magical dye";
			Weight = 0.01;
			Stackable = true;
			Amount = amount;
			Hue = Utility.RandomList( 0x436, 0x445, 0x435, 0x433, 0x43A, 0x424, 0x44C, 0x44B, 0x43F, 0x440, 0x449, 0x432, 0x43E, 0x44D, 0x437, 0x807, 0x809, 0x803, 0x806, 0x808, 0x804, 0x805, 0xB80, 0x436, 0x435, 0x424, 0x449, 0x99D, 2859, 2860, 2937, 2817, 2882, 1194, 2815, 2858, 2867, 0xB54, 0xB57, 0xB51, 0xAFE, 1072, 0x9ED, 0x696, 0x69C, 0x69E, 0x69D, 0x69F, 0x699, 0x69A, 0x698, 0x69B, 0x697, 0x695, 0x509, 0x50A, 0x50B, 0x50E, 0x508, 0x50F, 0x510, 0x512, 0x50D, 0x513, 0x514, 0x511, 0x507, 0x50C, 0x8BC, 0x911, 0xAFE, 0xB3B, 0x9A3, 0x981, 0xB0C, 0x8E4, 0x7B1, 0x8D7, 0x870, 0x8D5, 0x950, 0x4A2, 0x8E2, 0xB0C, 0xB3B, 0xB5E, 0x869, 0x982, 0x5CE, 0x56A, 0x7CB, 0x7CA, 0x856, 0x99D, 0xB1E, 0x960, 0xB80, 0xB79, 0xB4C, 0xBB4, 0xB7A, 0xB17, 0x98D, 0xB4A, 0x424, 0x44C, 0x806, 0x5B2, 0x961, 0x807, 0x83F, 0x436, 0x43F, 0x69A, 0x809, 0x803, 0x808, 0x804, 0x648, 0x437, 0x483, 0x484, 0x485, 0x486, 0x487, 0x488, 0x48A, 0x48B, 0x48C, 0x493, 0x494, 0x495, 0x497, 0x498, 0x2EF, 0x47E, 0x47F, 0x480, 0x481, 0x482, 0x4AB, 0xB83, 0xB93, 0xB94, 0xB95, 0xB96, 0x48F, 0x490, 0x491, 0x48D, 0x48E, 0xB54, 0x4AA, 0x4AC, 0x489, 0x496, 0x492, 0x7E3, 0x1, 0x81C, 0x81B, 0xB97, 0x6F3, 0xB85, 0x5B5, 0x9C2, 0x9C3 );
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1070722, "Change An Item Color" );
		}

		public override void OnDoubleClick( Mobile from )
		{
			Target t;

			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1060640 ); // The item must be in your backpack to use it.
			}
			else
			{
				from.SendMessage( "What do you want to use this on?" );
				t = new DyeTarget( this );
				from.Target = t;
			}
		}

		private class DyeTarget : Target
		{
			private MagicalDyes m_Dye;

			public DyeTarget( MagicalDyes tube ) : base( 1, false, TargetFlags.None )
			{
				m_Dye = tube;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Item )
				{
					Item iDye = targeted as Item;

					bool backpack = false;
					if ( iDye is Backpack && from.FindItemOnLayer( Layer.Backpack ) == iDye )
						backpack = true;

					if ( !iDye.IsChildOf( from.Backpack ) && !backpack )
					{
						from.SendMessage( "You can only dye things in your pack." );
					}
					else if ( ( iDye.Stackable == true ) || ( iDye.ItemID == 8702 ) || ( iDye.ItemID == 4011 ) )
					{
						from.SendMessage( "You cannot dye that." );
					}
					else if ( iDye.IsChildOf( from.Backpack ) || backpack )
					{
						iDye.Hue = m_Dye.Hue;
							if ( iDye.Hue == 0x2EF ){ iDye.Hue = 0; }
						from.RevealingAction();
						from.PlaySound( 0x23E );
						from.AddToBackpack( new Bottle() );
						m_Dye.Consume();
					}
					else
					{
						from.SendMessage( "You cannot dye that with this." );
					}
				}
				else
				{
					from.SendMessage( "You cannot dye that with this." );
				}
			}
		}

		public MagicalDyes( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}