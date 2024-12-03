using Alfateam.Core;
using Alfateam.Marketing.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.General
{
    public class ContactInfo : AbsModel
    {
        public ContactType Type { get; set; }
        public string Contact { get; set; }

        public string? Comment { get; set; }
    }
}
