using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RedDog.Search.Model
{
    public class ScoringProfileFunction
    {
        [JsonProperty("type")]
        
        public ScoringProfileFunctionType Type
        {
            get;
            set;
        }

        [JsonProperty("boost")]
        public double Boost
        {
            get;
            set;
        }

        [JsonProperty("fieldName")]
        public string FieldName
        {
            get;
            set;
        }
        [JsonProperty("interpolation")]
        
        public InterpolationType Interpolation
        {
            get;
            set;
        }

        [JsonProperty("magnitude")]
        public ScoringProfileFunctionMagnitude Magnitude
        {
            get;
            set;
        }

        [JsonProperty("freshness")]
        public ScoringProfileFunctionFreshness Freshness
        {
            get;
            set;
        }

        [JsonProperty("distance")]
        public ScoringProfileFunctionDistance Distance
        {
            get;
            set;
        }
    }
}