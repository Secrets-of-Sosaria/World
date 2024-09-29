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
	public class TradesmanButcher : Citizens
	{
		[Constructable]
		public TradesmanButcher()
		{
			CitizenType = 11;
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
				foreach ( Item carcass in this.GetItemsInRange( 1 ) )
				{
					if ( carcass is ButcherHit )
					{
						if ( this.FindItemOnLayer( Layer.FirstValid ) != null && !(this.FindItemOnLayer( Layer.FirstValid ) is Cleaver) ) { this.Delete(); }
						else if ( this.FindItemOnLayer( Layer.OneHanded ) != null && !(this.FindItemOnLayer( Layer.OneHanded ) is Cleaver) ) { this.Delete(); }
						else if ( this.FindItemOnLayer( Layer.TwoHanded ) != null ){ this.FindItemOnLayer( Layer.TwoHanded ).Delete(); }
						ButcherHit carcas = (ButcherHit)carcass;
						carcas.OnDoubleClick( this );
						m_NextTalk = (DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 2, 5 ) ));
					}
				}
			}
		}

		public override void OnAfterSpawn()
		{
			base.OnAfterSpawn();
			Server.Misc.TavernPatrons.RemoveSomeGear( this, false );
			Server.Misc.MorphingTime.CheckNecromancer( this );
			Item cleaver = new Cleaver();
			cleaver.Name = "cleaver";
			cleaver.Movable = false;
			AddItem( cleaver );
		}

		public TradesmanButcher( Serial serial ) : base( serial )
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
	public class ButcherHit : Item
	{
		[Constructable]
		public ButcherHit() : base( 0x13 )
		{
			Name = "carcass";
			Movable = false;
			Weight = -2.0;
			ItemID = Utility.RandomList (0x1E88, 0x1E89, 0x1E90, 0x1E91, 0x3D69, 0x63CC, 0x63CD, 0x63D8, 0x63D9, 0x63D0, 0x63D1, 0x63B6, 0x63B7 );
			if ( ItemID == 0x63D8 || ItemID == 0x63D9 ){ Hue = Utility.RandomList( 0x7D1, 0x7D2, 0x7D3, 0x7D4, 0x7D5, 0x7D6 ); }
		}

		public ButcherHit( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.FindItemOnLayer( Layer.OneHanded ) != null && from.FindItemOnLayer( Layer.OneHanded ) is BaseWeapon && from is Citizens )
			{
				int horse = Utility.RandomList( 0, 0, 0, 0, 0, 0x780, 0x781, 0x782, 0x783, 0x8FD, 0x8FE, 0x8FF, 0x900, 0x901, 0x902, 0x903, 0x904, 0x905, 0x906, 0x907, 0x908, Utility.RandomNeutralHue(), Utility.RandomNeutralHue(), Utility.RandomNeutralHue(), Utility.RandomNeutralHue(), Utility.RandomNeutralHue(), Utility.RandomNeutralHue() );
				if ( this.X == from.X && ( this.ItemID == 0x1E88 || this.ItemID == 0x1E90 || this.ItemID == 0x63D7 || this.ItemID == 0x63D8 || this.ItemID == 0x63D1 || this.ItemID == 0x63B7 ) )
				{
					this.Hue = 0;
					switch ( Utility.RandomMinMax( 1, 7 ) )
					{
						case 1:	this.ItemID = 0x1E89; break;
						case 2:	this.ItemID = 0x1E91; break;
						case 3:	this.ItemID = 0x3D69; break;
						case 4:	this.ItemID = 0x63D6; this.Hue = horse; break;
						case 5:	this.ItemID = 0x63D9; this.Hue = Utility.RandomList( 0x7D1, 0x7D2, 0x7D3, 0x7D4, 0x7D5, 0x7D6 ); break;
						case 6:	this.ItemID = 0x63D0; break;
						case 7:	this.ItemID = 0x63B6; break;
					}
				}
				else if ( this.Y == from.Y && ( this.ItemID == 0x1E89 || this.ItemID == 0x1E91 || this.ItemID == 0x3D69 || this.ItemID == 0x63D6 || this.ItemID == 0x63D9 || this.ItemID == 0x63D0 || this.ItemID == 0x63B6 ) )
				{
					this.Hue = 0;
					switch ( Utility.RandomMinMax( 1, 6 ) )
					{
						case 1:	this.ItemID = 0x1E88; break;
						case 2:	this.ItemID = 0x1E90; break;
						case 3:	this.ItemID = 0x63D7; this.Hue = horse; break;
						case 4:	this.ItemID = 0x63D8; this.Hue = Utility.RandomList( 0x7D1, 0x7D2, 0x7D3, 0x7D4, 0x7D5, 0x7D6 ); break;
						case 5:	this.ItemID = 0x63D1; break;
						case 6:	this.ItemID = 0x63B7; break;
					}
				}
				BaseWeapon weapon = ( BaseWeapon )( from.FindItemOnLayer( Layer.OneHanded ) );
				from.Direction = from.GetDirectionTo( GetWorldLocation() );
				weapon.PlaySwingAnimation( from );
				new Blood().MoveToWorld( Location, Map );
				from.PlaySound( 0x133 );
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

namespace Server.Items
{
	public class CrateOfMeats : Item
	{
		public int CrateQty;
		[CommandProperty(AccessLevel.Owner)]
		public int Crate_Qty { get { return CrateQty; } set { CrateQty = value; InvalidateProperties(); } }

		public string CrateItem;
		[CommandProperty(AccessLevel.Owner)]
		public string Crate_Item { get { return CrateItem; } set { CrateItem = value; InvalidateProperties(); } }

		[Constructable]
		public CrateOfMeats() : base( 0x5095 )
		{
			Name = "crate of meat";
			Weight = 10;
		}

		public CrateOfMeats( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) ) 
			{
				from.SendMessage( "This must be in your backpack to open." );
				return;
			}
			else
			{
				from.PlaySound( 0x02D );
				from.AddToBackpack ( new LargeCrate() );

				if ( ItemID == 0x508B ){ from.AddToBackpack ( new RawFishSteak( CrateQty ) ); }
				else if ( ItemID == 0x508C ){ from.AddToBackpack ( new RawLambLeg( CrateQty ) ); }
				else if ( ItemID == 0x508D ){ from.AddToBackpack ( new RawRibs( CrateQty ) ); }

				from.PrivateOverheadMessage(MessageType.Regular, 0x14C, false, "You separate the meat into your backpack", from.NetState);
				this.Delete();
			}
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);

			list.Add( 1070722, "Contains " + CrateQty + " " + CrateItem + "");
			list.Add( 1049644, "Open to Remove them from the Crate");
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
            writer.Write( CrateQty );
            writer.Write( CrateItem );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            CrateQty = reader.ReadInt();
            CrateItem = reader.ReadString();
		}
	}
}