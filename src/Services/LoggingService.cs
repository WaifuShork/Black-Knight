using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Blacknight.Logging
{
    internal class LoggingService
    {
       public LoggingService(DiscordSocketClient client)
       {
            client.Log += LogAsync;
       }

       private Task LogAsync(LogMessage msg)
       {
            if (msg.Severity == LogSeverity.Info) Console.ForegroundColor = ConsoleColor.Green;
            if (msg.Severity == LogSeverity.Error) Console.ForegroundColor = ConsoleColor.Red;
            if (msg.Severity == LogSeverity.Critical) Console.ForegroundColor = ConsoleColor.DarkRed;
            if (msg.Severity == LogSeverity.Warning) Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(msg.ToString() + $"    [Severity: {msg.Severity}]");

            return Task.CompletedTask;
       }
    }
}
