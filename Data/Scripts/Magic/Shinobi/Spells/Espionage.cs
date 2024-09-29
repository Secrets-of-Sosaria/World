using System;
using Server.Targeting;
using Server.Network;
using Server.Items;

namespace Server.Spells.Shinobi
{
	public class Espionage : ShinobiSpell
	{
		public override int spellIndex { get { return 293; } }
		private static SpellInfo m_Info = new SpellInfo(
				"Espionage", "Supai",
				-1,
				0
			);

		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 3.0 ); } }
		public override double RequiredSkill{ get{ return (double)(Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "skill" ))); } }
		public override int RequiredTithing{ get{ return Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "points" )); } }
		public override int RequiredMana{ get{ return Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "mana" )); } }

		public Espionage( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		private class InternalTarget : Target
		{
			private Espionage m_Owner;

			public InternalTarget( Espionage owner ) : base( 2, false, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				IPoint3D loc = o as IPoint3D;

				if ( loc == null )
					return;

				if ( m_Owner.CheckSequence() ) {
					SpellHelper.Turn( from, o );

					Effects.PlaySound( loc, from.Map, 0x241 );

					if ( o is Mobile )
					{
						from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 503101 ); // That did not need to be unlocked.
					}
					else if ( o is BaseHouseDoor )  // house door check
					{
						from.SendMessage( "This ability is to unlock certain containers and other types of doors." );
					}
					else if ( o is Item && ((Item)o).VirtualContainer )
					{
						from.SendMessage( "This key is to unlock almost any container." );
					}
					else if ( o is BaseDoor )
					{
						if ( Server.Items.DoorType.IsDungeonDoor( (BaseDoor)o ) )
						{
							if ( ((BaseDoor)o).Locked == false )
								from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 503101 ); // That did not need to be unlocked.

							else
							{
								((BaseDoor)o).Locked = false;
								Server.Items.DoorType.UnlockDoors( (BaseDoor)o );
							}
						}
						else
							from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 503101 ); // That did not need to be unlocked.
					}
					else if ( !( o is LockableContainer ) )
					{
						from.SendLocalizedMessage( 501666 ); // You can't unlock that!
					}
					else {
						LockableContainer cont = (LockableContainer)o;

						if ( Multis.BaseHouse.CheckSecured( cont ) ) 
							from.SendMessage( "You cannot use this ability on a secure item!" );
						else if ( !cont.Locked )
							from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 503101 ); // That did not need to be unlocked.
						else if ( cont.LockLevel == 0 )
							from.SendLocalizedMessage( 501666 ); // You can't unlock that!
						else if ( (this.GetType()).IsAssignableFrom(typeof(TreasureMapChest)) )
						{
							from.SendMessage( "A magical aura on this long lost treasure will always be too much for your abilities." );
						}
						else if ( (this.GetType()).IsAssignableFrom(typeof(ParagonChest)) )
						{
							from.SendMessage( "A magical aura on this long lost treasure will always be too much for your abilities." );
						}
						else if ( (this.GetType()).IsAssignableFrom(typeof(PirateChest)) )
						{
							from.SendMessage( "This seems to be protected from magic, but maybe an actual lock picker can get it open." );
						}
						else {
							int level = (int)(from.Skills[SkillName.Ninjitsu].Value) + 20;

							if ( level > 50 ){ level = 50; }

							if ( level >= cont.RequiredSkill && !(cont is TreasureMapChest && ((TreasureMapChest)cont).Level > 2) ) {
								cont.Locked = false;

								if ( cont.LockLevel == -255 )
									cont.LockLevel = cont.RequiredSkill - 10;
							}
							else
								from.SendMessage( "Your ability does not seem to have an effect on that lock!" );
						}		
					}
				}

				m_Owner.FinishSequence();
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}