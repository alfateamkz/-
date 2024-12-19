using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums
{
    public enum ResponseStatus
    {
        Success = 200,
        Unauthorized = 401,
        UnprocessableEntity = 422,
        RateLimitError = 429,
    }
}
