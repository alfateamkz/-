﻿using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.ClientModels.Shop;
using Alfateam.Website.API.Models.Core;
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
        public ShopController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        }




        #region Позиции

        [HttpGet, Route("GetProducts")]
        public async Task<IEnumerable<ShopProductClientModel>> GetProducts(int offset, int count = 20)
        {
            //TODO: инклюды везде чекнуть по шопу
            var items = DB.ShopProducts.Include(o => o.Category)
                                       .Include(o => o.MainImage)
                                       .Include(o => o.Modifiers).ThenInclude(o => o.Options).ThenInclude(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                                       .Include(o => o.Modifiers).ThenInclude(o => o.Options).ThenInclude(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                       .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                       .Skip(offset)
                                       .Take(count)
                                       .ToList();
            return ShopProductClientModel.CreateItems(items, LanguageId,CountryId);
        }

        [HttpGet, Route("GetProductsByFilter")]
        public async Task<IEnumerable<ShopProductClientModel>> GetProductsByFilter(ShopProductsFilter filter)
        {
            var products = DB.ShopProducts.Include(o => o.Category)
                                          .Include(o => o.MainImage)
                                          .Include(o => o.Modifiers).ThenInclude(o => o.Options).ThenInclude(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                                          .Include(o => o.Modifiers).ThenInclude(o => o.Options).ThenInclude(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                          .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                          .Where(o => !o.IsDeleted);

            if (filter.CategoryId > 0)
            {
                products = products.Where(o => o.Category.Id == filter.CategoryId);
            }

            if (!string.IsNullOrEmpty(filter.Query))
            {
                products = products.Where(o => o.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase));
            }

            products = products.Skip(filter.Offset).Take(filter.Count);
            return ShopProductClientModel.CreateItems(products.ToList(), LanguageId, CountryId);
        }

        [HttpGet, Route("GetProduct")]
        public async Task<ShopProductClientModel> GetProduct(int id)
        {
            var product = DB.ShopProducts.Include(o => o.Category)
                                         .Include(o => o.MainImage)
                                         .Include(o => o.Images)
                                         .Include(o => o.BasePricing)
                                         .Include(o => o.Modifiers).ThenInclude(o => o.Options).ThenInclude(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                                         .Include(o => o.Modifiers).ThenInclude(o => o.Options).ThenInclude(o => o.Pricing).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                         .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                         .FirstOrDefault(o => o.Id == id);
            return ShopProductClientModel.Create(product,LanguageId,CountryId);
        }





        [HttpGet, Route("GetProductCategories")]
        public async Task<IEnumerable<ShopProductCategoryClientModel>> GetProductCategories()
        {
            var items = DB.ShopProductCategories.Where(o => !o.IsDeleted).ToList();
            return ShopProductCategoryClientModel.CreateItems(items, LanguageId);
        }

        #endregion

        #region Корзина

        [HttpGet, Route("GetBasket")]
        public async Task<RequestResult<ShopOrder>> GetBasket()
        {
            var res = new RequestResult<ShopOrder>();

            //TODO: добить инклюды
            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.Basket).ThenInclude(o => o.Items).ThenInclude(o => o.Item).ThenInclude(o => o.MainImage)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);

            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                res.FillFromRequestResult(checkSessionRes);
            }
            else
            {
                if (session.User.Basket == null)
                {
                    session.User.Basket = new ShopOrder();
                }

                DB.Users.Update(session.User);
                DB.SaveChanges();

                res.Success = true;
                res.Value = session.User.Basket;
            }

            return res;
        }


        [HttpPut, Route("SetBasketCurrency")]
        public async Task<RequestResult> SetBasketCurrency()
        {
            var res = new RequestResult();


            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.Basket).ThenInclude(o => o.Items)
                                   .FirstOrDefault(o => o.SessID == this.UserSessid);

            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                res.FillFromRequestResult(checkSessionRes);
            }
            else if(this.CurrencyId == null)
            {
                res.Code = 400;
                res.Error = "Id валюты за заголовке CurrencyId не должен быть равен null";
            }
            else if (!DB.Currencies.Any(o => o.Id == this.CurrencyId && !o.IsDeleted))
            {
                res.Code = 400;
                res.Error = "По id, указанному в заголовке CurrencyId не найдено валюты";
            }
            else if (session.User.Basket?.Items?.Any(o => !o.IsDeleted) == true)
            {
                res.Code = 403;
                res.Error = "Нельзя изменить валюту, когда в корзине есть товары. Сначала удалите из корзины все позиции";
            }
            else
            {
                if (session.User.Basket == null)
                {
                    session.User.Basket = new ShopOrder();
                }
                session.User.Basket.CurrencyId = this.CurrencyId;

                DB.Users.Update(session.User);
                DB.SaveChanges();
            }

            return res;
        }


        [HttpPut, Route("AddToBasket")]
        public async Task<RequestResult> AddToBasket(ShopOrderItem item)
        {
            var res = new RequestResult();


            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.Basket).ThenInclude(o => o.Items)
                                     .Include(o => o.User).ThenInclude(o => o.Basket).ThenInclude(o => o.Currency)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);

            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                res.FillFromRequestResult(checkSessionRes);
                return res;
            }
            if(session.User.Basket.Currency == null)
            {
                res.Code = 400;
                res.Error = "Невозможно добавить в корзину товар, пока не выбрана валюта";
            }
            else
            {
                try
                {
                    //TODO: проставить стоимость

                    session.User.Basket.Items.Add(item);
                    DB.Users.Update(session.User);
                    DB.SaveChanges();

                    res.Success = true;
                }
                catch (Exception ex)
                {
                    res.Code = 400;
                    res.Error = "Неверно заполнены поля";
                }
            }

          
            return res;
        }

        [HttpPut, Route("EditBasketItem")]
        public async Task<RequestResult> EditBasketItem(ShopOrderItemEditModel model)
        {
            var res = new RequestResult();


            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.Basket).ThenInclude(o => o.Items)
                                   .FirstOrDefault(o => o.SessID == this.UserSessid);

            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                res.FillFromRequestResult(checkSessionRes);
            }
            else
            {
                var item = DB.ShopOrderItems.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
                if (item == null)
                {
                    res.Code = 404;
                    res.Error = "Товар в системе не найден";
                }
                else if (item.ShopOrderId != session.User.Basket?.Id)
                {
                    res.Code = 403;
                    res.Error = "Данная позиция не принадлежит пользователю";
                }
                else
                {
                    item.ItemId = model.ItemId;
                    item.Amount = model.Amount;

                    //TODO: проставить стоимость
                    //TODO: сделать и потестить модификаторы

                    DB.ShopOrderItems.Update(item);
                    DB.SaveChanges();

                    res.Success = true;
                }
            }


            return res;
        }

        [HttpDelete, Route("RemoveBasketItem")]
        public async Task<RequestResult> RemoveBasketItem(int basketItemId)
        {
            var res = new RequestResult();


            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.Basket).ThenInclude(o => o.Items)
                                   .FirstOrDefault(o => o.SessID == this.UserSessid);

            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                res.FillFromRequestResult(checkSessionRes);
            }
            else
            {
                var item = DB.ShopOrderItems.FirstOrDefault(o => o.Id == basketItemId && !o.IsDeleted);
                if (item == null)
                {
                    res.Code = 404;
                    res.Error = "Товар в системе не найден";
                }
                else if (item.ShopOrderId != session.User.Basket?.Id)
                {
                    res.Code = 403;
                    res.Error = "Данная позиция не принадлежит пользователю";
                }
                else
                {
                    //TODO: внимательно проверить удаление !!!
                    session.User.Basket.Items.Remove(item);

                    DB.Users.Update(session.User);
                    DB.SaveChanges();

                    res.Success = true;
                }
            }


            return res;
        }

        #endregion

        #region Избранное

        [HttpGet, Route("GetWishlist")]
        public async Task<RequestResult<ShopWishlist>> GetWishlist()
        {
            var res = new RequestResult<ShopWishlist>();

            //TODO: добить инклюды

            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.Wishlist).ThenInclude(o => o.Items).ThenInclude(o => o.Product).ThenInclude(o => o.MainImage)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);
            if (session == null)
            {
                res.Code = 404;
                res.Error = "Токен в системе не найден";
            }
            else if (session.IsExpired)
            {
                res.Code = 401;
                res.Error = "Вышел срок действия токена";
            }
            else
            {
                res.Success = true;
                res.Value = session.User.Wishlist;
            }

            return res;
        }

        [HttpPut, Route("ToggleWishlistItem")]
        public async Task<RequestResult<bool>> ToggleWishlistItem(int productId)
        {
            var res = new RequestResult<bool>();

            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.Wishlist).ThenInclude(o => o.Items)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);


            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                res.FillFromRequestResult(checkSessionRes);
            }
            else if (!DB.ShopProducts.Any(o => o.Id == productId && !o.IsDeleted))
            {
                res.Code = 404;
                res.Error = "Товарная позиция по данному id не найдена";
            }
            else
            {
                //TODO: CHECK IT

                var found = session.User.Wishlist.Items.FirstOrDefault(o => o.ProductId == productId);
                if (found != null)
                {
                    res.Value = false;
                    session.User.Wishlist.Items.Remove(found);
                }
                else
                {
                    res.Value = true;
                    session.User.Wishlist.Items.Add(new ShopWishlistItem
                    {
                        ProductId = productId
                    });
                }


                DB.Users.Update(session.User);
                DB.SaveChanges();

                res.Success = true;
            }


            return res;
        }

        #endregion

        #region Заказы

        [HttpGet, Route("GetOrders")]
        public async Task<IEnumerable<ShopOrder>> GetOrders()
        {
            var res = new RequestResult<ShopWishlist>();

            //TODO: добить инклюды
            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.Orders).ThenInclude(o => o.Items).ThenInclude(o => o.Item).ThenInclude(o => o.MainImage)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);


            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                return new List<ShopOrder>();
            }

            return session.User.Orders.Where(o => !o.IsDeleted);
        }

        [HttpGet, Route("GetOrder")]
        public async Task<RequestResult<ShopOrder>> GetOrders(int orderId)
        {
            var res = new RequestResult<ShopOrder>();

            //TODO: добить инклюды
            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.Orders).ThenInclude(o => o.Items).ThenInclude(o => o.Item).ThenInclude(o => o.MainImage)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);

            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                res.FillFromRequestResult(checkSessionRes);
            }
            else if (!session.User.Orders.Any(o => o.Id == orderId && !o.IsDeleted))
            {
                res.Code = 404;
                res.Error = "Заказ по данному id в системе не найден";
            }
            else
            {
                res.Value = session.User.Orders.FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);
                res.Success = true;
            }

            return res;
        }

        [HttpPut, Route("CreateOrderFromBasket")]
        public async Task<RequestResult> CreateOrderFromBasket()
        {
            var res = new RequestResult();

            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.Basket).ThenInclude(o => o.Items)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);

            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                res.FillFromRequestResult(checkSessionRes);
            }
            else if(!session.User.Basket.Items.Any(o => !o.IsDeleted))
            {
                res.Code = 400;
                res.Error = "Невозможно создать заказ, т.к. корзина пуста";
            }
            else
            {
                //TODO: внимательно чекнуть
                var basket = session.User.Basket;
                session.User.Orders.Add(basket);
                session.User.Basket = new ShopOrder();

                DB.Users.Update(session.User);
                DB.SaveChanges();

                res.Success = true;
            }

            return res;
        }


        [HttpDelete, Route("RemoveUnpaidOrder")]
        public async Task<RequestResult> RemoveUnpaidOrder(int orderId)
        {
            var res = new RequestResult();

            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.Orders)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);

            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                res.FillFromRequestResult(checkSessionRes);
                return res;
            }

            var order = session.User.Orders.FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);
            if (order == null)
            {
                res.Code = 404;
                res.Error = "Заказ по данному id в системе не найден";
            }
            else if(order.Status != ShopOrderStatus.Unpaid)
            {
                res.Code = 403;
                res.Error = "Невозможно удалить заказ";
            }
            else
            {
                //TODO: внимательно проверить

                order.IsDeleted = true;
                DB.ShopOrders.Update(order);
                DB.SaveChanges();

                res.Success = true;
            }

            return res;
        }


        #endregion



        #region Оплата заказа

        //TODO: пока нету, будем прикручивать юкассу и КЗ эквайринг

        public async Task<RequestResult> CreatePayment(int orderId, MerchantServiceType merchantType)
        {
            var res = new RequestResult();

            //TODO: добить инклюды
            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.Orders).ThenInclude(o => o.Items).ThenInclude(o => o.Item).ThenInclude(o => o.MainImage)
                                     .Include(o => o.User).ThenInclude(o => o.Orders).ThenInclude(o => o.UsedPromocode)
                                     .Include(o => o.User).ThenInclude(o => o.Orders).ThenInclude(o => o.Currency)
                                     .FirstOrDefault(o => o.SessID == this.UserSessid);


            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                res.FillFromRequestResult(checkSessionRes);
                return res;
            }
            
            var order = session.User.Orders.FirstOrDefault(o => o.Id == orderId && !o.IsDeleted);
            if(order == null)
            {
                res.Code = 404;
                res.Error = "Данный заказ в системе не найден";
            }
            else if(order.Status != ShopOrderStatus.Unpaid)
            {
                res.Code = 403;
                res.Error = "Данный заказ уже оплачен";
            }
            else
            {
                var sum = order.SumWithoutDiscount;

                if(order.UsedPromocode != null && order.UsedPromocode.IsCostInRange(new Cost(order.Currency, sum)))
                {
                    if(order.UsedPromocode is PercentPromocode percentPromocode)
                    {
                        order.DiscountByPromocode = percentPromocode.Percent;
                        sum -= sum / 100 * (double)order.DiscountByPromocode;
                    }
                    else if (order.UsedPromocode is PricePromocode pricePromocode)
                    {
                        //TODO: реализовать промокод
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

                DB.ShopOrders.Update(order);
                DB.SaveChanges();

                //TODO: отправка платежа на эквайринг


                res.Success = true;
            }


            return res;
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
    }
}
