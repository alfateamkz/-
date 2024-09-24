using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Core.Results.StatusCodes
{
    public class Result404 : NotFoundResult
    {
        public string Error { get; set; }
        public Result404(string error)
        {
            Error = error;
        }
    }
}
