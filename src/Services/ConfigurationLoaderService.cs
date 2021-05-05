using System.IO;
using Newtonsoft.Json;

namespace Blacknight.Services
{
    class ConfigurationLoaderService
    {
        public static string GetConfig(string configVar)
        {
            var json = File.ReadAllText("./appsettings.json");
            var botConfig = JsonConvert.DeserializeObject<Configuration>(json);

            string config = "";

            switch (configVar)
            {
                case "TOKEN": config = botConfig!.Token; break;
                case "PREFIX": config = botConfig!.Prefix; break;
            }

            return config;
        }
    }
}
