namespace Alfateam.Website.API.Attributes.DTO
{
    /// <summary>
    /// Атрибут связки List<int> ids с List<TEntity>
    /// </summary>
    public class DTOFieldBindWith : Attribute
    {
        public readonly string PropName;
        public readonly Type TypeOfEntity;

        public DTOFieldBindWith(string propName, Type typeOfEntity)
        {
            PropName = propName;
            TypeOfEntity = typeOfEntity;
        }
        public DTOFieldBindWith(Type typeOfEntity)
        {
            TypeOfEntity = typeOfEntity;
        }

    }
}
