using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a skeletal corpse" )]
	public class BoneSailor : BaseCreature
	{
		[Constructable]
		public BoneSailor() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			switch ( Utility.RandomMinMax( 0, 4 ) )
			{
				case 0: Name = "an undead sailor"; break;
				case 1: Name = "an undead pirate"; break;
				case 2: Name = "an undead buccaneer"; break;
				case 3: Name = "an undead fisherman"; break;
				case 4: Name = "an undead captain"; break;
			}
			Body = Utility.RandomList( 147, 57, 50, 56, 167, 168, 170 );
			BaseSoundID = 451;
			Hue = 2967;

			SetStr( 196, 250 );
			SetDex( 76, 95 );
			SetInt( 36, 60 );

			SetHits( 118, 150 );

			SetDamage( 8, 18 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Cold, 60 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 85.1, 100.0 );
			SetSkill( SkillName.FistFighting, 85.1, 95.0 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 40;

			if ( 1 == Utility.RandomMinMax( 0, 2 ) )
			{
				LootBag MyBag = new LootBag( Utility.RandomMinMax( 2, 5 ) );
				MyBag.Name = "soggy bag";
				MyBag.Hue = 2967;
				PackItem( MyBag );
			}

			PackItem( Loot.RandomWeapon() );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override int Skeletal{ get{ return Utility.Random(3); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Brittle; } }

		public BoneSailor( Serial serial ) : base( serial )
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