using System.Threading.Tasks;
using Blacknight.Services;
using Discord;
using Discord.WebSocket;

namespace Blacknight
{
    internal static class Blacknight
    {
        private static DiscordSocketClient client;
        private static LoggingService logger;
        
        internal static async Task StartAsync()
        {
            var config = new DiscordSocketConfig
            { 
                MessageCacheSize = 100,
                AlwaysDownloadUsers = true
            };

            client = new DiscordSocketClient(config);
            logger = new LoggingService(client); // Start the bots logger.

            var botConfig = await ConfigurationLoaderService.GetConfig();

            await client.LoginAsync(TokenType.Bot, botConfig.Token);
            await client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
    }
}