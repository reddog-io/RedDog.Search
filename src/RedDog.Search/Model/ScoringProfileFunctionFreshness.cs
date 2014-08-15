using System;
using Newtonsoft.Json;

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