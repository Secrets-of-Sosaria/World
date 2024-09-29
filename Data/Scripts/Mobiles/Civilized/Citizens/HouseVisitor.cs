using System;
using Server;
using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{
	public class HouseVisitor : Citizens
	{
		public override bool NoHouseRestrictions{ get{ return true; } }

		private DateTime m_NextChat;
		public DateTime NextChat{ get{ return m_NextChat; } set{ m_NextChat = value; } }

		[Constructable]
		public HouseVisitor() : base()
		{
			Direction = Direction.East;
			Blessed = true;
			NameHue = 1150;
			CantWalk = true;
			AI = AIType.AI_Melee;
		}

		public HouseVisitor( Serial serial ) : base( serial )
		{
		}

		public override void OnAfterSpawn()
		{
			base.OnAfterSpawn();
			Server.Misc.TavernPatrons.RemoveSomeGear( this, true );
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

		public override void OnThink()
		{
			if ( DateTime.Now >= m_NextChat && ( Server.Items.TavernTable.isShantyVisitor( this ) || Server.Items.TavernTable.isLawnVisitor( this ) || Server.Items.TavernTable.CountPatrons( this ) > 1 ) )
			{
				m_NextChat = (DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 15, 45 ) ));

				if ( this.Body == 9 || this.Body == 320 )
				{
					switch ( Utility.Random( 2 ) )
					{
						case 0: Animate( 17, 5, 1, true, false, 1 ); break;
						case 1: Animate( 18, 5, 1, true, false, 1 ); break;
					}

					switch ( Utility.Random( 4 ) )
					{
						case 0: this.Direction = Direction.East; break;
						case 1: this.Direction = Direction.South; break;
						case 2: this.Direction = Direction.West; break;
						case 3: this.Direction = Direction.North; break;
					}

					PlaySound( GetIdleSound() );
				}
				else
				{
					if ( Utility.RandomBool() ){ TavernPatrons.GetChatter( this ); }
				}
			}
		}
	}
}