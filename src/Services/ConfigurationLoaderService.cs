using System;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Blacknight.Services
{
    internal static class ConfigurationLoaderService
    {
        public static async Task<Configuration> GetConfig()
        {
            try
            {
                var json = await File.ReadAllTextAsync("./appsettings.json");
                var botConfig = JsonConvert.DeserializeObject<Configuration>(json);
                return botConfig;

            }
            catch (FileNotFoundException exception)
            {
                await Console.Out.WriteLineAsync($"Unable to read '{exception.FileName ?? "appsettings.json"}', please double check it exists and the path is correct.\n" +
                                                 $"Reason: {exception.Message}");
            }
            catch (JsonException exception)
            {
                await Console.Out.WriteLineAsync("Unable to deserialize json file.\n" +
                                                 $"Reason: {exception.Message}");
            }
            catch (Exception exception)
            {
                await Console.Out.WriteLineAsync("Something extra bad went wrong.\n" + 
                                                $"Reason: {exception.Message}");
            }
            
            return null;
        }
    }
}
