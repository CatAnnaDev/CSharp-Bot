using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Newtonsoft.Json.Linq;
using System.Net;
using System;
using Discord.WebSocket;

namespace csharp_discord_bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {

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
            JObject config = Functions.GetConfig();
            string Cats = config["Cats"].Value<string>();
            WebClient c = new WebClient();
            var data = c.DownloadString(Cats);
            JObject meows = JObject.Parse(data);
            var meow = meows.SelectToken("file");
            await ReplyAsync(meow.ToString());
        }
        [Command("dog")]
        public async Task DogAsync()
        {
            JObject config = Functions.GetConfig();
            string Dogy = config["Dogs"].Value<string>();
            WebClient c = new WebClient();
            var data = c.DownloadString(Dogy);
            JObject Dogs = JObject.Parse(data);
            var dog = Dogs.SelectToken("message");
            await ReplyAsync(dog.ToString());
        }
        [Command("Love")]
        public async Task LoveAsync()
        {
            JObject config = Functions.GetConfig();
            string giphelove = config["giphelove"].Value<string>();
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
            JObject config = Functions.GetConfig();
            string giphykittens = config["giphykittens"].Value<string>();
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
            JObject config = Functions.GetConfig();
            string memeu = config["meme"].Value<string>();
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
            JObject config = Functions.GetConfig();
            string porns = config["porn"].Value<string>();
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
