using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
	public class BedrolledOut : Item
	{
		public override string DefaultDescription{ get{ return "Bedrolls can be used by adventurers, to recovery health and stamina much quicker. There cannot be any enemies nearby and only the one who places the bedroll will benefit from the effects. It requires someone proficient in camping."; } }

		private Timer m_Timer;
		private DateTime m_Created;
		private Mobile m_Owner;

		public BedrolledOut( Mobile owner ) : base( 0x0A55 )
		{
			ItemID = Utility.RandomMinMax( 0x0A55, 0x0A56 );
			m_Owner = owner;
			Movable = false;
			m_Created = DateTime.Now;
			m_Timer = Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ), new TimerCallback( OnTick ) );
		}

		public BedrolledOut( Serial serial ) : base( serial )
		{
		}

		[CommandProperty( AccessLevel.Counselor, AccessLevel.GameMaster )]
		public Mobile Owner
		{
			get
			{
				return m_Owner;
			}
			set{ m_Owner = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime Created
		{
			get{ return m_Created; }
		}

		private void OnTick()
		{
			DateTime now = DateTime.Now;
			TimeSpan age = now - this.Created;

			if ( age >= TimeSpan.FromSeconds( 100.0 ) )
				RollUp();

			if ( this.Deleted )
				return;

			List<Mobile> toRest = new List<Mobile>();

			foreach( Mobile m in GetMobilesInRange( 3 ) )
			{
				if ( m is PlayerMobile && m == m_Owner && !Server.Items.Kindling.EnemiesNearby( m ) )
					toRest.Add( m );
			}

			for ( int i = 0; i < toRest.Count; i++ )
				Rest( toRest[i] );
		}

		public void RollUp()
		{
			if ( m_Owner != null )
			{
				Container cont = m_Owner.Backpack;
				if ( cont != null )
					m_Owner.AddToBackpack( new Bedroll() );
			}

			this.Delete();
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

		public override void OnDoubleClick( Mobile from )
		{
			if ( m_Owner == from )
				RollUp();
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
			writer.Write( (Mobile) m_Owner );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Owner = reader.ReadMobile();
			RollUp();
		}
	}
}