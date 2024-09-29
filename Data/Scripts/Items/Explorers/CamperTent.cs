using System;
using Server;
using System.Collections.Generic;
using System.Collections;
using Server.Mobiles;
using Server.Items;
using Server.Regions;
using Server.Network;
using Server.Multis;
using Server.Misc;
using Server.ContextMenus;
using Server.Gumps;
using Server.Commands;

namespace Server.Items 
{
	public enum CamperTentEffect
	{
		Charges
	}

	public class CampersTent : Item
	{
		public override string DefaultDescription{ get{ return "This is a camping tent that you can use to get away from the dangers of the land and rest. You can only use these tents if you have at least a 40 in the camping skill and they eventually wear out from use. If you double click the tent while it is in your pack, you will setup the tent for yourself. No one will be able to follow you in the tent unless they have a tent and the appropriate skill. If you set the tent down and double click it, then others will be able to use the tent to rest as they can double click the tent to follow you in. The original rolled tent will be put back into your pack, while the standing tent is left behind and will only remain for about 30 seconds so your comrades should make haste and follow you in. If anyone wants to leave the tent, then simply double click the tent flap you came in by. Anyone can stay in the tent as long as they want, but they will return to the spot where they used the tent when they leave."; } }

		private CamperTentEffect m_CamperTentEffect;
		private int m_Charges;

		[CommandProperty( AccessLevel.GameMaster )]
		public CamperTentEffect Effect
		{
			get{ return m_CamperTentEffect; }
			set{ m_CamperTentEffect = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges
		{
			get{ return m_Charges; }
			set{ m_Charges = value; InvalidateProperties(); }
		}

		[Constructable]
		public CampersTent() : base( 0x0A59 )
		{
			Name = "camping tent";
			Weight = 5.0; 
			Charges = 10;
			Hue = Utility.RandomList( 0x96D, 0x96E, 0x96F, 0x970, 0x971, 0x972, 0x973, 0x974, 0x975, 0x976, 0x977, 0x978, 0x979, 0x97A, 0x97B, 0x97C, 0x97D, 0x97E );		
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Setup A Safe Tent In Which To Rest");
			list.Add( 1049644, "Usable By Those Skilled In Camping");
        }

		public override void OnDoubleClick( Mobile from )
		{
			bool inCombat = ( from.Combatant != null && from.InRange( from.Combatant.Location, 20 ) && from.Combatant.InLOS( from ) );

			int CanUseTent = 0;

			if ( from.Skills[SkillName.Camping].Value < 40 )
			{
				from.SendMessage( "You must be a novice explorer to use this tent." );
				return;
			}
			else if ( from.Region.IsPartOf( typeof( PublicRegion ) ) )
			{
				from.SendMessage( "This is a really nice camping tent." ); 
				return;
			}
			else if ( Server.Misc.Worlds.IsOnBoat( from ) )
			{
				from.SendMessage( "You cannot setup this tent near a boat." );
				return;
			}
			else if ( Server.Misc.Worlds.IsOnSpaceship( from.Location, from.Map ) )
			{
				from.SendMessage( "You don't have anywhere to setup camp in this strange place." );
				return;
			}
			else if ( inCombat )
			{
				from.SendMessage( "You cannot setup a tent while in combat." );
				return;
			}
			else if ( ( from.Region.IsPartOf( typeof( BardDungeonRegion ) ) || from.Region.IsPartOf( typeof( DungeonRegion ) ) ) && from.Skills[SkillName.Camping].Value >= 90 )
			{
				CanUseTent = 1;
			}
			else if (	from.Skills[SkillName.Camping].Value < 90 && 
						!Server.Misc.Worlds.IsMainRegion( Server.Misc.Worlds.GetRegionName( from.Map, from.Location ) ) && 
						!from.Region.IsPartOf( typeof( OutDoorRegion ) ) && 
						!from.Region.IsPartOf( typeof( OutDoorBadRegion ) ) && 
						!from.Region.IsPartOf( typeof( VillageRegion ) ) )
			{
				from.SendMessage( "You are only skilled enough to use this tent outdoors." ); 
				return;
			}
			else if (	from.Skills[SkillName.Camping].Value >= 90 && 
						!from.Region.IsPartOf( typeof( DungeonRegion ) ) && 
						!from.Region.IsPartOf( typeof( BardDungeonRegion ) ) && 
						!Server.Misc.Worlds.IsMainRegion( Server.Misc.Worlds.GetRegionName( from.Map, from.Location ) ) && 
						!from.Region.IsPartOf( typeof( OutDoorRegion ) ) && 
						!from.Region.IsPartOf( typeof( OutDoorBadRegion ) ) && 
						!from.Region.IsPartOf( typeof( VillageRegion ) ) )
			{
				from.SendMessage( "You can only use this tent outdoors or in dungeons." ); 
				return;
			}
			else
			{
				CanUseTent = 1;
			}

			if ( CanUseTent > 0 && from.CheckSkill( SkillName.Camping, 0.0, 125.0 ) )
			{
				if ( IsChildOf( from.Backpack ) && Charges > 0 ) 
				{
					Server.Items.Kindling.RaiseCamping( from );
					ConsumeCharge( from );

					PlayerMobile pc = (PlayerMobile)from;
					string sX = from.X.ToString();
					string sY = from.Y.ToString();
					string sZ = from.Z.ToString();
					string sMap = Worlds.GetMyMapString( from.Map );
					string sZone = "the Camping Tent";
						if ( from.Region.IsPartOf( typeof( DungeonRegion ) ) || from.Region.IsPartOf( typeof( BardDungeonRegion ) ) ){ sZone = "the Dungeon Room"; }

					string doors = sX + "#" + sY + "#" + sZ + "#" + sMap + "#" + sZone;

					((PlayerMobile)from).CharacterPublicDoor = doors;

					Point3D loc = new Point3D( 3710, 3971, 0 );
						if ( from.Region.IsPartOf( typeof( DungeonRegion ) ) ){ loc = new Point3D( 3687, 3333, 0 ); }
						else if ( from.Region.IsPartOf( typeof( BardDungeonRegion ) ) ){ loc = new Point3D( 3687, 3333, 0 ); }
						else if ( from.Skills[SkillName.Camping].Value > 66 ){ loc = new Point3D( 3792, 3967, 0 ); }

					TentTeleport( from, loc, Map.Sosaria, 0x057, sZone, "enter" );
					return;
				}
				else if ( from.InRange( this.GetWorldLocation(), 3 ) && Charges > 0 )
				{
					Server.Items.Kindling.RaiseCamping( from );
					ConsumeCharge( from );

					PlayerMobile pc = (PlayerMobile)from;
					string sX = from.X.ToString();
					string sY = from.Y.ToString();
					string sZ = from.Z.ToString();
					string sMap = Worlds.GetMyMapString( from.Map );
					string sZone = "the Camping Tent";
						if ( from.Region.IsPartOf( typeof( DungeonRegion ) ) || from.Region.IsPartOf( typeof( BardDungeonRegion ) ) ){ sZone = "the Dungeon Room"; }

					string doors = sX + "#" + sY + "#" + sZ + "#" + sMap + "#" + sZone;

					((PlayerMobile)from).CharacterPublicDoor = doors;

					Point3D loc = new Point3D( 3710, 3971, 0 );
						if ( from.Region.IsPartOf( typeof( DungeonRegion ) ) ){ loc = new Point3D( 3687, 3333, 0 ); }
						else if ( from.Region.IsPartOf( typeof( BardDungeonRegion ) ) ){ loc = new Point3D( 3687, 3333, 0 ); }
						else if ( from.Skills[SkillName.Camping].Value > 66 ){ loc = new Point3D( 3792, 3967, 0 ); }

					InternalItem builtTent = new InternalItem();
					builtTent.Name = "camping tent";
					ThruDoor publicTent = (ThruDoor)builtTent;
					publicTent.m_PointDest = loc;
					publicTent.m_MapDest = Map.Sosaria;
					builtTent.MoveToWorld( this.Location, this.Map );
					from.AddToBackpack( this );

					TentTeleport( from, loc, Map.Sosaria, 0x057, sZone, "enter" );
					return;
				}
				else if ( !from.InRange( this.GetWorldLocation(), 3 ) && Charges > 0 )
				{
					from.SendLocalizedMessage( 502138 ); // That is too far away for you to use
					return;
				}
				else
				{
					from.SendMessage( "This tent is too worn from over use, and is no longer of any good." );
					this.Delete();
					return;
				}
			}
			else if ( CanUseTent > 0 )
			{
				from.SendMessage( "Your tent is a bit more worn out as you fail to set it up properly." );
				Server.Items.Kindling.RaiseCamping( from );
				ConsumeCharge( from );

				if ( Charges < 1 )
				{
					from.SendMessage( "This tent is too worn from over use, and is no longer of any good." );
					this.Delete();
					return;
				}

				return;
			}
		}

		public static void TentTeleport( Mobile m, Point3D loc, Map map, int sound, string zone, string direction )
		{
			BaseCreature.TeleportPets( m, loc, map, false );
			m.MoveToWorld ( loc, map );
			m.PlaySound( sound );
			LoggingFunctions.LogRegions( m, zone, direction );
		}

		public void ConsumeCharge( Mobile from )
		{
			--Charges;
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			list.Add( 1060584, "{0}\t{1}", m_Charges.ToString(), "Uses" );
		}

		private class InternalItem : ThruDoor
		{
			public InternalItem()
			{
				ItemID = 0x2795;
				InternalTimer t = new InternalTimer( this );
				t.Start();
			}

			public InternalItem( Serial serial ) : base( serial )
			{
			}

			public override void Serialize( GenericWriter writer )
			{
				base.Serialize( writer );
			}

			public override void Deserialize( GenericReader reader )
			{
				base.Deserialize( reader );
				Delete();
			}

			private class InternalTimer : Timer
			{
				private Item m_Item;

				public InternalTimer( Item item ) : base( TimeSpan.FromSeconds( 30.0 ) )
				{
					Priority = TimerPriority.OneSecond;
					m_Item = item;
				}

				protected override void OnTick()
				{
					m_Item.Delete();
				}
			}
		}

		public CampersTent( Serial serial ) : base( serial )
		{ 
		} 
		
		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 0 );
			writer.Write( (int) m_CamperTentEffect );
			writer.Write( (int) m_Charges );
		} 
		
		public override void Deserialize(GenericReader reader) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt();
			switch ( version )
			{
				case 0:
				{
					m_CamperTentEffect = (CamperTentEffect)reader.ReadInt();
					m_Charges = (int)reader.ReadInt();
					break;
				}
			}
		}
	}
}