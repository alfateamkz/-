using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Strategies
{
    public enum StrategiesMethod
    {
        [Description("add")]
        Add = 1,  
        [Description("archive")]
        Archive = 2,
        [Description("get")]
        Get = 3,
        [Description("unarchive")]
        Unarchive = 4,
        [Description("update")]
        Update = 5,
    }
}
