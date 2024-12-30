using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.Engagements
{
    public enum MeasurementEngagementPlatform
    {
        [Description("smartcast")]
        Smartcast = 1,
        [Description("tizen")]
        Tizen = 2,
        [Description("roku")]
        Roku = 3,
        [Description("webos")]
        webOS = 4,
        [Description("vidaa")]
        Vidaa = 5,
        [Description("playstation")]
        PlayStation = 6,
        [Description("steam")]
        Steam = 7,
        [Description("quest")]
        Quest = 8,
        [Description("battlenet")]
        Battlenet = 9,
        [Description("epic")]
        Epic = 10,
        [Description("switch")]
        Switch = 11,
        [Description("xbox")]
        Xbox = 12,
        [Description("nativepc")]
        NativePC = 13,
    }
}
