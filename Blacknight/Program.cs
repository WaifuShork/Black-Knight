using Blacknight.Logging;
using Blacknight.Services;
using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Blacknight
{
    class Program
    {
        static string token;
        static DiscordSocketClient client;
        static LoggingService logger;

        static void Main(string[] args) => StartAsync().GetAwaiter().GetResult();

        public static async Task StartAsync()
        {
            var config = new DiscordSocketConfig
            { 
                MessageCacheSize = 100
            };

            client = new DiscordSocketClient(config);
            token = ConfigurationService.GetClientToken();

            logger = new LoggingService(client); // Start the bots logger.

            // Login and start the bot.
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
    }
}
