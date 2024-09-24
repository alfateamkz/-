using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Enums
{
    public enum SignatureType
    {
        TraditionalSignature = 1, //Сканы подписанных документов на бумаге
        AlfateamEDM = 2, //Подписание через ЭДО Alfateam
        SignedByOtherEDM = 3, //Подписано через другой ЭДО сервис, просто отмечаем через какой и прикладываем документы
    }
}
