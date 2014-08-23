using System;
using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    public class SuggestionQuery
    {
        public SuggestionQuery()
        {

        }

        public SuggestionQuery(string search)
        {
            Search = search;
        }

        [JsonProperty("search")]
        public String Search
        {
            get;
            set;
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