using Alfateam.Database.Models;

namespace Alfateam.ViewModels
{
    public class VMWithLanguages<T>
    {
        public T TargetType { get; set; }
        public List<Language> Languages { get; set; } = new List<Language>();
    }
}
