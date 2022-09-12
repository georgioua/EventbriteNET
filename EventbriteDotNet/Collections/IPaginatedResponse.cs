using Newtonsoft.Json;
using System.Collections.Generic;

namespace EventbriteDotNet.Collections
{
    public interface IPaginatedResponse<T> where T : EventbriteObject
    {
        [JsonProperty("locale")]
        string Locale { get; set; }
        [JsonProperty("pagination")]
        Pagination Pagination { get; set; }
        [JsonProperty("data")]
        IList<T> Data { get; set; }

        string DataName { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}
