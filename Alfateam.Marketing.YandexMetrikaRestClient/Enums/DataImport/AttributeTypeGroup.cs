using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport
{
    public enum AttributeTypeGroup
    {
        [Description("PREDEFINED")]
        Predefined = 1,
        [Description("CUSTOM_LIST")]
        CustomList = 2,
        [Description("SYSTEM_LIST")]
        SystemList = 3
    }
}
