using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet
{
    public class CCMyOrdersPageTexts : LocalizableModel
    {
        [Description("Заголовок: Мои заказы")]
        public string Header { get; set; } = "Мои заказы";


        [Description("Доставлено: {dd.MM.yyyy}")]
        public string StatusDeliveredAt { get; set; } = "Доставлено: {dd.MM.yyyy}";

        [Description("Примерная дата доставки: {dd.MM.yyyy}")]
        public string StatusWillDeliveredAt { get; set; } = "Примерная дата доставки: {dd.MM.yyyy}";
        [Description("Отменен")]
        public string StatusCanceled { get; set; } = "Отменен";
    }
}
