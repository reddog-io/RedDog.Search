using Newtonsoft.Json;
using System;

namespace RedDog.Search.Model
{
    public class IndexField
    {
        public IndexField(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public IndexField()
        {
        }

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("type")]
        public string Type
        {
            get;
            set;
        }

        [JsonProperty("searchable")]
        public bool Searchable
        {
            get;
            set;
        }

        [JsonProperty("filterable")]
        public bool Filterable
        {
            get;
            set;
        }

        [JsonProperty("sortable")]
        public bool Sortable
        {
            get;
            set;
        }

        [JsonProperty("facetable")]
        public bool Facetable
        {
            get;
            set;
        }

        [ObsoleteAttribute("Consider using the suggesters property introduced in version 2014-10-20-Preview instead of this option for suggestions. In a future version the suggestions property will be deprecated in favor of using a separate suggesters specification.")]
        [JsonProperty("suggestions")]
        public bool Suggestions
        {
            get;
            set;
        }

        [JsonProperty("key")]
        public bool Key
        {
            get;
            set;
        }

        [JsonProperty("retrievable")]
        public bool Retrievable
        {
            get;
            set;
        }

        [JsonProperty("analyzer")]
        public string Analyzer
        {
            get;
            set;
        }
    }
}