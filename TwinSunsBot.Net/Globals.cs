using System.IO;

namespace TwinSunsBot.Net
{
    public static class Global
    {
        public static int Number { get; set; }
        public static string[] memes = Directory.GetFiles(@"Memes\");
        public static double version = 1.089;

    }
}
