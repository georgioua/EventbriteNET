using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventbriteNET
{
    public class AccessCode : EventbriteObject
    {
        public AccessCode()
        {
            ValidStartDate = new DateTimeTimezoneField();
            ValidEndDate = new DateTimeTimezoneField();
        }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("ticket_ids")]
        public IList<string> TicketIds { get; set; }

        [JsonProperty("quantity_available")]
        public int QuantityAvailable { get; set; }

        [JsonProperty("quantity_sold")]
        public int QuantitySold { get; set; }

        [JsonProperty("start_date")]
        public DateTimeTimezoneField ValidStartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTimeTimezoneField ValidEndDate { get; set; }

        [JsonProperty("event_id")]
        public long? EventId { get; set; }

    }

    public class PagedAccessCodes : EventbriteObject
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
        [JsonProperty("access_codes")]
        public List<AccessCode> AccessCodes { get; set; }
    }

}
