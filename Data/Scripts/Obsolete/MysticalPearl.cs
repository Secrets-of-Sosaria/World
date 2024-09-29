using Server;
using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Misc;

namespace Server.Items
{
	public class MysticalPearl : Item
	{
        [Constructable]
        public MysticalPearl() : base( 0x3196 )
		{
            Name = "Mystical Deep Sea Pearl";
			Weight = 1.0;
        }

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1070722, "Place into jewelry" );
		}

		public override void OnDoubleClick( Mobile from )
		{
			Target t;

			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1060640 ); // The item must be in your backpack to use it.
			}
			else if ( from.Skills[SkillName.Tinkering].Base >= 90 )
			{
				from.SendMessage( "What do you want to put the mystical pearl in?" );
				t = new PearlTarget( this );
				from.Target = t;
			}
			else
			{
				from.SendMessage( "Only a master tinkers can use this pearl." );
			}
		}

		private class PearlTarget : Target
		{
			private MysticalPearl m_Pearl;

			public PearlTarget( MysticalPearl tube ) : base( 1, false, TargetFlags.None )
			{
				m_Pearl = tube;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				Item iPearl = targeted as Item;

				if ( iPearl is BaseTrinket )
				{
					if ( !iPearl.IsChildOf( from.Backpack ) )
					{
						from.SendMessage( "You can only use this pearl on items in your pack." );
					}
					else if ( iPearl.Catalog == Catalogs.Jewelry )
					{
						string pName = "Mystical Pearl Ring";
						if ( iPearl is JewelryNecklace ){ pName = "Mystical Pearl Necklace"; }
						else if ( iPearl is JewelryEarrings ){ pName = "Mystical Pearl Earrings"; }
						else if ( iPearl is JewelryCirclet ){ pName = "Mystical Pearl Circlet"; }
						else if ( iPearl is JewelryBracelet ){ pName = "Mystical Pearl Bracelet"; }
						((BaseTrinket)iPearl).Attributes.CastRecovery = 1;
						((BaseTrinket)iPearl).Attributes.CastSpeed = 1;
						((BaseTrinket)iPearl).Attributes.LowerManaCost = 10;
						((BaseTrinket)iPearl).Attributes.LowerRegCost = 10;
						((BaseTrinket)iPearl).Attributes.Luck = 50;
						((BaseTrinket)iPearl).Attributes.NightSight = 1;
						((BaseTrinket)iPearl).Attributes.SpellDamage = 5;
						((BaseTrinket)iPearl).Hue = 1150;
						iPearl.Name = pName;
						from.RevealingAction();
						from.PlaySound( 0x242 );
						m_Pearl.Consume();
					}
					else
					{
						from.SendMessage( "You cannot use this pearl on that." );
					}
				}
				else
				{
					from.SendMessage( "You cannot use this pearl on that." );
				}
			}
		}

		public MysticalPearl( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			Item item = new Oyster();
			Server.Misc.Cleanup.DoCleanup( (Item)state, item );
		}
	}
}