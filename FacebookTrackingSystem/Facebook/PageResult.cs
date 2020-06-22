using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookTrackingSystem.Facebook
{
    public class PageResult
    {
        [JsonProperty("data")]
        public List<PageDetail> data { get; set; }

        public string errorMessage { get; set; }
    }

    public class PageDetail
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("access_token")]
        public string access_token { get; set; }
        [JsonProperty("id")]
        public string id { get; set; }
    }
}
