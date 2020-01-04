using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventbriteNET
{
    /// <summary>
    /// Represents an Eventbrite imgage <see cref="https://www.eventbrite.com/developer/v3/response_formats/image/#ebapi-std:format-image"/>
    /// </summary>
    public class Image : EventbriteObject
    {
        public Image()
        {

        }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
