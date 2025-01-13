using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.VCards
{
    public enum VCardFieldEnum
    {
        [Description("Id")]
        Id = 1,
        [Description("Country")]
        Country = 2,
        [Description("City")]
        City = 3,
        [Description("Street")]
        Street = 4,
        [Description("House")]
        House = 5,
        [Description("Building")]
        Building = 6,
        [Description("Apartment")]
        Apartment = 7,
        [Description("CompanyName")]
        CompanyName = 8,
        [Description("ExtraMessage")]
        ExtraMessage = 9,
        [Description("ContactPerson")]
        ContactPerson = 10,
        [Description("ContactEmail")]
        ContactEmail = 11,
        [Description("MetroStationId")]
        MetroStationId = 12,
        [Description("CampaignId")]
        CampaignId = 13,
        [Description("Ogrn")]
        OGRN = 14,
        [Description("WorkTime")]
        WorkTime = 15,
        [Description("InstantMessenger")]
        InstantMessenger = 16,
        [Description("Phone")]
        Phone = 17,
        [Description("PointOnMap")]
        PointOnMap = 18,
    }
}
