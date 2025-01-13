using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Businesses
{
    public enum BusinessFieldEnum
    {
        [Description("Id")]
        Id = 1,
        [Description("Name")]
        Name = 2,
        [Description("Address")]
        Address = 3,
        [Description("Phone")]
        Phone = 4,
        [Description("ProfileUrl")]
        ProfileURL = 5,
        [Description("InternalUrl")]
        InternalURL = 6,
        [Description("IsPublished")]
        IsPublished = 7,
        [Description("MergedIds")]
        MergedIds = 8,
        [Description("Rubric")]
        Rubric = 9,
        [Description("Urls")]
        URLs = 10,
        [Description("HasOffice")]
        HasOffice = 11,
    }
}
