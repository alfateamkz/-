namespace Alfateam.Website.API.Core
{
    public class RequestResult
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public int Code { get; set; } = 200;


        public object Value { get; set; }


        public static RequestResult FromBoolean(bool val, int errorCode, string errorText)
        {
            if (val) return AsSuccess();
            return AsError(errorCode, errorText);
        }

        public static RequestResult AsError(int code, string error)
        {
            return new RequestResult().SetError(code, error);
        }
        public static RequestResult AsSuccess()
        {
            return new RequestResult().SetSuccess();
        }
        public static RequestResult AsSuccess(object obj)
        {
            return new RequestResult().SetSuccess(obj);
        }


        /// <summary>
        /// Заполняет значения из другого RequestResult и возвращает ссылку на себя
        /// </summary>
        public virtual RequestResult FillFromRequestResult(RequestResult result)
        {
            Success = result.Success;
            Error = result.Error;
            Code = result.Code;

            return this;
        }


        /// <summary>
        /// Задает значения Code и Error и возвращает ссылку на себя
        /// </summary>
        public virtual RequestResult SetError(int code, string error)
        {
            Code = code;
            Error = error;

            return this;
        }

        /// <summary>
        /// Задает значения Success = true и возвращает ссылку на себя
        /// </summary>
        public RequestResult SetSuccess()
        {
            Success = true;
            Code = 200;

            return this;
        }

        /// <summary>
        /// Задает значения Success = true и возвращает ссылку на себя
        /// </summary>
        public RequestResult SetSuccess(object obj)
        {
            Success = true;
            Code = 200;
            Value = obj;

            return this;
        }

    }

    //public class RequestResult : RequestResult
    //{


    //    public static RequestResult AsError(int code, string error)
    //    {
    //        return new RequestResult().SetError(code, error);
    //    }
    //    public static RequestResult AsSuccess(T value)
    //    {
    //        return new RequestResult().SetSuccess(value);
    //    }


    //    public override RequestResult FillFromRequestResult(RequestResult result)
    //    {
    //        base.FillFromRequestResult(result);
    //        return this;
    //    }


    //    /// <summary>
    //    /// Заполняет значения из другого RequestResult и возвращает ссылку на себя
    //    /// </summary>
    //    public RequestResult FillFromRequestResult(RequestResult result)
    //    {
    //        FillFromRequestResult(result);
    //        Value = result.Value;

    //        return this;
    //    }



    //    public override RequestResult SetError(int code, string error)
    //    {
    //        base.SetError(code, error);

    //        return this;
    //    }


    //    /// <summary>
    //    /// Задает значения Success = true и Value и возвращает ссылку на себя
    //    /// </summary>
    //    public RequestResult SetSuccess(T val)
    //    {
    //        Code = 200;
    //        Success = true;
    //        Value = val;

    //        return this;
    //    }
    //}
}
