using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Enums
{
    public enum PromotionPuzzleType
    {
        [Description("Пазл 1")]
        Puzzle1 = 1,
        [Description("Пазл 2")]
        Puzzle2 = 2,
        [Description("Пазл 3")]
        Puzzle3 = 3,
        [Description("Пазл 4")]
        Puzzle4 = 4,
    }
}
