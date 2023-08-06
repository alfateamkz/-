namespace Alfateam.Website.API.Models.Core
{
    public class RequestResult
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public int Code { get; set; } = 200;


        public void FillFromRequestResult(RequestResult result)
        {
            Success = result.Success;
            Error = result.Error;
            Code = result.Code;
        }

        public void SetError(int code,string error)
        {
            Code = code;
            Error = error;
        }
    }

    public class RequestResult<T> : RequestResult
    {
        public T Value { get; set; }

        //public void FillFromRequestResult(RequestResult<T> result)
        //{
        //    Success = result.Success;
        //    Error = result.Error;
        //    Code = result.Code;

        //    Value = result.Value;
        //}
    }
}
