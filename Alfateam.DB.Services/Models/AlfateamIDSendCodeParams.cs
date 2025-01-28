using Alfateam.ID.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.Services.Models
{
    public class AlfateamIDSendCodeParams
    {
        public VerificationType Type { get; set; }
        public VerificationFor ActionFor { get; set; }
        public string Contact { get; set; }
        public string LetterTitle { get; set; }
        public string MessageText { get; set; }
    }
}
