using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "an elemental corpse" )]
	public class AnyGemElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 120.5; } }
		public override double DispelFocus{ get{ return 35.0; } }
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
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 22 ); }

		public string RealName;
		[CommandProperty( AccessLevel.GameMaster )]
		public string p_RealName { get{ return RealName; } set{ RealName = value; } }

		[Constructable]
		public AnyGemElemental() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a grue";
			BaseSoundID = 0x56F;
			Body = 142;

			switch ( Utility.RandomMinMax( 1, 7 ) )
			{
				case 1:	RealName = "a garnet grue"; break;
				case 2:	RealName = "an obsidian grue"; break;
				case 3:	RealName = "a quartz grue"; break;
				case 4:	RealName = "a silver grue"; break;
				case 5:	RealName = "a spinel grue"; break;
				case 6:	RealName = "a star ruby grue"; break;
				case 7:	RealName = "a topaz grue"; break;
			}

			if ( RealName == "a garnet grue" )
			{
				Resource = CraftResource.GarnetBlock;
				Hue = CraftResources.GetClr(Resource);

				SetStr( 256, 385 );
				SetDex( 196, 215 );
				SetInt( 221, 242 );

				SetHits( 194, 211 );

				SetDamage( 18, 29 );

				SetDamageType( ResistanceType.Physical, 100 );

				SetResistance( ResistanceType.Physical, 35, 45 );
				SetResistance( ResistanceType.Fire, 20, 30 );
				SetResistance( ResistanceType.Cold, 20, 30 );
				SetResistance( ResistanceType.Poison, 20, 30 );
				SetResistance( ResistanceType.Energy, 20, 30 );

				SetSkill( SkillName.Psychology, 40.5, 90.0 );
				SetSkill( SkillName.Magery, 40.5, 90.0 );
				SetSkill( SkillName.MagicResist, 60.1, 110.0 );
				SetSkill( SkillName.Tactics, 100.1, 130.0 );
				SetSkill( SkillName.FistFighting, 90.1, 120.0 );

				Fame = 7000;
				Karma = -7000;

				VirtualArmor = 60;
			}
			else if ( RealName == "an obsidian grue" )
			{
				Resource = CraftResource.Obsidian;
				Hue = CraftResources.GetClr(Resource);

				SetStr( 226, 255 );
				SetDex( 126, 145 );
				SetInt( 71, 92 );

				SetHits( 136, 153 );

				SetDamage( 9, 16 );

				SetDamageType( ResistanceType.Physical, 100 );

				SetResistance( ResistanceType.Physical, 60, 75 );
				SetResistance( ResistanceType.Fire, 10, 20 );
				SetResistance( ResistanceType.Cold, 30, 40 );
				SetResistance( ResistanceType.Poison, 30, 40 );
				SetResistance( ResistanceType.Energy, 30, 40 );

				SetSkill( SkillName.MagicResist, 50.1, 95.0 );
				SetSkill( SkillName.Tactics, 60.1, 100.0 );
				SetSkill( SkillName.FistFighting, 60.1, 100.0 );

				Fame = 3500;
				Karma = -3500;

				VirtualArmor = 60;
			}
			else if ( RealName == "a quartz grue" )
			{
				Resource = CraftResource.QuartzBlock;
				Hue = CraftResources.GetClr(Resource);

				SetStr( 256, 385 );
				SetDex( 196, 215 );
				SetInt( 221, 242 );

				SetHits( 194, 211 );

				SetDamage( 18, 29 );

				SetDamageType( ResistanceType.Physical, 100 );

				SetResistance( ResistanceType.Physical, 35, 45 );
				SetResistance( ResistanceType.Fire, 5, 10 );
				SetResistance( ResistanceType.Cold, 50, 60 );
				SetResistance( ResistanceType.Poison, 20, 30 );
				SetResistance( ResistanceType.Energy, 20, 30 );

				SetSkill( SkillName.Psychology, 40.5, 90.0 );
				SetSkill( SkillName.Magery, 40.5, 90.0 );
				SetSkill( SkillName.MagicResist, 60.1, 110.0 );
				SetSkill( SkillName.Tactics, 100.1, 130.0 );
				SetSkill( SkillName.FistFighting, 90.1, 120.0 );

				Fame = 7000;
				Karma = -7000;

				VirtualArmor = 60;
			}
			else if ( RealName == "a silver grue" )
			{
				Resource = CraftResource.SilverBlock;
				Hue = CraftResources.GetClr(Resource);

				SetStr( 126, 155 );
				SetDex( 66, 85 );
				SetInt( 71, 92 );

				SetHits( 76, 93 );

				SetDamage( 9, 16 );

				SetDamageType( ResistanceType.Physical, 100 );

				SetResistance( ResistanceType.Physical, 30, 35 );
				SetResistance( ResistanceType.Fire, 10, 20 );
				SetResistance( ResistanceType.Cold, 10, 20 );
				SetResistance( ResistanceType.Poison, 15, 25 );
				SetResistance( ResistanceType.Energy, 15, 25 );

				SetSkill( SkillName.MagicResist, 50.1, 95.0 );
				SetSkill( SkillName.Tactics, 60.1, 100.0 );
				SetSkill( SkillName.FistFighting, 60.1, 100.0 );

				Fame = 3500;
				Karma = -3500;

				VirtualArmor = 34;
			}
			else if ( RealName == "a spinel grue" )
			{
				Resource = CraftResource.SpinelBlock;
				Hue = CraftResources.GetClr(Resource);

				SetStr( 256, 385 );
				SetDex( 196, 215 );
				SetInt( 221, 242 );

				SetHits( 194, 211 );

				SetDamage( 18, 29 );

				SetDamageType( ResistanceType.Physical, 100 );

				SetResistance( ResistanceType.Physical, 35, 45 );
				SetResistance( ResistanceType.Fire, 5, 10 );
				SetResistance( ResistanceType.Cold, 50, 60 );
				SetResistance( ResistanceType.Poison, 20, 30 );
				SetResistance( ResistanceType.Energy, 20, 30 );

				SetSkill( SkillName.Psychology, 40.5, 90.0 );
				SetSkill( SkillName.Magery, 40.5, 90.0 );
				SetSkill( SkillName.MagicResist, 60.1, 110.0 );
				SetSkill( SkillName.Tactics, 100.1, 130.0 );
				SetSkill( SkillName.FistFighting, 90.1, 120.0 );

				Fame = 7000;
				Karma = -7000;

				VirtualArmor = 60;
			}
			else if ( RealName == "a star ruby grue" )
			{
				Resource = CraftResource.StarRubyBlock;
				Hue = CraftResources.GetClr(Resource);

				SetStr( 256, 385 );
				SetDex( 196, 215 );
				SetInt( 221, 242 );

				SetHits( 194, 211 );

				SetDamage( 18, 29 );

				SetDamageType( ResistanceType.Physical, 100 );

				SetResistance( ResistanceType.Physical, 35, 45 );
				SetResistance( ResistanceType.Fire, 5, 10 );
				SetResistance( ResistanceType.Cold, 50, 60 );
				SetResistance( ResistanceType.Poison, 20, 30 );
				SetResistance( ResistanceType.Energy, 20, 30 );

				SetSkill( SkillName.Psychology, 40.5, 90.0 );
				SetSkill( SkillName.Magery, 40.5, 90.0 );
				SetSkill( SkillName.MagicResist, 60.1, 110.0 );
				SetSkill( SkillName.Tactics, 100.1, 130.0 );
				SetSkill( SkillName.FistFighting, 90.1, 120.0 );

				Fame = 7000;
				Karma = -7000;

				VirtualArmor = 60;
			}
			else if ( RealName == "a topaz grue" )
			{
				Resource = CraftResource.TopazBlock;
				Hue = CraftResources.GetClr(Resource);

				SetStr( 256, 385 );
				SetDex( 196, 215 );
				SetInt( 221, 242 );

				SetHits( 194, 211 );

				SetDamage( 18, 29 );

				SetDamageType( ResistanceType.Physical, 100 );

				SetResistance( ResistanceType.Physical, 35, 45 );
				SetResistance( ResistanceType.Fire, 5, 10 );
				SetResistance( ResistanceType.Cold, 50, 60 );
				SetResistance( ResistanceType.Poison, 20, 30 );
				SetResistance( ResistanceType.Energy, 20, 30 );

				SetSkill( SkillName.Psychology, 40.5, 90.0 );
				SetSkill( SkillName.Magery, 40.5, 90.0 );
				SetSkill( SkillName.MagicResist, 60.1, 110.0 );
				SetSkill( SkillName.Tactics, 100.1, 130.0 );
				SetSkill( SkillName.FistFighting, 90.1, 120.0 );

				Fame = 7000;
				Karma = -7000;

				VirtualArmor = 60;
			}

			AddItem( new LightSource() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, 2 );
		}

		public override int Rocks{ get{ return Utility.RandomMinMax( 5, 10 ); } }
		public override RockType RockType{ get{ return ResourceRocks(); } }

		public override void CheckReflect( Mobile caster, ref bool reflect )
		{
			if ( Utility.RandomMinMax( 1, 3 ) == 1 ){ reflect = true; } // 25% spells are reflected back to the caster
			else { reflect = false; }
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			if ( this.Body == 13 && willKill == false && Utility.Random( 4 ) == 1 )
			{
				this.BaseSoundID = 0x56F;
				this.Body = 142;
			}
			else if ( willKill == false && Utility.Random( 4 ) == 1 )
			{
				this.Body = 13;
				this.BaseSoundID = 655;
			}

			base.OnDamage( amount, from, willKill );
		}

		public override bool OnBeforeDeath()
		{
			this.Body = 13;
			this.BaseSoundID = 655;
			return base.OnBeforeDeath();
		}

		public override bool BleedImmune{ get{ return true; } }
		public override bool AutoDispel{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 2; } }

		public AnyGemElemental( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( RealName );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			RealName = reader.ReadString();
		}
	}
}
