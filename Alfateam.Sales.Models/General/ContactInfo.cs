using Alfateam.Core;
using Alfateam.Sales.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.General
{
    public class ContactInfo : AbsModel
    {
        public ContactType Type { get; set; }
        public string Contact { get; set; }

        public string? Comment { get; set; }
    }
}
