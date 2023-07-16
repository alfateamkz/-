using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Lawyer
{
    /// <summary>
    /// Тип документа
    /// </summary>
    public enum DocumentType
    {
        ContractWithClient = 1, //Договор с клиентом
        ContractWithCounteragent = 2, //Договор с контрагентом/работником(ГПХ)
        Invoice = 3, //Счет на оплату
        CompletionCertificate = 4, //Акт выполненных работ
        TerminationWithClient = 5, //Расторжение договора с клиентом
        TerminationWithCounteragent = 6, //Расторжение договора с контрагентом
        PersonalDataProcessing = 7, //Согласие на обработку персональных данных
        ClaimLetter = 8, //Претензионное письмо
        ClaimLetterReply = 9, //Ответ на претензионное письмо
        StatementOfClaim = 10, //Исковое заявление

        Other = 999, //Прочее

    }
}
