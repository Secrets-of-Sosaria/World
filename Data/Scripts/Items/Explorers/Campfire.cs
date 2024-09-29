using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
	public enum CampfireStatus
	{
		Burning,
		Extinguishing,
		Off
	}

	public class Campfire : Item
	{
		public override string DefaultDescription{ get{ return "The fire can then be used by adventurers, to recovery health and stamina much quicker. There cannot be any enemies nearby for anyone to benefit from the effects."; } }

		private Timer m_Timer;
		private DateTime m_Created;

		public Campfire() : base( 0xDE3 )
		{
			Movable = false;
			Light = LightType.Circle300;
			m_Created = DateTime.Now;
			m_Timer = Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ), new TimerCallback( OnTick ) );
		}

		public Campfire( Serial serial ) : base( serial )
		{
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime Created
		{
			get{ return m_Created; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public CampfireStatus Status
		{
			get
			{
				switch ( this.ItemID )
				{
					case 0xDE3:
						return CampfireStatus.Burning;

					case 0xDE9:
						return CampfireStatus.Extinguishing;

					default:
						return CampfireStatus.Off;
				}
			}
			set
			{
				if ( this.Status == value )
					return;

				switch ( value )
				{
					case CampfireStatus.Burning:
						this.ItemID = 0xDE3;
						this.Light = LightType.Circle300;
						break;

					case CampfireStatus.Extinguishing:
						this.ItemID = 0xDE9;
						this.Light = LightType.Circle150;
						break;

					default:
						this.ItemID = 0xDEA;
						this.Light = LightType.ArchedWindowEast;
						break;
				}
			}
		}

		private void OnTick()
		{
			DateTime now = DateTime.Now;
			TimeSpan age = now - this.Created;

			if ( age >= TimeSpan.FromSeconds( 100.0 ) )
				this.Delete();
			else if ( age >= TimeSpan.FromSeconds( 90.0 ) )
				this.Status = CampfireStatus.Off;
			else if ( age >= TimeSpan.FromSeconds( 60.0 ) )
				this.Status = CampfireStatus.Extinguishing;

			if ( this.Status == CampfireStatus.Off || this.Deleted )
				return;

			List<Mobile> toRest = new List<Mobile>();

			foreach( Mobile m in GetMobilesInRange( 3 ) )
			{
				if ( m is PlayerMobile && !Server.Items.Kindling.EnemiesNearby( m ) )
					toRest.Add( m );
			}

			for ( int i = 0; i < toRest.Count; i++ )
				Rest( toRest[i] );
		}

		public void Rest( Mobile m )
		{
			if ( m.Hunger > 4 && m.Thirst > 4 )
			{
				if ( m.Stam < m.StamMax )
				{
					int stam = MyServerSettings.PlayerLevelMod( 2, m );
						if ( stam < 1 )
							stam = 1;

					m.Stam = m.Stam + stam;
				}
				if ( m.Hits < m.HitsMax )
				{
					int hits = MyServerSettings.PlayerLevelMod( 2, m );
						if ( hits < 1 )
							hits = 1;

					m.Hits = m.Hits + hits;
				}
				m.CheckSkill( SkillName.Camping, 0, 125 );
			}
		}

		public override void OnAfterDelete()
		{
			if ( m_Timer != null )
				m_Timer.Stop();
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
			this.Delete();
		}
	}
}