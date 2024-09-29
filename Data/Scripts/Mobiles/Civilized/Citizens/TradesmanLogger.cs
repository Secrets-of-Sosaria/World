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
	public class TradesmanLogger : Citizens
	{
		[Constructable]
		public TradesmanLogger()
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
				foreach ( Item tree in this.GetItemsInRange( 1 ) )
				{
					if ( tree is TreeHit )
					{
						if ( this.FindItemOnLayer( Layer.FirstValid ) != null && !(this.FindItemOnLayer( Layer.FirstValid ) is Hatchet) ) { this.Delete(); }
						else if ( this.FindItemOnLayer( Layer.OneHanded ) != null && !(this.FindItemOnLayer( Layer.OneHanded ) is Hatchet) ) { this.Delete(); }
						else if ( this.FindItemOnLayer( Layer.TwoHanded ) != null && !(this.FindItemOnLayer( Layer.TwoHanded ) is Hatchet) ) { this.Delete(); }
						TreeHit log = (TreeHit)tree;
						log.OnDoubleClick( this );
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
			Item axe = new Hatchet();
			axe.Name = "axe";
			axe.ItemID = Utility.RandomList( 0xF45, 0xF47, 0xF49, 0xF4B, 0x13FA, 0x1442 );
			axe.Movable = false;
			AddItem( axe );
		}

		public TradesmanLogger( Serial serial ) : base( serial )
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
	public class TreeHit : Item
	{
		[Constructable]
		public TreeHit() : base( 0x13 )
		{
			Name = "tree";
			Visible = false;
			Movable = false;
			Weight = -2.0;
		}

		public TreeHit( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.FindItemOnLayer( Layer.TwoHanded ) != null && from.FindItemOnLayer( Layer.TwoHanded ) is BaseWeapon && from is Citizens )
			{
				BaseWeapon weapon = ( BaseWeapon )( from.FindItemOnLayer( Layer.TwoHanded ) );
				from.Direction = from.GetDirectionTo( GetWorldLocation() );
				weapon.PlaySwingAnimation( from );
				from.PlaySound( 0x13E );
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
	public class CrateOfWood : Item
	{
		[Constructable]
		public CrateOfWood() : base( 0x5085 )
		{
			Name = "crate of boards";
			Weight = 10;
			Limits = Utility.RandomMinMax( 4, 12 ) * 100;
			Fill();
		}

		public void Fill()
		{
			ItemID = 0x5085;

			if ( Resource == CraftResource.None )
				ResourceMods.SetRandomResource( false, true, this, CraftResource.RegularWood, false, null );

			Name = "crate of " + CraftResources.GetName(Resource) + " boards";
			Hue = CraftResources.GetHue(Resource);

			if ( Resource == CraftResource.RegularWood )
				ItemID = 0x5088;
		}

		public CrateOfWood( Serial serial ) : base( serial )
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

				if ( Resource == CraftResource.AshTree ){ from.AddToBackpack ( new AshBoard( Limits ) ); }
				else if ( Resource == CraftResource.CherryTree ){ from.AddToBackpack ( new CherryBoard( Limits ) ); }
				else if ( Resource == CraftResource.EbonyTree ){ from.AddToBackpack ( new EbonyBoard( Limits ) ); }
				else if ( Resource == CraftResource.GoldenOakTree ){ from.AddToBackpack ( new GoldenOakBoard( Limits ) ); }
				else if ( Resource == CraftResource.HickoryTree ){ from.AddToBackpack ( new HickoryBoard( Limits ) ); }
				else if ( Resource == CraftResource.MahoganyTree ){ from.AddToBackpack ( new MahoganyBoard( Limits ) ); }
				else if ( Resource == CraftResource.OakTree ){ from.AddToBackpack ( new OakBoard( Limits ) ); }
				else if ( Resource == CraftResource.PineTree ){ from.AddToBackpack ( new PineBoard( Limits ) ); }
				else if ( Resource == CraftResource.GhostTree ){ from.AddToBackpack ( new GhostBoard( Limits ) ); }
				else if ( Resource == CraftResource.RosewoodTree ){ from.AddToBackpack ( new RosewoodBoard( Limits ) ); }
				else if ( Resource == CraftResource.WalnutTree ){ from.AddToBackpack ( new WalnutBoard( Limits ) ); }
				else if ( Resource == CraftResource.PetrifiedTree ){ from.AddToBackpack ( new PetrifiedBoard( Limits ) ); }
				else if ( Resource == CraftResource.DriftwoodTree ){ from.AddToBackpack ( new DriftwoodBoard( Limits ) ); }
				else if ( Resource == CraftResource.ElvenTree ){ from.AddToBackpack ( new ElvenBoard( Limits ) ); }
				else { from.AddToBackpack ( new Board( Limits ) ); }

				from.PrivateOverheadMessage(MessageType.Regular, 0x14C, false, "You separate the boards into your backpack", from.NetState);
				this.Delete();
			}
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);

			list.Add( 1070722, "Contains " + Limits + " " + CraftResources.GetName(Resource) + " Boards");
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
	public class CrateOfLogs : Item
	{
		[Constructable]
		public CrateOfLogs() : base( 0x5096 )
		{
			Name = "crate of logs";
			Weight = 10;
			Limits = Utility.RandomMinMax( 4, 12 ) * 100;
			Fill();
		}

		public void Fill()
		{
			ItemID = 0x5096;

			if ( Resource == CraftResource.None )
				ResourceMods.SetRandomResource( false, true, this, CraftResource.RegularWood, false, null );

			Name = "crate of " + CraftResources.GetName(Resource) + " logs";
			Hue = CraftResources.GetHue(Resource);

			if ( Resource == CraftResource.RegularWood )
				ItemID = 0x5097;
		}

		public CrateOfLogs( Serial serial ) : base( serial )
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

				if ( Resource == CraftResource.AshTree ){ from.AddToBackpack ( new AshLog( Limits ) ); }
				else if ( Resource == CraftResource.CherryTree ){ from.AddToBackpack ( new CherryLog( Limits ) ); }
				else if ( Resource == CraftResource.EbonyTree ){ from.AddToBackpack ( new EbonyLog( Limits ) ); }
				else if ( Resource == CraftResource.GoldenOakTree ){ from.AddToBackpack ( new GoldenOakLog( Limits ) ); }
				else if ( Resource == CraftResource.HickoryTree ){ from.AddToBackpack ( new HickoryLog( Limits ) ); }
				else if ( Resource == CraftResource.MahoganyTree ){ from.AddToBackpack ( new MahoganyLog( Limits ) ); }
				else if ( Resource == CraftResource.OakTree ){ from.AddToBackpack ( new OakLog( Limits ) ); }
				else if ( Resource == CraftResource.PineTree ){ from.AddToBackpack ( new PineLog( Limits ) ); }
				else if ( Resource == CraftResource.GhostTree ){ from.AddToBackpack ( new GhostLog( Limits ) ); }
				else if ( Resource == CraftResource.RosewoodTree ){ from.AddToBackpack ( new RosewoodLog( Limits ) ); }
				else if ( Resource == CraftResource.WalnutTree ){ from.AddToBackpack ( new WalnutLog( Limits ) ); }
				else if ( Resource == CraftResource.PetrifiedTree ){ from.AddToBackpack ( new PetrifiedLog( Limits ) ); }
				else if ( Resource == CraftResource.DriftwoodTree ){ from.AddToBackpack ( new DriftwoodLog( Limits ) ); }
				else if ( Resource == CraftResource.ElvenTree ){ from.AddToBackpack ( new ElvenLog( Limits ) ); }
				else { from.AddToBackpack ( new Log( Limits ) ); }

				from.PrivateOverheadMessage(MessageType.Regular, 0x14C, false, "You separate the logs into your backpack", from.NetState);
				this.Delete();
			}
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);

			list.Add( 1070722, "Contains " + Limits + " " + CraftResources.GetName(Resource) + " Logs");
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