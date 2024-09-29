using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Misc;
using Server.Network; 

namespace Server.Mobiles
{
	[CorpseName( "a pile of metal" )]
	public class Exodus : BaseCreature
	{
		private bool m_FieldActive;
		public bool FieldActive{ get{ return m_FieldActive; } }
		public bool CanUseField{ get{ return Hits >= HitsMax * 9 / 10; } } // TODO: an OSI bug prevents to verify this
		public override bool IsScaredOfScaryThings{ get{ return false; } }
		public override bool IsScaryToPets{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x9C2; } }
		public override int BreathEffectSound{ get{ return 0x665; } }
		public override int BreathEffectItemID{ get{ return 0x3818; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 14 ); }

		[Constructable]
		public Exodus () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Exodus";
			BaseSoundID = 0x300;
			Body = 451;

			SetStr( 500, 700 );
			SetDex( 177, 255 );
			SetInt( 151, 250 );

			SetHits( 400, 500 );

			SetDamage( 18, 23 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 45, 60 );
			SetResistance( ResistanceType.Fire, 20, 40 );
			SetResistance( ResistanceType.Cold, 20, 40 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 20, 40 );

			SetSkill( SkillName.Anatomy, 110.0 );
			SetSkill( SkillName.Psychology, 110.0 );
			SetSkill( SkillName.MagicResist, 110.0 );
			SetSkill( SkillName.Tactics, 110.0 );
			SetSkill( SkillName.FistFighting, 110.0 );

			Fame = 28000;
			Karma = -28000;

			VirtualArmor = 40;

			PackItem( new IronIngot( Utility.RandomMinMax( 20, 50 ) ) );
			PackItem( new PowerCrystal() );
			PackItem( new ArcaneGem() );
			PackItem( new ClockworkAssembly() );
			PackItem( new BottleOil( Utility.RandomMinMax( 3, 8 ) ) );
			PackItem( new Gears( Utility.RandomMinMax( 3, 8 ) ) );

			m_FieldActive = CanUseField;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Rich );
		}

		public override bool AutoDispel{ get{ return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 6; } }
		public override bool BardImmune { get { return true; } }

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( m_FieldActive )
				damage = (int)( damage * 0.75 ); // no melee damage when the field is up
		}

		public override void AlterSpellDamageFrom( Mobile caster, ref int damage )
		{
			if ( !m_FieldActive )
				damage = (int)( damage * 0.75 ); // no spell damage when the field is down
		}

		public override void CheckReflect( Mobile caster, ref bool reflect )
		{
			if ( Utility.RandomMinMax( 1, 4 ) == 1 ){ reflect = true; } // 25% spells are reflected back to the caster
			else { reflect = false; }
		}

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.4 > Utility.RandomDouble() )
			{
				SendEBolt( from );
			}

			if ( !m_FieldActive )
			{
				this.FixedParticles( 0, 10, 0, 0x2522, EffectLayer.Waist );
			}
			else if ( m_FieldActive && !CanUseField )
			{
				m_FieldActive = false;

				this.FixedParticles( 0x3735, 1, 30, 0x251F, EffectLayer.Waist );
			}
		}

        public override void OnAfterSpawn()
        {
			base.OnAfterSpawn();
			Worlds.MoveToRandomDungeon( this );
			Server.Misc.IntelligentAction.BurnAway( this );
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( m_FieldActive )
			{
				this.FixedParticles( 0x376A, 20, 10, 0x2530, EffectLayer.Waist );

				PlaySound( 0x2F4 );

				attacker.SendAsciiMessage( "Your weapon is less effective with the creature's magical barrier up!" );

				if ( attacker is BaseCreature ) // KILL ANY PETS PLAYERS FOOLISHLY BROUGHT WITH THEM
				{
					BaseCreature pet = (BaseCreature)attacker;
					if ( BaseCreature.IsPet( attacker ) )
					{
						SendEBoltOnPet( attacker );
					}
				}
			}

			if( attacker != null && attacker.Alive && attacker.Weapon is BaseRanged && 0.4 > Utility.RandomDouble() )
			{
				SendEBolt( attacker );
			}
		}

		public override bool OnBeforeDeath()
		{
			this.Body = 752;
			Server.Misc.IntelligentAction.BurnAway( this );
			return base.OnBeforeDeath();
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				int chance = 0;

				if ( killer is PlayerMobile )
				{
					Server.Items.QuestSouvenir.GiveReward( killer, "Exodus", 0, 0x65B9 );

					if ( Server.Misc.PlayerSettings.GetSpecialsKilled( killer, "Exodus" ) ){ chance = 9; }

					if ( chance < Utility.RandomMinMax(1,10) )
					{
						if ( !Server.Misc.PlayerSettings.GetSpecialsKilled( killer, "Exodus" ) )
						{
							Server.Misc.PlayerSettings.SetSpecialsKilled( killer, "Exodus", true );
							Item reward = new SummonReward();
							reward.Hue = 0x835;
							reward.ItemID = 0x2105;
							reward.Name = "Statue of Exodus";
							c.DropItem( reward );
						}
						c.DropItem( new DarkCoreExodus() );
						Server.Misc.LoggingFunctions.LogSlayingLord( this.LastKiller, this.Name );
					}
				}
			}
		}

		public override void OnThink()
		{
			base.OnThink();

			if ( !m_FieldActive && !IsHurt() )
				m_FieldActive = true;
		}

		public override bool Move( Direction d )
		{
			bool move = base.Move( d );

			if ( move && m_FieldActive && this.Combatant != null )
				this.FixedParticles( 0, 10, 0, 0x2530, EffectLayer.Waist );

			return move;
		}		

		public void SendEBolt( Mobile to )
		{
			this.MovingParticles( to, 0x3818, 7, 0, false, true, 0xBE3, 0xFCB, 0x211 );
			to.PlaySound( 0x229 );
			this.DoHarmful( to );
			AOS.Damage( to, this, 50, 0, 0, 0, 0, 100 );
		}

		public void SendEBoltOnPet( Mobile to )
		{
			this.MovingParticles( to, 0x3818, 7, 0, false, true, 0xBE3, 0xFCB, 0x211 );
			to.PlaySound( 0x229 );
			this.DoHarmful( to );
			AOS.Damage( to, this, 10000, 0, 0, 0, 0, 100 );
		}

		public Exodus( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			m_FieldActive = CanUseField;
		}
	}
}

namespace Server.Items
{
	public class DarkCoreExodus : Item
	{
		[Constructable]
		public DarkCoreExodus() : base( 0x1CD )
		{
			Hue = 0x497;
			Name = "dark core of Exodus";
		}

		public DarkCoreExodus( Serial serial ) : base( serial )
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

namespace Server.Gumps 
{ 
	public class DarkCoreGump : Gump 
	{
		public DarkCoreGump( Mobile from, string items, bool scroller ) : base( 50, 50 ) 
		{
			from.SendSound( 0x4A );

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			string color = "#e3a27e";

			AddPage(0);

			AddImage(0, 0, 7022, Server.Misc.PlayerSettings.GetGumpHue( from ));

			AddButton(427, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);

			AddHtml( 11, 11, 403, 20, @"<BODY><BASEFONT Color=" + color + ">SHRINE OF DILIGENCE</BASEFONT></BODY>", (bool)false, (bool)false);

			string text = "";

			if ( items == "null" )
			{
				text = "To destroy the dark core and absorb its power into one of your items, you can only place a single piece of armor, weapon, trinket, clothing, or jewelry onto the shrine. Remove some of the items and try to destroy the dark core again.";
			}
			else if ( items == "non" )
			{
				text = "To destroy the dark core and absorb its power into one of your items, you can only place a single piece of armor, weapon, trinket, clothing, or jewelry onto the shrine. Remove any of the items, that do not fall into these categories, and try to destroy the dark core again.";
			}
			else
			{
				text = "Some items have an inherent magical aura bestowed upon them, that the magic of the dark core cannot enhance any further. These include Artefacts and Relics where you use enhancement points to modify. Below are the items on the shrine that cannot be affected. Once you remove them, you can try to destroy the dark core of exodus again.<br>" + items + "";
			}

			AddHtml( 13, 43, 440, 301, @"<BODY><BASEFONT Color=" + color + ">" + text + "</BASEFONT></BODY>", (bool)false, (bool)false);
		}

		public override void OnResponse( NetState state, RelayInfo info ) 
		{
			Mobile from = state.Mobile; 
			from.SendSound( 0x4A );
		}
	}
}