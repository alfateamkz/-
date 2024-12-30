using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Exceptions
{
    public class AppMetrikaRestClientException : Exception
    {
        public AppMetrikaRestClientException(int statusCode, object APIErrorResponseObject)
        {
            this.StatusCode = statusCode;
            this.APIErrorResponseObject = APIErrorResponseObject;
        }
        public object APIErrorResponseObject { get; set; }
        public int StatusCode { get; set; }
    }
}
