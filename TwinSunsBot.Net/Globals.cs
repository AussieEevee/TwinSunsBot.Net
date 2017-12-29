using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinSunsBot.Net
{
    public static class Global
    {
        public static int Number { get; set; }
        public static string[] memes = Directory.GetFiles(@"Memes\");
        public static double version = 1.082;

    }
}
