using System;
using Server.Targeting;
using Server.Network;
using Server.Items;
using Server.Misc;

namespace Server.Spells.Third
{
	public class UnlockSpell : MagerySpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Unlock Spell", "Ex Por",
				215,
				9001,
				Reagent.Bloodmoss,
				Reagent.SulfurousAsh
			);

		public override SpellCircle Circle { get { return SpellCircle.Third; } }

		public UnlockSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		private class InternalTarget : Target
		{
			private UnlockSpell m_Owner;

			public InternalTarget( UnlockSpell owner ) : base( Core.ML ? 10 : 12, false, TargetFlags.None )
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

					Effects.SendLocationParticles( EffectItem.Create( new Point3D( loc ), from.Map, EffectItem.DefaultDuration ), 0x376A, 9, 32, PlayerSettings.GetMySpellHue( true, from, 0 ), 0, 5024, 0 );

					Effects.PlaySound( loc, from.Map, 0x1FF );

					if ( o is Mobile )
					{
						from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 503101 ); // That did not need to be unlocked.
					}
					else if ( o is BaseHouseDoor )  // house door check
					{
						from.SendMessage( "This spell is to unlock certain containers and other types of doors." );
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
							from.SendLocalizedMessage( 503098 ); // You cannot cast this on a secure item.
						else if ( !cont.Locked )
							from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 503101 ); // That did not need to be unlocked.
						else if ( cont.LockLevel == 0 )
							from.SendLocalizedMessage( 501666 ); // You can't unlock that!
						else if ( (this.GetType()).IsAssignableFrom(typeof(TreasureMapChest)) )
						{
							from.SendMessage( "A magical aura on this long lost treasure seems to negate your spell." );
						}
						else if ( (this.GetType()).IsAssignableFrom(typeof(ParagonChest)) )
						{
							from.SendMessage( "A magical aura on this long lost treasure seems to negate your spell." );
						}
						else if ( (this.GetType()).IsAssignableFrom(typeof(PirateChest)) )
						{
							from.SendMessage( "This seems to be protected from magic, but maybe a thief can get it open." );
						}
						else {
							int level = (int)( Spell.ItemSkillValue( from, SkillName.Magery, false ) ) + 20;

							if ( level > 50 ){ level = 50; }

							if ( level >= cont.RequiredSkill && !(cont is TreasureMapChest && ((TreasureMapChest)cont).Level > 2) ) {
								cont.Locked = false;

								if ( cont.LockLevel == -255 )
									cont.LockLevel = cont.RequiredSkill - 10;
							}
							else
								from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 503099 ); // My spell does not seem to have an effect on that lock.
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