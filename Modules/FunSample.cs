using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace csharp_discord_bot
{
    public class FunSample : ModuleBase<SocketCommandContext>
    {
        
        [Command("hello")] 
        [Summary("Say hello to the bot.")] 
        public async Task Hello()
            => await ReplyAsync($"Hello there, **{Context.User.Username}**!");

        [Command("pick")]
        [Alias("choose")] 
        [Summary("Pick something.")]
        public async Task Pick([Remainder]string message = "")
        {
            string[] options = message.Split(new string[] { " or " }, StringSplitOptions.RemoveEmptyEntries);
            string selection = options[new Random().Next(options.Length)];

            // ReplyAsync() is a shortcut for Context.Channel.SendMessageAsync()
            await ReplyAsync($"I choose **{selection}**");            
        }

        [Command("cookie")]
        [Summary("Give someone a cookie.")]
        public async Task Cookie(SocketGuildUser user)
        {
            if (Context.Message.Author.Id == user.Id)
                await ReplyAsync($"{Context.User.Mention} doesn't have anyone to share a cookie with... :(");          
            else
                await ReplyAsync($"{Context.User.Mention} shared a cookie with **{user.Username}** :cookie:");
        }

        [Command("amiadmin")]
        [Summary("Check your administrator status")]
        public async Task AmIAdmin()
        {
            if ((Context.User as SocketGuildUser).GuildPermissions.Administrator)
                await ReplyAsync($"Yes, **{Context.User.Username}**, you're an admin!");
            else
                await ReplyAsync($"No, **{Context.User.Username}**, you're **not** an admin!");
        }
    }
}
