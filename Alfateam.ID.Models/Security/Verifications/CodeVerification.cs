using Alfateam.ID.Models.Abstractions;
using Alfateam.ID.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.ID.Models.Security.Verifications
{
    public class CodeVerification : Verification
    {
        public VerificationType Type { get; set; }

        /// <summary>
        /// Телефон или email
        /// </summary>
        public string SentTo { get; set; }
        public string Code { get; set; }
        public DateTime ValidBefore { get; set; } = DateTime.UtcNow.AddMinutes(5);
        public bool IsVerified { get; set; }
    }
}
