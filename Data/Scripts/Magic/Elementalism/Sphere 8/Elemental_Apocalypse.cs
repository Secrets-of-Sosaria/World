using System;
using System.Collections.Generic;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells.Elementalism
{
	public class Elemental_Apocalypse_Spell : ElementalSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elemental Apocalypse", "Moarte",
				233,
				9012,
				false
			);

		public override SpellCircle Circle { get { return SpellCircle.Eighth; } }

		public Elemental_Apocalypse_Spell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool DelayedDamage{ get{ return !Core.AOS; } }

		public override void OnCast()
		{
			if ( SpellHelper.CheckTown( Caster, Caster ) && CheckSequence() )
			{
				List<Mobile> targets = new List<Mobile>();

				Map map = Caster.Map;

				if ( map != null )
					foreach ( Mobile m in Caster.GetMobilesInRange( 1 + (int)(Caster.Skills[CastSkill].Value / 15.0) ) )
						if ( Caster.Region == m.Region && Caster != m && SpellHelper.ValidIndirectTarget( Caster, m ) && Caster.CanBeHarmful( m, false ) && Caster.InLOS( m ) )
							targets.Add( m );

				string elm = ElementalSpell.GetElement( Caster );
				int sound = 0;
				int phys = 0;
				int fire = 0;
				int cold = 0;
				int engy = 0;
				int hue = 0;
				int efect = 0;
				int x = 0;
				int y = 0;
				int z = 0;
				int cyc = 0;

				if ( elm == "air" )
				{
					sound = 0x64F;
					phys = 40;
					fire = 0;
					cold = 0;
					engy = 60;
					hue = 0xAF8;
					efect = 0x55BB;
					x = 1;
					y = 1;
					z = 10;
				}
				else if ( elm == "earth" )
				{
					sound = 0x65A;
					phys = 100;
					fire = 0;
					cold = 0;
					engy = 0;
					hue = 0xAC0;
					efect = 0x23B2;
					x = 2;
					y = 2;
					z = 15;
				}
				else if ( elm == "fire" )
				{
					sound = 0x345;
					phys = 40;
					fire = 60;
					cold = 0;
					engy = 0;
					hue = 0;
					efect = 0x551A;
					x = 1;
					y = 1;
					z = 5;
				}
				else if ( elm == "water" )
				{
					sound = 0x64F;
					phys = 40;
					fire = 0;
					cold = 60;
					engy = 0;
					hue = 0;
					efect = 0x55BB;
					x = 2;
					y = 0;
					z = 0;
				}

				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile m = targets[i];
					Point3D spot = new Point3D( (m.Location).X+x, (m.Location).Y+y, (m.Location).Z+z );

					int nBenefit = (int)(Caster.Skills[CastSkill].Value / 5);

					double damage = m.Hits / 2;

					if ( !m.Player )
						damage = Math.Max( Math.Min( damage, 100 ), 15 );
						damage += Utility.RandomMinMax( 0, 15 );

					damage = damage + nBenefit;

					Caster.DoHarmful( m );
					Effects.SendLocationEffect( spot, m.Map, efect, 30, 10, hue-1, 0 );
					SpellHelper.Damage( TimeSpan.Zero, m, Caster, damage, phys, fire, cold, 0, engy );
					if ( cyc == 0 ){ Caster.PlaySound( sound ); }

					cyc++;
				}
			}

			FinishSequence();
		}
	}
}