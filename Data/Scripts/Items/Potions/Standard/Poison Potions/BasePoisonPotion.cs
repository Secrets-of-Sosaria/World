using Server;
using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Misc;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
	public abstract class BasePoisonPotion : BasePotion
	{
		public override string DefaultDescription{ get{ return "( " + Poison + " Strength ) This poison can be used by someone with a skill of " + (int)MinPoisoningSkill + " to " + (int)MaxPoisoningSkill + " in poisoning. You can use them on bladed weapons or dump the contents on the ground. Once on the ground, those that walk over the liquid have a chance to suffer the poison's effects."; } }

		public abstract Poison Poison{ get; }

		public abstract double MinPoisoningSkill{ get; }
		public abstract double MaxPoisoningSkill{ get; }

		//public override int Hue{ get { return 0; } }

		public BasePoisonPotion( PotionEffect effect ) : base( 0xF0A, effect )
		{
		}

		public BasePoisonPotion( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

		public void DoPoison( Mobile from )
		{
			from.ApplyPoison( from, Poison );
		}

		public override void Drink( Mobile from )
		{
			int skillLevel = 50;
			if ( this is PoisonPotion ){ skillLevel = 60; }
			else if ( this is GreaterPoisonPotion ){ skillLevel = 70; }
			else if ( this is DeadlyPoisonPotion ){ skillLevel = 80; }
			else if ( this is LethalPoisonPotion ){ skillLevel = 90; }

			if ( from.Skills[SkillName.Poisoning].Value >= skillLevel )
			{
				if ( !IsChildOf( from.Backpack ) )
				{
					from.SendLocalizedMessage( 1060640 ); // The item must be in your backpack to use it.
				}
				else if ( !from.Region.AllowHarmful( from, from ) )
				{
					from.SendMessage( "That doesn't feel like a good idea." ); 
					return;
				}
				else if ( Server.Items.MonsterSplatter.TooMuchSplatter( from ) )
				{
					from.SendMessage( "There is too much liquid on the ground already." ); 
					return;
				}
				else
				{
					from.SendMessage( "Where do you want to dump the poison?" );
					ThrowTarget targ = from.Target as ThrowTarget;

					if ( targ != null && targ.Potion == this )
						return;

					from.RevealingAction();
					from.Target = new ThrowTarget( this );
				}
			}
			else
			{
				DoPoison( from );
				BasePotion.PlayDrinkEffect( from );
				this.Consume();
			}
		}

		private class ThrowTarget : Target
		{
			private BasePoisonPotion m_Potion;

			public BasePoisonPotion Potion
			{
				get{ return m_Potion; }
			}

			public ThrowTarget( BasePoisonPotion potion ) : base( 12, true, TargetFlags.None )
			{
				m_Potion = potion;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Potion.Deleted || m_Potion.Map == Map.Internal )
					return;
					
				IPoint3D p = targeted as IPoint3D;
				Point3D d = new Point3D( p );

				if ( p == null || from.Map == null )
					return;

				SpellHelper.GetSurfaceTop( ref p );

				int nThrown = 1;

				if ( from.GetDistanceToSqrt( d ) > 8 )
				{
					nThrown = 0;
					from.SendMessage( "That is too far away." );
				}
				else if ( !from.CanSee( d ) )
				{
					nThrown = 0;
					from.SendLocalizedMessage( 500237 ); // Target can not be seen.
				}
				else if ( (from.Paralyzed || from.Blessed || from.Frozen || (from.Spell != null && from.Spell.IsCasting)) )
				{
					nThrown = 0;
					from.SendMessage( "You cannot do that yet." );
				}
				else
				{
					MonsterSplatter.AddSplatter( p.X, p.Y, p.Z, from.Map, d, from, m_Potion.Name, 0x4F8, 0 );
				}

				if ( nThrown > 0 )
				{
					from.RevealingAction();
					m_Potion.Consume();
					from.AddToBackpack( new Bottle() );
					Misc.Titles.AwardKarma( from, -40, true );
				}
			}
		}
	}
}