using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Shop
{
    public class ShopOrderNotPaidPageTexts : LocalizableModel
    {
        public string Header { get; set; } = "Заказ не оплачен!";


        public string ErrorInvalidCVV { get; set; } = "Ошибка: Неверный CVV";
        public string ErrorInvalidOther { get; set; } = "Ошибка: Неверные реквизиты";

        public string ErrorInsufficientMoney { get; set; } = "Ошибка: Недостаточно средств на счете";
        public string ErrorBankDeclined { get; set; } = "Ошибка: Банк отклонил платеж";


        public string ErrorOther { get; set; } = "Ошибка: Оплата не прошла";
    }
}
