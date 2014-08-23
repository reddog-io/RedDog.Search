using System;
using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    public class LookupQuery
    {
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