using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a savage corpse" )]
	public class SavageLord : BaseCreature
	{
		[Constructable]
		public SavageLord() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "savage shaman" );
			Title = "the chieftain";
			Body = 230;

			SetStr( 536, 585 );
			SetDex( 126, 145 );
			SetInt( 281, 305 );

			SetHits( 322, 351 );

			SetDamage( 13, 16 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 25, 35 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.Psychology, 85.1, 100.0 );
			SetSkill( SkillName.Magery, 85.1, 100.0 );
			SetSkill( SkillName.MagicResist, 80.2, 110.0 );
			SetSkill( SkillName.Tactics, 60.1, 80.0 );
			SetSkill( SkillName.FistFighting, 40.1, 50.0 );

			Fame = 11500;
			Karma = -11500;

			VirtualArmor = 40;

			Item feathers = new Feather();
			feathers.Amount = Utility.RandomMinMax(5,15);
			PackItem( feathers );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.MedScrolls );
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Mobile killer = this.LastKiller;

			if ( killer is BaseCreature )
				killer = ((BaseCreature)killer).GetMaster();

			if ( killer is PlayerMobile )
			{
				if ( GetPlayerInfo.LuckyKiller( killer.Luck ) && Server.Misc.IntelligentAction.FameBasedEvent( this ) )
				{
					LootChest MyBag = new LootChest( Server.Misc.IntelligentAction.FameBasedLevel( this ) );
					MyBag.Locked = false;
					MyBag.TrapType = TrapType.None;
					MyBag.TrapLevel = 0;
					MyBag.ItemID = Utility.RandomMinMax( 0x5776, 0x5777 );
					ResourceMods.SetRandomResource( false, false, MyBag, CraftResource.RegularLeather, false, null );
					MyBag.Hue = CraftResources.GetHue(MyBag.Resource);
					MyBag.Name = "chieftain pouch";
					MyBag.DropSound = 72;
					MyBag.GumpID = 61;
					c.DropItem( MyBag );
				}
				if ( GetPlayerInfo.LuckyKiller( killer.Luck ) )
				{
					Item mask = new SavageMask();
					switch( Utility.RandomMinMax( 0, 2 ) )
					{
						case 1: mask.Delete(); mask = new HornedTribalMask(); break;
						case 2: mask.Delete(); mask = new TribalMask(); break;
					}
					int attributeCount = Utility.RandomMinMax(1,5);
					int min = Utility.RandomMinMax(4,10);
					int max = min + 10;
					BaseRunicTool.ApplyAttributesTo( (BaseHat)mask, attributeCount, min, max );
					mask.Name = "chieftain tribal mask";
					c.DropItem( mask );
				}
			}
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 2; } }
		public override int Skeletal{ get{ return Utility.Random(3); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Brittle; } }

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

		public SavageLord( Serial serial ) : base( serial )
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