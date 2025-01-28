using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Filters;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO;
using Alfateam.Website.API.Models.DTO.Promocodes;
using Alfateam.Website.API.Models.DTO.Shop;
using Alfateam.Website.API.Models.DTO.Shop.Orders;
using Alfateam.Website.API.Models.DTO.Shop.Wishes;
using Alfateam.Website.API.Models.Filters;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Promocodes;
using Alfateam2._0.Models.Shop;
using Alfateam2._0.Models.Shop.Orders;
using Alfateam2._0.Models.Shop.Wishes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alfateam.Website.API.Controllers.Website
{
    public class ShopController : AbsController
    {
        public ShopController(ControllerParams @params) : base(@params)
        {
        }




        #region Позиции

        [HttpGet, Route("GetProducts")]
        public async Task<IEnumerable<ShopProductDTO>> GetProducts(int offset, int count = 20)
        {
            var items = GetShopProducts().Skip(offset).Take(count).ToList();
            return new ShopProductDTO().CreateDTOsWithLocalization(items, (int)LanguageId, (int)CountryId, (int)CurrencyId);
        }

        [HttpGet, Route("GetProductsByFilter")]
        public async Task<IEnumerable<ShopProductDTO>> GetProductsByFilter([FromQuery]ClientShopProductsFilter filter)
        {
            var products = GetShopProducts();

            if (filter.CategoryId > 0)
            {
                products = products.Where(o => o.Category.Id == filter.CategoryId);
            }

            if (!string.IsNullOrEmpty(filter.Query))
            {
                products = products.Where(o => o.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase));
            }

            products = products.Skip(filter.Offset).Take(filter.Count);
            return new ShopProductDTO().CreateDTOsWithLocalization(products.ToList(), (int)LanguageId, (int)CountryId, (int)CurrencyId);
        }

        [HttpGet, Route("GetProduct")]
        public async Task<ShopProductDTO> GetProduct(int id)
        {
            var product = GetShopProducts().FirstOrDefault(o => o.Id == id);
            return new ShopProductDTO().CreateDTOWithLocalization(product, (int)LanguageId, (int)CountryId, (int)CurrencyId);
        }





        [HttpGet, Route("GetProductCategories")]
        public async Task<IEnumerable<ShopProductCategoryDTO>> GetProductCategories()
        {
            var items = DB.ShopProductCategories.IncludeAvailability()
                                                .Include(o => o.Localizations)
                                                .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                                .ToList();
            return new ShopProductCategoryDTO().CreateDTOsWithLocalization(items, LanguageId).Cast<ShopProductCategoryDTO>();
        }

        #endregion

        #region Корзина

        [HttpGet, Route("GetBasket")]
        [UserActionsFilter]
        public async Task<ShopOrderDTO> GetBasket()
        {
            var user = GetSessionWithBasketInclude().User;
            if (user.Basket == null)
            {
                user.Basket = new ShopOrder();
                DbService.UpdateEntity(DB.Users, user);
            }

            return (ShopOrderDTO)new ShopOrderDTO().CreateDTO(user.Basket);
        }


        [HttpPut, Route("SetBasketCurrency")]
        [UserActionsFilter]
        public async Task SetBasketCurrency()
        {
            var user = GetSessionWithBasketInclude().User;

            if(this.CurrencyId == null)
            {
                throw new Exception400("Id валюты за заголовке CurrencyId не должен быть равен null");
            }
            else if (!DB.Currencies.Any(o => o.Id == this.CurrencyId && !o.IsDeleted))
            {
                throw new Exception400("По id, указанному в заголовке CurrencyId не найдено валюты");
            }
            else if (user.Basket?.Items?.Any(o => !o.IsDeleted) == true)
            {
                throw new Exception400("Нельзя изменить валюту, когда в корзине есть товары. Сначала удалите из корзины все позиции");
            }


            if (user.Basket == null)
            {
                user.Basket = new ShopOrder();
            }
            user.Basket.CurrencyId = this.CurrencyId;

            DbService.UpdateEntity(DB.Users, user);
        }


        [HttpPut, Route("UsePromocode")]
        [UserActionsFilter]
        public async Task UsePromocode(string code)
        {
            var user = GetSessionWithPromocodesInclude().User;
            var promocode = DB.Promocodes.IncludeAvailability()
                                         .FirstOrDefault(o => o.Code == code && !o.IsDeleted 
                                                       && o.Availability.IsAvailable(CountryId));
            if(promocode == null)
            {
                throw new Exception404("Данный промокод не найден");
            }
            else if (promocode.IsExpired)
            {
                throw new Exception403("Данный промокод уже не активен");
            }
            else if(user.UsedPromocodes.Any(o => o.PromocodeId == promocode.Id) && !promocode.IsReusable)
            {
                throw new Exception403("Данный промокод уже был использован Вами ранее");
            }
            else if(user.Basket.UsedPromocodeId != null)
            {
                throw new Exception403("Промокод на данную покупку уже активирован");
            }

            user.Basket.UsedPromocodeId = promocode.Id;
            user.UsedPromocodes.Add(new UsedPromocode
            {
                PromocodeId = promocode.Id,
            });

            DbService.UpdateEntity(DB.Users, user);
        }



        [HttpPut, Route("AddToBasket")]
        [UserActionsFilter]
        public async Task<ShopOrderItemDTO> AddToBasket(ShopOrderItemDTO model)
        {
            var user = GetSessionWithBasketInclude().User;
            if (user.Basket.CurrencyId == null)
            {
                throw new Exception400("Невозможно добавить в корзину товар, пока не выбрана валюта");
            }
            if (user.Basket.CountryId == null)
            {
                throw new Exception400("Невозможно добавить в корзину товар, пока не выбрана страна");
            }


            var product = DB.ShopProducts.FirstOrDefault(o => o.Id == model.ItemId && !o.IsDeleted);
            if(product == null)
            {
                throw new Exception404("Товар с данным id не найден");
            }

            

            var item = model.CreateDBModelFromDTO();
            SetItemActualPrices(user.Basket,item);

            user.Basket.Items.Add(item);
            DbService.UpdateEntity(DB.Users, user);

            model.Id = item.Id;
            return model;
        }

        [HttpPut, Route("EditBasketItem")]
        [UserActionsFilter]
        public async Task<ShopOrderItemDTO> EditBasketItem(ShopOrderItemDTO model)
        {
            var user = GetSessionWithBasketInclude().User;

            var item = DB.ShopOrderItems.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (item == null)
            {
                throw new Exception404("Товар в системе не найден");
            }
            else if (item.ShopOrderId != user.Basket?.Id)
            {
                throw new Exception403("Данная позиция не принадлежит пользователю");
            }


            UpdateOrderItem(item, model);
            SetItemActualPrices(user.Basket, item);

            DbService.UpdateEntity(DB.ShopOrderItems, item);
            return model;
        }

        [HttpDelete, Route("RemoveBasketItem")]
        [UserActionsFilter]
        public async Task RemoveBasketItem(int basketItemId)
        {
            var user = GetSessionWithBasketInclude().User;

            var item = DB.ShopOrderItems.FirstOrDefault(o => o.Id == basketItemId && !o.IsDeleted);
            if (item == null)
            {
                throw new Exception404("Товар в системе не найден");
            }
            else if (item.ShopOrderId != user.Basket?.Id)
            {
                throw new Exception403("Данная позиция не принадлежит пользователю");
            }


            //TODO: внимательно проверить удаление !!!
            user.Basket.Items.Remove(item);
            DbService.UpdateEntity(DB.Users, user);
        }

        #endregion

        #region Избранное

        [HttpGet, Route("GetWishlist")]
        [UserActionsFilter]
        public async Task<ShopWishlistDTO> GetWishlist()
        {
            var user = GetSessionWithWishlistInclude().User;
            return (ShopWishlistDTO)new ShopWishlistDTO().CreateDTO(user.Wishlist);
        }

        [HttpPut, Route("ToggleWishlistItem")]
        [UserActionsFilter]
        public async Task<bool> ToggleWishlistItem(int productId)
        {
            var user = GetSessionWithWishlistInclude().User;

            if (!DB.ShopProducts.Any(o => o.Id == productId && !o.IsDeleted))
            {
                throw new Exception404("Товарная позиция по данному id не найдена");
            }

            //TODO: CHECK IT
            var found = user.Wishlist.Items.FirstOrDefault(o => o.ProductId == productId);
            if (found != null)
            {
                user.Wishlist.Items.Remove(found);
                DbService.UpdateEntity(DB.Users, user);
                return false;
            }

            user.Wishlist.Items.Add(new ShopWishlistItem
            {
                ProductId = productId
            });
            DbService.UpdateEntity(DB.Users, user);
            return true;
        }

        #endregion

        #region Заказы

        [HttpGet, Route("GetOrders")]
        [UserActionsFilter]
        public async Task<IEnumerable<ShopOrderDTO>> GetOrders()
        {
            var user = GetSessionWithOrdersInclude().User;
            return new ShopOrderDTO().CreateDTOsWithLocalization(user.Orders.Where(o => !o.IsDeleted), this.LanguageId).Cast<ShopOrderDTO>();
        }

        [HttpGet, Route("GetOrder")]
        [UserActionsFilter]
        public async Task<ShopOrderDTO> GetOrders(int orderId)
        {
            var user = GetSessionWithOrdersInclude().User;
            return (ShopOrderDTO)DbService.TryGetOne(user.Orders, orderId,new ShopOrderDTO());
        }

        [HttpPut, Route("CreateOrderFromBasket")]
        [UserActionsFilter]
        public async Task CreateOrderFromBasket()
        {
            var user = GetSessionWithOrdersInclude().User;

            if(!user.Basket.Items.Any(o => !o.IsDeleted))
            {
                throw new Exception400("Невозможно создать заказ, т.к. корзина пуста");
            }

            //TODO: внимательно чекнуть
            var basket = user.Basket;
            user.Orders.Add(basket);
            user.Basket = new ShopOrder();

            DbService.UpdateEntity(DB.Users, user);
        }


        [HttpDelete, Route("RemoveUnpaidOrder")]
        [UserActionsFilter]
        public async Task RemoveUnpaidOrder(int orderId)
        {
            var user = GetSessionWithOrdersInclude().User;
            var order = user.Orders.FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);
            if (order == null)
            {
                throw new Exception404("Заказ по данному id в системе не найден");
            }
            else if(order.Status != ShopOrderStatus.Unpaid)
            {
                throw new Exception403("Невозможно удалить заказ");
            }

            DbService.DeleteEntity(DB.ShopOrders, order);
        }


        #endregion

        #region Оплата заказа

        //TODO: пока нету, будем прикручивать юкассу и КЗ эквайринг
        [HttpPut, Route("CreatePayment")]
        [UserActionsFilter]
        public async Task CreatePayment(int orderId, MerchantServiceType merchantType)
        {
            var user = GetSessionWithOrdersInclude().User;

            var order = user.Orders.FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);
            if (order == null)
            {
                throw new Exception404("Заказ по данному id в системе не найден");
            }
            else if (order.Status != ShopOrderStatus.Unpaid)
            {
                throw new Exception403("Невозможно удалить заказ");
            }

            var sum = order.SumWithoutDiscount;

            if (order.UsedPromocode != null && order.UsedPromocode.IsCostInRange(new Cost(order.Currency, sum), order.CountryId))
            {
                if (order.UsedPromocode is PercentPromocode percentPromocode)
                {
                    order.DiscountByPromocode = percentPromocode.Percent;
                    sum -= sum / 100 * (double)order.DiscountByPromocode;
                }
                else if (order.UsedPromocode is PricePromocode pricePromocode)
                {
                    var price = pricePromocode.Discount.GetPrice(order.CountryId, (int)order.CurrencyId);
                    sum -= price.Value;
                }
            }


            var payment = new ShopOrderPayment()
            {
                CurrencyId = (int)order.CurrencyId,
                MerchantService = merchantType,
                Description = $"Оплата заказа #{order.Id}",
                Sum = sum
            };
            order.Payments.Add(payment);

            DbService.UpdateEntity(DB.ShopOrders, order);

            //TODO: отправка платежа на эквайринг
        }

        [HttpGet,HttpPost,HttpPut, Route("RU_YookassaWebhook")]
        public async Task RU_YookassaWebhook()
        {

        }
        [HttpGet, HttpPost, HttpPut, Route("KZ_JusanWebhook")]
        public async Task KZ_JusanWebhook()
        {

        }

        #endregion


        [HttpGet, Route("GetPromocodeInfo")]
        public async Task<PromocodeDTO> GetPromocodeInfo(string code)
        {
            var promocode = DB.Promocodes.IncludeAvailability()
                                         .FirstOrDefault(o => o.Code == code && !o.IsDeleted
                                                      && o.Availability.IsAvailable(CountryId));
            if (promocode == null)
            {
                throw new Exception404("Данный промокод не найден");
            }
            if (promocode.IsExpired)
            {
                throw new Exception403("Данный промокод уже не активен");
            }

            return PromocodeDTO.Create(promocode, CountryId, (int)CurrencyId);
        }








        #region Private methods


        private void UpdateOrderItem(ShopOrderItem item, ShopOrderItemDTO DTO)
        {
            item.ItemId = DTO.ItemId;
            item.Amount = DTO.Amount;

            item.SelectedModifiers.Clear();
            foreach(var updModifier in DTO.SelectedModifiers)
            {
                var modifier = new ShopOrderItemModifier()
                {
                    ModifierId = updModifier.ModifierId
                };

                foreach(var updOption in updModifier.SelectedOptions)
                {
                    modifier.SelectedOptions.Add(new ShopOrderItemModifierOption
                    {
                        OptionId = updOption.OptionId,
                    });
                }
            }

            //TODO: внимательно проверить работу метода
        }


        private void SetOrderActualPrices(ShopOrder order)
        {
            foreach(var item in order.Items)
            {
                SetItemActualPrices(order, item);
            }
        }
        private void SetItemActualPrices(ShopOrder order, ShopOrderItem item)
        {
            var product = item.Item;
            if(product == null)
            {
                product = DB.ShopProducts.FirstOrDefault(o => o.Id == item.ItemId);
            }

            var cost = product.BasePricing.GetPrice(order.CountryId, (int)order.CurrencyId);
            item.PriceForOne = cost.Value;

            foreach (var selectedOption in item.SelectedModifiers.SelectMany(o => o.SelectedOptions))
            {
                var option = selectedOption.Option;
                if (option == null)
                {
                    option = DB.ProductModifierItems.FirstOrDefault(o => o.Id == selectedOption.OptionId);
                }

                var optionCost = option.Pricing.GetPrice(order.CountryId, (int)order.CurrencyId);
                item.PriceForOne = optionCost.Value;
            }
        }

        #endregion

        #region Private include methods
        private IEnumerable<ShopProduct> GetShopProducts()
        {
            return DB.ShopProducts.IncludeAvailability()
                                  .Include(o => o.Category).ThenInclude(o => o.Localizations)
                                  .Include(o => o.MainImage)
                                  .Include(o => o.Images)
                                  .IncludePricing()
                                  .Include(o => o.Modifiers).ThenInclude(o => o.Localizations)
                                  .Include(o => o.Modifiers).ThenInclude(o => o.Options).ThenInclude(o => o.Localizations)
                                  .Include(o => o.Modifiers).ThenInclude(o => o.Options).ThenInclude(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                  .Include(o => o.Modifiers).ThenInclude(o => o.Options).ThenInclude(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                                  .Include(o => o.Localizations)
                                  .ToList()
                                  .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }


        private Session GetSessionWithBasketInclude()
        {
            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.Basket).ThenInclude(o => o.Items).ThenInclude(o => o.Item).ThenInclude(o => o.MainImage)
                                     .Include(o => o.User).ThenInclude(o => o.Basket).ThenInclude(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.Modifier)
                                     .Include(o => o.User).ThenInclude(o => o.Basket).ThenInclude(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.SelectedOptions).ThenInclude(o => o.Option)
                                     .Include(o => o.User).ThenInclude(o => o.Basket).ThenInclude(o => o.Address).ThenInclude(o => o.Country)
                                     .Include(o => o.User).ThenInclude(o => o.Basket).ThenInclude(o => o.Currency)
                                     .Include(o => o.User).ThenInclude(o => o.Basket).ThenInclude(o => o.Payments).ThenInclude(o => o.Currency)
                                     .Include(o => o.User).ThenInclude(o => o.Basket).ThenInclude(o => o.Return)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);

            return session;
        }
        private Session GetSessionWithOrdersInclude()
        {
            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.Orders).ThenInclude(o => o.Items).ThenInclude(o => o.Item).ThenInclude(o => o.MainImage)
                                     .Include(o => o.User).ThenInclude(o => o.Orders).ThenInclude(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.Modifier)
                                     .Include(o => o.User).ThenInclude(o => o.Orders).ThenInclude(o => o.Items).ThenInclude(o => o.SelectedModifiers).ThenInclude(o => o.SelectedOptions).ThenInclude(o => o.Option)
                                     .Include(o => o.User).ThenInclude(o => o.Orders).ThenInclude(o => o.Address).ThenInclude(o => o.Country)
                                     .Include(o => o.User).ThenInclude(o => o.Orders).ThenInclude(o => o.Currency)
                                     .Include(o => o.User).ThenInclude(o => o.Orders).ThenInclude(o => o.Payments).ThenInclude(o => o.Currency)
                                     .Include(o => o.User).ThenInclude(o => o.Orders).ThenInclude(o => o.Return)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);

            return session;
        }
        private Session GetSessionWithWishlistInclude()
        {
            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.MainImage)
                                     .Include(o => o.User).ThenInclude(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.Localizations)
                                     .Include(o => o.User).ThenInclude(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.Category).ThenInclude(o => o.Localizations)
                                     .Include(o => o.User).ThenInclude(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.BasePricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                     .Include(o => o.User).ThenInclude(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.BasePricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);

            return session;
        }
        private Session GetSessionWithPromocodesInclude()
        {
            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.UsedPromocodes)
                                     .Include(o => o.User).ThenInclude(o => o.Basket)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);
            return session;
        }
        #endregion
    }
}
