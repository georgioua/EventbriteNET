using Newtonsoft.Json;

namespace EventbriteDotNet
{
    /// <summary>
    /// Represents an Eventbrite image <see cref="https://www.eventbrite.com/developer/v3/response_formats/image/#ebapi-std:format-image"/>
    /// </summary>
    public class Image : EventbriteObject
    {
        public Image()
        {

        }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("crop_mask")]
        public CropMask CropMask { get; set; }

        [JsonProperty("original")]
        public Original Original { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("aspect_ratio")]
        public string AspectRatio { get; set; }

        [JsonProperty("edge_color")]
        public string EdgeColor { get; set; }

        [JsonProperty("edge_color_set")]
        public bool EdgeColorSet { get; set; }
    }

    public partial class CropMask
    {
        [JsonProperty("top_left")]
        public TopLeft TopLeft { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public partial class TopLeft
    {
        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }
    }

    public partial class Original
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }
}
