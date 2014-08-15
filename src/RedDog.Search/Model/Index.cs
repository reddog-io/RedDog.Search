using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    public class Index
    {
        public Index()
        {
            Fields = new Collection<IndexField>();
            ScoringProfiles = new Collection<ScoringProfile>();
        }

        public Index(string name)
            : this()
        {
            Name = name;
        }

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("fields")]
        public ICollection<IndexField> Fields
        {
            get;
            set;
        }

        [JsonProperty("scoringProfiles")]
        public ICollection<ScoringProfile> ScoringProfiles
        {
            get;
            set;
        }

        [JsonProperty("defaultScoringProfile")]
        public string DefaultScoringProfile
        {
            get;
            set;
        }

        [JsonProperty("corsOptions")]
        public CorsOptions CorsOptions
        {
            get;
            set;
        }
    }
}