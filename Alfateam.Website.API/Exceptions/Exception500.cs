namespace Alfateam.Website.API.Exceptions
{
    public class Exception500 : Exception
    {
        public string Error { get; set; }
        public Exception500(string error)
        {
            Error = error;
        }
    }
}
