using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Exceptions
{
    public class DirectRestClientException : Exception
    {
        public DirectRestClientException(int statusCode, object APIErrorResponseObject)
        {
            this.StatusCode = statusCode;
            this.APIErrorResponseObject = APIErrorResponseObject;
        }
        public object APIErrorResponseObject { get; set; }
        public int StatusCode { get; set; }
    }
}
