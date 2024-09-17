namespace Alfateam.Website.API.Exceptions
{
    public class Exception401 : Exception
    {
        public string Error { get; set; }
        public Exception401(string error)
        {
            Error = error;
        }
    }
}
