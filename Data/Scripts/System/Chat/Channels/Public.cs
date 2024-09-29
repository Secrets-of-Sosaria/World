using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Server.Network;
using System.Globalization;
using Server.Commands;

namespace Knives.Chat3
{
    public class Public : Channel
    {
        public Public() : base("Public")
        {
            Commands.Add("chat");
            Commands.Add("c");
            NewChars = true;

            Register(this);
        }
    }
}