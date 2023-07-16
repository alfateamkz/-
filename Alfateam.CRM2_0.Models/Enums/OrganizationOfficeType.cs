using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums
{
    /// <summary>
    /// Тип офиса организации
    /// </summary>
    public enum OrganizationOfficeType
    {
        Headquarters = 1, //Штаб-квартира
        CountryMainOffice = 2, //Главный офис в стране
        RegionalOffice = 3, //Региональный офис
        Office = 4, //Офис 
    }
}
