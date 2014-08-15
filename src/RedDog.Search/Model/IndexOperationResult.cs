using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    public class IndexOperationResult
    {
        [JsonProperty(PropertyName = "key")]
        public string Key
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "status")]
        public bool Status
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage
        {
            get;
            set;
        }
    }
}