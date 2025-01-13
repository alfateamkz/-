using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AdExtensions
{
    public enum AdExtensionFieldName
    {
        [Description("Id")]
        Id = 1,
        [Description("Type")]
        Type = 2,
        [Description("Status")]
        Status = 3,
        [Description("StatusClarification")]
        StatusClarification = 4,
        [Description("Associated")]
        Associated = 5,
    }
}
