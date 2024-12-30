using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Management.AppManagementAPIV2
{
    public enum DeleteAppPlatform
    {
        [Description("android")]
        Android = 1,
        [Description("ios")]
        iOS = 2,
        [Description("windowsphone")]
        WindowsPhone = 3,
        [Description("roku")]
        Roku = 4,
        [Description("smartcast")]
        Smartcast = 5,
        [Description("tizen")]
        Tizen = 6,
        [Description("webos")]
        webOS = 7,
        [Description("playstation")]
        PlayStation = 8,
        [Description("vidaa")]
        Vidaa = 9,
        [Description("steam")]
        Steam = 10,
        [Description("quest")]
        Quest = 11,
        [Description("battlenet")]
        Battlenet = 12,
        [Description("web")]
        Web = 13,
        [Description("switch")]
        Switch = 14,
        [Description("xbox")]
        Xbox = 15,
        [Description("epic")]
        Epic = 16,
        [Description("nativepc")]
        NativePC = 17,
        [Description("chatgpt")]
        ChatGPT = 18
    }
}
