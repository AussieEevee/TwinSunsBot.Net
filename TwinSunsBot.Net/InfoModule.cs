using System;
using Discord.Commands;
using System.Threading.Tasks;

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
            await Context.Channel.SendMessageAsync($"You can't calculate pi yourself, {userinfo.Mention}? Pi is: " + pi);

        }

        
        [Command("memes")]
        [Summary("Show a random meme")]
        public async Task ShowAMeme()
        {
            await Context.Channel.SendMessageAsync($"I'm sorry. Memes are unavailable at the moment. Blame the lazy developer.");

        }






    }
}
