using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Website.API.Results.StatusCodes
{
    public class Result401 : UnauthorizedResult
    {
        public string Error { get; set; }
        public Result401(string error)
        {
            Error = error;
        }
    }
}
