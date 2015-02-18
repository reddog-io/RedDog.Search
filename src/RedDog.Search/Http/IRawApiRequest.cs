using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RedDog.Search.Http
{
    public interface IRawApiRequest
    {
        string Url
        {
            get;
            set;
        }

        HttpMethod Method
        {
            get;
            set;
        }
    }
}
