using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Configuration;

namespace csharp_discord_bot
{
    class Program
    {
        private DiscordSocketClient client;
        private CommandService commands;
        private CommandService Help;

        static void Main(string[] args) 
            => new Program().RunBotAsync().GetAwaiter().GetResult();
       
        public async Task RunBotAsync()
            {
            string Token;
            string Hellow;

            client = new DiscordSocketClient(new DiscordSocketConfig
                { 
                    LogLevel = LogSeverity.Debug 
                });

            commands = new CommandService();
            Help = new CommandService();
            client.Log += Log;
            commands.Log += Log;
            Help.Log += Log;
            client.Ready += () =>
                {
                    Hellow = ConfigurationManager.AppSettings.Get("Hellow");
                    Console.WriteLine("[Info]: " + Hellow);
                    return Task.CompletedTask;
                };

            await InstallCommandsAsync();
            
            Token = ConfigurationManager.AppSettings.Get("Token");
                await client.LoginAsync(TokenType.Bot, Token);
           // Console.WriteLine("The value of Token: " + sAttr);
            await client.StartAsync();
            await Task.Delay(-1);
        }

        public async Task InstallCommandsAsync()
        {
            client.MessageReceived += HandleCommandAsync;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);
            await Help.AddModulesAsync(Assembly.GetEntryAssembly(), null);
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

        private static Task Log (LogMessage arg)
        {
            switch (arg.Severity)
            {
                case LogSeverity.Critical:
                case LogSeverity.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogSeverity.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogSeverity.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogSeverity.Verbose:
                case LogSeverity.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            }
                Console.WriteLine($"{DateTime.Now,-19} [{arg.Severity,7}] {arg.Source}: {arg.Message} {arg.Exception}");
                Console.ResetColor();
            return Task.CompletedTask;
        }
    }

}

