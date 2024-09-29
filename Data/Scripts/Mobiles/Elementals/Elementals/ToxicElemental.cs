using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "an elemental corpse" )]
	public class ToxicElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 140.5; } }
		public override double DispelFocus{ get{ return 30.0; } }

		public override int BreathPhysicalDamage{ get{ return 50; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 50; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x48F; } }
		public override int BreathEffectSound{ get{ return 0x012; } }
		public override int BreathEffectItemID{ get{ return 0x1A85; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 36 ); }

		[Constructable]
		public ToxicElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an acid elemental";
			Body = 16;
			Hue = 60;
			BaseSoundID = 278;

			if ( Utility.RandomMinMax(1,5) == 1 )
			{
				Body = 224;
				Hue = 0;
				SetStr( 426, 455 );
				SetDex( 166, 185 );
				SetInt( 371, 395 );

				SetHits( 296, 313 );

				SetDamage( 14, 20 );

				SetDamageType( ResistanceType.Physical, 50 );
				SetDamageType( ResistanceType.Poison, 50 );

				SetResistance( ResistanceType.Physical, 55, 65 );
				SetResistance( ResistanceType.Poison, 50, 60 );
				SetResistance( ResistanceType.Fire, 30, 40 );
				SetResistance( ResistanceType.Cold, 20, 30 );
				SetResistance( ResistanceType.Energy, 40, 50 );

				SetSkill( SkillName.Anatomy, 40.3, 90.0 );
				SetSkill( SkillName.Psychology, 80.1, 95.0 );
				SetSkill( SkillName.Magery, 80.1, 95.0 );
				SetSkill( SkillName.MagicResist, 70.1, 85.0 );
				SetSkill( SkillName.Tactics, 90.1, 100.0 );
				SetSkill( SkillName.FistFighting, 80.1, 100.0 );

				Fame = 12000;
				Karma = -12000;

				VirtualArmor = 50;

				PackItem( new BottleOfAcid() );
				if ( Utility.RandomBool() ){ PackItem( new BottleOfAcid() ); }
			}
			else
			{
				if ( Utility.RandomBool() )
				{
					Body = 977;
					Hue = 0xB51;
				}

				SetStr( 326, 355 );
				SetDex( 66, 85 );
				SetInt( 271, 295 );

				SetHits( 196, 213 );

				SetDamage( 9, 15 );

				SetDamageType( ResistanceType.Physical, 50 );
				SetDamageType( ResistanceType.Poison, 50 );

				SetResistance( ResistanceType.Physical, 45, 55 );
				SetResistance( ResistanceType.Poison, 40, 50 );
				SetResistance( ResistanceType.Fire, 20, 30 );
				SetResistance( ResistanceType.Cold, 10, 20 );
				SetResistance( ResistanceType.Energy, 30, 40 );

				SetSkill( SkillName.Anatomy, 30.3, 60.0 );
				SetSkill( SkillName.Psychology, 70.1, 85.0 );
				SetSkill( SkillName.Magery, 70.1, 85.0 );
				SetSkill( SkillName.MagicResist, 60.1, 75.0 );
				SetSkill( SkillName.Tactics, 80.1, 90.0 );
				SetSkill( SkillName.FistFighting, 70.1, 90.0 );

				Fame = 10000;
				Karma = -10000;

				VirtualArmor = 40;
			}

			PackItem( new BottleOfAcid() );
			PackItem( new BottleOfAcid() );
			if ( Utility.RandomBool() ){ PackItem( new BottleOfAcid() ); }
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			if ( Body == 224 ){ AddLoot( LootPack.FilthyRich ); }
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override double HitPoisonChance{ get{ return 0.6; } }
		public override int TreasureMapLevel{ get{ return Core.AOS ? 2 : 3; } }

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( Utility.RandomMinMax( 1, 4 ) == 1 && this.Fame > 10000 )
			{
				int goo = 0;

				foreach ( Item splash in this.GetItemsInRange( 10 ) ){ if ( splash is MonsterSplatter && splash.Name == "acidic slime" ){ goo++; } }

				if ( goo == 0 )
				{
					MonsterSplatter.AddSplatter( this.X, this.Y, this.Z, this.Map, this.Location, this, "acidic slime", 1167, 0 );
				}
			}
		}

		public ToxicElemental( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 263 )
				BaseSoundID = 278;

			if ( Body == 13 )
				Body = 0x9E;

			if ( Hue == 0x4001 )
				Hue = 0;
		}
	}
}