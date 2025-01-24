using Alfateam.TicketSystem.Models.Enums;
using Alfateam.TicketSystem.API.Abstractions;
using Alfateam.TicketSystem.API.Filters;
using Alfateam.TicketSystem.API.Models;
using Alfateam.TicketSystem.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.TicketSystem.API.Controllers.Owner
{
    [Route("Owner/[controller]")]
    [RequiredRole(UserRole.Owner)]
    public class BusinessController : AbsAuthorizedController
    {
        public BusinessController(ControllerParams @params) : base(@params)
        {
        }


        [HttpGet, Route("GetBusiness")]
        public async Task<BusinessDTO> GetBusiness()
        {
            var business = DB.Businesses.Include(o => o.SubscriptionInfo)
                                        .FirstOrDefault(o => o.Id == this.BusinessId);
            return (BusinessDTO)new BusinessDTO().CreateDTO(business);
        }




        [HttpPut, Route("PaySubscription")]
        public async Task PaySubscription()
        {
            //TODO: Sales - PaySubscription
            throw new NotImplementedException();
        }
    }
}
