using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Blacknight.Services
{ 
    internal class LoggingService
    { 
        public LoggingService(DiscordSocketClient client)
        { 
            client.Log += LogAsync;
            client.Ready += () =>
            { 
                LogMsg($"{client.CurrentUser} connected to Discord with latency of {client.Latency} ms", "Info", "Blacknight").GetAwaiter().GetResult();
                return Task.CompletedTask;
            };
        }
        
        private async Task LogAsync(LogMessage msg)
        { 
            Console.ForegroundColor = msg.Severity switch
            {
                LogSeverity.Info => ConsoleColor.Green,
                LogSeverity.Error => ConsoleColor.Red,
                LogSeverity.Critical => ConsoleColor.DarkYellow,
                LogSeverity.Warning => ConsoleColor.Yellow,
                LogSeverity.Verbose => ConsoleColor.Cyan,
                LogSeverity.Debug => ConsoleColor.DarkMagenta,
                _ => throw new ArgumentOutOfRangeException(nameof(msg.Severity), msg.Severity, "Arguments were out of range at LogAsync()l")
            };

            await Console.Out.WriteLineAsync($"[Severity: {msg.Severity}] {msg}");
            Console.ResetColor();
            await Task.CompletedTask;
        }

        private async Task LogMsg(string msg, string log, string source)
        {
            Console.ForegroundColor = log switch
            {
                "Info" => ConsoleColor.Green,
                "Error" => ConsoleColor.Red,
                _ => throw new ArgumentOutOfRangeException(nameof(log), log, "Arguments were out of range at LogMsg();")
            };

            var time = DateTime.Now.ToString("HH:mm:ss");
            await Console.Out.WriteLineAsync($"[Severity: {log}] {time} {source} {msg}");
            Console.ResetColor();
            await Task.CompletedTask;
        }
    }
}
