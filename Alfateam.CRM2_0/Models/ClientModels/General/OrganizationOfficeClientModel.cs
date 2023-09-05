using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.ClientModels.General
{
    public class OrganizationOfficeClientModel : ClientModel<OrganizationOffice>
    {    
        /// <summary>
        /// Реальный ли офис или виртуальный
        /// </summary>
        public bool IsReal { get; set; } = true;
        public OrganizationOfficeType Type { get; set; }


        /// <summary>
        /// Адрес офиса. Равен null, если IsReal == false
        /// </summary>
        public Address? Address { get; set; }
        public TimeZoneClientModel TimeZone { get; set; }



        /// <summary>
        /// Офисы, находящиеся в подчинении у данного офиса
        /// Структура офисов в целом: штаб-квартира -> главные офисы по странам -> региональные офисы -> офисы
        /// Структура офисов данного списка: главные офисы по странам -> региональные офисы -> офисы.
        /// Так потому-что штаб-квартира одновременно является главным офисом по стране, в которой находится
        /// </summary>
        public List<OrganizationOfficeClientModel> SubOffices { get; set; } = new List<OrganizationOfficeClientModel>();
    }
}
