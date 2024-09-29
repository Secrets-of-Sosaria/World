using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles; 
using Server.Network;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Mobiles 
{
	[CorpseName( "a huge corpse" )] 
	public class FrankenFighter : BaseCreature
	{
		private bool m_Stunning;

		public int FighterLevel;
		[CommandProperty(AccessLevel.Owner)]
		public int Fighter_Level{ get { return FighterLevel; } set { FighterLevel = value; InvalidateProperties(); } }

		private DateTime m_NextTalking;
		public DateTime NextTalking{ get{ return m_NextTalking; } set{ m_NextTalking = value; } }
		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalking && InRange( m, 20 ) )
			{
				this.Loyalty = 100;
				m_NextTalking = (DateTime.Now + TimeSpan.FromSeconds( 300 ));
			}
		}

		[Constructable] 
		public FrankenFighter( ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8 )
		{
			m_NextTalking = (DateTime.Now + TimeSpan.FromSeconds( 60 ));

			Name = "a reanimation";
			Body = 69;
			BaseSoundID = 684;
			ControlSlots = 3;
			ActiveSpeed = 0.1;
			PassiveSpeed = 0.2;
		}

		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool AlwaysAttackable{ get{ return true; } }
		public override bool DeleteOnRelease{ get{ return true; } }
		public override bool DeleteCorpseOnDeath{ get{ return true; } }
		public override bool IsDispellable { get { return false; } }
		public override bool IsBondable{ get{ return false; } }
		public override bool CanBeRenamedBy( Mobile from ){ return true; }
		public override bool BleedImmune{ get{ return true; } }
		public override bool BardImmune { get { return !Core.SE; } }
		public override bool Unprovokable { get { return Core.SE; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override bool IsScaredOfScaryThings{ get{ return false; } }
		public override bool IsScaryToPets{ get{ return true; } }

		public FrankenFighter( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void OnAfterSpawn()
		{
			double scalar = 1.0;

			if ( FighterLevel < 10 ){ scalar = 1; }
			else if ( FighterLevel < 15 ){ scalar = 1.1; }
			else if ( FighterLevel < 20 ){ scalar = 1.2; }
			else if ( FighterLevel < 25 ){ scalar = 1.3; }
			else if ( FighterLevel < 30 ){ scalar = 1.4; }
			else if ( FighterLevel < 35 ){ scalar = 1.5; }
			else if ( FighterLevel < 40 ){ scalar = 1.6; }
			else if ( FighterLevel < 45 ){ scalar = 1.7; }
			else if ( FighterLevel < 50 ){ scalar = 1.8; }
			else if ( FighterLevel < 55 ){ scalar = 1.9; }
			else if ( FighterLevel < 60 ){ scalar = 2; }
			else if ( FighterLevel < 65 ){ scalar = 2.1; }
			else if ( FighterLevel < 70 ){ scalar = 2.2; }
			else if ( FighterLevel < 75 ){ scalar = 2.3; }
			else if ( FighterLevel < 80 ){ scalar = 2.4; }
			else if ( FighterLevel < 85 ){ scalar = 2.5; }
			else if ( FighterLevel < 90 ){ scalar = 2.6; }
			else if ( FighterLevel < 95 ){ scalar = 2.7; }
			else { scalar = 2.8; }

			if ( FighterLevel >= 65 ){ Body = 999; }

			SetStr( (int)(300*scalar) );
			SetDex( (int)(100*scalar) );
			SetInt( (int)(60*scalar) );

			SetHits( (int)(210*scalar) );

			SetDamage( (int)(5*scalar), (int)(10*scalar) );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, (int)(26*scalar) );
			SetResistance( ResistanceType.Fire, (int)(20*scalar) );
			SetResistance( ResistanceType.Cold, (int)(20*scalar) );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, (int)(20*scalar) );

			SetSkill( SkillName.MagicResist, (50.0*scalar) );
			SetSkill( SkillName.Tactics, (50.0*scalar) );
			SetSkill( SkillName.FistFighting, (50.0*scalar) );
		}

		public override bool OnBeforeDeath()
		{
			Effects.SendLocationEffect(this.Location, this.Map, 0x36B0, 9, 10, 0, 0);
			this.PlaySound( 0x1DB );
			this.AIObject.DoOrderRelease();
			return false;
		}

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 0 ); // version
            writer.Write( FighterLevel );
			Loyalty = 100;
		} 

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( !Server.Items.HiddenTrap.IAmAWeaponSlayer( defender, this ) )
			{
				if ( !m_Stunning && 0.3 > Utility.RandomDouble() )
				{
					m_Stunning = true;

					defender.Animate( 21, 6, 1, true, false, 0 );
					this.PlaySound( 0xEE );
					defender.LocalOverheadMessage( MessageType.Regular, 0x3B2, false, "You have been knocked senseless!" );

					BaseWeapon weapon = this.Weapon as BaseWeapon;
					if ( weapon != null )
						weapon.OnHit( this, defender );

					if ( defender.Alive )
					{
						defender.Frozen = true;
						Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerStateCallback( Recover_Callback ), defender );
					}
				}
			}
		}

		private void Recover_Callback( object state )
		{
			Mobile defender = state as Mobile;

			if ( defender != null )
			{
				defender.Frozen = false;
				defender.Combatant = null;
				defender.LocalOverheadMessage( MessageType.Regular, 0x3B2, false, "You recover your senses." );
			}

			m_Stunning = false;
		}

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt();
			FighterLevel = reader.ReadInt();

			LeaveNowTimer thisTimer = new LeaveNowTimer( this ); 
			thisTimer.Start(); 
		} 
	}
}