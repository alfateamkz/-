using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Bids
{
    public enum CalculateByEnum
    {
        [Description("VALUE")]
        Value = 1,
        [Description("DIFF")]
        Diff = 2,
    }
}
