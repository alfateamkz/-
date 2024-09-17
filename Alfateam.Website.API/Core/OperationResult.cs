namespace Alfateam.Website.API.Core
{
    public class OperationResult
    {
        public int Code { get; set; } = 200;
        public string Message { get; set; }

        public object Value { get; set; }
    }
}
