using Alfateam.Core;
using Alfateam.Marketing.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Filters.Items
{
    public class FilterContactTypeItem : AbsModel
    {
        public ContactType Type { get; set; }
    }
}
