using System.Collections.Generic;

namespace csharp_discord_bot.DataStructs
{
    public class BotConfig
    {   //BOT
        public string token { get; set; }
        public string prefixes { get; set; }
        public string join_message { get; set; }

        //GameStatus
        public string currently { get; set; }

        public string playing_status { get; set; }
        public string status { get; set; }

        //URL
        public string Cats { get; set; }

        public string Dogs { get; set; }
        public string giphelove { get; set; }
        public string giphykittens { get; set; }
        public string meme { get; set; }
        public string porn { get; set; }

        //BL
        public List<ulong> BlacklistedChannels { get; set; }
    }
}