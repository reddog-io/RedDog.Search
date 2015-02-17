using System.Threading;
using System.Threading.Tasks;

namespace RedDog.Search.Http
{
    public delegate Task<TResponse> ResultFormatter<TResponse>(IBodyReader reader, CancellationToken cancelToken);
}