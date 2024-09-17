using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Website.API.Results.StatusCodes
{
    public class Result500 : StatusCodeResult
    {
        public string Error { get; set; }
        public Result500(string error) : base(500)
        {
            Error = error;
        }
    }
}
