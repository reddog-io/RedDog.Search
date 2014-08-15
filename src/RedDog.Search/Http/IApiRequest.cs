using System;
using System.Collections.Generic;
using System.Net.Http;

namespace RedDog.Search.Http
{
    public interface IApiRequest
    {
        string Uri
        {
            get;
            set;
        }


        List<string> UriParameters
        {
            get;
            set;
        }

        object Body
        {
            get;
            set;
        }

        HttpMethod Method
        {
            get;
            set;
        }

        List<Tuple<string, string>> QueryParameters
        {
            get;
            set;
        }

        void AddQueryParameter(string key, string value);
    }
}