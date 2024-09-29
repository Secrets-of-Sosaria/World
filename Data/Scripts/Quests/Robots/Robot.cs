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
	[CorpseName( "a broken machine" )] 
	public class Robot : BaseCreature
	{
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
		public Robot( ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8 )
		{
			m_NextTalking = (DateTime.Now + TimeSpan.FromSeconds( 60 ));

			Name = "a robot";
			Body = 334;
			BaseSoundID = 1368;

			ControlSlots = 3;
			ActiveSpeed = 0.1;
			PassiveSpeed = 0.2;

			SetStr( 561, 650 );
			SetDex( 76, 95 );
			SetInt( 61, 90 );

			SetHits( 431, 490 );

			SetDamage( 13, 19 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Fire, 40, 60 );
			SetResistance( ResistanceType.Cold, 25, 35 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 25, 35 );

			SetSkill( SkillName.MagicResist, 80.2, 98.0 );
			SetSkill( SkillName.Tactics, 80.2, 98.0 );
			SetSkill( SkillName.FistFighting, 80.2, 98.0 );

			VirtualArmor = 50;
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

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			if ( dropped is BaseLog )
			{
				BaseLog m_Log = (BaseLog)dropped;
				double difficulty;

				switch ( m_Log.Resource )
				{
					default: difficulty = 40.0; break;
					case CraftResource.AshTree: difficulty = 55.0; break;
					case CraftResource.CherryTree: difficulty = 60.0; break;
					case CraftResource.EbonyTree: difficulty = 65.0; break;
					case CraftResource.GoldenOakTree: difficulty = 70.0; break;
					case CraftResource.HickoryTree: difficulty = 75.0; break;
					case CraftResource.MahoganyTree: difficulty = 80.0; break;
					case CraftResource.DriftwoodTree: difficulty = 80.0; break;
					case CraftResource.OakTree: difficulty = 85.0; break;
					case CraftResource.PineTree: difficulty = 90.0; break;
					case CraftResource.GhostTree: difficulty = 90.0; break;
					case CraftResource.RosewoodTree: difficulty = 95.0; break;
					case CraftResource.WalnutTree: difficulty = 99.0; break;
					case CraftResource.PetrifiedTree: difficulty = 99.9; break;
					case CraftResource.ElvenTree: difficulty = 100.1; break;
				}

				double minSkill = difficulty - 25.0;
				double maxSkill = difficulty + 25.0;
				
				if ( difficulty > 50.0 && difficulty > from.Skills[SkillName.Lumberjacking].Value )
				{
					from.SendMessage( "You have no idea how to have the robot cut this type of wood!" );
					return false;
				}

				if ( from.CheckTargetSkill( SkillName.Lumberjacking, this, minSkill, maxSkill ) )
				{
					if ( m_Log.Amount <= 0 )
					{
						from.SendMessage( "There is not enough wood in this pile to make a board." );
					}
					else
					{
						int amount = m_Log.Amount;
						BaseWoodBoard wood = m_Log.GetLog();
						m_Log.Delete();
						wood.Amount = amount;
						from.AddToBackpack( wood );
						from.PlaySound( 0x21C );
						from.SendMessage( "The robot cuts the logs and you put some boards in your backpack." );
					}
				}
				else
				{
					int amount = m_Log.Amount;
					int lose = Utility.RandomMinMax( 1, amount );

					if ( amount < 2 || lose == amount )
					{
						m_Log.Delete();
						from.SendMessage( "The robot tries to cut the logs but ruins all of the wood." );
					}
					else
					{
						m_Log.Amount = amount - lose;
						from.SendMessage( "The robot tries to cut the logs but ruins some of the wood." );
					}

					from.PlaySound( 0x21C );
				}
			}
			else
			{
				from.SendMessage( "The robot doesn't know what to do with that." );
			}
			return base.OnDragDrop( from, dropped );
		}

		public override int GetAttackSound()
		{
			return 0x21C;
		}

		public Robot( Serial serial ) : base( serial ) 
		{ 
		} 

		public override bool OnBeforeDeath()
		{
			Effects.SendLocationEffect(this.Location, this.Map, 0x36B0, 9, 10, 0, 0);
			this.PlaySound( 0x307 );
			this.AIObject.DoOrderRelease();
			return false;
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
			LeaveNowTimer thisTimer = new LeaveNowTimer( this ); 
			thisTimer.Start(); 
		} 
	}
}