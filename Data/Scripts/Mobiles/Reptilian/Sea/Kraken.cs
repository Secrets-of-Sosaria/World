using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a krakens corpse" )]
	public class Kraken : BaseCreature
	{
		[Constructable]
		public Kraken() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a kraken";
			Body = Utility.RandomList( 77, 965 );

			if ( Body == 965 )
				Hue = 0x846;

			BaseSoundID = 353;

			SetStr( 756, 780 );
			SetDex( 226, 245 );
			SetInt( 26, 40 );

			SetHits( 454, 468 );
			SetMana( 0 );

			SetDamage( 19, 33 );

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

			Fame = 11000;
			Karma = -11000;

			VirtualArmor = 50;

			CanSwim = true;
			CantWalk = true;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			if ( Utility.RandomBool() )
			{
				this.PlaySound( 0x026 );
				Effects.SendLocationEffect( this.Location, this.Map, 0x23B2, 16 );

				if ( this.Body == 77 )
				{
					this.Body = 965;
					this.Hue = 0x846;
				}
				else
				{
					this.Body = 77;
					this.Hue = 0;
				}
			}

			base.OnDamage( amount, from, willKill );
		}

		public override bool OnBeforeDeath()
		{
			this.Body = 77;
			this.Hue = 0;
			this.PlaySound( 0x026 );
			Effects.SendLocationEffect( this.Location, this.Map, 0x23B2, 16 );
			return base.OnBeforeDeath();
		}

		public override bool BleedImmune{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public Kraken( Serial serial ) : base( serial )
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
