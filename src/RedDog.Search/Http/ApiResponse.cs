using System.Net;

namespace RedDog.Search.Http
{
    public class ApiResponse<TResult> : IApiResponse<TResult>
    {
        public Error Error
        {
            get;
            set;
        }

        public bool IsSuccess
        {
            get;
            set;
        }

        public HttpStatusCode StatusCode
        {
            get;
            set;
        }

        public TResult Body
        {
            get;
            set;
        }
    }
}