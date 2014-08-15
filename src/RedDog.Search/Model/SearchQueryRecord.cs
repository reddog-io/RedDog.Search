using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    public class SearchQueryRecord
    {
        public SearchQueryRecord()
        {
            Properties = new Dictionary<string, object>();
            Highlights = new Dictionary<string, string[]>();
        }

        [JsonProperty("@search.score")]
        public double Score
        {
            get;
            set;
        }

        [JsonProperty("@search.highlights")]
        public Dictionary<string, string[]> Highlights
        {
            get;
            set;
        }

        [JsonExtensionData]
        public Dictionary<string, object> Properties
        {
            get;
            set;
        }
    }
}