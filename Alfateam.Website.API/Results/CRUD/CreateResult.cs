namespace Alfateam.Website.API.Results.CRUD
{
    public class CreateResult
    {
        public int Code { get; set; } = 200;
        public string Message { get; set; }

        public object NewEntity { get; set; }
    }
}
