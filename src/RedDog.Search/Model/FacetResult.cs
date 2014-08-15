using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    public class FacetResult
    {
        [JsonProperty("value")]
        public string Value
        {
            get;
            set;
        }

        [JsonProperty("from")]
        public long From
        {
            get;
            set;
        }

        [JsonProperty("to")]
        public long To
        {
            get;
            set;
        }

        [JsonProperty("count")]
        public long Count
        {
            get;
            set;
        }
    }
}