using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet
{
    public class CCOrderPageTexts : LocalizableModel
    {
        public string Header { get; set; } = "Заказ #{number}";


        public string ItemPriceForOne { get; set; } = "Цена за ед.";
        public string ItemPriceTotal { get; set; } = "Итого";
        public string ItemPriceAmount { get; set; } = "Кол-во: ";



        public string TotalItemsPrice { get; set; } = "Общий заказ";
        public string DeliveryPrice { get; set; } = "Стоимость доставки";
        public string OrderTotalPrice { get; set; } = "Итог:";


        public string BtnTrackOrder { get; set; } = "Отследить заказ";
    }
}
