using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedDog.Search.Http;

namespace RedDog.Search.Model.Internal
{
    internal class IndexList
    {
        [JsonProperty("value")]
        public IEnumerable<Index> Items
        {
            get;
            set;
        }

        public static async Task<IEnumerable<Index>> GetIndexes(IBodyReader reader, CancellationToken cancellationToken)
        {
            var body = await reader.ReadAsync<IndexList>(cancellationToken)
                .ConfigureAwait(false);
            return body.Items;
        }
    }
}