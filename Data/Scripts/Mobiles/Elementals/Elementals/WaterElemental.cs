using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "an elemental corpse" )]
	public class WaterElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		public override int BreathPhysicalDamage{ get{ return 50; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 50; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectSound{ get{ return 0x012; } }
		public override int BreathEffectItemID{ get{ return 0x1A85; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 30 ); }

		[Constructable]
		public WaterElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a water elemental";
			Body = 16;
			BaseSoundID = 278;
			CanSwim = true;

			if ( Utility.RandomMinMax(1,5) == 1 )
			{
				Body = 224;
				Hue = 0xB3E;
				SetStr( 226, 255 );
				SetDex( 166, 185 );
				SetInt( 201, 225 );

				SetHits( 176, 193 );

				SetDamage( 12, 16 );

				SetDamageType( ResistanceType.Physical, 100 );

				SetResistance( ResistanceType.Physical, 45, 55 );
				SetResistance( ResistanceType.Fire, 20, 35 );
				SetResistance( ResistanceType.Cold, 20, 35 );
				SetResistance( ResistanceType.Poison, 70, 80 );
				SetResistance( ResistanceType.Energy, 15, 20 );

				SetSkill( SkillName.Psychology, 70.1, 85.0 );
				SetSkill( SkillName.Magery, 70.1, 85.0 );
				SetSkill( SkillName.MagicResist, 100.1, 115.0 );
				SetSkill( SkillName.Tactics, 60.1, 80.0 );
				SetSkill( SkillName.FistFighting, 60.1, 80.0 );

				Fame = 7500;
				Karma = -7500;

				VirtualArmor = 50;
				ControlSlots = 3;

				PackItem( new SeaSalt( Utility.RandomMinMax(5,15) ) );
				PackItem( new WaterBottle() );
				if ( Utility.RandomBool() )
					PackItem( new WaterBottle() );
			}
			else
			{
				if ( Utility.RandomBool() )
				{
					Body = 977;
					Hue = Utility.RandomList( 0xBA7, 0xB3F, 0xB3D );
				}

				SetStr( 126, 155 );
				SetDex( 66, 85 );
				SetInt( 101, 125 );

				SetHits( 76, 93 );

				SetDamage( 7, 9 );

				SetDamageType( ResistanceType.Physical, 100 );

				SetResistance( ResistanceType.Physical, 35, 45 );
				SetResistance( ResistanceType.Fire, 10, 25 );
				SetResistance( ResistanceType.Cold, 10, 25 );
				SetResistance( ResistanceType.Poison, 60, 70 );
				SetResistance( ResistanceType.Energy, 5, 10 );

				SetSkill( SkillName.Psychology, 60.1, 75.0 );
				SetSkill( SkillName.Magery, 60.1, 75.0 );
				SetSkill( SkillName.MagicResist, 100.1, 115.0 );
				SetSkill( SkillName.Tactics, 50.1, 70.0 );
				SetSkill( SkillName.FistFighting, 50.1, 70.0 );

				Fame = 4500;
				Karma = -4500;

				VirtualArmor = 40;
				ControlSlots = 3;

				PackItem( new SeaSalt( Utility.RandomMinMax(3,9) ) );
				PackItem( new WaterBottle() ); 
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.MedPotions );
			if ( Body == 224 ){ AddLoot( LootPack.Rich ); }
		}

		public override bool BleedImmune{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 2; } }

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( Utility.RandomMinMax( 1, 4 ) == 1 && ( this.Fame > 4500 || this.WhisperHue == 999 ) )
			{
				int goo = 0;

				foreach ( Item splash in this.GetItemsInRange( 10 ) ){ if ( splash is MonsterSplatter && splash.Name == "freezing water" ){ goo++; } }

				if ( goo == 0 )
				{
					MonsterSplatter.AddSplatter( this.X, this.Y, this.Z, this.Map, this.Location, this, "freezing water", 296, 0 );
				}
			}
		}

		public WaterElemental( Serial serial ) : base( serial )
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