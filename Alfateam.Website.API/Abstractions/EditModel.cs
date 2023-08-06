using Alfateam2._0.Models.Abstractions.Interfaces;

namespace Alfateam.Website.API.Abstractions
{
    public abstract class EditModel<T> : IValidatableModel
    {
        public int Id { get; set; }
        public abstract bool IsValid();

        public abstract void Fill(T item);

    }


}
