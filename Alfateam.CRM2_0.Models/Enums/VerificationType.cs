using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums
{
    /// <summary>
    /// Способ верификации
    /// </summary>
    public enum VerificationType
    {
        PhoneSMS = 1, //SMS сообщение с кодом
        EmailCode = 2 //Письмо на электронную почту с кодом
    }
}
