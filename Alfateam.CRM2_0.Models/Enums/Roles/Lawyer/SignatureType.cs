using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Lawyer
{
    /// <summary>
    /// Вид подписи документа
    /// </summary>
    public enum SignatureType
    {
        TraditionalSignature = 1, //Подпись документа на бумаге
        DigitalSignature = 2, //ЭЦП
    }
}
