using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Audio;
using Newtonsoft.Json.Linq;
using System.Net;
using System;
using Discord.WebSocket;
using System.Configuration;

namespace csharp_discord_bot.Modules
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task HelpAsync()
        {
            var builder = new EmbedBuilder()
    .WithTitle("~(c# bot help )~")
    .WithColor(new Color(0xFF00FF))
    .WithTimestamp(DateTimeOffset.FromUnixTimeMilliseconds(1610151618624))
    .AddField("!ping", "ping le bot")
    .AddField("!love", "Love pic")
    .AddField("!gif", "Kittens gif")
    .AddField("!avatar", "retrouve le lien de vôtre avatar discord")
    .AddField("!react", "auto react a une phrase")
    .AddField("!meow", "Kittens gif / pic")
    .AddField("!dog", "Dogs gif / pic")
    .AddField("!meme", "Meme gif / pic")
    .AddField("!say", "repeat your last sentence")
    .AddField("!square", "square a number")
    .AddField("!userinfo", "return info about the current user")
    .AddField("!asian", "fun fun fun");
            var embed = builder.Build();
            await ReplyAsync(
                null,
                embed: embed)
                .ConfigureAwait(false);
        }

        [Command("TEST")]
        public async Task TestAsync(SocketUser user = null)
        {
                var userInfo = user ?? Context.Client.CurrentUser;
                await ReplyAsync(
                    $"{userInfo.Username}#{userInfo.Discriminator} \n" +
                    $"is: {userInfo.Status}");
        }

        [Command("print")]
        public async Task PrintAsync()
        {
            config();
        }

        public void config()
        {
            Console.WriteLine("Count: " + ConfigurationManager.AppSettings.Count);
            Console.WriteLine("Token: " + ConfigurationManager.AppSettings.Get("Token"));
            Console.WriteLine("Cats: " + ConfigurationManager.AppSettings.Get("Cats"));
            Console.WriteLine("Dogs: " + ConfigurationManager.AppSettings.Get("Dogs"));
            Console.WriteLine("giphelove: " + ConfigurationManager.AppSettings.Get("giphelove"));
            Console.WriteLine("giphykittens: " + ConfigurationManager.AppSettings.Get("giphykittens"));
            Console.WriteLine("meme: " + ConfigurationManager.AppSettings.Get("meme"));
            Console.WriteLine("porn: " + ConfigurationManager.AppSettings.Get("porn"));
            Console.WriteLine("Hellow: " + ConfigurationManager.AppSettings.Get("Hellow"));
        }
    }
}
