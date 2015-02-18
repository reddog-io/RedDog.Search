using System.Threading;
using System.Threading.Tasks;

namespace RedDog.Search.Http
{
    public interface IBodyReader
    {
        Task<T> ReadAsync<T>(CancellationToken cancellationToken);
    }
}