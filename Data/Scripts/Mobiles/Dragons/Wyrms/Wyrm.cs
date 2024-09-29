using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class Wyrm : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public Wyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a draguul";
			Body = Utility.RandomList( 46, 899 );
			BaseSoundID = 362;

			SetStr( 896, 985 );
			SetDex( 86, 175 );
			SetInt( 486, 575 );

			SetHits( 458, 511 );

			SetDamage( 20, 26 );

			SetDamageType( ResistanceType.Physical, 65 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 70, 80 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 50, 60 );
			SetResistance( ResistanceType.Energy, 50, 60 );

			SetSkill( SkillName.Psychology, 70.1, 90.0 );
			SetSkill( SkillName.Magery, 70.1, 90.0 );
			SetSkill( SkillName.Meditation, 42.5, 65.0 );
			SetSkill( SkillName.MagicResist, 90.5, 140.0 );
			SetSkill( SkillName.Tactics, 87.6, 90.0 );
			SetSkill( SkillName.FistFighting, 87.6, 90.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 50;
			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;

			Item Venom = new VenomSack();
				Venom.Name = "venom sack";
				AddItem( Venom );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 1 );
			AddLoot( LootPack.Rich, 1 );
			AddLoot( LootPack.Gems, 4 );
		}

		public override bool AutoDispel{ get{ return true; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Hides{ get{ return 30; } }
		public override int Meat{ get{ return 15; } }
		public override int Scales{ get{ return 10; } }
		public override ScaleType ScaleType{ get{ return (ScaleType)Utility.Random( 4 ); } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override Poison HitPoison{ get{ return Utility.RandomBool() ? Poison.Lesser : Poison.Regular; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Skin{ get{ return Utility.Random(5); } }
		public override SkinType SkinType{ get{ return SkinType.Dragon; } }
		public override int Skeletal{ get{ return Utility.Random(5); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Draco; } }

        public override int GetAngerSound()
        {
            return 0x63E;
        }

        public override int GetDeathSound()
        {
            return 0x63F;
        }

        public override int GetHurtSound()
        {
            return 0x640;
        }

        public override int GetIdleSound()
        {
            return 0x641;
        }

		public Wyrm( Serial serial ) : base( serial )
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