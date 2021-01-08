using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Configuration;
using System.Collections.Specialized;

namespace csharp_discord_bot
{
    class Program
    {
        private DiscordSocketClient client;
        private CommandService commands;

        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();
       
        public async Task RunBotAsync()
            {
            string Token;
            string Hellow;
            
            client = new DiscordSocketClient(new DiscordSocketConfig
                { 
                    LogLevel = LogSeverity.Debug 
                });

            commands = new CommandService();
                client.Log += Log;
                client.Ready += () =>
                {
                    Hellow = ConfigurationManager.AppSettings.Get("Hellow");
                    Console.WriteLine("[Info]: " + Hellow);
                    return Task.CompletedTask;
                };

            await InstallCommandsAsync();
            
            Token = ConfigurationManager.AppSettings.Get("Token");
            if (Token.Length <= 50)
            {
                Console.WriteLine("NO TOKEN OR WRONG" + Token);
            }
            await client.LoginAsync(TokenType.Bot, Token);
           // Console.WriteLine("The value of Token: " + sAttr);
            await client.StartAsync();
            await Task.Delay(-1);
        }

        public async Task InstallCommandsAsync()
        {
            client.MessageReceived += HandleCommandAsync;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);
        }

        private async Task HandleCommandAsync(SocketMessage pmsg)
        {
            var message = (SocketUserMessage)pmsg;
            if (message == null) return;
            int argPos = 0;

            // Prefix
            if (!message.HasCharPrefix('!', ref argPos)) return;
            var context = new SocketCommandContext(client, message);
            var result = await commands.ExecuteAsync(context, argPos, null);

            // Erreur
            if (!result.IsSuccess) 
                await context.Channel.SendMessageAsync(result.ErrorReason);
        }

        private Task Log (LogMessage arg)
        {
            Console.WriteLine(arg.ToString());
            return Task.CompletedTask;
        }
    }
}
