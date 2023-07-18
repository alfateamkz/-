using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Sales.Orders
{
    /// <summary>
    /// Статус заказа
    /// </summary>
    public enum OrderStatus
    {
        Lead = 1, //Потенциальный заказ
        Negotiations = 2, //Переговоры
        Research = 3, //Изучение задачи
        WaitingForDecision = 4, //Ожидание решения клиента
        ContractDiscussion = 5, //Обсуждение условий договора
        WaitingForUpfrontPayment = 6, //Ожидание предоплаты по заказу
        WaitingForStart = 7, //В ожидании работ
        Started = 8, //Работа начата
        WaitingForPayment = 9, //Ожидание оплаты по заказу
        MilestoneAcceptance = 10, //Приемка этапа
        Acceptance = 11, //Приемка заказа
        Completed = 12, //Заказ выполнен
        CouldNotSellIgnoring = 13, //Не получилось продать - игнор клиента
        CouldNotSell = 14, //Не получилось продать - не сошлись по условиям
        Termination = 15, //Расторжение по договору
        Pause = 16, //Пауза по заказу
        WorkSuspended = 17, //Работа приостановлена

    }
}
