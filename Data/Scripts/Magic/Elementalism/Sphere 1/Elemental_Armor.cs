using System;
using System.Collections;
using Server.Targeting;
using Server.Network;

namespace Server.Spells.Elementalism
{
	public class Elemental_Armor_Spell : ElementalSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elemental Armor", "Armura",
				236,
				9011
			);

		public override SpellCircle Circle { get { return SpellCircle.First; } }

		public Elemental_Armor_Spell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			return true;
		}

		private static Hashtable m_Table = new Hashtable();

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				Mobile targ = Caster;

				ResistanceMod[] mods = (ResistanceMod[])m_Table[targ];

				if ( mods == null )
				{
					string args = null;
					int resist = 15 + (int)(targ.Skills[CastSkill].Value / 20);
					string elm = ElementalSpell.GetElement( Caster );

					if ( elm == "air" )
					{
						Effects.SendLocationEffect( targ.Location, targ.Map, 0x5590, 30, 10, 0xB24, 0 );
						targ.PlaySound( 0x10B );

						mods = new ResistanceMod[5]
							{
								new ResistanceMod( ResistanceType.Physical, -5 ),
								new ResistanceMod( ResistanceType.Fire, -5 ),
								new ResistanceMod( ResistanceType.Cold, -5 ),
								new ResistanceMod( ResistanceType.Poison, -5 ),
								new ResistanceMod( ResistanceType.Energy, resist )
							};

						m_Table[targ] = mods;

						for ( int i = 0; i < mods.Length; ++i )
							targ.AddResistanceMod( mods[i] );

						args = String.Format("{0}\t{1}\t{2}\t{3}\t{4}", -5, -5, -5, -5, resist);
					}
					else if ( elm == "earth" )
					{
						Point3D hands = new Point3D( ( targ.X ), ( targ.Y ), ( targ.Z+5 ) );
						Effects.SendLocationEffect( hands, targ.Map, 0x3837, 23, 10, 0, 0 );
						targ.PlaySound( 0x65A );

						mods = new ResistanceMod[5]
							{
								new ResistanceMod( ResistanceType.Physical, resist ),
								new ResistanceMod( ResistanceType.Fire, -5 ),
								new ResistanceMod( ResistanceType.Cold, -5 ),
								new ResistanceMod( ResistanceType.Poison, -5 ),
								new ResistanceMod( ResistanceType.Energy, -5 )
							};

						m_Table[targ] = mods;

						for ( int i = 0; i < mods.Length; ++i )
							targ.AddResistanceMod( mods[i] );

						args = String.Format("{0}\t{1}\t{2}\t{3}\t{4}", resist, -5, -5, -5, -5);
					}
					else if ( elm == "fire" )
					{
						targ.FixedParticles( 0x3709, 10, 30, 5052, 0, 0, EffectLayer.LeftFoot );
						targ.PlaySound( 0x208 );

						mods = new ResistanceMod[5]
							{
								new ResistanceMod( ResistanceType.Physical, -5 ),
								new ResistanceMod( ResistanceType.Fire, resist ),
								new ResistanceMod( ResistanceType.Cold, -5 ),
								new ResistanceMod( ResistanceType.Poison, -5 ),
								new ResistanceMod( ResistanceType.Energy, -5 )
							};

						m_Table[targ] = mods;

						for ( int i = 0; i < mods.Length; ++i )
							targ.AddResistanceMod( mods[i] );

						int physresist = 15 + (int)(targ.Skills[CastSkill].Value / 20);
						args = String.Format("{0}\t{1}\t{2}\t{3}\t{4}", -5, resist, -5, -5, -5);
					}
					else if ( elm == "water" )
					{
						Effects.SendLocationEffect( targ.Location, targ.Map, 0x1A84, 30, 10, 0xBA4, 0 );
						targ.PlaySound( 0x026 );

						mods = new ResistanceMod[5]
							{
								new ResistanceMod( ResistanceType.Physical, -5 ),
								new ResistanceMod( ResistanceType.Fire, -5 ),
								new ResistanceMod( ResistanceType.Cold, resist ),
								new ResistanceMod( ResistanceType.Poison, -5 ),
								new ResistanceMod( ResistanceType.Energy, -5 )
							};

						m_Table[targ] = mods;

						for ( int i = 0; i < mods.Length; ++i )
							targ.AddResistanceMod( mods[i] );

						args = String.Format("{0}\t{1}\t{2}\t{3}\t{4}", -5, -5, resist, -5, -5);
					}

					BuffInfo.AddBuff(Caster, new BuffInfo(BuffIcon.ElementalArmor, 1063527, 1075818, args.ToString(),true));
				}
				else
				{
					targ.PlaySound( 0x1ED );
					targ.FixedParticles( 0x376A, 9, 32, 5008, 0, 0, EffectLayer.Waist );

					m_Table.Remove( targ );

					for ( int i = 0; i < mods.Length; ++i )
						targ.RemoveResistanceMod( mods[i] );

					BuffInfo.RemoveBuff(Caster, BuffIcon.ElementalArmor);
				}
			}

			FinishSequence();
		}

		public static void EndArmor( Mobile m )
		{
			if ( m_Table.Contains( m ) )
			{
				ResistanceMod[] mods = (ResistanceMod[]) m_Table[ m ];

				if ( mods != null )
				{
					for ( int i = 0; i < mods.Length; ++i )
						m.RemoveResistanceMod( mods[ i ] );
				}

				m_Table.Remove( m );
				BuffInfo.RemoveBuff( m, BuffIcon.ReactiveArmor );
			}
		}
	}
}