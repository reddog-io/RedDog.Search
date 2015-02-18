using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RedDog.Search.Http
{
    public class RawApiRequest : IRawApiRequest
    {
        public RawApiRequest(string url, HttpMethod method)
        {
            Url = url;
            Method = method;
        }

        public string Url
        {
            get;
            set;
        }

        public HttpMethod Method
        {
            get;
            set;
        }
    }
}
