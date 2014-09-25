using Newtonsoft.Json;
using System.Collections.Generic;

namespace RedDog.Search.Model
{
    public class SearchQuery
    {
        public SearchQuery()
        {
        }

        public SearchQuery(string query)
        {
            Query = query;
        }

        [JsonProperty("query")]
        public string Query
        {
            get;
            set;
        }

        [JsonProperty("mode")]
        public SearchMode? Mode
        {
            get;
            set;
        }

        [JsonProperty("searchFields")]
        public string SearchFields
        {
            get;
            set;
        }

        [JsonProperty("skip")]
        public long Skip
        {
            get;
            set;
        }

        [JsonProperty("top")]
        public long Top
        {
            get;
            set;
        }

        [JsonProperty("count")]
        public bool Count
        {
            get;
            set;
        }

        [JsonProperty("orderBy")]
        public string OrderBy
        {
            get;
            set;
        }

        [JsonProperty("select")]
        public string Select
        {
            get;
            set;
        }

        [JsonProperty("facet")]
        public IEnumerable<string> Facets
        {
            get;
            set;
        }

        [JsonProperty("filter")]
        public string Filter
        {
            get;
            set;
        }

        [JsonProperty("highlight")]
        public string Highlight
        {
            get;
            set;
        }

        [JsonProperty("scoringProfile")]
        public string ScoringProfile
        {
            get;
            set;
        }

        [JsonProperty("scoringParameter")]
        public string ScoringParameter
        {
            get;
            set;
        }
    }
}