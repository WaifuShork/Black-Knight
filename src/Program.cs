using Blacknight.Services;
using Discord;
using Discord.WebSocket;
using System.IO;
using System.Threading.Tasks;


namespace Blacknight
{
    internal static class Program
    {
        private static DiscordSocketClient client;
        private static LoggingService logger;

        private static async Task Main() => await StartAsync();

        private static async Task StartAsync()
        {
            var config = new DiscordSocketConfig
            { 
                MessageCacheSize = 100,
                // Download users for caching reasons because Discord.NET is jank
                AlwaysDownloadUsers = true
            };

            client = new DiscordSocketClient(config);

            logger = new LoggingService(client); // Start the bots logger.

            // Login and start the bot.
            await client.LoginAsync(TokenType.Bot, ConfigurationLoaderService.GetConfig("TOKEN"));
            await client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
    }
}
