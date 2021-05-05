using Newtonsoft.Json;

namespace Blacknight
{
    [JsonObject]
    public class Configuration
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        
        [JsonProperty("prefix")]
        public string Prefix { get; set; }
    }
}