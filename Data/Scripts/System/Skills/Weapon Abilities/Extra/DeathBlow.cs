using System;

namespace Server.Items
{
	public class DeathBlow : WeaponAbility
	{
		public DeathBlow()
		{
		}

		public override int BaseMana{ get{ return 50; } }
		public override double DamageScalar{ get{ return 1.5; } }

		public override void OnHit( Mobile attacker, Mobile defender, int damage )
		{
			if ( !Validate( attacker ) || !CheckMana( attacker, true ) )
				return;

			ClearCurrentAbility( attacker );

			attacker.SendMessage("You strike a deadly blow!");
			defender.SendMessage("You were struck with a deadly blow!");

			defender.PlaySound(0x213);
			defender.FixedParticles(0x377A, 1, 32, 9949, 1153, 0, EffectLayer.Head);
			Effects.SendMovingParticles(new Entity(Serial.Zero, new Point3D(defender.X, defender.Y, defender.Z + 10), defender.Map), new Entity(Serial.Zero, new Point3D(defender.X, defender.Y, defender.Z + 20), defender.Map), 0x36FE, 1, 0, false, false, 1133, 3, 9501, 1, 0, EffectLayer.Waist, 0x100);
		}
	}
}