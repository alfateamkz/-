using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Enums
{
    public enum SignatureType
    {
        TraditionalSignature = 1, //Сканы подписанных документов на бумаге с документооборотом (каждая сторона прислала сканы через сервис)
        AlfateamEDM = 2, //Подписание через ЭДО Alfateam
        SignedByOtherEDM = 3, //Подписано через другой ЭДО сервис, просто отмечаем через какой и прикладываем документы
        TraditionalSignatureWithoutDF = 4, //Сканы подписанных документов на бумаге без фактического документооборота (подгрузили сканы сами)
    }
}
