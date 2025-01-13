using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Campaigns
{
    public enum CampaignsMethod
    {
        [Description("add")]
        Add = 1,
        [Description("archive")]
        Archive = 2,
        [Description("delete")]
        Delete = 3,
        [Description("get")]
        Get = 4,
        [Description("resume")]
        Resume = 5,
        [Description("suspend")]
        Suspend = 6,
        [Description("unarchive")]
        Unarchive = 7,
        [Description("update")]
        Update = 8,
    }
}
