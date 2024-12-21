using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Segments
{
    public enum SegmentStatus
    {
        [Description("active")]
        Active = 1,
        [Description("deleted")]
        Deleted = 2,
    }
}
