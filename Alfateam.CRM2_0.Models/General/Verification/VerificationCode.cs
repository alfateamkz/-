using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Verification
{
    /// <summary>
    /// Модель верификационного кода
    /// </summary>
    public class VerificationCode : AbsModel
    {
        public VerificationType Type { get; set; } 
        public string Contact { get; set; }

        public string Code { get; set; }    
        public string Message { get; set; }


        public bool IsVerified { get; set; }
    }
}
