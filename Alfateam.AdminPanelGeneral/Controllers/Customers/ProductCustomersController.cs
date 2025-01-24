using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Enums;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.AdminPanelGeneral.API.Models.Customers;
using Alfateam.AdminPanelGeneral.API.Models.Filters.Customers;
using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.ID.Models;
using Alfateam.ID.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Customers
{
    public class ProductCustomersController : AbsController
    {
        public ProductCustomersController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetCustomerProducts")]
        public async Task<CustomerWithProducts> GetCustomerProducts(int userId)
        {
            var user = DBService.TryGetOne(GetAvailableUsers(), userId);
            var model = new CustomerWithProducts
            {
                User = (UserDTO)new UserDTO().CreateDTO(user)
            };

            AddSalesProductIfHas(model, user.Guid);
            AddMarketingProductIfHas(model, user.Guid);
            AddEDMProductIfHas(model, user.Guid);
            AddTelephonyProductIfHas(model, user.Guid);
            AddMessengerProductIfHas(model, user.Guid);

            return model;
        }

        [HttpGet, Route("GetProductCustomers")]
        public async Task<ItemsWithTotalCount<ProductCustomer>> GetProductCustomers(ProductCustomersSearchFilter filter)
        {
            IEnumerable<ProductCustomer> customers = new List<ProductCustomer>();
            switch (filter.ProductName)
            {
                case PublicProductName.SalesCRM:
                    customers = GetSalesCRMProductCustomers();
                    break;
                case PublicProductName.MarketingCRM:
                    customers = GetMarketingCRMProductCustomers();
                    break;
                case PublicProductName.Telephony:
                    customers = GetTelephonyProductCustomers();
                    break;
                case PublicProductName.Messenger:
                    customers = GetMessengerProductCustomers();
                    break;
                case PublicProductName.EDM:
                    customers = GetEDMProductCustomers();
                    break;
                default:
                    throw new Exception400("Данное название продукта не поддерживается");
            }

            if (!string.IsNullOrEmpty(filter.Query))
            {
                customers = customers.Where(o => o.User.FIO.Contains(filter.Query, StringComparison.OrdinalIgnoreCase));
            }

            return new ItemsWithTotalCount<ProductCustomer>
            { 
                Items = customers.Skip(filter.Offset).Take(filter.Count).ToList(),
                TotalCount = customers.Count()
            };
        }








        #region Private get methods

        private IEnumerable<User> GetAvailableUsers()
        {
            return IdDb.Users.Where(o => !o.IsDeleted);
        }
        private UserDTO GetUserDTOByAlfateamId(string alfateamId)
        {
            var user = GetAvailableUsers().FirstOrDefault(o => o.Guid == alfateamId);
            if (user == null)
            {
                return null;
            }
            return (UserDTO)new UserDTO().CreateDTO(user);
        }

        #endregion

        #region Private GetCustomerProducts methods

        private void AddSalesProductIfHas(CustomerWithProducts customer, string userAlfateamId)
        {
            var salesDomain = SalesDb.Businesses.FirstOrDefault(o => o.OwnerAlfateamID == userAlfateamId);
            if (salesDomain != null)
            {
                customer.Products.Add(new CustomerProduct
                {
                    ProductName = PublicProductName.SalesCRM,
                    Domain = salesDomain.Domain,
                    RegisteredAt = salesDomain.CreatedAt,
                    SubscriptionBefore = salesDomain.SubscriptionInfo.SubscriptionBefore,
                });
            }
        }
        private void AddMarketingProductIfHas(CustomerWithProducts customer, string userAlfateamId)
        {
            var marketingDomain = MarketingDb.Businesses.FirstOrDefault(o => o.OwnerAlfateamID == userAlfateamId);
            if (marketingDomain != null)
            {
                customer.Products.Add(new CustomerProduct
                {
                    ProductName = PublicProductName.MarketingCRM,
                    Domain = marketingDomain.Domain,
                    RegisteredAt = marketingDomain.CreatedAt,
                    SubscriptionBefore = marketingDomain.SubscriptionInfo.SubscriptionBefore,
                });
            }
        }
        private void AddEDMProductIfHas(CustomerWithProducts customer, string userAlfateamId)
        {
            var edmDomain = EDMDb.Businesses.FirstOrDefault(o => o.OwnerAlfateamID == userAlfateamId);
            if (edmDomain != null)
            {
                customer.Products.Add(new CustomerProduct
                {
                    ProductName = PublicProductName.EDM,
                    Domain = edmDomain.Domain,
                    RegisteredAt = edmDomain.CreatedAt,
                    SubscriptionBefore = edmDomain.SubscriptionInfo.SubscriptionBefore,
                });
            }
        }
        private void AddTelephonyProductIfHas(CustomerWithProducts customer, string userAlfateamId)
        {
            var telephonyDomain = TelephonyDb.Businesses.FirstOrDefault(o => o.OwnerAlfateamID == userAlfateamId);
            if (telephonyDomain != null)
            {
                customer.Products.Add(new CustomerProduct
                {
                    ProductName = PublicProductName.EDM,
                    Domain = telephonyDomain.Domain,
                    RegisteredAt = telephonyDomain.CreatedAt,
                    SubscriptionBefore = telephonyDomain.SubscriptionInfo.SubscriptionBefore,
                });
            }
        }
        private void AddMessengerProductIfHas(CustomerWithProducts customer, string userAlfateamId)
        {
            var messengerDomain = MessengerDb.Businesses.FirstOrDefault(o => o.OwnerAlfateamID == userAlfateamId);
            if (messengerDomain != null)
            {
                customer.Products.Add(new CustomerProduct
                {
                    ProductName = PublicProductName.EDM,
                    Domain = messengerDomain.Domain,
                    RegisteredAt = messengerDomain.CreatedAt,
                    SubscriptionBefore = messengerDomain.SubscriptionInfo.SubscriptionBefore,
                });
            }
        }


        #endregion

        #region Private GetProductCustomers methods
        private IEnumerable<ProductCustomer> GetSalesCRMProductCustomers()
        {
            var customers = new List<ProductCustomer>();

            foreach(var product in SalesDb.Businesses.Include(o => o.SubscriptionInfo))
            {
                customers.Add(new ProductCustomer()
                {
                    Domain = product.Domain,
                    RegisteredAt = product.CreatedAt,
                    SubscriptionBefore = product.SubscriptionInfo.SubscriptionBefore,
                    User = GetUserDTOByAlfateamId(product.OwnerAlfateamID)
                });
            }

            return customers;
        }
        private IEnumerable<ProductCustomer> GetMarketingCRMProductCustomers()
        {
            var customers = new List<ProductCustomer>();

            foreach (var product in MarketingDb.Businesses.Include(o => o.SubscriptionInfo))
            {
                customers.Add(new ProductCustomer()
                {
                    Domain = product.Domain,
                    RegisteredAt = product.CreatedAt,
                    SubscriptionBefore = product.SubscriptionInfo.SubscriptionBefore,
                    User = GetUserDTOByAlfateamId(product.OwnerAlfateamID)
                });
            }

            return customers;
        }
        private IEnumerable<ProductCustomer> GetTelephonyProductCustomers()
        {
            var customers = new List<ProductCustomer>();

            foreach (var product in TelephonyDb.Businesses.Include(o => o.SubscriptionInfo))
            {
                customers.Add(new ProductCustomer()
                {
                    Domain = product.Domain,
                    RegisteredAt = product.CreatedAt,
                    SubscriptionBefore = product.SubscriptionInfo.SubscriptionBefore,
                    User = GetUserDTOByAlfateamId(product.OwnerAlfateamID)
                });
            }

            return customers;
        }
        private IEnumerable<ProductCustomer> GetMessengerProductCustomers()
        {
            var customers = new List<ProductCustomer>();

            foreach (var product in MessengerDb.Businesses.Include(o => o.SubscriptionInfo))
            {
                customers.Add(new ProductCustomer()
                {
                    Domain = product.Domain,
                    RegisteredAt = product.CreatedAt,
                    SubscriptionBefore = product.SubscriptionInfo.SubscriptionBefore,
                    User = GetUserDTOByAlfateamId(product.OwnerAlfateamID)
                });
            }

            return customers;
        }
        private IEnumerable<ProductCustomer> GetEDMProductCustomers()
        {
            var customers = new List<ProductCustomer>();

            foreach (var product in EDMDb.Businesses.Include(o => o.SubscriptionInfo))
            {
                customers.Add(new ProductCustomer()
                {
                    Domain = product.Domain,
                    RegisteredAt = product.CreatedAt,
                    SubscriptionBefore = product.SubscriptionInfo.SubscriptionBefore,
                    User = GetUserDTOByAlfateamId(product.OwnerAlfateamID)
                });
            }

            return customers;
        }

        #endregion

    }
}
