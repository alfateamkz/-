using Alfateam.ID.Abstractions;
using Alfateam.ID.API.Abstractions.DTO;
using Alfateam.ID.API.Filters;
using Alfateam.ID.API.Models;
using Alfateam.ID.Models.DTO.Payments;
using Alfateam.ID.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Alfateam.ID.API.Controllers
{
    [AuthorizedUser(mustBeVerified: true)]
    public class PaymentsController : AbsController
    {
        public PaymentsController(ControllerParams @params) : base(@params)
        {
        }


        [HttpGet, Route("GetPayments")]
        public async Task<IEnumerable<PaymentDTO>> GetPayments()
        {
            var payments = DB.Payments.Where(o => o.UserId == this.Session.UserId && !o.IsDeleted);
            return new PaymentDTO().CreateDTOs(payments).Cast<PaymentDTO>();
        }


        [HttpPost, Route("PayService")]
        public async Task PayService(string currencyCode, decimal sum)
        {
            throw new NotImplementedException("Пока еще не сделал эндпоинт");
        }




        [HttpGet, Route("GetBindedPaymentWays")]
        public async Task<IEnumerable<BindedPaymentWayDTO>> GetBindedPaymentWays()
        {
            var paymentWays = DB.BindedPaymentWays.Where(o => o.Id == this.Session.UserId && !o.IsDeleted);
            return new BindedPaymentWayDTO().CreateDTOs(paymentWays).Cast<BindedPaymentWayDTO>();
        }

        [HttpDelete, Route("RemoveBindedPaymentWay")]
        public async Task RemoveBindedPaymentWay(int id)
        {
            var paymentWays = DB.BindedPaymentWays.Where(o => o.Id == this.Session.UserId && !o.IsDeleted);
            var bindedPaymentWay = DBService.TryGetOne(paymentWays, id);

            DBService.DeleteEntity(DB.BindedPaymentWays, bindedPaymentWay, false);
        }
    }
}
