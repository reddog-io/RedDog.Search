using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    [DataContract]
    public class ScoringProfileText
    {
        public ScoringProfileText()
        {
            Weights = new Dictionary<string, double>();
        }

        [JsonProperty("weights")]
        public IDictionary<string, double> Weights
        {
            get;
            set;
        }
    }
}