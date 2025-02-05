using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Forms
{
    public class ContactMeForm : SentFromWebsiteForm
    {
        public ContactMeFormType Type { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Message { get; set; }
    }
}
