using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Creatives
{
    public enum CreativeTypeEnum
    {
        [Description("IMAGE_CREATIVE")]
        ImageCreative = 1,
        [Description("HTML5_CREATIVE")]
        HTML5Creative = 2,
        [Description("VIDEO_EXTENSION_CREATIVE")]
        VideoExtensionCreative = 3,
        [Description("CPC_VIDEO_CREATIVE")]
        CPCVideoCreative = 4,
        [Description("CPM_VIDEO_CREATIVE")]
        CPMVideoCreative = 5,
        [Description("SMART_CREATIVE")]
        SmartCreative = 6,
    }
}
