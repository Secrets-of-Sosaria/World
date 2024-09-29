using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a skeletal corpse" )]
	public class BoneSlasher : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public BoneSlasher() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a bone slasher";
			Body = 347;
			BaseSoundID = 0x4FB;

			SetStr( 336, 385 );
			SetDex( 496, 515 );
			SetInt( 31, 55 );

			SetHits( 202, 231 );
			SetMana( 0 );

			SetDamage( 7, 23 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 50 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 25, 35 );
			SetResistance( ResistanceType.Poison, 50, 60 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 60.3, 105.0 );
			SetSkill( SkillName.Tactics, 80.1, 100.0 );
			SetSkill( SkillName.FistFighting, 80.1, 90.0 );

			Fame = 5000;
			Karma = -5000;

			VirtualArmor = 48;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
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
						LootChest MyChest = new LootChest( Server.Misc.IntelligentAction.FameBasedLevel( this ) );
						MyChest.Name = "bone carved chest";
						MyChest.ItemID = Utility.RandomList( 0x2DF1, 0x2DF1 );
						MyChest.Hue = 0;
						c.DropItem( MyChest );
					}
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

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return (0.8 >= Utility.RandomDouble() ? Poison.Greater : Poison.Deadly); } }
		public override int Skin{ get{ return Utility.Random(6); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Brittle; } }

		public BoneSlasher( Serial serial ) : base( serial )
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