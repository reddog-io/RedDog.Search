using System;
using Newtonsoft.Json;
using RedDog.Search.Http;

namespace RedDog.Search.Model
{
    public class ScoringProfileFunctionFreshness
    {
        [JsonProperty("boostingDuration")]
        public TimeSpan BoostingDuration
        {
            get;
            set;
        }
    }
}