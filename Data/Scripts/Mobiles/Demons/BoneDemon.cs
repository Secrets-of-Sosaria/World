using System;
using Server;
using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a bone demon corpse" )]
	public class BoneDemon : BaseCreature
	{
		[Constructable]
		public BoneDemon() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a bone demon";
			Body = 339;
			BaseSoundID = 0x48D;
			Hue = 0x80F;

			SetStr( 451, 575 );
			SetDex( 151, 175 );
			SetInt( 171, 220 );

			SetHits( 451, 575 );

			SetDamage( 26, 32 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Cold, 50 );

			SetResistance( ResistanceType.Physical, 75 );
			SetResistance( ResistanceType.Fire, 60 );
			SetResistance( ResistanceType.Cold, 90 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 60 );

			SetSkill( SkillName.Searching, 80.0 );
			SetSkill( SkillName.Psychology, 77.6, 87.5 );
			SetSkill( SkillName.Magery, 77.6, 87.5 );
			SetSkill( SkillName.Meditation, 100.0 );
			SetSkill( SkillName.MagicResist, 50.1, 75.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.FistFighting, 100.0 );

			Fame = 10000;
			Karma = -10000;

			VirtualArmor = 34;

			PackItem( new BoneContainer() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 5 );
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
						switch( Utility.RandomMinMax( 0, 5 ) )
						{
							case 0: armor = new BoneLegs();		break;
							case 1: armor = new BoneGloves();	break;
							case 2: armor = new BoneArms();		break;
							case 3: armor = new BoneChest();	break;
							case 4: armor = new BoneHelm();		break;
							case 5: armor = new BoneSkirt();	break;
						}
						ResourceMods.SetRandomResource( false, true, armor, CraftResource.None, false, this );
						BaseRunicTool.ApplyAttributesTo( armor, false, 1000, 5, 25, 100 );
						c.DropItem( armor );
					}
				}
			}
		}

		public override bool Unprovokable { get { return Core.SE; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 1; } }

		public BoneDemon( Serial serial ) : base( serial )
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