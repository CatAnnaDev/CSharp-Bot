using Discord;
using Discord.Commands;
using System;
using System.Text;
using System.Threading.Tasks;
using csharp_discord_bot.Handlers;
using System.Linq;
using System.Collections.Generic;
using Victoria;

namespace csharp_discord_bot.Services
{
    public sealed class BotService
    {
        public LavaLinkAudio Audio { get; set; }

        public async Task<Embed> DisplayInfoAsync(SocketCommandContext context)
        {
            var fields = new List<EmbedFieldBuilder>();
            fields.Add(new EmbedFieldBuilder {
                Name = "Client Info",
                Value = $"Current Server: {context.Guild.Name} - Prefix: {GlobalData.Config.prefixes}",
                IsInline = false
            });
            fields.Add(new EmbedFieldBuilder {
                Name = "Guild Info",
                Value = $"Current People: {context.Guild.Users.Count(x => !x.IsBot)} - Current Bots: {context.Guild.Users.Count(x => x.IsBot)} - Overall Users: {context.Guild.Users.Count}\n" +
                $"Text Channels: {context.Guild.TextChannels.Count} - Voice Channels: {context.Guild.VoiceChannels.Count}",
                IsInline = false
            });

            var embed = await Task.Run(() => new EmbedBuilder
            {
                Title = $"Info",
                ThumbnailUrl = context.Guild.IconUrl,
                Timestamp = DateTime.UtcNow,
                Color = Color.DarkOrange,
                Footer = new EmbedFooterBuilder { Text = "PsykoDev C#_discord_bot", IconUrl = context.Client.CurrentUser.GetAvatarUrl() },
                Fields = fields
            });

            return embed.Build();
        }

    }
}
