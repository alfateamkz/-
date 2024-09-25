using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Core.Results.StatusCodes
{
    public class Result500 : JsonResult
    {
        public string Error { get; set; }
        public Result500(string error) : base(RequestResult.AsError(500, error))
        {
            Error = error;
        }
    }
}
