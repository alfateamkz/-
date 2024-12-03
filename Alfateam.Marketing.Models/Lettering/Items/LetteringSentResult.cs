using Alfateam.Core;
using Alfateam.Marketing.Models.Enums;
using Alfateam.Marketing.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Lettering.Items
{
    public class LetteringSentResult : AbsModel
    {
        public ContactInfo Contact { get; set; }



        public LetteringSentResultType ResultType { get; set; }
        public string? ResultText { get; set; }
    }
}
