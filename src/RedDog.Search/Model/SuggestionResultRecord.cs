using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    public class SuggestionResultRecord
    {
        public SuggestionResultRecord()
        {
            Properties = new Dictionary<string, object>();
        }
        
        [JsonProperty("@search.text")]
        public string Text
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