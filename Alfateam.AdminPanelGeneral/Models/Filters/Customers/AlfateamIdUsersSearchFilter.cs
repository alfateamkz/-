using Alfateam.AdminPanelGeneral.API.Abstractions;

namespace Alfateam.AdminPanelGeneral.API.Models.Filters.Customers
{
    public class AlfateamIdUsersSearchFilter : SearchFilter
    {
        public string CountryCode { get; set; }
        public string LanguageCode { get; set; }


        public bool? HasAnySuccessfulPayment { get; set; }
    }
}
