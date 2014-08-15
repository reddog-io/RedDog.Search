using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    public class SearchQueryResult
    {
        [JsonProperty("@odata.count")]
        public int Count
        {
            get;
            set;
        }

        [JsonProperty("@search.facets")]
        public Dictionary<string, FacetResult[]> Facets
        {
            get;
            set;
        }

        [JsonProperty("value")]
        public IEnumerable<SearchQueryRecord> Records
        {
            get;
            set;
        }

        [JsonProperty("@odata.nextLink")]
        public string NextLink
        {
            get;
            set;
        }
    }
}