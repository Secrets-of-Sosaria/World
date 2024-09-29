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
using Server.Targeting;

namespace Server.Scripts.Commands 
{
    public class TargetLog
    {
        public static void Initialize()
        {
            CommandSystem.Register("TargetLog", AccessLevel.Counselor, new CommandEventHandler( TargetLogs ));
        }

        [Usage("TargetLog")]
        [Description("Records the x, y, and z coordinates of the caller...along with the map they are in.")]
        public static void TargetLogs( CommandEventArgs e )
        {
			e.Mobile.SendMessage( "What target do you want to log?" );
			e.Mobile.Target = new InternalTarget();
		}

		private class InternalTarget : Target
		{
			public InternalTarget() :  base ( 8, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				string sX = "";
				string sY = "";
				string sZ = "";
				string sItem = "";

				if ( targeted is Item )
				{
					sX = ((Item)targeted).X.ToString();
					sY = ((Item)targeted).Y.ToString();
					sZ = ((Item)targeted).Z.ToString();
					sItem = ((Item)targeted).ItemID.ToString();
				}
				else if ( targeted is StaticTarget )
				{
					sX = ((StaticTarget)targeted).X.ToString();
					sY = ((StaticTarget)targeted).Y.ToString();
					sZ = ((StaticTarget)targeted).Z.ToString();
					sItem = ((StaticTarget)targeted).ItemID.ToString();
				}

				string sRegion = Server.Misc.Worlds.GetRegionName( from.Map, from.Location );

				string sMap = "Map.Sosaria";
				if ( from.Map == Map.Lodor ){ sMap = "Map.Lodor"; }
				else if ( from.Map == Map.Underworld ){ sMap = "Map.Underworld"; }
				else if ( from.Map == Map.SerpentIsland ){ sMap = "Map.SerpentIsland"; }
				else if ( from.Map == Map.IslesDread ){ sMap = "Map.IslesDread"; }
				else if ( from.Map == Map.SavagedEmpire ){ sMap = "Map.SavagedEmpire"; }
				else if ( from.Map == Map.Atlantis ){ sMap = "Map.Atlantis"; }

				if ( sX != "" )
				{
					StreamWriter w = File.AppendText("targets.txt");
					w.WriteLine( sRegion + "\t" + sItem + "\t" + sX + "\t" + sY + "\t" + sZ + "\t" + sMap );

					w.Close();

					from.SendMessage( sRegion + " " + sItem + " " + sX + " " + sY + " " + sZ + " " + sMap );
				}
				else
				{
					from.SendMessage( "Target failed to log!" );
				}
			}
        }
    }
}