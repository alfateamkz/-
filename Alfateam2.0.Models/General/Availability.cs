using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.General
{
    /// <summary>
    /// Сущность доступности по странам
    /// Если AvailableInAllCountries == true, то показывается во всех странах, кроме списка DisallowedCountries
    /// Если AvailableInAllCountries == false, то показывается только в странах, которые в списке AllowedCountries
    /// </summary>
    public class Availability : AbsModel
    {

        public bool AvailableInAllCountries { get; set; } = true;
        public List<Country> AllowedCountries { get; set; } = new List<Country>();
        public List<Country> DisallowedCountries { get; set; } = new List<Country>();


        public bool IsAvailable(int? countryId)
        {
            if (AvailableInAllCountries)
            {
                return !DisallowedCountries.Any(o => o.Id == countryId);
            }
            else
            {
                return AllowedCountries.Any(o => o.Id == countryId);
            }

        }
        public bool IsAvailable(List<Country> countries)
        {
            foreach(var country in countries)
            {
                if(IsAvailable(country.Id)) 
                    return true;
            }
            return false;
        }

    }
}
