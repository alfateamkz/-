using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AdExtensions
{
    public enum AdExtensionsMethod
    {
        [Description("add")]
        Add = 1,
        [Description("get")]
        Get = 2,
        [Description("delete")]
        Delete = 3
    }
}
