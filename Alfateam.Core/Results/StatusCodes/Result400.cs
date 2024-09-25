using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Core.Results.StatusCodes
{
    public class Result400 : JsonResult
    {
        public string Error { get; set; }
        public Result400(string error) : base(RequestResult.AsError(400, error))
        {
            Error = error;
        }
    }
}
