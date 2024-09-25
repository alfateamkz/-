using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Core.Results.StatusCodes
{
    public class Result403 : JsonResult
    {
        public string Error { get; set; }
        public Result403(string error) : base(RequestResult.AsError(403, error))
        {
            Error = error;
        }
    }
}
