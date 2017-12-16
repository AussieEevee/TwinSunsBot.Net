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
            // We can also access the channel from the Command Context.
            await Context.Channel.SendMessageAsync($"Pong! I can see you, {userinfo.Mention}");
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











    }
}
