using System;
using Server.Items;
using Server.Mobiles;
using Server.Multis;
using Server.Targeting;
using Server.Regions;
using System.Collections;
using System.Collections.Generic;

namespace Server.SkillHandlers
{
	public class Searching
	{
		public static void Initialize()
		{
			SkillInfo.Table[(int)SkillName.Searching].Callback = new SkillUseCallback( OnUse );
		}

		public static TimeSpan OnUse( Mobile src )
		{
			if ( src.Blessed )
			{
				src.SendMessage( "You cannot search while in this state." );
			}
			else 
			{
				src.SendLocalizedMessage( 500819 );//Where will you search?
				src.Target = new InternalTarget();
			}

			return TimeSpan.FromSeconds( 6.0 );
		}

		private class InternalTarget : Target
		{
			public InternalTarget() : base( 12, true, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile src, object targ )
			{
				bool foundAnyone = false;

				Point3D p;
				if ( targ is Mobile )
					p = ((Mobile)targ).Location;
				else if ( targ is Item )
					p = ((Item)targ).Location;
				else if ( targ is IPoint3D )
					p = new Point3D( (IPoint3D)targ );
				else 
					p = src.Location;

				double srcSkill = src.Skills[SkillName.Searching].Value;
				int range = (int)(srcSkill / 10.0);

				if ( !src.CheckSkill( SkillName.Searching, 0.0, 125.0 ) )
					range /= 2;

				BaseHouse house = BaseHouse.FindHouseAt( p, src.Map, 16 );

				bool inHouse = ( house != null && house.IsFriend( src ) );

				if ( inHouse )
					range = 22;

				if ( range > 0 )
				{
					IPooledEnumerable inRange = src.Map.GetMobilesInRange( p, range );

					foreach ( Mobile trg in inRange )
					{
						if ( trg.Hidden && src != trg )
						{
							double ss = srcSkill + Utility.Random( 21 ) - 10;
							double ts = trg.Skills[SkillName.Hiding].Value + Utility.Random( 21 ) - 10;

							if ( src.AccessLevel >= trg.AccessLevel && ( ss >= ts || ( inHouse && house.IsInside( trg ) ) ) )
							{
								trg.RevealingAction();
								trg.SendLocalizedMessage( 500814 ); // You have been revealed!
								foundAnyone = true;
							}
						}
					}

					inRange.Free();
					ArrayList ItemsToDelete = new ArrayList();

					IPooledEnumerable TitemsInRange = src.Map.GetItemsInRange( p, range );

					foreach ( Item item in TitemsInRange )
					{
						if ( Server.SkillHandlers.Searching.DetectSomething( item, src, true ) )
						{
							ItemsToDelete.Add( item );
							foundAnyone = true;
						}
					}

					TitemsInRange.Free();

					for ( int i = 0; i < ItemsToDelete.Count; ++i )
					{
						Item rid = ( Item )ItemsToDelete[ i ];
						if ( rid is HiddenChest )
							rid.Delete();
						else if ( ( rid is HiddenDoorEast || rid is HiddenDoorSouth ) && rid.ItemID != 0x6723 && rid.ItemID != 0x6724 )
							((BaseDoor)rid).Use( src );
					}
				}

				if ( !foundAnyone )
					src.SendLocalizedMessage( 500817 ); // You can see nothing hidden there.
				else
				{
					src.PlaySound( src.Female ? 778 : 1049 );
					src.Say( "*ah!*" );
				}
			}
		}

		public static bool SpotInTheDark( Mobile m )
		{
			bool see = false;

			int night = 2 * AosAttributes.GetValue( m, AosAttribute.NightSight );
				if ( m.LightLevel > 0 ){ night = night + 2; }

			if ( night >= Utility.RandomMinMax(1,100) )
				see = true;

			return see;
		}

		public static bool DetectSomething( Item item, Mobile m, bool skillCheck )
		{
			bool foundAnyone = false;
			string sTrap;

			bool foundIt = false;

			if ( skillCheck && m.CheckSkill( SkillName.Searching, 0, 125 ) )
				foundIt = true;

			if ( !foundIt && SpotInTheDark( m ) )
				foundIt = true;

			if ( m is PlayerMobile && m.Alive && ( !skillCheck || foundIt ) )
			{
				if ( item is BaseTrap )
				{
					BaseTrap trap = (BaseTrap) item;

					if ( trap is FireColumnTrap ){ sTrap = "(fire column trap)"; }
					else if ( trap is FlameSpurtTrap ){ sTrap = "(fire spurt trap)"; }
					else if ( trap is GasTrap ){ sTrap = "(poison gas trap)"; }
					else if ( trap is GiantSpikeTrap ){ sTrap = "(giant spike trap)"; }
					else if ( trap is MushroomTrap ){ sTrap = "(odd mushroom)"; }
					else if ( trap is SawTrap ){ sTrap = "(saw blade trap)"; }
					else if ( trap is SpikeTrap ){ sTrap = "(spike trap)"; }
					else if ( trap is StoneFaceTrap ){ sTrap = "(stone face trap)"; }
					else { sTrap = ""; }

					m.SendMessage( "There is a trap nearby! " + sTrap + "" );
					foundAnyone = true;
				}
				else if ( ( item is HiddenDoorEast || item is HiddenDoorSouth ) && item.ItemID != 0x6723 && item.ItemID != 0x6724 )
				{
					foundAnyone = true;
				}
				else if ( item is BaseDoor && (	item.ItemID == 0x35E || 
												item.ItemID == 0xF0 || 
												item.ItemID == 0xF2 || 
												item.ItemID == 0x326 || 
												item.ItemID == 0x324 || 
												item.ItemID == 0x32E || 
												item.ItemID == 0x32C || 
												item.ItemID == 0x314 || 
												item.ItemID == 0x316 || 
												item.ItemID == 0x31C || 
												item.ItemID == 0x31E || 
												item.ItemID == 0xE8 || 
												item.ItemID == 0xEA || 
												item.ItemID == 0x34C || 
												item.ItemID == 0x356 || 
												item.ItemID == 0x35C || 
												item.ItemID == 0x354 || 
												item.ItemID == 0x344 || 
												item.ItemID == 0x346 || 
												item.ItemID == 0x34E || 
												item.ItemID == 0x334 || 
												item.ItemID == 0x336 || 
												item.ItemID == 0x33C || 
												item.ItemID == 0x33E ) )
				{
					m.PlaySound( m.Female ? 778 : 1049 ); m.Say( "*ah!*" );
					m.SendMessage( "There is a hidden door nearby!" );
					foundAnyone = true;
				}
				else if ( item is HiddenTrap )
				{
					if ( item.Weight <= 2.0 && HiddenTrap.SeeIfTrapActive( item ) )
					{
						string textSay = "There is a hidden floor trap somewhere nearby!";
						if ( Server.Misc.Worlds.IsOnSpaceship( item.Location, item.Map ) )
						{
							textSay = "There is a dangerous area nearby!";
						}
						m.SendMessage( textSay );
						foundAnyone = true;
						HiddenTrap.DiscoverTrap( item );
					}
				}
				else if ( item is HiddenChest )
				{
					int minLevel = (int)(m.Skills[SkillName.Searching].Value / 25 );
					int maxLevel = (int)(m.Skills[SkillName.Searching].Value / 10 );
					// at 100 searching, generates a box between level 4 and 10
					int level = Utility.RandomMinMax(minLevel,maxLevel);
						if (level < 1){level = 1;}
						if (level > 10){level = 10;}

					if ( HiddenChest.FoundBox( m, skillCheck, level, item ) )
						foundAnyone = true;
				}
			}
			return foundAnyone;
		}
	}
}
