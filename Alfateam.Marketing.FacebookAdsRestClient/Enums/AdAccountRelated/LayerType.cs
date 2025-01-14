using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum LayerType
    {
        [Description("image")]
        Image = 1,
        [Description("frame_overlay")]
        FrameOverlay = 2,
        [Description("text_overlay")]
        TextOverlay = 3,
    }
}
