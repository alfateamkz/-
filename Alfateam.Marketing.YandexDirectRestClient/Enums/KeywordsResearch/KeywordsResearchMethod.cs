using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.KeywordsResearch
{
    public enum KeywordsResearchMethod
    {
        [Description("deduplicate")]
        Deduplicate = 1,
        [Description("hasSearchVolume")]
        HasSearchVolume = 2,
    }
}
