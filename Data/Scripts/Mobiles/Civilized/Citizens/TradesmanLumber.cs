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
	public class TradesmanLumber : Citizens
	{
		[Constructable]
		public TradesmanLumber()
		{
			CitizenType = 5;
			SetupCitizen();
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
				foreach ( Item forge in this.GetItemsInRange( 2 ) )
				{
					if ( forge is SawHit )
					{
						if ( this.FindItemOnLayer( Layer.FirstValid ) != null && !(this.FindItemOnLayer( Layer.FirstValid ) is Club) ) { this.Delete(); }
						else if ( this.FindItemOnLayer( Layer.OneHanded ) != null && !(this.FindItemOnLayer( Layer.OneHanded ) is Club) ) { this.Delete(); }
						else if ( this.FindItemOnLayer( Layer.TwoHanded ) != null && !(this.FindItemOnLayer( Layer.TwoHanded ) is Club) ) { this.Delete(); }
						SawHit smith = (SawHit)forge;
						smith.OnDoubleClick( this );
						m_NextTalk = (DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 8, 14 ) ));
					}
				}
			}
		}

		public override void OnAfterSpawn()
		{
			base.OnAfterSpawn();
			Server.Misc.TavernPatrons.RemoveSomeGear( this, false );
			Server.Misc.MorphingTime.CheckNecromancer( this );
			Item hammer = new Club();
			hammer.Name = "hammer";
			hammer.ItemID = 0x0FB4;
			hammer.Movable = false;
			AddItem( hammer );
		}

		public TradesmanLumber( Serial serial ) : base( serial )
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

namespace Server.Items
{
	public class SawHit : Item
	{
		[Constructable]
		public SawHit() : base( 0x1B72 )
		{
			Name = "saw";
			Movable = false;
			Visible = false;
			Weight = -2.0;
		}

		public SawHit( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from is Citizens )
			{
				from.Direction = from.GetDirectionTo( GetWorldLocation() );
				if ( Utility.RandomMinMax(1,3) == 1 )
				{
					from.Animate( 230, 5, 1, true, false, 0 );   
					from.PlaySound( 0x21C );
				}
				else if ( from.FindItemOnLayer( Layer.OneHanded ) != null && from.FindItemOnLayer( Layer.OneHanded ) is BaseWeapon )
				{
					BaseWeapon weapon = ( BaseWeapon )( from.FindItemOnLayer( Layer.OneHanded ) );
					weapon.PlaySwingAnimation( from );
					from.PlaySound( 0x23D );
				}
			}
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
			Weight = -2.0;
		}
	}
}