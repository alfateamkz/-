using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AdExtensions
{
    public enum AdExtensionStatus
    {
        [Description("DRAFT")]
        Draft = 1,
        [Description("MODERATION")]
        Moderation = 2,
        [Description("ACCEPTED")]
        Accepted = 3,
        [Description("REJECTED")]
        Rejected = 4,
        [Description("UNKNOWN")]
        Unknown = 5,
    }
}
