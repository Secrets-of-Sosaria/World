using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles; 
using Server.Network;
using Server.Regions;

namespace Server.Mobiles 
{
	[CorpseName( "a henchman corpse" )] 
	public class HenchmanMonster : BaseCreature
	{
		private DateTime m_Healing;
		public DateTime Healing{ get{ return m_Healing; } set{ m_Healing = value; } }

		private DateTime m_NextMorale;
		public DateTime NextMorale{ get{ return m_NextMorale; } set{ m_NextMorale = value; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			bool GoAway = HenchmanFunctions.OnMoving( m, oldLocation, this, m_NextMorale );
			if ( GoAway == true ){ Timer.DelayCall( TimeSpan.FromSeconds( 2.0 ), new TimerCallback( Delete ) ); }
			else { m_NextMorale = (DateTime.Now + TimeSpan.FromSeconds( 60 )); }
		}

		[Constructable] 
		public HenchmanMonster( int myBody, int nMounted, double nSkills, int nStats, int nType, int nSound ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "henchman";
			Body = myBody;
			BaseSoundID = nSound;

			int nStr = (int)((nStats / 6) * 3);
			int nDex = (int)((nStats / 6) * 2);
			int nInt = (int)((nStats / 6) * 1);
			int nArmor = (int)(nStats / 4);
			int nProtect = (int)(nStats / 2);
			int nDamage = (int)(nStats / 10);

			if ( nType == 3 )
			{
				AI = AIType.AI_Mage;
				RangeFight = 7;
				nStr = (int)((nStats / 6) * 1);
				nDex = (int)((nStats / 6) * 2);
				nInt = (int)((nStats / 6) * 3);
				nArmor = (int)(nStats / 6);
				nProtect = (int)(nStats / 4);
				nDamage = (int)(nStats / 7);

				SetSkill(SkillName.FistFighting, nSkills );
				SetSkill(SkillName.Marksmanship, nSkills );
				SetSkill(SkillName.Focus, nSkills );
				SetSkill(SkillName.MagicResist, nSkills );
				SetSkill(SkillName.Tactics, nSkills );
				SetSkill(SkillName.Parry, nSkills );
				SetSkill(SkillName.Anatomy, nSkills );
				SetSkill(SkillName.Magery, nSkills );
				SetSkill(SkillName.Psychology, nSkills );
				SetSkill(SkillName.Poisoning, nSkills );
				SetSkill(SkillName.Meditation, nSkills );
				SetSkill(SkillName.Healing, nSkills );

				AddItem( new WizardStaff() );
			}
			else if ( nType == 2 )
			{
				AI = AIType.AI_Archer;
				RangeFight = 7;
				nStr = (int)((nStats / 6) * 2);
				nDex = (int)((nStats / 6) * 3);
				nInt = (int)((nStats / 6) * 1);
				nArmor = (int)(nStats / 5);
				nProtect = (int)(nStats / 3);
				nDamage = (int)(nStats / 10);

				SetSkill(SkillName.FistFighting, nSkills );
				SetSkill(SkillName.Focus, nSkills );
				SetSkill(SkillName.MagicResist, nSkills );
				SetSkill(SkillName.Tactics, nSkills );
				SetSkill(SkillName.Anatomy, nSkills );
				SetSkill(SkillName.Marksmanship, nSkills );
				SetSkill(SkillName.Healing, nSkills );

				AddItem( new Bow() );
			}
			else
			{
				SetSkill(SkillName.FistFighting, nSkills );
				SetSkill(SkillName.Focus, nSkills );
				SetSkill(SkillName.MagicResist, nSkills );
				SetSkill(SkillName.Tactics, nSkills );
				SetSkill(SkillName.Parry, nSkills );
				SetSkill(SkillName.Anatomy, nSkills );
				SetSkill(SkillName.Healing, nSkills );
			}

			if ( nArmor > 70 ){ nArmor = 70; }
			if ( nProtect > 70 ){ nProtect = 70; }

       	    SetStr( nStr );
            SetDex( nDex );
            SetInt( nInt );

            SetHits( nStr*2 );
            SetStam( nDex*2 );
            SetMana( nInt*2 );

			SetDamage( (int)(nDamage/2), nDamage );

			ControlSlots = 1;

			VirtualArmor = (int)(nStats / 5);

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 10 );
			SetDamageType( ResistanceType.Cold, 10 );
			SetDamageType( ResistanceType.Poison, 10 );
			SetDamageType( ResistanceType.Energy, 10 );

			SetResistance( ResistanceType.Physical, nProtect );
			SetResistance( ResistanceType.Fire, nArmor );
			SetResistance( ResistanceType.Cold, nArmor );
			SetResistance( ResistanceType.Poison, nArmor );
			SetResistance( ResistanceType.Energy, nArmor );

			if ( nMounted > 0 )
			{
				ActiveSpeed = 0.1;
				PassiveSpeed = 0.2;
			}
		}

        public override void OnSpeech( SpeechEventArgs e )
        {
            if (!e.Handled && Insensitive.Equals(e.Speech, "report"))
            {
                HenchmanFunctions.ReportStatus(this);
            }
            base.OnSpeech(e);
        }

		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool AlwaysAttackable{ get{ return true; } }
		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool InitialInnocent{ get{ return true; } }
		public override bool DeleteOnRelease{ get{ return true; } }
		public override bool DeleteCorpseOnDeath{ get{ return true; } }
		public override bool IsDispellable { get { return false; } }
		public override bool IsBondable{ get{ return false; } }
		public override bool CanBeRenamedBy( Mobile from ){ return false; }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			HenchmanFunctions.OnGaveAttack( this );
		}

        public override void OnDamagedBySpell(Mobile attacker)
        {
            base.OnDamagedBySpell(attacker);
			HenchmanFunctions.OnSpellAttack( this );
        }

		public override void OnGotMeleeAttack( Mobile defender )
		{
			HenchmanFunctions.OnGotAttack( this );
		}

		public override bool OnBeforeDeath()
		{
			HenchmanFunctions.OnDead( this );
			if ( !base.OnBeforeDeath() )
				return false;

			return true;
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			HenchmanFunctions.OnGive( from, dropped, this );
			return base.OnDragDrop( from, dropped );
		}

		public HenchmanMonster( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 0 ); // version
			Loyalty = 100;
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerCallback( Delete ) );
		} 
	} 
}   