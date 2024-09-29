using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a dragon turtle corpse" )]
	public class DragonTurtle : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 100; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x9C4; } }
		public override int BreathEffectSound{ get{ return 0x108; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 16 ); }

		[Constructable]
		public DragonTurtle () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the dragon turtle";
			Body = 767;
			BaseSoundID = 362;
			CanSwim = true;
			Resource = CraftResource.GreenScales;

			SetStr( 867, 1045 );
			SetDex( 86, 105 );
			SetInt( 46, 70 );

			SetHits( 576, 652 );

			SetDamage( 22, 28 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 16000;
			Karma = -16000;

			VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 99.9;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					if ( GetPlayerInfo.LuckyKiller( killer.Luck ) && Utility.RandomMinMax( 1, 4 ) == 1 )
					{
						BaseArmor armor = null;

						switch ( Utility.RandomMinMax( 0, 5 ) )
						{
							case 0: armor = new PlateArms();	armor.Resource = CraftResource.TurtleSpec;		c.DropItem( armor );	break;
							case 1: armor = new PlateChest();	armor.Resource = CraftResource.TurtleSpec;		c.DropItem( armor );	break;
							case 2: armor = new PlateGloves();	armor.Resource = CraftResource.TurtleSpec;		c.DropItem( armor );	break;
							case 3: armor = new PlateGorget();	armor.Resource = CraftResource.TurtleSpec;		c.DropItem( armor );	break;
							case 4: armor = new PlateLegs();	armor.Resource = CraftResource.TurtleSpec;		c.DropItem( armor );	break;
							case 5: armor = new DreadHelm();	armor.Resource = CraftResource.TurtleSpec;		c.DropItem( armor );	break;
						}
					}
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 2 );
			AddLoot( LootPack.FilthyRich, 1 );
			AddLoot( LootPack.Gems, 3 );
		}

		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 10; } }
		public override MeatType MeatType{ get{ return MeatType.Fish; } }
		public override int Hides{ get{ return 12; } }
		public override HideType HideType{ get{ if ( Utility.RandomBool() ){ return HideType.Spined; } else { return HideType.Draconic; } } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ResourceScales(); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public DragonTurtle( Serial serial ) : base( serial )
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