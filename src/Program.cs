using Blacknight.Logging;
using Discord;
using Discord.WebSocket;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Blacknight
{
    internal static class Program
    {
        private static DiscordSocketClient _client;
        private static LoggingService _logger;

        // Dunno why you had args, you weren't even using them
        // This method can also be async so you don't need to 
        // GetAwaiter().GetResult() on it. 
        private static async Task Main() => await StartAsync();

        private static async Task StartAsync()
        {
            var config = new DiscordSocketConfig
            { 
                MessageCacheSize = 100,
                // Download users for caching reasons because Discord.NET is jank
                AlwaysDownloadUsers = true
            };

            // I'm not going to handle exceptions for you lmao
            var json = await File.ReadAllTextAsync("appsettings.json");
            var botConfig = JsonConvert.DeserializeObject<Configuration>(json);

            _client = new DiscordSocketClient(config);

            _logger = new LoggingService(_client); // Start the bots logger.

            // Login and start the bot.
            await _client.LoginAsync(TokenType.Bot, botConfig!.Token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
    }
}
