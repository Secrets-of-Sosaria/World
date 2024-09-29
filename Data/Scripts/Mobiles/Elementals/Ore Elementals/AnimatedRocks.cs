using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "an elemental corpse" )]
	public class AnimatedRocks : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 120.5; } }
		public override double DispelFocus{ get{ return 35.0; } }

		public override int BreathPhysicalDamage{ get{ return 50; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 50; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return this.Hue; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override int BreathEffectItemID{ get{ return 0; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 33 ); }

		[Constructable]
		public AnimatedRocks() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x56F;
			Body = 142;
			Name = "animated rocks";

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

			SetStr( 226, 255 );
			SetDex( 126, 145 );
			SetInt( 71, 92 );

			SetHits( 136, 153 );

			SetDamage( 28 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 40 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 5, 10 );

			SetSkill( SkillName.MagicResist, 50.1, 95.0 );
			SetSkill( SkillName.Tactics, 60.1, 100.0 );
			SetSkill( SkillName.FistFighting, 60.1, 100.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 32;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, 2 );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override bool AutoDispel{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 1; } }
		public override int Rocks{ get{ return Utility.RandomMinMax( 5, 10 ); } }
		public override RockType RockType{ get{ return ResourceRocks(); } }

		public AnimatedRocks( Serial serial ) : base( serial )
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
