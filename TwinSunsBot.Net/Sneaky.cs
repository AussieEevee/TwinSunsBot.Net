using System.IO;
using System.Text;

namespace TwinSunsBot.Net
{
   static public class Sneaky
        {
            static string text = File.ReadAllText(@"c:\important\discordtoken.txt", Encoding.UTF8);
            private static string token = text;
            
            public static string Token { get => token; }
        }
    
}
