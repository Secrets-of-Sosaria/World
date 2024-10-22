using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Misc;
using Server.Items;
using Server.Network;
using Server.Commands;
using Server.Commands.Generic;
using Server.Mobiles;
using Server.Accounting;
using Server.Regions;

namespace Server.Mobiles
{
	[CorpseName( "Surtaz's corpse" )]
	public class Surtaz : BaseCreature
	{
		[Constructable]
		public Surtaz() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Surtaz";
			Title = "the fallen";
			Body = 125;
			Hue = 0x9C4;
			BaseSoundID = Utility.RandomList( 0x19C, 0x3E9 );
			EmoteHue = 123;

			SetStr( 986, 1185 );
			SetDex( 177, 255 );
			SetInt( 151, 250 );

			SetHits( 592, 711 );

			SetDamage( 22, 29 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Fire, 25 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 65, 80 );
			SetResistance( ResistanceType.Fire, 60, 80 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Anatomy, 25.1, 50.0 );
			SetSkill( SkillName.Psychology, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 95.5, 100.0 );
			SetSkill( SkillName.Meditation, 25.1, 50.0 );
			SetSkill( SkillName.MagicResist, 100.5, 150.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 24000;
			Karma = -24000;

			VirtualArmor = 90;

			PackReg( 30, 275 );
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );
			GhostlyDust ingut = new GhostlyDust();
   			ingut.Amount = Utility.RandomMinMax( 1, 3 );
   			c.DropItem(ingut);

   			c.DropItem( new StaffPartLight() );

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					if ( GetPlayerInfo.LuckyKiller( killer.Luck ) && Server.Misc.IntelligentAction.FameBasedEvent( this ) )
					{
						LootChest MyChest = new LootChest( Server.Misc.IntelligentAction.FameBasedLevel( this ) );
						Server.Misc.ContainerFunctions.MakeTomb( MyChest, this, 0 );
						c.DropItem( MyChest );
					}
				}
			}
		}

		public override void OnAfterSpawn()
		{
			Server.Misc.IntelligentAction.BeforeMyBirth( this );
			base.OnAfterSpawn();
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );
			Server.Misc.IntelligentAction.DoSpecialAbility( this, attacker );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );
			Server.Misc.IntelligentAction.DoSpecialAbility( this, defender );
		}

		public override bool OnBeforeDeath()
		{
			Server.Misc.IntelligentAction.BeforeMyDeath( this );
			Server.Misc.IntelligentAction.DropItem( this, this.LastKiller );

			SurtazChest MyChest = new SurtazChest();
			MyChest.MoveToWorld( Location, Map );

			QuestGlow MyGlow = new QuestGlow();
			MyGlow.MoveToWorld( Location, Map );

			return base.OnBeforeDeath();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
			AddLoot( LootPack.MedScrolls, 2 );
		}

		public override bool Unprovokable{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Skeletal{ get{ return Utility.Random(10); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Lich; } }

        public override int GetAngerSound()
        {
            return 0x61E;
        }

        public override int GetDeathSound()
        {
            return 0x61F;
        }

        public override int GetHurtSound()
        {
            return 0x620;
        }

        public override int GetIdleSound()
        {
            return 0x621;
        }

		public Surtaz( Serial serial ) : base( serial )
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
		}
	}
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace Server.Items
{
	public class SurtazChest : Item
	{
		[Constructable]
		public SurtazChest() : base( 0xE40 )
		{
			Name = "Surtaz's Vault";
			Movable = false;
			Hue = 0xB85;
			ItemRemovalTimer thisTimer = new ItemRemovalTimer( this ); 
			thisTimer.Start(); 
		}

		public SurtazChest( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.InRange( this.GetWorldLocation(), 2 ) )
			{
				from.SendSound( 0x3D );
				from.PrivateOverheadMessage(MessageType.Regular, 1150, false, "You have pulled Surtaz's Vault toward you.", from.NetState);

				LootChest MyChest = new LootChest( 6 );
				MyChest.Name = "Surtaz's Vault";
				MyChest.Hue = 0xB85;

				if ( from is PlayerMobile )
				{
					if ( GetPlayerInfo.LuckyKiller( from.Luck ) && !Server.Misc.PlayerSettings.GetSpecialsKilled( from, "Surtaz" ) )
					{
						if ( GetPlayerInfo.LuckyKiller( from.Luck ) )
						{
							Item arty = Loot.RandomArty();
							MyChest.DropItem( arty );
						}
						Server.Misc.PlayerSettings.SetSpecialsKilled( from, "Surtaz", true );
						ManualOfItems lexicon = new ManualOfItems();
							lexicon.Hue = 0xB85;
							lexicon.Name = "Chest of Surtaz Relics";
							lexicon.m_Charges = 1;
							lexicon.m_Skill_1 = Utility.RandomList( 31, 36 );
							lexicon.m_Skill_2 = 0;
							lexicon.m_Skill_3 = 0;
							lexicon.m_Skill_4 = 0;
							lexicon.m_Skill_5 = 0;
							lexicon.m_Value_1 = 10.0;
							lexicon.m_Value_2 = 0.0;
							lexicon.m_Value_3 = 0.0;
							lexicon.m_Value_4 = 0.0;
							lexicon.m_Value_5 = 0.0;
							lexicon.m_Slayer_1 = 1;
							lexicon.m_Slayer_2 = 0;
							lexicon.m_Owner = from;
							lexicon.m_Extra = "of Surtaz the Fallen";
							lexicon.m_FromWho = "Taken from Surtaz";
							lexicon.m_HowGiven = "Acquired by";
							lexicon.m_Points = 200;
							lexicon.m_Hue = 0xB85;
							MyChest.DropItem( lexicon );
					}
				}

				MyChest.MoveToWorld( from.Location, from.Map );

				LoggingFunctions.LogGenericQuest( from, "defeated Surtaz the Fallen" );
				this.Delete();
			}
			else
			{
				from.SendLocalizedMessage( 502138 ); // That is too far away for you to use
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
			this.Delete(); // none when the world starts 
		}

		public class ItemRemovalTimer : Timer 
		{ 
			private Item i_item; 
			public ItemRemovalTimer( Item item ) : base( TimeSpan.FromMinutes( 10.0 ) ) 
			{ 
				Priority = TimerPriority.OneSecond; 
				i_item = item; 
			} 

			protected override void OnTick() 
			{ 
				if (( i_item != null ) && ( !i_item.Deleted ))
				{
					i_item.Delete();
				}
			} 
		} 
	}
}