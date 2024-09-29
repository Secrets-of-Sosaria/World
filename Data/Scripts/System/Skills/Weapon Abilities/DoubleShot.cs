using System;
using Server;

namespace Server.Items
{
	public class DoubleShot : WeaponAbility
	{
		public DoubleShot()
		{
		}

		public override int BaseMana { get { return 30; } }

		public override bool CheckSkills( Mobile from )
		{
			return base.CheckSkills( from );
		}

		public override void OnHit( Mobile attacker, Mobile defender, int damage )
		{
			Use( attacker, defender );
		}

		public override void OnMiss( Mobile attacker, Mobile defender )
		{
			Use( attacker, defender );
		}

		public void Use( Mobile attacker, Mobile defender )
		{
			if( !Validate( attacker ) || !CheckMana( attacker, true ) || attacker.Weapon == null )	//sanity
				return;

			ClearCurrentAbility( attacker );

			attacker.SendLocalizedMessage( 1063348 ); // You launch two shots at once!
			defender.SendLocalizedMessage( 1063349 ); // You're attacked with a barrage of shots!

			defender.FixedParticles( 0x37B9, 1, 19, 0x251D, EffectLayer.Waist );

			attacker.Weapon.OnSwing( attacker, defender );
		}
	}
}