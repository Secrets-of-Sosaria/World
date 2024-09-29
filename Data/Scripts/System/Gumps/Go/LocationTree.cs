using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Server;

namespace Server.Gumps
{
	public class LocationTree
	{
		private ParentNode m_Root;
		private Dictionary<Mobile, ParentNode> m_LastBranch;

		public LocationTree( string fileName )
		{
			m_LastBranch = new Dictionary<Mobile, ParentNode>();

			string path = Path.Combine( "Data/", fileName );

			if ( File.Exists( path ) )
			{
				XmlTextReader xml = new XmlTextReader( new StreamReader( path ) );

				xml.WhitespaceHandling = WhitespaceHandling.None;

				m_Root = Parse( xml );

				xml.Close();
			}
		}

		public Dictionary<Mobile, ParentNode> LastBranch
		{
			get
			{
				return m_LastBranch;
			}
		}

		public ParentNode Root
		{
			get
			{
				return m_Root;
			}
		}

		private ParentNode Parse( XmlTextReader xml )
		{
			xml.Read();
			xml.Read();
			xml.Read();

			return new ParentNode( xml, null );
		}
	}
}