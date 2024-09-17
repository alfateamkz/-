﻿namespace Alfateam.Website.API.Exceptions
{
    public class Exception400 : Exception
    {
        public string Error { get; set; }
        public Exception400(string error)
        {
            Error = error;
        }
    }
}
