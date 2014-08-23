using System;
using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    public class LookupQuery
    {
        public LookupQuery()
        {
        }

        public LookupQuery(string key)
        {
            Key = key;
        }

        [JsonIgnore]
        public String Key
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