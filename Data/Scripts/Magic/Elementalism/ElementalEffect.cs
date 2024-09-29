using System;
using Server;

namespace Server.Items
{
	public class ElementalEffect : Item
	{
		public override bool HandlesOnMovement{ get{ return true; } }
		public static double m_Seconds;
		public Mobile m_Owner;

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( m == m_Owner )
				this.Delete();
		}

		[Constructable]
		public ElementalEffect() : this( 0, 0.0, null )
		{
		}

		[Constructable]
		public ElementalEffect( int itemID, double seconds, Mobile m ) : base( itemID )
		{
			Movable = false;
			m_Seconds = seconds;
			m_Owner = m;

			new InternalTimer( this ).Start();
		}

		public ElementalEffect( Serial serial ) : base( serial )
		{
			new InternalTimer( this ).Start();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Seconds = 1.0;
			new InternalTimer( this ).Start();
		}

		private class InternalTimer : Timer
		{
			private Item m_ElementalEffect;

			public InternalTimer( Item ElementalEffect ) : base( TimeSpan.FromSeconds( m_Seconds ) )
			{
				Priority = TimerPriority.OneSecond;
				m_ElementalEffect = ElementalEffect;
			}

			protected override void OnTick()
			{
				m_ElementalEffect.Delete();
			}
		}
	}
}