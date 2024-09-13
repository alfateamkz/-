namespace Alfateam.Website.API.Attributes.DTO
{
    /// <summary>
    /// Поле используется для создания и обновления сущности из DTO, но не заполняется для клиентских моделей.
    /// Если модель будет создаваться для клиента, то поля с данным атрибутом будут иметь значение по умолчанию
    /// </summary>
    public class HiddenFromClient : Attribute
    {
        public HiddenFromClient()
        {

        }
    }
}
