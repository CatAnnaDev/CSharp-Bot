using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

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
        public async Task MeowAsync()
        {
            await ReplyAsync("https://tenor.com/view/ajaa-gif-19469374");
        }
    }
}
