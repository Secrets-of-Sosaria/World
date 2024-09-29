using System;
using System.Collections;
using Server.Items;
using Server.Misc;
using Server.Targeting;
using Server.Regions;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a ghostly essence" )]
	public class Kull : BaseCreature
	{
		[Constructable]
		public Kull() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Spirit of Kull";
			Title = "the Wyrm Guard";
			BaseSoundID = 412;
			Hue = 1150;
			Body = 0x190;

			SetStr( 386, 400 );
			SetDex( 151, 165 );
			SetInt( 161, 175 );

			SetHits( 200, 300 );

			SetDamage( 8, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 25, 30 );
			SetResistance( ResistanceType.Cold, 25, 30 );
			SetResistance( ResistanceType.Poison, 10, 20 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.Searching, 100.0 );
			SetSkill( SkillName.Anatomy, 125.0 );
			SetSkill( SkillName.Poisoning, 60.0, 82.5 );
			SetSkill( SkillName.MagicResist, 83.5, 92.5 );
			SetSkill( SkillName.Swords, 125.0 );
			SetSkill( SkillName.Tactics, 125.0 );

			Fame = 10000;
			Karma = -10000;

			VirtualArmor = 20;

			AddItem( new PlateChest() );
			AddItem( new PlateArms() );
			AddItem( new PlateLegs() );
			AddItem( new PlateGorget() );
			AddItem( new PlateGloves() );
			AddItem( new OrcHelm() );
			AddItem( new Longsword() );
			AddItem( new OrderShield() );

			MorphingTime.BlessMyClothes( this );
			MorphingTime.ColorMyClothes( this, 2817, 0 );

			AddItem( new LightSource() );
			new GhostDragyn().Rider = this;
			ActiveSpeed = 0.1;
			PassiveSpeed = 0.2;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Rich );
		}

		public override bool OnBeforeDeath()
		{
			this.Body = 13;
			this.Hue = 1150;
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

				if ( killer is PlayerMobile )
				{
					if ( GetPlayerInfo.LuckyKiller( killer.Luck ) && Utility.RandomMinMax( 1, 4 ) == 1 )
					{
						Item loot = null;

						switch( Utility.RandomMinMax( 0, 9 ) )
						{
							case 0: loot = new PlateChest(); break;
							case 1: loot = new PlateArms(); break;
							case 2: loot = new PlateLegs(); break;
							case 3: loot = new PlateGorget(); break;
							case 4: loot = new PlateGloves(); break;
							case 5: loot = new OrcHelm(); break;
							case 6: loot = new Longsword(); break;
							case 7: loot = new OrderShield(); break;
							case 8: loot = new Boots(); break;
							case 9: loot = Loot.RandomJewelry(); break;
						}

						if ( loot != null )
						{
							ResourceMods.SetResource( loot, CraftResource.WyrmSpec );
							loot = Server.LootPackEntry.Enchant( killer, 500, loot );
							loot.InfoText1 = "Kull the Wyrm Guard";
							c.DropItem( loot ); 
						}
					}
				}
			}
		}

		public override bool ShowFameTitle{ get{ return false; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 3; } }
		public override bool AlwaysAttackable{ get{ return true; } }

		public Kull( Serial serial ) : base( serial )
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