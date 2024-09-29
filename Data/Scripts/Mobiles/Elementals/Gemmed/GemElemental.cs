using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "an elemental corpse" )]
	public class GemElemental : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		public override double DispelDifficulty{ get{ return 120.5; } }
		public override double DispelFocus{ get{ return 35.0; } }

		public override int BreathPhysicalDamage{ get{ return 20; } }
		public override int BreathFireDamage{ get{ return 20; } }
		public override int BreathColdDamage{ get{ return 20; } }
		public override int BreathPoisonDamage{ get{ return 20; } }
		public override int BreathEnergyDamage{ get{ return 20; } }
		public override int BreathEffectHue{ get{ return Hue-1; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override int BreathEffectItemID{ get{ return 0; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 33 ); }

		[Constructable]
		public GemElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an elemental mineral";
			Body = 322;
			BaseSoundID = 268;

			switch ( Utility.RandomMinMax( 0, 23 ) )
			{
				case 0:		Resource = CraftResource.OnyxBlock; break;
				case 1:		Resource = CraftResource.QuartzBlock; break;
				case 2:		Resource = CraftResource.RubyBlock; break;
				case 3:		Resource = CraftResource.SapphireBlock; break;
				case 4:		Resource = CraftResource.SpinelBlock; break;
				case 5:		Resource = CraftResource.TopazBlock; break;
				case 6:		Resource = CraftResource.AmethystBlock; break;
				case 7:		Resource = CraftResource.EmeraldBlock; break;
				case 8:		Resource = CraftResource.GarnetBlock; break;
				case 9:		Resource = CraftResource.SilverBlock; break;
				case 10:	Resource = CraftResource.StarRubyBlock; break;
				case 11:	Resource = CraftResource.JadeBlock; break;
				case 12:	Resource = CraftResource.Copper; break;
				case 13:	Resource = CraftResource.Verite; break;
				case 14:	Resource = CraftResource.Valorite; break;
				case 15:	Resource = CraftResource.Agapite; break;
				case 16:	Resource = CraftResource.Bronze; break;
				case 17:	Resource = CraftResource.DullCopper; break;
				case 18:	Resource = CraftResource.Gold; break;
				case 19:	Resource = CraftResource.ShadowIron; break;
				case 20:	Resource = CraftResource.Mithril; break;
				case 21:	Resource = CraftResource.Xormite; break;
				case 22:	Resource = CraftResource.Obsidian; break;
				case 23:	Resource = CraftResource.Nepturite; break;
			}

			Hue = CraftResources.GetClr(Resource);

			SetStr( 256, 385 );
			SetDex( 196, 215 );
			SetInt( 221, 242 );

			SetHits( 194, 211 );

			SetDamage( 18, 29 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 25, 35 );
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

		public override bool BleedImmune{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 2; } }

		public GemElemental( Serial serial ) : base( serial )
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
