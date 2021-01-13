using csharp_discord_bot.DataStructs;
using csharp_discord_bot.Services;
using Discord;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace csharp_discord_bot.Handlers
{
    public class GlobalData
    {
        public static string ConfigPath { get; set; } = "Config.json";
        public static BotConfig Config { get; set; }

        public async Task InitializeAsync()
        {
            var json = string.Empty;

            if (!File.Exists(ConfigPath))
            {
                json = JsonConvert.SerializeObject(GenerateNewConfig(), Formatting.Indented);
                File.WriteAllText("Config.json", json, new UTF8Encoding(false));
                await LoggingService.LogAsync("Bot", LogSeverity.Error, "No Config file found. A new one has been generated. Please close the & fill in the required section.");
                await Task.Delay(-1);
            }

            json = File.ReadAllText(ConfigPath, new UTF8Encoding(false));
            Config = JsonConvert.DeserializeObject<BotConfig>(json);
        }

        private static BotConfig GenerateNewConfig() => new BotConfig
        {
            //BOT
            token = "",
            prefixes = "!",
            join_message = "CHANGE ME IN CONFIG",
            //GameStatus
            currently = "playing|listening|watching|streaming",
            playing_status = "cool status here.",
            status = "online|dnd|idle|offline",
            //URL
            Cats = "https://aws.random.cat/meow",
            Dogs = "https://dog.ceo/api/breeds/image/random",
            giphelove = "https://api.giphy.com/v1/gifs/random?api_key= CHANGE_ME &tag=Love&rating=g",
            giphykittens = "https://api.giphy.com/v1/gifs/random?api_key= CHANGE_ME &tag=kittens&rating=g",
            meme = "https://meme-api.herokuapp.com/gimme",
            porn = "",
            //BL
            BlacklistedChannels = new List<ulong>()
        };
    }
}