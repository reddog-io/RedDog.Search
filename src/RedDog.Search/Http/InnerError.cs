using Newtonsoft.Json;

namespace RedDog.Search.Http
{
    public class InnerError
    {
        [JsonProperty("message")]
        public string Message
        {
            get;
            set;
        }

        [JsonProperty("stacktrace")]
        public string Stacktrace
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
    }
}