using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    public class ScoringProfileFunctionDistance
    {
        [JsonProperty("referencePointParameter")]
        public string ReferencePointParameter
        {
            get;
            set;
        }

        [JsonProperty("boostingDistance")]
        public double BoostingDistance
        {
            get;
            set;
        }
    }
    
    public class ScoringProfileFunctionTag
    {
        [JsonProperty("tagsParameter")]
        public string TagsParameter
        {
            get;
            set;
        }
    }
}