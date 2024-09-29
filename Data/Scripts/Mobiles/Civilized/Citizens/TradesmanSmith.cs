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
	public class TradesmanSmith : Citizens
	{
		[Constructable]
		public TradesmanSmith()
		{
			CitizenType = 4;
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
				foreach ( Item anvil in this.GetItemsInRange( 1 ) )
				{
					if ( anvil is AnvilHit )
					{
						if ( this.FindItemOnLayer( Layer.FirstValid ) != null && !(this.FindItemOnLayer( Layer.FirstValid ) is Club) ) { this.Delete(); }
						else if ( this.FindItemOnLayer( Layer.OneHanded ) != null && !(this.FindItemOnLayer( Layer.OneHanded ) is Club) ) { this.Delete(); }
						else if ( this.FindItemOnLayer( Layer.TwoHanded ) != null && !(this.FindItemOnLayer( Layer.TwoHanded ) is Club) ) { this.Delete(); }
						AnvilHit smith = (AnvilHit)anvil;
						smith.OnDoubleClick( this );
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
			Item hammer = new Club();
			hammer.Name = "hammer";
			hammer.ItemID = 0x0FB4;
			hammer.Movable = false;
			AddItem( hammer );
		}

		public TradesmanSmith( Serial serial ) : base( serial )
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
	[FlipableAttribute( 0xFAF, 0xFB0 )]
	public class AnvilHit : Item
	{
		[Constructable]
		public AnvilHit() : base( 0xFAF )
		{
			Name = "anvil";
			Movable = false;
			Weight = -2.0;
		}

		public int AnvilID( int o, int i )
		{
			if ( o == i && ItemID == 0x64F7 )
				return Utility.RandomMinMax( 25837, 25858 );

			else if ( o == i )
				return 0x64F7;

			else if ( o != i && ItemID == 0x650D )
				return Utility.RandomMinMax( 25859, 25880 );

			return 0x650D;
		}

		public AnvilHit( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.FindItemOnLayer( Layer.OneHanded ) != null && from.FindItemOnLayer( Layer.OneHanded ) is BaseWeapon && from is Citizens )
			{
				BaseWeapon weapon = ( BaseWeapon )( from.FindItemOnLayer( Layer.OneHanded ) );
				from.Direction = from.GetDirectionTo( GetWorldLocation() );
				this.ItemID = AnvilID( this.X, from.X );
				weapon.PlaySwingAnimation( from );
				from.PlaySound( Utility.RandomList( 0x541, 0x2A, 0x2A, 0x2A ) );
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
	public class CrateOfMetal : Item
	{
		[Constructable]
		public CrateOfMetal() : base( 0x5095 )
		{
			Name = "crate of ingots";
			Weight = 10;
			Limits = Utility.RandomMinMax( 4, 12 ) * 100;
			Fill();
		}

		public void Fill()
		{
			ItemID = 0x5095;

			if ( Resource == CraftResource.None )
				ResourceMods.SetRandomResource( false, true, this, CraftResource.Iron, false, null );

			Name = "crate of " + CraftResources.GetName(Resource) + " ingots";
			Hue = CraftResources.GetHue(Resource);

			if ( Resource == CraftResource.Iron )
				ItemID = 0x5094;
		}

		public CrateOfMetal( Serial serial ) : base( serial )
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

				if ( Resource == CraftResource.DullCopper ){ from.AddToBackpack ( new DullCopperIngot( Limits ) ); }
				else if ( Resource == CraftResource.ShadowIron ){ from.AddToBackpack ( new ShadowIronIngot( Limits ) ); }
				else if ( Resource == CraftResource.Copper ){ from.AddToBackpack ( new CopperIngot( Limits ) ); }
				else if ( Resource == CraftResource.Bronze ){ from.AddToBackpack ( new BronzeIngot( Limits ) ); }
				else if ( Resource == CraftResource.Gold ){ from.AddToBackpack ( new GoldIngot( Limits ) ); }
				else if ( Resource == CraftResource.Agapite ){ from.AddToBackpack ( new AgapiteIngot( Limits ) ); }
				else if ( Resource == CraftResource.Verite ){ from.AddToBackpack ( new VeriteIngot( Limits ) ); }
				else if ( Resource == CraftResource.Valorite ){ from.AddToBackpack ( new ValoriteIngot( Limits ) ); }
				else if ( Resource == CraftResource.Nepturite ){ from.AddToBackpack ( new NepturiteIngot( Limits ) ); }
				else if ( Resource == CraftResource.Obsidian ){ from.AddToBackpack ( new ObsidianIngot( Limits ) ); }
				else if ( Resource == CraftResource.Steel ){ from.AddToBackpack ( new SteelIngot( Limits ) ); }
				else if ( Resource == CraftResource.Brass ){ from.AddToBackpack ( new BrassIngot( Limits ) ); }
				else if ( Resource == CraftResource.Mithril ){ from.AddToBackpack ( new MithrilIngot( Limits ) ); }
				else if ( Resource == CraftResource.Xormite ){ from.AddToBackpack ( new XormiteIngot( Limits ) ); }
				else if ( Resource == CraftResource.Dwarven ){ from.AddToBackpack ( new DwarvenIngot( Limits ) ); }
				else { from.AddToBackpack ( new IronIngot( Limits ) ); }

				from.PrivateOverheadMessage(MessageType.Regular, 0x14C, false, "You separate the ingots into your backpack", from.NetState);
				this.Delete();
			}
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);

			list.Add( 1070722, "Contains " + Limits + " " + CraftResources.GetName(Resource) + " Ingots");
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