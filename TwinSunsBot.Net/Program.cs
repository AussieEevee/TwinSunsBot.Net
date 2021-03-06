﻿using System;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace TwinSunsBot.Net
{
    class Program
    {
         //set the version number, so we can check which version is running on the server

        static void Main(string[] args)
                => new Program().MainAsync().GetAwaiter().GetResult();
        public static DiscordSocketClient _client = new DiscordSocketClient();
        private CommandService _commands;


        private IServiceProvider _services;
        private void ScanMemes()
        {


        }
        public async Task MainAsync()
        {

            //_client = new DiscordSocketClient(); //Create the discord client.

            _client.Log += Log; // log important stuff
            _commands = new CommandService();
            string ver;
            if (System.Diagnostics.Debugger.IsAttached)
            {
                ver = $"{Global.version}.debug"; // code or timeout value when running tests in debug mode
            }

            else
            {
                ver = $"{Global.version}";  // non debug mode
            }

            Console.WriteLine($"TwinSunsBot.Net version {ver}");


            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            await InstallCommandsAsync(); // Install the command service
            string token = Sneaky.Token; // Our secret little token that is the source of all our power.
            await _client.LoginAsync(TokenType.Bot, token); // We should login, shouldn't we?
            await _client.StartAsync(); //Start the client.
            await _client.SetGameAsync($"v{ver}"); // Set the running game to our current version.


            _client.UserJoined += async (s) =>
            {
                Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy")} {DateTime.Now.ToString("HH:mm:ss")} New user has joined: {s.Username}"); // Log to the console that someone joined us.
                await s.Guild.DefaultChannel.SendMessageAsync($"Everyone, Please welcome {s.Mention} to the server!\n\nFeel free to tell us a little about yourself, {s.Username}.\n\nWhere are you from? What Star Wars books do you like?\n\n Do you play the Star Wars video games? Are you interested in the Disney-era movies?\n\nAnd if you haven't already, don't forget to like our Facebook, Youtube, Twitter and Twitch accounts."); // Announce them to the world

            };

            _client.UserLeft += async (s) =>
            {
                Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy")} {DateTime.Now.ToString("HH:mm:ss")} User left: {s.Username}"); // Why'd they leave? :(
                await s.Guild.DefaultChannel.SendMessageAsync($"{s.Username} has left the server. This makes me sad."); // Say good bye to our comrade.

            };

            DonationAd.Run();
            // Block this task until the program is closed.
            await Task.Delay(-1);

        }
        public async Task InstallCommandsAsync()
        {
            // Hook the MessageReceived Event into our Command Handler
            _client.MessageReceived += HandleCommandAsync;
            // Discover all of the commands in this assembly and load them.
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            // Don't process the command if it was a System Message
            var message = messageParam as SocketUserMessage;
            if (message == null) return;
            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;
            // Determine if the message is a command, based on if it starts with '!' or a mention prefix
            if (!(message.HasCharPrefix('!', ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))) return;
            // Create a Command Context
            var context = new SocketCommandContext(_client, message);
            // Execute the command. (result does not indicate a return value, 
            // rather an object stating if the command executed successfully)
            var result = await _commands.ExecuteAsync(context, argPos, _services);
            if (!result.IsSuccess)
                await context.Channel.SendMessageAsync(result.ErrorReason);
        }


        private Task Log(LogMessage msg)
        {
            Console.WriteLine($"{DateTime.Now.ToString(Global.dateformat)} {msg.ToString()}"); // Log our logs to the console
            return Task.CompletedTask;
        }

        public static void Log (string msg)
        {
            Console.WriteLine($"{DateTime.Now.ToString(Global.dateformat)} {msg}"); // Log our logs to the console
        }
        

    };


   




}

