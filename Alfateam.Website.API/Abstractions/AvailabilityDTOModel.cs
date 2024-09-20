using Alfateam.Website.API.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.Abstractions;

namespace Alfateam.Website.API.Abstractions
{
    /// <summary>
    /// DTO с моделькой доступности по регионам
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AvailabilityDTOModel<T> : DTOModel<T> where T : AvailabilityModel, new()  
    {
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public AvailabilityDTO? Availability { get; set; }
    }
}
