namespace Alfateam.Models
{
    public class StaticFileModel<T> 
    {
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();
        public T Value { get; set; }
    }
}
