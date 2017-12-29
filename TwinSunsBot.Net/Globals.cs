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
        //public static string[] memes = { "Memes/meme01.jpg", "Memes/meme02.jpg", "Memes/meme03.jpg", "Memes/meme04.jpg", "Memes/meme05.jpg", "Memes/meme06.png", "Memes/meme07.jpg", "Memes/meme08.jpg", "Memes/meme09.jpg", "Memes/meme10.jpg", "Memes/meme11.jpg", "Memes/meme12.jpg", "Memes/meme13.jpg", "Memes/meme14.jpg", "Memes/meme15.jpg", "Memes/meme16.jpg", "Memes/meme17.jpg", "Memes/meme18.jpg", "Memes/meme19.jpg", "Memes/meme20.jpg", "Memes/meme21.jpg", "Memes/meme22.jpg", "Memes/meme23.jpg", "Memes/meme24.jpg" };
        public static string[] memes = Directory.GetFiles(@"Memes\");
        public static double version = 1.081;

    }
}
