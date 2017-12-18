using System;
using Discord.Commands;
using System.Threading.Tasks;
using System.IO;
using Discord.WebSocket;

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
            int next = rnd.Next(0, memes.Length + 1);
            string chosen = memes[next];
            Console.WriteLine($"Meme requested by {Context.User.Username}\nArray length: {memes.Length}\nRandom Number chosen: {next}\nMeme file: {chosen}.\n\n");
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

        [Command("help")]
        [Summary("Show help")]
        public async Task HelpMe()
        {
            await Context.Channel.SendMessageAsync($"Help system offline.");

        }

        [Command("beep")]
        public async Task BeepThis(int times = 1)
        {
            for (int i = 0; i < times; i++)
            {
                Console.Beep(550, 500);
            }


            await Context.Channel.SendMessageAsync("Done beeping. What's next?");


        }

        /**AussieEevee Code is so far broken I'm going to use Dylan's code
        [Command("guess")]
        [Summary("Guessing game")]
        public async Task GuessGame(int guess = 0)
        {
            Console.WriteLine($"Debug. Global.number is: {Global.Number}");
            if(Global.Number == 0) { Randomnumber(); }
            
            Console.WriteLine($"\nNew Random Number Guess.\nGuess is {guess}.\nCorrect answer is: {Global.Number}.\n");
            if(guess == 0)
            {
                await Context.Channel.SendMessageAsync($"Welcome to the number guessing game.\n\nI am thinking of a number between 1 and 1000.\n\nUse the !guess [your guess] command to guess what number I am thinking of. Anyone can play.");
            }
            else if(guess == Global.Number)
            {
                Randomnumber();
                await Context.Channel.SendMessageAsync($"{Context.User.Mention} has guessed the number correctly. I was indeed thinking of {guess}. Now, I am thinking of a new number.");
            }
            else if (guess < Global.Number)
            {
                await Context.Channel.SendMessageAsync($"Sorry {Context.User.Mention}, Your guess is lower than the number I am thinking of.");
            }
            else if (guess > Global.Number)
            {
                await Context.Channel.SendMessageAsync($"Sorry {Context.User.Mention}, Your guess is higher than the number I am thinking of.");
            }
            
        }




        
        Random rnd = new Random();

        private void Randomnumber()
        {
            
            Global.Number = rnd.Next(0, 1001);
            Console.WriteLine($"New Number Generated: {Global.Number}");
        }
        */

        //Dylan's code
        [Command("guess")]
        public async Task GuessGame()
        {
            await Context.Channel.SendMessageAsync("It's time for a game of guessing, I've got a number. You may guess! Once it's correct, I'll tell you. It'll be a number between 1-50");
            Random rand = new Random();
            int answer = rand.Next(51);

            (Context.Client as DiscordSocketClient).MessageReceived += (s) => GuessHandler(s, answer);
        }

        private async Task GuessHandler(SocketMessage arg, int answer)
        {
            if (int.Parse(arg.Content) < answer) { await Context.Channel.SendMessageAsync("My number is higher."); }
            else if (int.Parse(arg.Content) > answer) { await Context.Channel.SendMessageAsync("My number is lower."); }

            if (arg.Content.StartsWith(answer.ToString()))
            {
                await arg.Channel.SendMessageAsync($"{arg.Author.Mention} Correct! The answer is indeed {answer}!");
                (Context.Client as DiscordSocketClient).MessageReceived -= (s) => GuessHandler(s, answer);
            }
        }
         


    }

    
}
