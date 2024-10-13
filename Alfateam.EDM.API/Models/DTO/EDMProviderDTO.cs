using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.Models;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO
{
    public class EDMProviderDTO : DTOModelAbs<EDMProvider>
    {
        public string Title { get; set; }
        public string CountryCode { get; set; }


        /// <summary>
        /// Вшит ли тип провайдер ЭДО в систему. Если false, то создан пользователем
        /// </summary>
        [ForClientOnly]
        public bool IsDefault { get; set; }


        /// <summary>
        /// Доступен ли роуминг между Alfateam ЭДО и данным провайдером
        /// </summary>
        [ForClientOnly]
        public bool IsRoamingAvailable { get; set; }
    }
}
