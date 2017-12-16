using System;
using System.Threading.Tasks;
using System.Reflection;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace TwinSunsBot.Net
{
    class Program
    {
        public static double version = 0.22;

        static void Main(string[] args)
            	=> new Program().MainAsync().GetAwaiter().GetResult();
        private DiscordSocketClient _client;
        private CommandService _commands;
        
      
        private IServiceProvider _services;
        public async Task MainAsync()
            {
            _client = new DiscordSocketClient();

            _client.Log += Log;
            _commands = new CommandService();

            // Avoid hard coding your token. Use an external source instead in your code.
            

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            await InstallCommandsAsync();
            string token = Sneaky.Token; // Remember to keep this private!
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();


            _client.UserJoined += async (s) =>
            {
                Console.WriteLine($"New user has joined: {s.Username}");
                await s.Guild.GetTextChannel(391550686958977036).SendMessageAsync($"Welcome {s.Mention} to the server!");
                
            };

            _client.UserLeft += async (s) =>
            {
                Console.WriteLine($"User left: {s.Username}");
                await s.Guild.GetTextChannel(391550686958977036).SendMessageAsync($"{s.Username} has left the server. This makes me sad.");

            };

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
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
        

    };







}

