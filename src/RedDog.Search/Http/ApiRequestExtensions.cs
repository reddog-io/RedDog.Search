namespace RedDog.Search.Http
{
    internal static class ApiRequestExtensions
    {
        public static IApiRequest WithBody(this IApiRequest request, object body)
        {
            request.Body = body;
            return request;
        }

        public static IApiRequest WithUriParameter(this IApiRequest request, string parameter)
        {
            request.UriParameters.Add(parameter);
            return request;
        }
    }
}