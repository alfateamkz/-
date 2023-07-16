using CRM.Models.Network.LoyaltyProgram;
using CRM.Models.Stores;
using CRMAdminMoblieApp.Helpers;
using CRMMobileApp.Abstractions;
using CRMMoblieApiWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMMobileApp.Helpers
{
    public static class OrdersHelper
    {
        public static Order CurrentOrder { get; set; }
        public static List<Order> ActiveOrders { get; set; } = new List<Order>();




        /// <summary>
        /// Когда выбираем стол и заказ в режиме "кафе"
        /// </summary>
        public static AbsTable FromTable { get; set; }




        public static event EventHandler<Order> OnOrderItemsCountChanged;

        public static async Task GetCurrentOrder()
        {
            CurrentOrder = await MobileAPI.BaristaMethods.BaristaOrdersMethods.GetLastOrder(ApplicationState.CurrentDomain, ApplicationState.CurrentStore.Id);
            if(CurrentOrder is null)
            {
                await OpenOrder();
            }
        }
        public static async Task GetActiveOrders()
        {
            ActiveOrders = await MobileAPI.BaristaMethods.BaristaOrdersMethods.GetActiveOrders(ApplicationState.CurrentDomain,
                                                                                               ApplicationState.CurrentStore.Id,
                                                                                               ApplicationState.CurrentDuty.Id);
        }




        public static async Task CancelOrder()
        {
            CurrentOrder.ClosedAt = DateTime.Now;
            CurrentOrder.IsCanceled = true;
            await MobileAPI.BaristaMethods.BaristaOrdersMethods.CancelOrder(ApplicationState.CurrentDomain, CurrentOrder.Id);

            CurrentOrder = null;
            onOrderItemsCountChanged();
        }
        public static async Task CloseOrder()
        {
            CurrentOrder.ClosedAt = DateTime.Now;
            await MobileAPI.BaristaMethods.BaristaOrdersMethods.CloseOrder(ApplicationState.CurrentDomain,
                                                                           ApplicationState.CurrentTradeNetwork.Id,
                                                                           ApplicationState.CurrentStore.Id, 
                                                                           CurrentOrder);

            if (FromTable != null)
            {
                FromTable.RemoveOrder(CurrentOrder);
            }

            CurrentOrder = null;
            onOrderItemsCountChanged();
        }
        public static async Task OpenOrder()
        {
            CurrentOrder = await MobileAPI.BaristaMethods.BaristaOrdersMethods.OpenOrder(
                                                                           ApplicationState.CurrentDomain,
                                                                           ApplicationState.CurrentStore.Id,
                                                                           ApplicationState.CurrentDuty.Id,
                                                                           Auth.User.Id);
            onOrderItemsCountChanged();
        }


        public static void SetActiveOrder(Order order)
        {
            CurrentOrder = order;
            onOrderItemsCountChanged();
        }


        public static void AddOrderItem(OrderItem orderItem)
        {
            CurrentOrder.Items.Add(orderItem);
            if(orderItem.TechnicalCard != null)
            {
                orderItem.Price = orderItem.TechnicalCard.Price * orderItem.Amount;
            }
            else if (orderItem.Product != null)
            {
                orderItem.Price = orderItem.Product.Price * orderItem.Amount;
            }
            foreach(var option in orderItem.SelectedModifiers.SelectMany(o => o.SelectedOptions))
            {
                orderItem.Price += option.ModifierOption.Price * option.Amount;
            }
            onOrderItemsCountChanged();
        }
        public static void DeleteOrderItem(OrderItem orderItem)
        {
            CurrentOrder.Items.Remove(orderItem);
            onOrderItemsCountChanged();
        }
        public static void ClearOrderItems()
        {
            CurrentOrder.Items.Clear();
            onOrderItemsCountChanged();
        }


        public static void SetDiscount(Discount discount)
        {
            CurrentOrder.Discount = discount;
            CurrentOrder.DiscountId = discount.Id;

            onOrderItemsCountChanged();
        }




        private static async void onOrderItemsCountChanged()
        {
            OnOrderItemsCountChanged?.Invoke(null, CurrentOrder);
            await MobileAPI.BaristaMethods.BaristaOrdersMethods.UpdateOrder(ApplicationState.CurrentDomain,
                                                                            CurrentOrder);
        }
    }
}
