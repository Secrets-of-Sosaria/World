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
using System.Text;

namespace Server.Scripts.Commands 
{
    public class AreaLog
    {
        public static void Initialize()
        {
            CommandSystem.Register("AreaLog", AccessLevel.Counselor, new CommandEventHandler( AreaLogs ));
        }

        [Usage("AreaLog")]
        [Description("Records the x and y coordinates of an area.")]
        public static void AreaLogs( CommandEventArgs e )
        {
			e.Mobile.SendMessage( "What area do you want to log?" );
			BeginArea( e.Mobile );
		}

		public static void BeginArea( Mobile mob )
		{
	    	BoundingBoxPicker.Begin(mob, new BoundingBoxCallback(Area_Callback), new object[]{ "area.txt" } );
		}

		private static void Area_Callback(Mobile mob, Map map, Point3D start, Point3D end, object state )
		{
			StreamWriter w = File.AppendText("area.txt");
			w.WriteLine( "else if ( m.X >= " + start.X + " && m.Y >= " + start.Y + " && m.X <= " + end.X + " && m.Y <= " + end.Y + " ){ indoors = true; }" );
			w.Close();
			mob.SendMessage( start.X + " " + start.Y + " " + end.X + " " + end.Y );
        }
    }
}