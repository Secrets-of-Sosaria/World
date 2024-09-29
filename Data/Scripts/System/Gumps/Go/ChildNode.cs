using System;
using System.Xml;
using Server;

namespace Server.Gumps
{
	public class ChildNode
	{
		private ParentNode m_Parent;

		private string m_Name;
		private Point3D m_Location;
		private Map m_Map;

		public ChildNode( XmlTextReader xml, ParentNode parent )
		{
			m_Parent = parent;

			Parse( xml );
		}

		private void Parse( XmlTextReader xml )
		{
			if ( xml.MoveToAttribute( "name" ) )
				m_Name = xml.Value;
			else
				m_Name = "empty";

			int x = 0, y = 0, z = 0; m_Map = Map.Sosaria;

			if ( xml.MoveToAttribute( "x" ) )
				x = Utility.ToInt32( xml.Value );

			if ( xml.MoveToAttribute( "y" ) )
				y = Utility.ToInt32( xml.Value );

			if ( xml.MoveToAttribute( "z" ) )
				z = Utility.ToInt32( xml.Value );

			if ( xml.MoveToAttribute( "map" ) )
			{
				if ( xml.Value == "Lodor" ){ m_Map = Map.Lodor; }
				else if ( xml.Value == "SerpentIsland" ){ m_Map = Map.SerpentIsland; }
				else if ( xml.Value == "SavagedEmpire" ){ m_Map = Map.SavagedEmpire; }
				else if ( xml.Value == "Underworld" ){ m_Map = Map.Underworld; }
				else if ( xml.Value == "IslesDread" ){ m_Map = Map.IslesDread; }
				else if ( xml.Value == "Atlantis" ){ m_Map = Map.Atlantis; }
			}

			m_Location = new Point3D( x, y, z );
		}

		public ParentNode Parent
		{
			get
			{
				return m_Parent;
			}
		}

		public string Name
		{
			get
			{
				return m_Name;
			}
		}

		public Point3D Location
		{
			get
			{
				return m_Location;
			}
		}

		public Map World
		{
			get
			{
				return m_Map;
			}
		}
	}
}