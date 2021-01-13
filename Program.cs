using csharp_discord_bot.Services;
using System.Threading.Tasks;

namespace csharp_discord_bot
{
    internal class Program
    {
        private static Task Main()
            => new DiscordService().InitializeAsync();
    }
}