using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    public class ScoringProfileFunctionMagnitude
    {
        [JsonProperty("boostingRangeStart")]
        public double BoostingRangeStart
        {
            get;
            set;
        }

        [JsonProperty("boostingRangeEnd")]
        public double BoostingRangeEnd
        {
            get;
            set;
        }

        [JsonProperty("constantBoostBeyondRange")]
        public bool ConstantBoostBeyondRange
        {
            get;
            set;
        }
    }
}