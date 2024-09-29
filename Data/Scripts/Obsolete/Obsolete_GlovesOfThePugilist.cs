using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x13C6, 0x13C6 )]
	public class GlovesOfThePugilist : BaseWeapon
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.Disarm; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.WhirlwindAttack; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.FistsOfFury; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.DeathBlow; } }

		public override int AosStrengthReq{ get{ return 20; } }
		public override int AosMinDamage{ get{ return 2; } }
		public override int AosMaxDamage{ get{ return 5; } }
		public override int AosSpeed{ get{ return 2; } }
		public override float MlSpeed{ get{ return 2.00f; } }

		public override int DefHitSound{ get{ return 0x13D; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override SkillName DefSkill{ get{ return SkillName.FistFighting; } }
		public override WeaponType DefType{ get{ return WeaponType.Fists; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Punching; } }

		[Constructable]
		public GlovesOfThePugilist() : base( 0x13C6 )
		{
			Name = "gloves of the pugilist";
			Weight = 2.0;
			Hue = 0x6D1;
			SkillBonuses.SetValues( 0, SkillName.FistFighting, 10.0 );
			Attributes.BonusDex = 8;
			Attributes.WeaponDamage = 15;
			Layer = Layer.OneHanded;
			Attributes.SpellChanneling = 1;
			WeaponAttributes.ResistPhysicalBonus = 18;
			WeaponAttributes.ResistColdBonus = 3;
			WeaponAttributes.ResistEnergyBonus = 3;
			WeaponAttributes.ResistFireBonus = 4;
			WeaponAttributes.ResistPoisonBonus = 3;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
			list.Add( 1049644, "Cannot be used with hand-held weapons" );
		}

		public GlovesOfThePugilist( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_GlovesOfThePugilist(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}