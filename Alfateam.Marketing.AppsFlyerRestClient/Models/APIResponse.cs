using Alfateam.Marketing.AppsFlyerRestClient.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models
{
    public class APIResponse<T>
    {
        public ResponseStatus Status { get; set; }
        public int APIStatusCode { get; set; }


        public T Data { get; set; }
        public string Error { get; set; }
    }
}
