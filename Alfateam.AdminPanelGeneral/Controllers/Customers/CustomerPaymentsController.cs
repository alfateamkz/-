using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.AdminPanelGeneral.API.Models.Filters.Customers;
using Alfateam.Core;
using Alfateam.ID.Models;
using Alfateam.ID.Models.Abstractions;
using Alfateam.ID.Models.DTO.Abstractions;
using Alfateam.ID.Models.DTO.Payments;
using Alfateam.ID.Models.Payments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Customers
{
    [Route("Customers/[controller]")]
    public class CustomerPaymentsController : AbsController
    {
        public CustomerPaymentsController(ControllerParams @params) : base(@params)
        {
        }

        #region Платежи пользователей

        [HttpGet, Route("GetPayments")]
        public async Task<ItemsWithTotalCount<PaymentDTO>> GetPayments(CustomerPaymentsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Payment, PaymentDTO>(GetAvailablePayments(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.User.FIO.Contains(filter.Query)
                              || entity.User.Email.Contains(filter.Query)
                              || entity.User.Phone.Contains(filter.Query)
                              || entity.Comment.Contains(filter.Query);
                }
                if (!string.IsNullOrEmpty(filter.CurrencyCode))
                {
                    condition &= entity.CurrencyCode == filter.CurrencyCode;
                }
                if (filter.SumFrom != null)
                {
                    condition &= entity.Sum >= filter.SumFrom;
                }
                if (filter.SumTo != null)
                {
                    condition &= entity.Sum <= filter.SumTo;
                }
                if (filter.PaidAtFrom != null)
                {
                    condition &= entity.PaidAt >= filter.PaidAtFrom;
                }
                if (filter.PaidAtTo != null)
                {
                    condition &= entity.PaidAt <= filter.PaidAtTo;
                }
                if (filter.Status != null)
                {
                    condition &= entity.Status <= filter.Status;
                }
                if (filter.UserId != null)
                {
                    condition &= entity.UserId == filter.UserId;
                }
                if (!string.IsNullOrEmpty(filter.ProductIdentifier))
                {
                    condition &= entity.ProductIdentifier.Contains(filter.ProductIdentifier);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetPayment")]
        public async Task<PaymentDTO> GetPayment(int id)
        {
            return (PaymentDTO)DBService.TryGetOne(GetAvailablePayments(), id, new PaymentDTO());
        }

        #endregion

        #region Привязанные платежные средства

        [HttpGet, Route("GetUserPaymentWays")]
        public async Task<IEnumerable<BindedPaymentWayDTO>> GetUserPaymentWays(int userId)
        {
            var user = DBService.TryGetOne(GetAvailableUsers(), userId);
            return DBService.GetMany<BindedPaymentWay, BindedPaymentWayDTO>(user.PaymentWays);
        }

        [HttpDelete, Route("DeleteUserPaymentWay")]
        public async Task DeleteUserPaymentWay(int userId, int paymentWayId)
        {
            var user = DBService.TryGetOne(GetAvailableUsers(), userId);
            var paymentWay = DBService.TryGetOne(user.PaymentWays, paymentWayId);

            DBService.SetDB(IdDb);
            DBService.DeleteEntity(IdDb.BindedPaymentWays, paymentWay, false);
        }


        #endregion







        #region Private methods

        private IEnumerable<User> GetAvailableUsers()
        {
            return IdDb.Users.Include(o => o.Payments)
                             .Include(o => o.PaymentWays)
                             .Where(o => !o.IsDeleted);
        }
        private IEnumerable<Payment> GetAvailablePayments()
        {
            return IdDb.Payments.Include(o => o.User)
                                .Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
