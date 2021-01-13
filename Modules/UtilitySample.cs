using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_discord_bot
{
    public class UtilitySample : ModuleBase<SocketCommandContext>
    {
        [Command("avatar")]
        [Alias("getavatar")]
        [Summary("Get a user's avatar.")]
        public async Task GetAvatar([Remainder] SocketGuildUser user = null)
            => await ReplyAsync($":frame_photo: **{(user ?? Context.User as SocketGuildUser).Username}**'s avatar\n{Functions.GetAvatarUrl(user)}");

        [Command("ping")]
        [Summary("Show current latency.")]
        public async Task Ping()
            => await ReplyAsync($"Latency: {Context.Client.Latency} ms");
        [Command("role")]
        [Alias("roleinfo")]
        [Summary("Show information about a role.")]
        public async Task RoleInfo([Remainder] SocketRole role)
        {
            // Just in case someone tries to be funny.
            if (role.Id == Context.Guild.EveryoneRole.Id)
                return;

            await ReplyAsync(
                $":flower_playing_cards: **{role.Name}** information```ini" +
                $"\n[Members]             {role.Members.Count()}" +
                $"\n[Role ID]             {role.Id}" +
                $"\n[Hoisted status]      {role.IsHoisted}" +
                $"\n[Created at]          {role.CreatedAt:dd/M/yyyy}" +
                $"\n[Hierarchy position]  {role.Position}" +
                $"\n[Color Hex]           {role.Color}```");
        }

        [Command("info")]
        [Alias("server", "serverinfo")]
        [Summary("Show server information.")]
        [RequireBotPermission(GuildPermission.EmbedLinks)]
        public async Task ServerEmbed()
        {
            double botPercentage = Math.Round(Context.Guild.Users.Count(x => x.IsBot) / Context.Guild.MemberCount * 100d, 2);

            EmbedBuilder embed = new EmbedBuilder()
                .WithColor(0, 225, 225)
                .WithDescription(
                    $"🏷️\n**Guild name:** {Context.Guild.Name}\n" +
                    $"**Guild ID:** {Context.Guild.Id}\n" +
                    $"**Created at:** {Context.Guild.CreatedAt:dd/M/yyyy}\n" +
                    $"**Owner:** {Context.Guild.Owner}\n\n" +
                    $"💬\n" +
                    $"**Users:** {Context.Guild.MemberCount - Context.Guild.Users.Count(x => x.IsBot)}\n" +
                    $"**Bots:** {Context.Guild.Users.Count(x => x.IsBot)} [ {botPercentage}% ]\n" +
                    $"**Channels:** {Context.Guild.Channels.Count}\n" +
                    $"**Roles:** {Context.Guild.Roles.Count}\n" +
                    $"**Emotes: ** {Context.Guild.Emotes.Count}\n\n" +
                    $"🌎 **Region:** {Context.Guild.VoiceRegionId}\n\n" +
                    $"🔒 **Security level:** {Context.Guild.VerificationLevel}")
                 .WithImageUrl(Context.Guild.IconUrl);

            await ReplyAsync($":information_source: Server info for **{Context.Guild.Name}**", embed: embed.Build());
        }

        [Command("source")]
        [Alias("sourcecode", "src")]
        [Summary("Link the source code used for this bot.")]
        public async Task Source()
            => await ReplyAsync($":heart: **{Context.Client.CurrentUser}** is based on this source code:\nhttps://github.com/PsykoDev/CSharp-Bot");
    }
}