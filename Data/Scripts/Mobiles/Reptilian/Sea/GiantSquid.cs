using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a squid corpse" )]
	public class GiantSquid : BaseCreature
	{
		[Constructable]
		public GiantSquid() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a giant squid";
			Body = Utility.RandomList( 77, 965 );
			BaseSoundID = 353;
			Hue = 0x8AB;

			SetStr( 556, 580 );
			SetDex( 126, 145 );
			SetInt( 26, 40 );

			SetHits( 354, 368 );
			SetMana( 0 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Cold, 30 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.MagicResist, 15.1, 20.0 );
			SetSkill( SkillName.Tactics, 45.1, 60.0 );
			SetSkill( SkillName.FistFighting, 45.1, 60.0 );

			Fame = 9000;
			Karma = -9000;

			VirtualArmor = 30;

			CanSwim = true;
			CantWalk = true;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			if ( Utility.RandomBool() )
			{
				this.PlaySound( 0x026 );
				Effects.SendLocationEffect( this.Location, this.Map, 0x23B2, 16 );

				if ( this.Body == 77 )
					this.Body = 965;
				else
					this.Body = 77;
			}

			base.OnDamage( amount, from, willKill );
		}

		public override bool OnBeforeDeath()
		{
			this.Body = 77;
			this.PlaySound( 0x026 );
			Effects.SendLocationEffect( this.Location, this.Map, 0x23B2, 16 );
			return base.OnBeforeDeath();
		}

		public GiantSquid( Serial serial ) : base( serial )
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
