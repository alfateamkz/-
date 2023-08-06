using Alfateam2._0.Models.Abstractions.Interfaces;

namespace Alfateam.Website.API.Abstractions
{

    public abstract class LocalizationEditModel : IValidatableModel
    {
        public int Id { get; set; }
        public abstract bool IsValid();   
    }

    public abstract class LocalizationEditModel<T>: LocalizationEditModel
    {
        public abstract void Fill(T item);
    }
}
