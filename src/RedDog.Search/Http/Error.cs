using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedDog.Search.Http
{
    public class Error
    {
        [JsonProperty("code")]
        public string Code
        {
            get;
            set;
        }


        [JsonProperty("message")]
        public string Message
        {
            get;
            set;
        }

        [JsonProperty("innererror")]
        public InnerError InnerError
        {
            get;
            set;
        }

        public Dictionary<string, List<string>> ModelState
        {
            get;
            set;
        }
    }
}