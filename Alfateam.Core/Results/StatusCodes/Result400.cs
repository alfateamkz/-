using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Core.Results.StatusCodes
{
    public class Result400 : BadRequestResult
    {
        public string Error { get; set; }
        public Result400(string error)
        {
            Error = error;
        }
    }
}
