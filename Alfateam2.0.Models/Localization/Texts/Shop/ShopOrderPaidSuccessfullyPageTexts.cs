using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Shop
{
    public class ShopOrderPaidSuccessfullyPageTexts : LocalizableModel
    {
        public string Header { get; set; } = "Заказ успешно оплачен!";
        public string OrderNumber { get; set; } = "Номер заказа #{number}";
    }
}
