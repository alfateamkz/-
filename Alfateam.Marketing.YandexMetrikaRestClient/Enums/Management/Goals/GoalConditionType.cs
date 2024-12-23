using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Goals
{
    public enum GoalConditionType
    {
        [Description("contain")]
        Contain = 1,
        [Description("exact")]
        Exact = 2,
        [Description("start")]
        Start = 3,
        [Description("regexp")]
        RegExp = 4,
        [Description("action")]
        Action = 5,
        [Description("messenger")]
        Messenger = 6,
        [Description("all_files")]
        AllFiles = 7,
        [Description("file")]
        File = 8,
        [Description("search")]
        Search = 9,
        [Description("all_social")]
        AllSocial = 10,
        [Description("social")]
        Social = 11,
        [Description("regexp_action")]
        RegExpAction = 12,
        [Description("contain_action")]
        ContainAction = 13
    }
}
