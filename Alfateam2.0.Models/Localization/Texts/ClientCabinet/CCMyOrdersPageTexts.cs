using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet
{
    public class CCMyOrdersPageTexts : LocalizableModel
    {
        public string Header { get; set; } = "Мои заказы";


        public string StatusDeliveredAt { get; set; } = "Доставлено: {dd.MM.yyyy}";
        public string StatusWillDeliveredAt { get; set; } = "Примерная дата доставки: {dd.MM.yyyy}";
        public string StatusCanceled { get; set; } = "Отменен";
    }
}
