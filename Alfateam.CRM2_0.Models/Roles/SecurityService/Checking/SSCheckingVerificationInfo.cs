using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General.Verification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Checking
{
    /// <summary>
    /// Модель проверки контактных данных
    /// </summary>
    public class SSCheckingVerificationInfo : AbsModel
    {
        public VerificationCode VerificationCode { get; set; }

    }
}
