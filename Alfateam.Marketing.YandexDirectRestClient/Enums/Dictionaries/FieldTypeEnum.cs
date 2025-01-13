using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries
{
    public enum FieldTypeEnum
    {
        [Description("Enum")]
        Enum = 1,
        [Description("Number")]
        Number = 2,
        [Description("String")]
        String = 3,
    }
}
