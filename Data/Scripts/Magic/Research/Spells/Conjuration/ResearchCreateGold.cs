using System;
using Server.Targeting;
using Server.Network;
using Server.Items;

namespace Server.Spells.Research
{
	public class ResearchCreateGold : ResearchSpell
	{
		public override int spellIndex { get { return 25; } }
		public override bool alwaysConsume { get{ return bool.Parse( Server.Misc.Research.SpellInformation( spellIndex, 14 )); } }
		public int CirclePower = 4;
		public static int spellID = 25;
		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 1.0 ); } }
		public override double RequiredSkill{ get{ return (double)(Int32.Parse( Server.Misc.Research.SpellInformation( spellIndex, 8 ))); } }
		public override int RequiredMana{ get{ return Int32.Parse( Server.Misc.Research.SpellInformation( spellIndex, 7 )); } }

		private static SpellInfo m_Info = new SpellInfo(
				Server.Misc.Research.SpellInformation( spellID, 2 ),
				Server.Misc.Research.CapsCast( Server.Misc.Research.SpellInformation( spellID, 4 ) ),
				266,
				9040,
				Reagent.UnicornHorn,Reagent.SeaSalt,Reagent.Ginseng,Reagent.GoldenSerpentVenom
			);

		public ResearchCreateGold( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				Caster.SendMessage( "What item do you want to transmute into gold?" );
				Caster.Target = new InternalTarget( this, spellID, Scroll, alwaysConsume );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private ResearchCreateGold m_Owner;
			private int m_SpellIndex;
			private Item m_fromBook;
			private bool m_alwaysConsume;

			public InternalTarget( ResearchCreateGold owner, int spellIndex, Item fromBook, bool alwaysConsume ) : base( Core.ML ? 10 : 12, false, TargetFlags.None )
			{
				m_Owner = owner;
				m_fromBook = fromBook;
				m_SpellIndex = spellIndex;
				m_alwaysConsume = alwaysConsume;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				bool TurnToGold = false;
				if ( targeted is BaseArmor || targeted is BaseWeapon || targeted is DDRelicCoins || targeted is DDCopper || targeted is DDSilver || targeted is DDXormite )
				{
					TurnToGold = true;
				}
				else if ( targeted is Item )
				{
					Item item = (Item)targeted;
					if ( item.ItemID == 0x1BE3 || item.ItemID == 0x1BE6 || item.ItemID == 0x1BE9 || item.ItemID == 0x1BEC || item.ItemID == 0x1BEF || item.ItemID == 0x1BF2 || item.ItemID == 0x1BF5 || item.ItemID == 0x1BF8 )
					{
						if ( item.Stackable )
						{
							TurnToGold = true;
						}
					}
				}

				if ( TurnToGold )
				{
					Server.Misc.Research.ConsumeScroll( from, true, m_SpellIndex, m_alwaysConsume, m_fromBook );
					GoldenTouch( from, targeted );
					from.PlaySound( 0x64E );
					from.FixedParticles( 0x3039, 9, 32, 5008, Server.Misc.PlayerSettings.GetMySpellHue( true, from, 0xAD3 ), 0, EffectLayer.Waist );
				}
				else
				{
					from.SendMessage( "You decide against transmuting such a thing." );
				}
				m_Owner.FinishSequence();
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}

		public static void GoldenTouch( Mobile from, object o )
		{
			if ( o is Item )
			{
				Item item = (Item)o;

				if ( item is DDXormite )
				{
					Item gold = new Gold();
					gold.Amount = item.Amount;
					from.AddToBackpack( gold );
					item.Delete();
					from.SendMessage( "You turn that into " + gold.Amount + " gold coins." );
				}
				else if ( item is DDRelicCoins )
				{
					int value = item.CoinPrice;
					double mod = DamagingSkill( from ) * 0.02;
						if ( mod < 1 ){ mod = 1.0; }

					Item gold = new Gold();
					gold.Amount = (int)(value*mod);
					from.AddToBackpack( gold );

					item.Delete();
					from.SendMessage( "You turn that into " + value + " gold coins." );

				}
				else if ( item is DDCopper )
				{
					int value = (int)Math.Floor((decimal)(item.Amount / 10));
					double mod = DamagingSkill( from ) * 0.02;
						if ( mod < 1 ){ mod = 1.0; }

					Item gold = new Gold();
					gold.Amount = (int)(value*mod);
					from.AddToBackpack( gold );

					item.Delete();
					from.SendMessage( "You turn that into " + gold.Amount + " gold coins." );
				}
				else if ( item is DDSilver )
				{
					int value = (int)Math.Floor((decimal)(item.Amount / 5));
					double mod = DamagingSkill( from ) * 0.02;
						if ( mod < 1 ){ mod = 1.0; }

					Item gold = new Gold();
					gold.Amount = (int)(value*mod);
					from.AddToBackpack( gold );

					item.Delete();
					from.SendMessage( "You turn that into " + gold.Amount + " gold coins." );
				}
				else if ( ResourceMods.SetResource( item, CraftResource.Gold ) )
				{
					from.SendMessage( "You turn that item into gold." );
				}
				else if ( ResourceMods.ResourceToGold( item, from ) )
				{
					from.SendMessage( "You turn that item into gold ingots." );
				}
			}
		}
	}
}
