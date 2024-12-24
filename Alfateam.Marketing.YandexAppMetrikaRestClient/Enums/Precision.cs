using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Enums
{
    public enum Precision
    {
        [Description("publisher_defined")]
        PublisherDefined = 1,
        [Description("estimated")]
        Estimated = 2,
    }
}
