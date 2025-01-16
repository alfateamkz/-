using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums
{
    public enum DelimiterSymbol
    {
        [Description("AUTODETECT")]
        Autodetect = 1,
        [Description("BAR")]
        Bar = 2,
        [Description("COMMA")]
        Comma = 3,
        [Description("TAB")]
        Tab = 4,
        [Description("TILDE")]
        Tilde = 5,
        [Description("SEMICOLON")]
        Semicolon = 6,
    }
}
