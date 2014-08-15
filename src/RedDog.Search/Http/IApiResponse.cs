using System.Net;

namespace RedDog.Search.Http
{
    public interface IApiResponse<out TResult> : IApiResponse
    {
        TResult Body
        {
            get;
        }
    }

    public interface IApiResponse
    {
        Error Error
        {
            get;
        }

        bool IsSuccess
        {
            get;
        }

        HttpStatusCode StatusCode
        {
            get;
        }
    }
}