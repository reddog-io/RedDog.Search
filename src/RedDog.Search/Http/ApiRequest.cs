using System;
using System.Collections.Generic;
using System.Net.Http;

namespace RedDog.Search.Http
{
    public class ApiRequest : IApiRequest
    {
        public ApiRequest(string uri, HttpMethod method, object body = null)
        {
            Uri = uri;
            Method = method;
            Body = body;
            UriParameters = new List<string>();
            QueryParameters = new List<Tuple<string, string>>();
        }

        public string Uri
        {
            get;
            set;
        }

        public List<string> UriParameters
        {
            get;
            set;
        }

        public HttpMethod Method
        {
            get;
            set;
        }

        public List<Tuple<string, string>> QueryParameters
        {
            get;
            set;
        }

        public object Body
        {
            get;
            set;
        }

        public void AddQueryParameter(string key, string value)
        {
            QueryParameters.Add(new Tuple<string, string>(key, value));
        }
    }
}