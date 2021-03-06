﻿using System;
using Discord.Commands;
using System.Threading.Tasks;
using System.IO;
using Discord.WebSocket;
using Discord;

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

        [Command("donate")]
        [Summary("Request donation information")]
        public async Task donate()
        {
            // We can also access the channel from the Command Context.
            await Context.Channel.SendMessageAsync($"We appreciate your inquery, {Context.User.Username}. You can support Twin Suns here, all donations go towards the current fundraiser: https://www.twin-suns.net/donate");
        }



        [Command("hi")]
        [Summary("Say hi to the user.")]
        public async Task HiUser()
        {
            var userinfo = Context.User;
            // We can also access the channel from the Command Context.
            await Context.Channel.SendMessageAsync($"Hello {userinfo.Mention}!");
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
            
            var rnd = new Random();
            int next = rnd.Next(0, Global.memes.Length - 1);
            string chosen = Global.memes[next];
            Console.WriteLine($"Meme requested by {Context.User.Username}\nArray length: {Global.memes.Length}\nRandom Number chosen: {next}\nMeme file: {chosen}.\n\n");
            if (File.Exists(chosen))
                {
                    await Context.Channel.SendFileAsync(chosen, "Memes courtesy of Star Wars Legends Memes on Facebook.");
                }
            else
                {
                     await Context.Channel.SendMessageAsync($"I had trouble accessing the meme database. Try again.");
                }
            
            //await Context.Channel.SendMessageAsync($"I'm sorry. Memes are unavailable at the moment. Blame the lazy developer.");

        }

        [Command("listmemes")]
        [Summary("LIsts the memes array")]
        public async Task ListMemes()
        {
            Console.WriteLine("\nList of memes in the array requested. Processing....");
            for (int i = 0; i < Global.memes.Length; i++)
            {
                Console.WriteLine($"{i} = {Global.memes[i]}");
            }
            await Context.Channel.SendMessageAsync($"I have listed the memes array in the console window.");

        }

        [Command("help")]
        [Summary("Show help")]
        public async Task HelpMe()
        {
            await Context.Channel.SendMessageAsync($"Help system offline.");

        }

        [Command("admin")]
        public async Task AdminCommand(string cmd = "")
        {
            string thecmd = cmd.ToLower();
            if (Context.User.Username == "AussieEevee" || Context.User.Username == "Brian Borg" || Context.User.Username == "Saberthrib")
            {
                switch (thecmd)
            {
                case "test":
                    await Context.Channel.SendMessageAsync($"Admin Command Test");
                    break;

                case "reloadmemes":
                    Console.WriteLine("Reload Meme directory requested.");
                    Global.memes = Directory.GetFiles(@"Memes\");
                    await Context.Channel.SendMessageAsync($"Memes refreshed. I have {Global.memes.Length} memes in my database.");
                    break;

                case "version":
                    await Context.Channel.SendMessageAsync($"This is TwinSunsBot.Net v{Global.version}");
                    break;

                case "ping":
                    var userinfo = Context.User;
                    var ping = Context.Client.Latency;
                    // We can also access the channel from the Command Context.
                    await Context.Channel.SendMessageAsync($"Pong! I can see you, {userinfo.Mention}. The bots ping is: {ping}ms.");
                    break;

                default:
                    await Context.User.SendMessageAsync("Valid Commands are: test, reloadmemes, ping, version.");
                    await Context.Channel.SendMessageAsync($"Command vacant or not recognized. Valid commands have been PMed to you.");
                    break;


            }
            
            
               
            }
            else
            {
                await Context.Channel.SendMessageAsync($"Only admins can use these commands. Sorry, {Context.User.Username}.");
            }



        }

        [Command("beep")]
        public async Task BeepThis(int times = 1)
        {
            if(Context.User.Username == "AussieEevee")
            {
                for (int i = 0; i < times; i++)
                {
                    Console.Beep(550, 500);
                }


                await Context.Channel.SendMessageAsync("I have finished my beeping, @AussieEevee. What's next?");
            }
            else
            {
                await Context.Channel.SendMessageAsync("You're not AussieEevee.");
            }
           


        }

    }

}
