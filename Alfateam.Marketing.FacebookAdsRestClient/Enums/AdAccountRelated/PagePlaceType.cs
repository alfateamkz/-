using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum PagePlaceType
    {
        [Description("CITY")]
        City = 1,
        [Description("COUNTRY")]
        Country = 2,
        [Description("EVENT")]
        Event = 3,
        [Description("GEO_ENTITY")]
        GeoEntity = 4,
        [Description("PLACE")]
        Place = 5,
        [Description("RESIDENCE")]
        Residence = 6,
        [Description("STATE_PROVINCE")]
        StateProvince = 7,
        [Description("TEXT")]
        Text = 8,
    }
}
