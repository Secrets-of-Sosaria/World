using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;

namespace Server.Gumps
{
	public class PetResurrectGump : Gump
	{
		private BaseCreature m_Pet;
		private double m_HitsScalar;

		public PetResurrectGump( Mobile from, BaseCreature pet ) : this( from, pet, 0.0 )
		{
		}

		public PetResurrectGump( Mobile from, BaseCreature pet, double hitsScalar ) : base( 50, 50 )
		{
			from.SendSound( 0x0F8 ); 
			string color = "#b7cbda";
			from.CloseGump( typeof( PetResurrectGump ) );

			m_Pet = pet;
			m_HitsScalar = hitsScalar;

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

			int img = 9586;
				if ( from.Karma < 0 ){ img = 9587; }

			AddImage(0, 0, img, Server.Misc.PlayerSettings.GetGumpHue( from ));
			AddHtml( 10, 11, 349, 20, @"<BODY><BASEFONT Color=" + color + ">RESURRECTION</BASEFONT></BODY>", (bool)false, (bool)false);
			AddButton(368, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);

			AddHtml( 11, 41, 385, 141, @"<BODY><BASEFONT Color=" + color + ">Wilt thou sanctify the resurrection of " + pet.Name + "</BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(10, 225, 4023, 4023, 1, GumpButtonType.Reply, 0);
			AddButton(367, 225, 4020, 4020, 2, GumpButtonType.Reply, 0);
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			if ( m_Pet.Deleted || !m_Pet.IsBonded || !m_Pet.IsDeadPet )
				return;

			Mobile from = state.Mobile;

			if ( info.ButtonID == 1 )
			{
				if ( m_Pet.Map == null || !m_Pet.Map.CanFit( m_Pet.Location, 16, false, false ) )
				{
					from.SendLocalizedMessage( 503256 ); // You fail to resurrect the creature.
					return;
				}
				else if( m_Pet.Region != null && m_Pet.Region.IsPartOf( "Khaldun" ) )	//TODO: Confirm for pets, as per Bandage's script.
				{
					from.SendLocalizedMessage( 1010395 ); // The veil of death in this area is too strong and resists thy efforts to restore life.
					return;
				}

				m_Pet.PlaySound( 0x214 );
				m_Pet.FixedEffect( 0x376A, 10, 16 );
				m_Pet.ResurrectPet();

				double decreaseAmount;

				if( from == m_Pet.ControlMaster )
					decreaseAmount = 0.1;
				else
					decreaseAmount = 0.2;

				for ( int i = 0; i < m_Pet.Skills.Length; ++i )	//Decrease all skills on pet.
					m_Pet.Skills[i].Base -= decreaseAmount;

				if( !m_Pet.IsDeadPet && m_HitsScalar > 0 )
					m_Pet.Hits = (int)(m_Pet.HitsMax * m_HitsScalar);
			}

		}
	}
}