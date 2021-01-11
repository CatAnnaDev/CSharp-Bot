using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Newtonsoft.Json.Linq;
using System.Net;
using System;
using Discord.WebSocket;
using System.Configuration;

namespace csharp_discord_bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        string Cats;
        string Dogy;
        string giphelove;
        string giphykittens;
        string memeu;
        string porns;

        [Command("ping")]
        public async Task PingAsync()
        {
            await ReplyAsync("Pong!");
        }
        [Command("avatar")]
        public async Task AvatrAsync(ushort Size = 512)
        {
            await ReplyAsync(CDN.GetUserAvatarUrl(Context.User.Id, Context.User.AvatarId, Size = 512, ImageFormat.Auto));
        }
        [Command("react")]
        public async Task ReactAsync(string pmsg, string pEmoji)
        {
            var message = await Context.Channel.SendMessageAsync(pmsg);
            var emeji = new Emoji(pEmoji);
            await message.AddReactionAsync(emeji);
        }

        [Command("meow")]
        [Alias("cats", "cat", "yaong")]
        public async Task MeowAsync()
        {
            Cats = ConfigurationManager.AppSettings.Get("Cats");
            WebClient c = new WebClient();
            var data = c.DownloadString(Cats);
            JObject meows = JObject.Parse(data);
            var meow = meows.SelectToken("file");
            await ReplyAsync(meow.ToString());
        }
        [Command("dog")]
        public async Task DogAsync()
        {
            Dogy = ConfigurationManager.AppSettings.Get("Dogs");
            WebClient c = new WebClient();
            var data = c.DownloadString(Dogy);
            JObject Dogs = JObject.Parse(data);
            var dog = Dogs.SelectToken("message");
            await ReplyAsync(dog.ToString());
        }
        [Command("Love")]
        public async Task LoveAsync()
        {
            giphelove = ConfigurationManager.AppSettings.Get("giphelove");
            WebClient c = new WebClient();
            var data = c.DownloadString(giphelove);
            JObject Loves = JObject.Parse(data);
            var Love = Loves.SelectToken("data");
            var love1 = Love.SelectToken("url");
            await ReplyAsync(love1.ToString());
        }
        [Command("gif")]
        public async Task GifAsync()
        {
            giphykittens = ConfigurationManager.AppSettings.Get("giphykittens");
            WebClient c = new WebClient();
            var data = c.DownloadString(giphykittens);
            JObject meows = JObject.Parse(data);
            var meow = meows.SelectToken("data");
            var meow1 = meow.SelectToken("url");
            await ReplyAsync(meow1.ToString());
        }
        [Command("meme")]
        [Alias("truc", "fun", "lol")]
        public async Task MemeAsync()
        {
            memeu = ConfigurationManager.AppSettings.Get("meme");
            WebClient c = new WebClient();
            var data = c.DownloadString(memeu);
            JObject Memes = JObject.Parse(data);
            var meme = Memes.SelectToken("url");
            await ReplyAsync(meme.ToString());
        }
        [Command("asian")]
        [Alias("porn", "pussy", "-18")]
        public async Task AsianAsync()
        {
            porns = ConfigurationManager.AppSettings.Get("porn");
            WebClient c = new WebClient();
            var data = c.DownloadString(porns);
            JObject asians = JObject.Parse(data);
            var asian = asians.SelectToken("url");
            await ReplyAsync(asian.ToString());
        }
        public class InfoModule : ModuleBase<SocketCommandContext>
        {
            [Command("say")]
            [Summary("Echoes a message.")]
            public Task SayAsync([Remainder][Summary("The text to echo")] string echo)
                => ReplyAsync(echo);
        }
        [Command("square")]
        [Summary("Squares a number.")]
        public async Task SquareAsync(
            [Summary("The number to square.")]
        int num)
        {
            await ReplyAsync($"{num}^2 = {Math.Pow(num, 2)}");
        }
        [Command("userinfo")]
        [Summary
        ("Returns info about the current user, or the user parameter, if one passed.")]
        [Alias("user", "whois")]
        public async Task UserInfoAsync(
            [Summary("The (optional) user to get info from")]
        SocketUser user = null)
        {
            var userInfo = user ?? Context.Client.CurrentUser;
            await ReplyAsync($"{userInfo.Username}#{userInfo.Discriminator}");
        }

    }
}
