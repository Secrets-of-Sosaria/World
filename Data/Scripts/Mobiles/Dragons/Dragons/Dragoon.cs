using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Misc;
using Server.Regions;

namespace Server.Mobiles
{

	[CorpseName( "a dragoon corpse" )]
	public class Dragoon : BaseMount
	{
		[Constructable]
		public Dragoon() : this( "a dragoon", 59, 0 )
		{
		}

		[Constructable]
		public Dragoon( string name, int body, int hue ) : base( name, 59, 586, AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a dragoon";
			Body = 59;
			BaseSoundID = 362;
			MakeDragoon();

			if ( Body == 609 )
			{
				Name = NameList.RandomName( "dragon" );
				Title = "the ancient dragoon";

				SetStr( 796, 825 );
				SetDex( 86, 105 );
				SetInt( 436, 475 );

				SetHits( 478, 495 );

				SetDamage( 16, 22 );

				SetDamageType( ResistanceType.Physical, 100 );

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

				Fame = 15000;
				Karma = -15000;

				VirtualArmor = 60;

				Tamable = true;
				ControlSlots = 3;
				MinTameSkill = 93.9;
			}
			else if ( Body == 589 )
			{
				SetStr( 401, 430 );
				SetDex( 133, 152 );
				SetInt( 101, 140 );

				SetHits( 241, 258 );

				SetDamage( 11, 17 );

				SetDamageType( ResistanceType.Physical, 80 );
				SetDamageType( ResistanceType.Fire, 20 );

				SetResistance( ResistanceType.Physical, 45, 50 );
				SetResistance( ResistanceType.Fire, 50, 60 );
				SetResistance( ResistanceType.Cold, 40, 50 );
				SetResistance( ResistanceType.Poison, 20, 30 );
				SetResistance( ResistanceType.Energy, 30, 40 );

				SetSkill( SkillName.MagicResist, 65.1, 80.0 );
				SetSkill( SkillName.Tactics, 65.1, 90.0 );
				SetSkill( SkillName.FistFighting, 65.1, 80.0 );

				Fame = 5500;
				Karma = -5500;

				VirtualArmor = 46;

				Tamable = true;
				ControlSlots = 2;
				MinTameSkill = 75.9;
			}
			else
			{
				SetStr( 636, 660 );
				SetDex( 68, 84 );
				SetInt( 348, 396 );

				SetHits( 382, 396 );

				SetDamage( 12, 17 );

				SetDamageType( ResistanceType.Physical, 100 );

				SetResistance( ResistanceType.Physical, 44, 54 );
				SetResistance( ResistanceType.Fire, 48, 58 );
				SetResistance( ResistanceType.Cold, 24, 34 );
				SetResistance( ResistanceType.Poison, 20, 30 );
				SetResistance( ResistanceType.Energy, 28, 38 );

				SetSkill( SkillName.Psychology, 24.1, 34.0 );
				SetSkill( SkillName.Magery, 24.1, 34.0 );
				SetSkill( SkillName.MagicResist, 79.1, 90.0 );
				SetSkill( SkillName.Tactics, 77.6, 87.0 );
				SetSkill( SkillName.FistFighting, 72.1, 82.5 );

				Fame = 12000;
				Karma = -12000;

				VirtualArmor = 48;

				Tamable = true;
				ControlSlots = 3;
				MinTameSkill = 84.3;
			}
		}

		public void MakeDragoon()
		{
			Body = Utility.RandomList( 609, 610, 602, 603, 655, 589, 604, 610, 602, 603, 655, 589, 604 );

			if ( Body == 609 ){ Name = "ancient dragoon"; }

			if ( Body == 604 ){ ItemID = 596; }
			else if ( Body == 602 ){ ItemID = 595; }
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Body == 602 || Body == 604 ){ base.OnDoubleClick( from ); }
			else
			{
				if ( from.AccessLevel >= AccessLevel.GameMaster && !Body.IsHuman )
				{
					Container pack = this.Backpack;

					if ( pack != null )
						pack.DisplayTo( from );
				}
			}
		}

		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType
		{
			get
			{
				if ( Body == 604 )
					return ( ScaleType.Red );
				else
					return ( ScaleType.Black );
			} 
		}
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }
		public override int Skin{ get{ return Utility.Random(3); } }
		public override SkinType SkinType{ get{ return SkinType.Dragon; } }
		public override int Skeletal{ get{ return Utility.Random(3); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Draco; } }

		public Dragoon( Serial serial ) : base( serial )
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