using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedDog.Search.Http;

namespace RedDog.Search.Model.Internal
{
    internal class IndexOperationList
    {
        [JsonProperty("value")]
        public IEnumerable<IndexOperationResult> Items
        {
            get;
            set;
        }

        public static async Task<IEnumerable<IndexOperationResult>> GetIndexes(IBodyReader reader, CancellationToken cancellationToken)
        {
            var body = await reader.ReadAsync<IndexOperationList>(cancellationToken)
                .ConfigureAwait(false);
            return body.Items;
        }
    }
}