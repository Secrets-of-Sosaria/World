using System;
using Server;

namespace Server.Items
{
	public enum HeadType
	{
		Regular,
		Duel,
		Tournament
	}

	public class Head : Item
	{
		public override Catalogs DefaultCatalog{ get{ return Catalogs.Body; } }

		private string m_PlayerName;
		public string m_Job;
		private HeadType m_HeadType;

		[CommandProperty( AccessLevel.GameMaster )]
		public string PlayerName
		{
			get { return m_PlayerName; }
			set { m_PlayerName = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public string Job
		{
			get { return m_Job; }
			set { m_Job = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public HeadType HeadType
		{
			get { return m_HeadType; }
			set { m_HeadType = value; }
		}

		public override string DefaultName
		{
			get
			{
				if ( m_PlayerName == null )
					return base.DefaultName;

				switch ( m_HeadType )
				{
					default:
						return String.Format( "the head of {0}", m_PlayerName );

					case HeadType.Duel:
						return String.Format( "the head of {0}, taken in a duel", m_PlayerName );

					case HeadType.Tournament:
						return String.Format( "the head of {0}, taken in a tournament", m_PlayerName );
				}
			}
		}

		[Constructable]
		public Head() : this( null )
		{
		}

		[Constructable]
		public Head( string playerName ) : this( HeadType.Regular, playerName )
		{
		}

		[Constructable]
		public Head( HeadType headType, string playerName ) : base( 0x66FD )
		{
			Name = "head";
			m_HeadType = headType;
			m_PlayerName = playerName;
			Weight = 1.0;
			Hue = Utility.RandomSkinHue();
		}

		public Head( Serial serial ) : base( serial )
		{
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			if ( m_Job != "" && m_Job != null ){ list.Add( 1070722, "" + m_Job + ""); }
        }

		public override void OnDoubleClick( Mobile from )
		{
			if ( this.ItemID == 0x66FD ){ this.ItemID = 0x66FE; }
			else { this.ItemID = 0x66FD; }
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (string) m_PlayerName );
			writer.Write( (string) m_Job );
			writer.WriteEncodedInt( (int) m_HeadType );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
					m_PlayerName = reader.ReadString();
					m_Job = reader.ReadString();
					m_HeadType = (HeadType) reader.ReadEncodedInt();
					break;

				case 0:
					string format = this.Name;

					if ( format != null )
					{
						if ( format.StartsWith( "the head of " ) )
							format = format.Substring( "the head of ".Length );

						if ( format.EndsWith( ", taken in a duel" ) )
						{
							format = format.Substring( 0, format.Length - ", taken in a duel".Length );
							m_HeadType = HeadType.Duel;
						}
						else if ( format.EndsWith( ", taken in a tournament" ) )
						{
							format = format.Substring( 0, format.Length - ", taken in a tournament".Length );
							m_HeadType = HeadType.Tournament;
						}
					}

					m_PlayerName = format;
					m_Job = reader.ReadString();
					this.Name = null;

					break;
			}
			Weight = 1.0;
		}
	}
}