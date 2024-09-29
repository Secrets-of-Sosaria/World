using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Misc;
using Server.Items;
using Server.Network;
using Server.Commands;
using Server.Commands.Generic;
using Server.Mobiles;
using Server.Accounting;
using Server.Regions;
using System.IO;

namespace Server.Scripts.Commands 
{
    public class PointLog
    {
        public static void Initialize()
        {
            CommandSystem.Register("PointLog", AccessLevel.Counselor, new CommandEventHandler( PointLogs ));
        }

        [Usage("PointLog")]
        [Description("Records the x, y, and z coordinates of the caller...along with the map they are in.")]
        public static void PointLogs( CommandEventArgs e )
        {
			string sX = e.Mobile.X.ToString();
			string sY = e.Mobile.Y.ToString();
			string sZ = e.Mobile.Z.ToString();

			string sRegion = Server.Misc.Worlds.GetRegionName( e.Mobile.Map, e.Mobile.Location );

			string sMap = "Map.Sosaria";
			if ( e.Mobile.Map == Map.Lodor ){ sMap = "Map.Lodor"; }
			else if ( e.Mobile.Map == Map.Underworld ){ sMap = "Map.Underworld"; }
			else if ( e.Mobile.Map == Map.SerpentIsland ){ sMap = "Map.SerpentIsland"; }
			else if ( e.Mobile.Map == Map.IslesDread ){ sMap = "Map.IslesDread"; }
			else if ( e.Mobile.Map == Map.SavagedEmpire ){ sMap = "Map.SavagedEmpire"; }
			else if ( e.Mobile.Map == Map.Atlantis ){ sMap = "Map.Atlantis"; }

            StreamWriter w = File.AppendText("points.txt");
            w.WriteLine( sRegion + "\t" + "(" + sX + ", " + sY + ", " + sZ + ")\t" + sMap );

            w.Close();

			e.Mobile.SendMessage( sRegion + "       " + "(" + sX + ", " + sY + ", " + sZ + ")       " + sMap );
        }
    }

    public class ContainerLog
    {
        public static void ContainerLogs( int x, int y, int item, int gump, Mobile from )
        {
            StreamWriter w = File.AppendText("containers.txt");
            w.WriteLine( "X\tY\tItemID\tGump" );
            w.WriteLine( "" + x + "\t" + y + "\t" + item + "\t" + gump + "" );

            w.Close();

			from.SendMessage( "" + x + " --- " + y + " --- " + item + " --- " + gump + "" );
        }
    }
}