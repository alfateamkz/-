using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Core.Results.StatusCodes
{
    public class Result403 : ForbidResult
    {
        public string Error { get; set; }
        public Result403(string error)
        {
            Error = error;
        }
    }
}
