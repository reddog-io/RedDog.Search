using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    public class SuggestionResult
    {  
        [JsonProperty("value")]
        public IEnumerable<SuggestionResultRecord> Records
        {
            get;
            set;
        }

        [JsonProperty("@odata.context")]
        public string Context
        {
            get;
            set;
        }
        
    }
}