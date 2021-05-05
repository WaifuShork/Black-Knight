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
                LogMsg($"{client.CurrentUser} connected to Discord with latency of {client.Latency} ms", "Info", "Blacknight");
                return Task.CompletedTask;
            };
       }

       private Task LogAsync(LogMessage msg)
       {
            if (msg.Severity == LogSeverity.Info) Console.ForegroundColor = ConsoleColor.Green;
            if (msg.Severity == LogSeverity.Error) Console.ForegroundColor = ConsoleColor.Red;
            if (msg.Severity == LogSeverity.Critical) Console.ForegroundColor = ConsoleColor.DarkRed;
            if (msg.Severity == LogSeverity.Warning) Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"[Severity: {msg.Severity}] " + msg.ToString());

            Console.ResetColor();

            return Task.CompletedTask;
       }

        private void LogMsg(string msg, string log, string source)
        {
            switch(log)
            {
                case "Info": Console.ForegroundColor = ConsoleColor.Green; break;
                case "Error": Console.ForegroundColor = ConsoleColor.Red; break;
            }
         

            var time = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine($"[Severity: {log}] {time} {source}  {msg}");
            Console.ResetColor();
        }
    }
}
