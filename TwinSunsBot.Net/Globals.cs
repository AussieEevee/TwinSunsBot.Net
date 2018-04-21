using System.IO;

namespace TwinSunsBot.Net
{
    public static class Global
    {
        public static int Number { get; set; }
        public static string[] memes = Directory.GetFiles(@"Memes\");
        public static string version = "1.0.10";
        public static string dateformat = "dd/MM/yyyy HH:mm:ss";

    }
    public class AdVariables
    {
        public static int adinterval = 86400000;
        public static ulong adchannel = 285953712898441217;
        public static ulong adminchannel = 286284599661821972;
        public static ulong guild = 285953712898441217;
        public static bool enabled = false;
        public static string message = "";
    }
}
