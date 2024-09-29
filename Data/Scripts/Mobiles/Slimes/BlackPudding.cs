using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a pile of black goo" )]
	public class BlackPudding : BaseCreature
	{
		[Constructable]
		public BlackPudding () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a black pudding";
			Body = 100;
			Hue = 0x497;

			SetStr( 62, 84 );
			SetDex( 56, 71 );
			SetInt( 56, 70 );

			SetHits( 70, 100 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 80 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Fire, 80 );
			SetResistance( ResistanceType.Poison, 80 );
			SetResistance( ResistanceType.Energy, 80 );

			SetSkill( SkillName.Poisoning, 36.0, 49.1 );
			SetSkill(SkillName.Anatomy, 0);
			SetSkill( SkillName.MagicResist, 15.9, 18.9 );
			SetSkill( SkillName.Tactics, 24.6, 26.1 );
			SetSkill( SkillName.FistFighting, 24.9, 26.1 );

			Fame = 900;
			Karma = -900;

			VirtualArmor = 12;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems );
		}

		public override void OnGaveMeleeAttack( Mobile m )
		{
			base.OnGaveMeleeAttack( m );

			if ( 1 == Utility.RandomMinMax( 1, 20 ) )
			{
				Container cont = m.Backpack;
				Item iWrapped = Server.Items.HiddenTrap.GetMyItem( m );

				if ( iWrapped != null )
				{
					if ( Server.Items.HiddenTrap.IAmShielding( m, 70 ) || Server.Items.HiddenTrap.IAmAWeaponSlayer( m, this ) )
					{
					}
					else if ( Server.Items.HiddenTrap.CheckInsuranceOnTrap( iWrapped, m ) )
					{
						m.LocalOverheadMessage(MessageType.Emote, 1150, true, "Slime almost covered one of your protected items!");
					}
					else
					{
						m.LocalOverheadMessage(MessageType.Emote, 0x916, true, "One of your items is covered in slime!");
						m.PlaySound( 0x364 );
						Container box = new SlimeItem();
						box.DropItem(iWrapped);
						box.ItemID = iWrapped.GraphicID;
						box.Hue = this.Hue;
						m.AddToBackpack ( box );
					}
				}
			}
		}

        public override int GetAngerSound(){ return 0x581; }
        public override int GetIdleSound(){ return 0x582; }
        public override int GetAttackSound(){ return 0x580; }
        public override int GetHurtSound(){ return 0x583; }
        public override int GetDeathSound(){ return 0x584; }

		public override Poison PoisonImmune { get { return Poison.Regular; } }
		public override Poison HitPoison { get { return Poison.Regular; } }
		public override bool BleedImmune{ get{ return true; } }
		public override int Skeletal{ get{ return Utility.Random(5); } }
		public override SkeletalType SkeletalType{ get{ return SkeletalType.Brittle; } }

		public BlackPudding( Serial serial ) : base( serial )
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