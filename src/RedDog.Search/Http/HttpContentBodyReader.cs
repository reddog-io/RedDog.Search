using System.Net.Http;
using System.Threading.Tasks;

namespace RedDog.Search.Http
{
    /// <summary>
    ///     Wrapper that allows passing around the ReadAsAsync method.
    /// </summary>
    internal class HttpContentBodyReader : IBodyReader
    {
        private readonly HttpContent _content;

        public HttpContentBodyReader(HttpContent content)
        {
            _content = content;
        }

        public Task<T> ReadAsync<T>()
        {
            return _content.ReadAsAsync<T>();
        }
    }
}