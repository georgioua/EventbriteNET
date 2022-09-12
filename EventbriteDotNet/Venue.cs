using Newtonsoft.Json;

namespace EventbriteDotNet
{
    /// <summary>
    /// Represents an Eventbrite Venue <see cref="https://developer.eventbrite.com/docs/venue-object/"/>
    /// </summary>
    public class Venue : EventbriteObject
    {
        public Venue()
        {
            Address = new AddressField();
        }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public AddressField Address { get; set; }
        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }
        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }
    }
}
