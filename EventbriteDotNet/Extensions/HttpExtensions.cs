using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;

namespace EventbriteDotNet.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="HttpClient"/> related calls
    /// </summary>
    public static class HttpExtensions
    {
        public static T As<T>(this HttpResponseMessage response)
        {
            if (response.Content != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(content);
            }
            else
                return default(T);
        }

        public static string ToUrlParam(this StatusOptions[] status) 
        {
            if (status != null && status.Any())
                return string.Join(",", status.Select(s => s.ToString()));
            return null;
        }

        public static string ToUrlParam(this OrderOptions[] status)
        {
            if (status != null && status.Any())
                return string.Join(",", status.Select(s => s.ToString()));
            return null;
        }

        public static string ToUrlParam(this DateTime? date)
        {
            if (date.HasValue)
                return date.Value.ToString("yyyy-MM-ddTHH:mm:ss");
            return null;
        }

        public static string ToUrlParam(this DateTime date)
        {
            return ((DateTime?)date).ToUrlParam();
        }

        public static string ToUrlParam(this bool? boolean)
        {
            if (boolean.HasValue)
                return Newtonsoft.Json.JsonConvert.SerializeObject(boolean.Value);
            return null;
        }

        public static string ToUrlParam(this bool boolean)
        {
            return ((bool?)boolean).ToUrlParam();
        }
    }
}
