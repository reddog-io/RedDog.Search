using System;
using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    public class SuggestionQuery
    {

        public SuggestionQuery(string search)
        {
            if (string.IsNullOrWhiteSpace(search) || search.Length < 3)
            {
                throw new ArgumentOutOfRangeException("search", search, "The search parameter should have at least 3 characters.");
            }
            Search = search;
        }

        [JsonProperty("search")]
        public String Search
        {
            get;
            private set;
        }


        [JsonProperty("fuzzy")]
        public bool Fuzzy
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

        [JsonProperty("top")]
        public long Top
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

    }
}