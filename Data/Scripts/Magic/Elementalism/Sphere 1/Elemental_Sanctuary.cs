using System;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Regions;
using Server.Misc;

namespace Server.Spells.Elementalism
{
	public class Elemental_Sanctuary_Spell : ElementalSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elemental Sanctuary", "Invata",
				239,
				9031
			);

		public override SpellCircle Circle { get { return SpellCircle.First; } }

		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 2.25 ); } }

		public Elemental_Sanctuary_Spell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			bool inCombat = ( Caster.Combatant != null && Caster.InRange( Caster.Combatant.Location, 20 ) && Caster.Combatant.InLOS( Caster ) );

			bool CanCast = false;

			if ( Server.Misc.WeightOverloading.IsOverloaded( Caster ) )
			{
				Caster.SendLocalizedMessage( 502359, "", 0x22 ); // Thou art too encumbered to move.
			}
			else if ( Caster.Region.IsPartOf( typeof( PublicRegion ) ) )
			{
				Caster.SendMessage( "You cannot cast this here." ); 
			}
			else if ( Server.Misc.Worlds.IsOnBoat( Caster ) )
			{
				Caster.SendMessage( "You cannot cast this near a boat." );
			}
			else if ( Server.Misc.Worlds.IsOnSpaceship( Caster.Location, Caster.Map ) )
			{
				Caster.SendMessage( "The metal walls of this place seems to be blocking this spell." );
			}
			else if ( inCombat )
			{
				Caster.SendMessage( "You cannot cast this while in combat." );
			}
			else if ( ( Caster.Region.IsPartOf( typeof( BardDungeonRegion ) ) || Caster.Region.IsPartOf( typeof( DungeonRegion ) ) ) && Caster.Skills[SkillName.Elementalism].Value >= 90 )
			{
				CanCast = true;
			}
			else if (	Caster.Skills[SkillName.Elementalism].Value < 90 && 
						!Server.Misc.Worlds.IsMainRegion( Server.Misc.Worlds.GetRegionName( Caster.Map, Caster.Location ) ) && 
						!Caster.Region.IsPartOf( typeof( OutDoorRegion ) ) && 
						!Caster.Region.IsPartOf( typeof( OutDoorBadRegion ) ) && 
						!Caster.Region.IsPartOf( typeof( VillageRegion ) ) )
			{
				Caster.SendMessage( "You are only skilled enough to cast this spell outdoors." ); 
			}
			else if (	Caster.Skills[SkillName.Elementalism].Value >= 90 && 
						!Caster.Region.IsPartOf( typeof( DungeonRegion ) ) && 
						!Caster.Region.IsPartOf( typeof( BardDungeonRegion ) ) && 
						!Server.Misc.Worlds.IsMainRegion( Server.Misc.Worlds.GetRegionName( Caster.Map, Caster.Location ) ) && 
						!Caster.Region.IsPartOf( typeof( OutDoorRegion ) ) && 
						!Caster.Region.IsPartOf( typeof( OutDoorBadRegion ) ) && 
						!Caster.Region.IsPartOf( typeof( VillageRegion ) ) )
			{
				Caster.SendMessage( "You can only cast this spell outdoors or in dungeons." ); 
			}
			else
			{
				CanCast = true;
			}

			if ( CanCast && CheckSequence() )
			{
				Point3D loc = new Point3D( 1438, 1360, 80 );
				Map map = Map.Sosaria;

				PlayerMobile pc = (PlayerMobile)Caster;
				string sX = pc.X.ToString();
				string sY = pc.Y.ToString();
				string sZ = pc.Z.ToString();
				string sMap = Worlds.GetMyMapString( pc.Map );
				string sZone = "the Lyceum";
				string doors = sX + "#" + sY + "#" + sZ + "#" + sMap + "#" + sZone;

				((PlayerMobile)Caster).CharacterPublicDoor = doors;

				BaseCreature.TeleportPets( Caster, loc, map, false );
				Caster.PlaySound( 0x20E );

				if ( Server.Misc.Worlds.GetRegionName( map, loc ) != "the Lyceum" )
				{
					Item gate = new ElementalEffect( 0x3D5E, 5.0, null );
					gate.Name = "magic portal";
					gate.Hue = 0xAFE;
					gate.Movable = false;
					gate.Light = LightType.Circle300;
					gate.MoveToWorld( loc, map );
				}

				Caster.MoveToWorld( loc, map );
				Caster.PlaySound( 0x20E );
			}

			FinishSequence();
		}
	}
}