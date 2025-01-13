using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.KeywordsResearch
{
    public enum DeduplicateOperationEnum
    {
        [Description("MERGE_DUPLICATES")]
        MergeDuplicates = 1,
        [Description("ELIMINATE_OVERLAPPING")]
        EliminateOverlapping = 2,
    }
}
