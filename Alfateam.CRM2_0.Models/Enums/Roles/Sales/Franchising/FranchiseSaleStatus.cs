using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Sales.Franchising
{
    /// <summary>
    /// Статус продажи франшизы
    /// </summary>
    public enum FranchiseSaleStatus
    {
        Lead = 1, //Потенциальный партнер
        Negotiations = 2, //Переговоры
        Review = 3, //Изучение благонадежности партнера
        WaitingForDecision = 4, //Ожидание решения клиента
        ContractDiscussion = 5, //Обсуждение условий договора
        WaitingForSigning = 6, //Ожидание подписания договора
        WaitingForStartPayment = 7, //Ожидание оплаты стартового взноса по договору
        WaitingForStart = 8, //Ожидание запуска бизнеса
        Active = 9, //Активно
        FrozenUntilPayment = 10, //Доступ к crm заморожен до внесения роялти
        Terminated = 11, //Договор партнерства/франшизы закрыт(например, клиент обанкротился или нарушение условий договора)
    }
}
