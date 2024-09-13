using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Shop
{
    public class ShopBasketPageTexts : LocalizableModel
    {
        public string MiddleBreadcrump { get; set; } = "Мерч";
        public string LastBreadcrump { get; set; } = "Корзина";

        public string Header { get; set; } = "КОРЗИНА";


        public string ItemPriceForOne { get; set; } = "Цена за ед.";
        public string ItemPriceTotal { get; set; } = "Итого";
        public string ItemPriceAmount { get; set; } = "Кол-во: ";




        public string TotalItemsPrice { get; set; } = "Общий заказ";
        public string DeliveryPrice { get; set; } = "Стоимость доставки";
        public string DeliverySetAddress { get; set; } = "Указать адрес";
        public string OrderTotalPrice { get; set; } = "Итог:";


        public string PromocodeFieldTitle { get; set; } = "Промокод";
        public string PromocodeFieldPlaceholder { get; set; } = "Введите промокод (если есть)";


        public string BtnMakeOrder { get; set; } = "Оформить заказ";
        public string BtnClearBasket { get; set; } = "Очистить корзину";


        public string ClearBasketConfirmation { get; set; } = "Вы действительно хотите очистить корзину?";
        public string ClearBasketConfirmationYes { get; set; } = "Да";
        public string ClearBasketConfirmationNo { get; set; } = "Нет";


        public string EmptyBasketText { get; set; } = "Ваша корзина пуста";
    }
}
