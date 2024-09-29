using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	[Flipable( 0x1070, 0x1074 )]
	public class TrainingDummy : AddonComponent
	{
		private double m_MinSkill;
		private double m_MaxSkill;

		private Timer m_Timer;

		[CommandProperty( AccessLevel.GameMaster )]
		public double MinSkill
		{
			get{ return m_MinSkill; }
			set{ m_MinSkill = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public double MaxSkill
		{
			get{ return m_MaxSkill; }
			set
			{
				m_MaxSkill = value;
				InfoData = "These dummies are used those that wish to practice fist fighting, or a weapon skill. This dummy has the ability to train you up to " + m_MaxSkill + " skill with your fists or with the weapon.";
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Swinging
		{
			get{ return ( m_Timer != null ); } 
		}

		[Constructable]
		public TrainingDummy() : this( 0x1074 )
		{
		}

		[Constructable]
		public TrainingDummy( int itemID ) : base( itemID )
		{
			MinSkill = -25.0;
			MaxSkill = MySettings.S_TrainDummies;
		}

		public void UpdateItemID()
		{
			int baseItemID = (ItemID / 2) * 2;

			ItemID = baseItemID + (Swinging ? 1 : 0);
		}

		public void BeginSwing()
		{
			if ( m_Timer != null )
				m_Timer.Stop();

			m_Timer = new InternalTimer( this );
			m_Timer.Start();
		}

		public void EndSwing()
		{
			if ( m_Timer != null )
				m_Timer.Stop();

			m_Timer = null;

			UpdateItemID();
		}

		public void OnHit()
		{
			UpdateItemID();
			Effects.PlaySound( GetWorldLocation(), Map, Utility.RandomList( 0x3A4, 0x3A6, 0x3A9, 0x3AE, 0x3B4, 0x3B6 ) );
		}

		public void Use( Mobile from, BaseWeapon weapon )
		{
			BeginSwing();

			from.Direction = from.GetDirectionTo( GetWorldLocation() );

			if ( from.RaceID > 0 )
				from.Animate( Utility.RandomList(4,5), 5, 1, true, false, 0 );
			else
				weapon.PlaySwingAnimation( from );

			if ( from is PlayerMobile )
			{
				int cycle = MyServerSettings.TrainMulti();
				int extra = 0;

				while ( cycle > 0 )
				{
					cycle--;
					extra++;	if ( extra > MyServerSettings.StatGainDelayNum() ){ extra = 1; }
					Server.Misc.SkillCheck.ResetStatGain( from, extra );
					from.CheckSkill( weapon.Skill, m_MinSkill, m_MaxSkill );
				}
			}

			if ( weapon is BaseWhip ){ from.PlaySound( 0x3CA ); }
		}

		public override void OnDoubleClick( Mobile from )
		{
			BaseWeapon weapon = from.Weapon as BaseWeapon;

			if ( !(from is PlayerMobile) )
				Use( from, weapon );
			else if ( weapon is BaseRanged )
				SendLocalizedMessageTo( from, 501822 ); // You can't practice ranged weapons on this.
			else if ( weapon == null || !from.InRange( GetWorldLocation(), weapon.MaxRange ) )
				SendLocalizedMessageTo( from, 501816 ); // You are too far away to do that.
			else if ( Swinging )
				SendLocalizedMessageTo( from, 501815 ); // You have to wait until it stops swinging.
			else if ( from.Skills[weapon.Skill].Base >= m_MaxSkill )
				SendLocalizedMessageTo( from, 501828 ); // Your skill cannot improve any further by simply practicing with a dummy.
			else if ( from.Mounted )
				SendLocalizedMessageTo( from, 501829 ); // You can't practice on this while on a mount.
			else
				Use( from, weapon );
		}

		public TrainingDummy( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );

			writer.Write( m_MinSkill );
			writer.Write( m_MaxSkill );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					MinSkill = reader.ReadDouble();
					MaxSkill = reader.ReadDouble();

					break;
				}
			}

			UpdateItemID();
		}

		private class InternalTimer : Timer
		{
			private TrainingDummy m_Dummy;
			private bool m_Delay = true;

			public InternalTimer( TrainingDummy dummy ) : base( TimeSpan.FromSeconds( 0.25 ), TimeSpan.FromSeconds( 2.75 ) )
			{
				m_Dummy = dummy;
				Priority = TimerPriority.FiftyMS;
			}

			protected override void OnTick()
			{
				if ( m_Delay )
					m_Dummy.OnHit();
				else
					m_Dummy.EndSwing();

				m_Delay = !m_Delay;
			}
		}
	}

	public class TrainingDummyEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new TrainingDummyEastDeed(); } }

		[Constructable]
		public TrainingDummyEastAddon()
		{
			AddComponent( new TrainingDummy( 0x1074 ), 0, 0, 0 );
		}

		public TrainingDummyEastAddon( Serial serial ) : base( serial )
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
	}

	public class TrainingDummyEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new TrainingDummyEastAddon(); } }
		public override int LabelNumber{ get{ return 1044335; } } // training dummy (east)

		[Constructable]
		public TrainingDummyEastDeed()
		{
		}

		public TrainingDummyEastDeed( Serial serial ) : base( serial )
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
	}

	public class TrainingDummySouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new TrainingDummySouthDeed(); } }

		[Constructable]
		public TrainingDummySouthAddon()
		{
			AddComponent( new TrainingDummy( 0x1070 ), 0, 0, 0 );
		}

		public TrainingDummySouthAddon( Serial serial ) : base( serial )
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
	}

	public class TrainingDummySouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new TrainingDummySouthAddon(); } }
		public override int LabelNumber{ get{ return 1044336; } } // training dummy (south)

		[Constructable]
		public TrainingDummySouthDeed()
		{
		}

		public TrainingDummySouthDeed( Serial serial ) : base( serial )
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
	}
}