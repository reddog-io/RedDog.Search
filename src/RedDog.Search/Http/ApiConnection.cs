using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RedDog.Search.Model.Internal;

namespace RedDog.Search.Http
{
    public class ApiConnection : IDisposable
    {
        private HttpClient _client;

        private readonly JsonMediaTypeFormatter _formatter;

        internal ApiConnection(Uri baseUri, string apiKey, HttpClientHandler handler)
        {
            BaseUri = baseUri;

            _client = new HttpClient(handler) { BaseAddress = BaseUri };
            _client.DefaultRequestHeaders.Add("api-key", apiKey);
            _client.DefaultRequestHeaders.Add("Accept", "application/json;odata.metadata=none");

            // Configure serialization.
            _formatter = new JsonMediaTypeFormatter();
            _formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            _formatter.SerializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
            _formatter.SerializerSettings.Converters.Add(new XsdDurationConverter());
        }

        public Uri BaseUri
        {
            get;
            private set;
        }

        public static ApiConnection Create(Uri baseUri, string apiKey, IWebProxy proxy = null)
        {
            var handler = new HttpClientHandler() { Proxy = proxy };
            return new ApiConnection(baseUri, apiKey, handler);
        }

        public static ApiConnection Create(string serviceName, string apiKey, IWebProxy proxy = null)
        {
            var handler = new HttpClientHandler() { Proxy = proxy };
            return new ApiConnection(new Uri(String.Format(ApiConstants.BaseUrl, serviceName)), apiKey, handler);
        }

        /// <summary>
        /// Execute a request that doesn't return a result.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IApiResponse> Execute(IApiRequest request)
        {
            var response = await Execute(request, reader => Task.FromResult(new NullBody()))
                .ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Execute a request which returns a result.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="formatter"></param>
        /// <returns></returns>
        public async Task<IApiResponse<TResponse>> Execute<TResponse>(IApiRequest request, ResultFormatter<TResponse> formatter = null)
        {
            // Send the request.
            var responseMessage = await _client.SendAsync(BuildRequest(request))
                .ConfigureAwait(false);

            // Build the response.
            return await BuildResponse(responseMessage, formatter)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Build the HttpRequestMessage based the ApiRequest.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private HttpRequestMessage BuildRequest(IApiRequest request)
        {
            var url = BuildUrl(request);
            var requestMessage = new HttpRequestMessage(request.Method,url );
            requestMessage.Content = request.Body != null ?
                new ObjectContent(request.Body.GetType(), request.Body, _formatter, new MediaTypeHeaderValue("application/json")) : requestMessage.Content;
            return requestMessage;
        }

        /// <summary>
        /// Build the ApiResponse based on the HttpResponseMessage.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="message"></param>
        /// <param name="formatter"></param>
        /// <returns></returns>
        private async Task<IApiResponse<TResponse>> BuildResponse<TResponse>(HttpResponseMessage message, ResultFormatter<TResponse> formatter = null)
        {
            var response = new ApiResponse<TResponse> { StatusCode = message.StatusCode, IsSuccess = message.IsSuccessStatusCode };
            if (message.Content != null)
            {
                if (message.IsSuccessStatusCode)
                {
                    if (formatter != null)
                    {
                        // The formatter allows us to handle a body wrapped in a root element.
                        response.Body = await formatter(new HttpContentBodyReader(message.Content, _formatter))
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        // The complete body can be deserialized to an object.
                        response.Body = await message.Content.ReadAsAsync<TResponse>(new[] { _formatter })
                            .ConfigureAwait(false);
                    }
                }
                else
                {
                    // Errors should also be deserialized.
                    var errorResponse = await message.Content.ReadAsAsync<ErrorResponse>()
                        .ConfigureAwait(false);
                    if (errorResponse != null)
                    {
                        response.Error = errorResponse.Error;
                    }
                }
            }
            return response;
        }

        /// <summary>
        /// Build the url with parameters and make sure we always add the api version.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string BuildUrl(IApiRequest request)
        {
            string url = request.UriParameters.Count > 0 ?
                String.Format(request.Uri, request.UriParameters.Select(p => WebUtility.UrlEncode(p) as object).ToArray()) : request.Uri;
            List<string> parameters = request.QueryParameters.Select(
                p => FormatQueryStringParameter(p.Item1, p.Item2)).ToList();
            parameters.Add(FormatQueryStringParameter("api-version", ApiConstants.Version));
            return url + "?" + String.Join("&", parameters);
        }

        /// <summary>
        /// Format a query string parameter.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string FormatQueryStringParameter(string key, string value)
        {
            return String.Format("{0}={1}", Uri.EscapeUriString(key), WebUtility.UrlEncode(value));
        }
        
        ~ApiConnection()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose resources.
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_client != null)
                {
                    _client.Dispose();
                    _client = null;
                }
            }
        }
    }
}