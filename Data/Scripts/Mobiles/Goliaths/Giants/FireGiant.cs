using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a giant corpse" )]
	public class FireGiant : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 100; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 17 ); }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.Dismount;
		}

		[Constructable]
		public FireGiant() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "giant" );
			Title = "the fire giant";
			Body = Utility.RandomList( 774, 996 );
			BaseSoundID = 609;

			SetStr( 536, 585 );
			SetDex( 126, 145 );
			SetInt( 281, 305 );

			SetHits( 322, 351 );
			SetMana( 0 );

			SetDamage( 16, 23 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Fire, 50 );

			SetResistance( ResistanceType.Physical, 45, 50 );
			SetResistance( ResistanceType.Fire, 70, 80 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 60.3, 105.0 );
			SetSkill( SkillName.Tactics, 80.1, 100.0 );
			SetSkill( SkillName.FistFighting, 80.1, 90.0 );

			Fame = 11000;
			Karma = -11000;

			VirtualArmor = 48;

			AddItem( new LighterSource() );
		}

		public override int GetAttackSound(){ return 0x5F8; }	// A
		public override int GetDeathSound(){ return 0x5F9; }	// D
		public override int GetHurtSound(){ return 0x5FA; }		// H

		public override void OnDeath( Container c )
		{
			Region reg = Region.Find( this.Location, this.Map );

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					if ( GetPlayerInfo.LuckyKiller( killer.Luck ) && Utility.RandomMinMax( 1, 4 ) == 1 )
					{
						LootChest MyChest = new LootChest( Server.Misc.IntelligentAction.FameBasedLevel( this ) );
						MyChest.ItemID = Utility.RandomList( 0x1248, 0x1264, 0x55DD, 0x577E );
						MyChest.GumpID = 0x3D;
						MyChest.TrapType = TrapType.None;
						MyChest.Locked = false;
						MyChest.Name = "fire giant sack";
						MyChest.Hue = 0x489;
						c.DropItem( MyChest );
					}
					if ( GetPlayerInfo.LuckyKiller( killer.Luck ) && Utility.RandomMinMax( 1, 10 ) == 1 )
					{
						c.DropItem( new FireGiantForge() );
					}
					if ( GetPlayerInfo.LuckyKiller( killer.Luck ) && Utility.RandomMinMax( 1, 5 ) == 1 && Body == 996 )
					{
						BaseWeapon hammer = new WarHammer();
						hammer.Name = "fire giant hammer";
						hammer.ItemID = 0x267C;
						hammer.Hue = 0xB73;
						hammer.SkillBonuses.SetValues( 0, SkillName.Bludgeoning, 10 );
						hammer.SkillBonuses.SetValues( 1, SkillName.Tactics, 10 );
						hammer.WeaponAttributes.ResistFireBonus = 15;
						hammer.Attributes.WeaponDamage = 50;
						hammer.Attributes.AttackChance = 10;
           				hammer.Slayer = SlayerName.WaterDissipation;
						hammer.AccuracyLevel = WeaponAccuracyLevel.Supremely;
						hammer.MinDamage = hammer.MinDamage + 6;
						hammer.MaxDamage = hammer.MaxDamage + 10;
            			hammer.DurabilityLevel = WeaponDurabilityLevel.Indestructible;
						hammer.AosElementDamages.Fire = 50;
						hammer.AosElementDamages.Physical = 50;
						c.DropItem( hammer );
					}
				}
			}

			base.OnDeath( c );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
		}

		public override int Meat{ get{ return 4; } }
		public override int TreasureMapLevel{ get{ return 3; } }
		public override int Hides{ get{ return 18; } }
		public override HideType HideType{ get{ if ( Utility.RandomBool() ){ return HideType.Volcanic; } else { return HideType.Goliath; } } }
		public override int Skeletal{ get{ return Utility.Random(5); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Colossal; } }

		public FireGiant( Serial serial ) : base( serial )
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