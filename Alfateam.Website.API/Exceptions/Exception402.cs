namespace Alfateam.Website.API.Exceptions
{
    public class Exception402 : Exception
    {
        public string Error { get; set; }
        public Exception402(string error)
        {
            Error = error;
        }
    }
}
