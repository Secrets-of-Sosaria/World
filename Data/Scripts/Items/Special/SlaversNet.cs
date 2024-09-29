using Server;
using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Misc;
using Server.Mobiles;

namespace Server.Items
{
	public class SlaversNet : Item
	{
		[Constructable]
		public SlaversNet() : this( 1 )
		{
		}

		[Constructable]
		public SlaversNet( int amount ) : base( 0x3D8E )
		{
			Weight = 10.0;
			ItemID = Utility.RandomList( 0x3D8E, 0x3D8F );
			Hue = 0xB79;
			Name = "throwing net";
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1070722, "Used to capture tamable creatures" );
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
				from.SendMessage( "Which tamable creature do you want to capture?" );
				t = new SlaveTarget( this );
				from.Target = t;
			}
		}

		private class SlaveTarget : Target
		{
			private SlaversNet m_Net;

			public SlaveTarget( SlaversNet net ) : base( 6, false, TargetFlags.None )
			{
				m_Net = net;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Mobile )
				{
					Mobile o_Net = targeted as Mobile;

					if ( o_Net is BaseCreature )
					{
						BaseCreature i_Net = (BaseCreature)o_Net;
						int slots = i_Net.ControlSlots + 2;

						if ( i_Net.IsParagon )
						{
							from.SendMessage("You cannot capture a cursed creature!");
						}
						else if ( !i_Net.Tamable )
						{
							from.SendMessage("You cannot capture that!");
						}
						else if ( i_Net.Controlled )
						{
							from.SendMessage("You cannot capture a controlled creature!");
						}
						else if ( ( from.Followers + slots ) > from.FollowersMax )
						{
							from.SendMessage("You have too many followers to capture");
							from.SendMessage("that creature as it requires " + slots + " slots!");
						}
						else if ( i_Net.MinTameSkill < Utility.RandomMinMax( 50, 200 ) )
						{
							if ( Utility.RandomBool() )
							{
								from.PlaySound(0x059);
								from.SendMessage("The net has been torn to shreds!");
								m_Net.Delete();
							}
							else
							{
								from.PlaySound(0x059);
								from.SendMessage("The net failed to capture the creature!");
							}
						}
						else if ( i_Net.Tamable )
						{
							from.PlaySound(0x059);
							i_Net.ControlSlots = slots;
							if ( i_Net.MinTameSkill > 29.0 ){ i_Net.MinTameSkill = 29.1; }
							i_Net.SetControlMaster( from );
							i_Net.ControlTarget = from;
							i_Net.IsBonded = true;
							i_Net.ControlOrder = OrderType.Follow;
							from.SendMessage("You have captured the creature!");
							m_Net.Delete();
						}
						else
						{
							from.SendMessage("You cannot capture that!");
						}
					}
					else
					{
						from.SendMessage("You cannot capture that!");
					}
				}
				else
				{
					from.SendMessage("You cannot capture that!");
				}
			}
		}

		public SlaversNet( Serial serial ) : base( serial )
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