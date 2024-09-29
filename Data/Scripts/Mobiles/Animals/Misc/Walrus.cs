using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a seal corpse" )]
	public class Walrus : BaseCreature
	{
		[Constructable]
		public Walrus() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a seal";
			Body = 0xDD;
			BaseSoundID = 0xE0;

			SetStr( 21, 29 );
			SetDex( 46, 55 );
			SetInt( 16, 20 );

			SetHits( 14, 17 );
			SetMana( 0 );

			SetDamage( 4, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 20, 25 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 5, 10 );

			SetSkill( SkillName.MagicResist, 15.1, 20.0 );
			SetSkill( SkillName.Tactics, 19.2, 29.0 );
			SetSkill( SkillName.FistFighting, 19.2, 29.0 );

			Fame = 150;
			Karma = 0;

			VirtualArmor = 18;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 35.1;

			if ( Utility.RandomList( 1, 5 ) == 1 )
			{
				Name = "a walrus";
				Body = 891;

				SetStr( 41, 69 );
				SetDex( 46, 55 );
				SetInt( 16, 20 );

				SetHits( 34, 47 );
				SetMana( 0 );

				SetDamage( 9, 14 );

				SetResistance( ResistanceType.Physical, 30, 35 );
				SetResistance( ResistanceType.Fire, 15, 20 );
				SetResistance( ResistanceType.Cold, 30, 35 );
				SetResistance( ResistanceType.Poison, 15, 20 );
				SetResistance( ResistanceType.Energy, 15, 20 );

				SetSkill( SkillName.MagicResist, 35.1, 40.0 );
				SetSkill( SkillName.Tactics, 39.2, 59.0 );
				SetSkill( SkillName.FistFighting, 49.2, 59.0 );

				Fame = 350;

				VirtualArmor = 28;

				ControlSlots = 2;
				MinTameSkill = 55.1;
			}
		}

		public override int Meat
		{
			get
			{
				if ( Body == 891 )
					return 4;

				return 1;
			}
		}
		public override int Hides
		{
			get
			{
				if ( Body == 891 )
					return 22;

				return 12;
			}
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Fish; } }

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Mobile killer = this.LastKiller;
			if ( killer != null && Utility.RandomMinMax( 0, 100 ) > 60 )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					if ( GetPlayerInfo.LuckyKiller( killer.Luck ) )
					{
						c.DropItem( new IvoryTusk() );
					}
				}
			}
		}

		public Walrus(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}