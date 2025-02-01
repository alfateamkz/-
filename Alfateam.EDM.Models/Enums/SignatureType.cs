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
    }
}
