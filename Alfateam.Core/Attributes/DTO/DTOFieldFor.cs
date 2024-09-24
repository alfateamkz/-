namespace Alfateam.Core.Attributes.DTO
{

    /// <summary>
    /// Ограничение заполнения поля. Можно ограничить заполнение поля при создании объекта или его редактировании
    /// Например, статус отклика на вакансию при создании нельзя менять, но при обновлении может администратора
    /// </summary>
    public class DTOFieldFor : Attribute
    {
        public DTOFieldForType For { get; private set; }
        public DTOFieldFor(DTOFieldForType type)
        {
            For = type;
        }
    }

    public enum DTOFieldForType
    {
        UpdateOnly = 1,
        CreationOnly = 2,
    }
}
