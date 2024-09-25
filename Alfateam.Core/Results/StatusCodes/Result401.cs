using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Core.Results.StatusCodes
{
    public class Result401 : JsonResult
    {
        public string Error { get; set; }
        public Result401(string error) : base(RequestResult.AsError(401, error))
        {
            Error = error;
        }
    }
}
