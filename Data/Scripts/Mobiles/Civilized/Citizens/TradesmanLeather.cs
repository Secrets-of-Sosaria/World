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
	public class TradesmanLeather : Citizens
	{
		[Constructable]
		public TradesmanLeather()
		{
			CitizenType = 6;
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
				foreach ( Item skin in this.GetItemsInRange( 1 ) )
				{
					if ( skin is LeatherHit )
					{
						if ( this.FindItemOnLayer( Layer.FirstValid ) != null ) { this.Delete(); }
						else if ( this.FindItemOnLayer( Layer.TwoHanded ) != null ) { this.Delete(); }
						else if ( this.FindItemOnLayer( Layer.OneHanded ) != null ) { this.Delete(); }
						LeatherHit hide = (LeatherHit)skin;
						hide.OnDoubleClick( this );
						m_NextTalk = (DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 6, 12 ) ));
					}
				}
			}
		}

		public override void OnAfterSpawn()
		{
			base.OnAfterSpawn();
			Server.Misc.TavernPatrons.RemoveSomeGear( this, false );
			Server.Misc.MorphingTime.CheckNecromancer( this );
		}

		public TradesmanLeather( Serial serial ) : base( serial )
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
	[FlipableAttribute( 0x1069, 0x107A )]
	public class LeatherHit : Item
	{
		[Constructable]
		public LeatherHit() : base( 0x13 )
		{
			Name = "stretched hide";
			Movable = false;
			Weight = -2.0;
		}

		public LeatherHit( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from is Citizens )
			{
				from.Direction = from.GetDirectionTo( GetWorldLocation() );
				from.Animate( 230, 5, 1, true, false, 0 ); 
				if ( this.X == from.X && ( this.ItemID == 0x1069 || this.ItemID == 0x106A ) )
				{
					this.ItemID = 0x107A;
				}
				else if ( this.Y == from.Y && ( this.ItemID == 0x107A || this.ItemID == 0x107B ) )
				{
					this.ItemID = 0x1069;
				}
				if ( ItemID == 0x1069 || ItemID == 0x106A ){ ItemID = Utility.RandomList( 0x1069, 0x106A ); }
				else { ItemID = Utility.RandomList( 0x107A, 0x107B ); }
				from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
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
	public class CrateOfLeather : Item
	{
		[Constructable]
		public CrateOfLeather() : base( 0x5093 )
		{
			Name = "crate of leather";
			Weight = 10;
			Limits = Utility.RandomMinMax( 4, 12 ) * 100;
			Fill();
		}

		public void Fill()
		{
			ItemID = 0x5093;

			if ( Resource == CraftResource.None )
				ResourceMods.SetRandomResource( false, true, this, CraftResource.RegularLeather, false, null );

			Name = "crate of " + CraftResources.GetName(Resource) + " leather";
			Hue = CraftResources.GetHue(Resource);

			if ( Resource == CraftResource.RegularLeather )
				ItemID = 0x5092;
		}

		public CrateOfLeather( Serial serial ) : base( serial )
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

				if ( Resource == CraftResource.SpinedLeather ){ from.AddToBackpack ( new SpinedLeather( Limits ) ); }
				else if ( Resource == CraftResource.HornedLeather ){ from.AddToBackpack ( new HornedLeather( Limits ) ); }
				else if ( Resource == CraftResource.BarbedLeather ){ from.AddToBackpack ( new BarbedLeather( Limits ) ); }
				else if ( Resource == CraftResource.NecroticLeather ){ from.AddToBackpack ( new NecroticLeather( Limits ) ); }
				else if ( Resource == CraftResource.VolcanicLeather ){ from.AddToBackpack ( new VolcanicLeather( Limits ) ); }
				else if ( Resource == CraftResource.FrozenLeather ){ from.AddToBackpack ( new FrozenLeather( Limits ) ); }
				else if ( Resource == CraftResource.GoliathLeather ){ from.AddToBackpack ( new GoliathLeather( Limits ) ); }
				else if ( Resource == CraftResource.DraconicLeather ){ from.AddToBackpack ( new DraconicLeather( Limits ) ); }
				else if ( Resource == CraftResource.HellishLeather ){ from.AddToBackpack ( new HellishLeather( Limits ) ); }
				else if ( Resource == CraftResource.DinosaurLeather ){ from.AddToBackpack ( new DinosaurLeather( Limits ) ); }
				else if ( Resource == CraftResource.AlienLeather ){ from.AddToBackpack ( new AlienLeather( Limits ) ); }
				else { from.AddToBackpack ( new Leather( Limits ) ); }

				from.PrivateOverheadMessage(MessageType.Regular, 0x14C, false, "You separate the leather into your backpack", from.NetState);
				this.Delete();
			}
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);

			list.Add( 1070722, "Contains " + Limits + " " + CraftResources.GetName(Resource) + " Leather");
			list.Add( 1049644, "Open to Remove them from the Crate");
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( version < 1 )
			{
				Limits = reader.ReadInt();
				string CrateItem = reader.ReadString();
				Fill();
			}
		}
	}
}