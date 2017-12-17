using System;
using Discord.Commands;
using System.Threading.Tasks;
using System.IO;

namespace TwinSunsBot.Net
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("square")]
        [Summary("Squares a number.")]
        public async Task SquareAsync([Summary("The number to square.")] int num)
        {
            // We can also access the channel from the Command Context.
            await Context.Channel.SendMessageAsync($"{num}^2 = {Math.Pow(num, 2)}");
        }

        [Command("ping")]
        [Summary("Check to see if the bot is working?")]
        public async Task PingBot()
        {
            var userinfo = Context.User;
            var ping = Context.Client.Latency;
            // We can also access the channel from the Command Context.
            await Context.Channel.SendMessageAsync($"Pong! I can see you, {userinfo.Mention}. The bots ping is: {ping}ms.");
        }

        [Command("hi")]
        [Summary("Say hi to the user.")]
        public async Task HiUser()
        {
            var userinfo = Context.User;
            // We can also access the channel from the Command Context.
            await Context.Channel.SendMessageAsync($"Hello {userinfo.Mention}!");
        }

        [Command("version")]
        [Summary("Check what version we are running.")]
        public async Task VersionCheck()
        {
            await Context.Channel.SendMessageAsync($"This is Twin Suns Bot .Net version {Program.version}");
        }

        [Command("random")]
        [Summary("Returns a random number.")]
        public async Task RandomNumber([Summary("The lowest number.")] int min, [Summary("The highest number.")] int max)
        {
            var rnd = new Random();
            await Context.Channel.SendMessageAsync($"🎲 Your random number is: {rnd.Next(min, max)}");
        }

        [Command("pi")]
        [Summary("What is pi?")]
        public async Task TellMePi()
        {
            double pi = Math.PI;
            var userinfo = Context.User;
            await Context.Channel.SendMessageAsync($"```You can't calculate pi yourself, {userinfo.Mention}? Pi is: {pi}```");

        }

        
        [Command("memes")]
        [Summary("Show a random meme")]
        public async Task ShowAMeme()
        {
            string[] memes = { "","Memes/meme01.jpg", "Memes/meme02.jpg", "Memes/meme03.jpg", "Memes/meme04.jpg", "Memes/meme05.jpg", "Memes/meme06.png", "Memes/meme07.jpg", "Memes/meme08.jpg", "Memes/meme09.jpg", "Memes/meme10.jpg", "Memes/meme11.jpg", "Memes/meme12.jpg", "Memes/meme13.jpg", "Memes/meme14.jpg", "Memes/meme15.jpg", "Memes/meme16.jpg", "Memes/meme17.jpg", "Memes/meme18.jpg", "Memes/meme19.jpg", "Memes/meme20.jpg", "Memes/meme21.jpg", "Memes/meme22.jpg", "Memes/meme23.jpg", "Memes/meme24.jpg" };
            var rnd = new Random();
            int next = rnd.Next(0, memes.Length);
            string chosen = memes[next];
            Console.WriteLine($"Meme requested.\nArray length: {memes.Length}\nRandom Number chosen: {next}\nMeme file: {chosen}.");
            if (File.Exists(chosen))
                {
                    await Context.Channel.SendFileAsync(chosen,"Memes curtosy of Star Wars Legends Memes on Facebook.");
                }
            else
                {
                     await Context.Channel.SendMessageAsync($"I had trouble accessing the meme database. Try again.");
                }
            
            //await Context.Channel.SendMessageAsync($"I'm sorry. Memes are unavailable at the moment. Blame the lazy developer.");

        }

        [Command("help")]
        [Summary("Show help")]
        public async Task HelpMe()
        {
            await Context.Channel.SendMessageAsync($"Help system offline.");

        }





    }
}
