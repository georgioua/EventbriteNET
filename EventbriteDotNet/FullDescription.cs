using Newtonsoft.Json;

namespace EventbriteDotNet
{
    public class FullDescription
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
