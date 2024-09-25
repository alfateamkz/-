using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Core.Results.StatusCodes
{
    public class Result404 : JsonResult
    {
        public string Error { get; set; }
        public Result404(string error) : base(RequestResult.AsError(404, error))
        {
            Error = error;
        }
    }
}
