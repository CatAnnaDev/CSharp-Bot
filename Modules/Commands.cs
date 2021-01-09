using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Newtonsoft.Json.Linq;
using System.Net;
using System;
using Discord.WebSocket;


public class Root
{
    public string file { get; set; }
}

namespace csharp_discord_bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {

        [Command("ping")]
        public async Task PingAsync()
        {
            await ReplyAsync("Pong!");
        }

        [Command("avatar")]
        public async Task AvatrAsync(ushort size = 512)
        {
            await ReplyAsync(CDN.GetUserAvatarUrl(Context.User.Id, Context.User.AvatarId, size = 512, ImageFormat.Auto));
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
            WebClient c = new WebClient();
            var data = c.DownloadString("https://aws.random.cat/meow");
            JObject meows = JObject.Parse(data);
            var meow = meows.SelectToken("file");
            await ReplyAsync(meow.ToString());
        }
        [Command("dog")]
        public async Task DogAsync()
        {
            WebClient c = new WebClient();
            var data = c.DownloadString("https://dog.ceo/api/breeds/image/random");
            JObject Dogs = JObject.Parse(data);
            var dog = Dogs.SelectToken("message");
            await ReplyAsync(dog.ToString());
        }
        [Command("Love")]
        public async Task LoveAsync()
        {
            WebClient c = new WebClient();
            var data = c.DownloadString("https://api.giphy.com/v1/gifs/random?api_key=&&&&tag=Love&rating=g");
            JObject Loves = JObject.Parse(data);
            var Love = Loves.SelectToken("data");
            var love1 = Love.SelectToken("url");
            await ReplyAsync(love1.ToString());
        }
        [Command("gif")]
        public async Task GifAsync()
        {
            WebClient c = new WebClient();
            var data = c.DownloadString("https://api.giphy.com/v1/gifs/random?api_key=&&&&tag=kittens&rating=g");
            JObject meows = JObject.Parse(data);
            var meow = meows.SelectToken("data");
            var meow1 = meow.SelectToken("url");
            await ReplyAsync(meow1.ToString());
        }
        [Command("meme")]
        [Alias("truc", "fun", "lol")]
        public async Task MemeAsync()
        {
            WebClient c = new WebClient();
            var data = c.DownloadString("https://meme-api.herokuapp.com/gimme"); // /gimme/{subreddit}
            JObject Memes = JObject.Parse(data);
            var meme = Memes.SelectToken("url");
            await ReplyAsync(meme.ToString());
        }
        [Command("asian")]
        [Alias("porn", "pussy", "-18")]
        public async Task AsianAsync()
        {
            WebClient c = new WebClient();
            var data = c.DownloadString("https://meme-api.herokuapp.com/gimme/juicyasians"); // /gimme/{subreddit}
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
    }
}
