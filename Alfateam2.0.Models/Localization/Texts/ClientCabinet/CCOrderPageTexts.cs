using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet
{
    public class CCOrderPageTexts : LocalizableModel
    {
        [Description("Заголовок: Заказ #{number}")]
        public string Header { get; set; } = "Заказ #{number}";





        [Description("Цена за ед.")]
        public string ItemPriceForOne { get; set; } = "Цена за ед.";

        [Description("Итого")]
        public string ItemPriceTotal { get; set; } = "Итого";

        [Description("Кол-во: ")]
        public string ItemPriceAmount { get; set; } = "Кол-во: ";



        [Description("Общий заказ")]
        public string TotalItemsPrice { get; set; } = "Общий заказ";
        [Description("Стоимость доставки")]
        public string DeliveryPrice { get; set; } = "Стоимость доставки";
        [Description("Итог:")]
        public string OrderTotalPrice { get; set; } = "Итог:";


        [Description("Отследить заказ")]
        public string BtnTrackOrder { get; set; } = "Отследить заказ";
    }
}
