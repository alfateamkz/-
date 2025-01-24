using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models
{
    public class ModerationForbiddenPhrase : AbsModel
    {
        public string Phrase { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
