using System.Collections.Generic;

namespace csharp_discord_bot.DataStructs
{
    public class BotConfig
    {   //BOT
        public string Token { get; set; }
        public string Prefixes { get; set; }
        public string Join_message { get; set; }

        //GameStatus
        public string Currently { get; set; }

        public string Playing_status { get; set; }
        public string Status { get; set; }

        //URL
        public string Cats { get; set; }

        public string Dogs { get; set; }
        public string Giphelove { get; set; }
        public string Giphykittens { get; set; }
        public string Meme { get; set; }
        public string Porn { get; set; }

        //BL
        public List<ulong> BlacklistedChannels { get; set; }
    }
}