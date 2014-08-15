using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    public class IndexOperation
    {
        public IndexOperation(IndexOperationType action, string keyField, string keyValue)
        {
            Action = action;
            Properties = new Dictionary<string, object> {{keyField, keyValue}};
        }

        [JsonProperty(PropertyName = "@search.action")]
        public IndexOperationType Action
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