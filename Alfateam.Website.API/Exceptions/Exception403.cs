namespace Alfateam.Website.API.Exceptions
{
    public class Exception403 : Exception
    {
        public string Error { get; set; }
        public Exception403(string error)
        {
            Error = error;
        }
    }
}
