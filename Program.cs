using System.Threading.Tasks;
using csharp_discord_bot.Services;

namespace csharp_discord_bot
{
    class Program
    {
        private static Task Main()
            => new DiscordService().InitializeAsync();
    }
}
