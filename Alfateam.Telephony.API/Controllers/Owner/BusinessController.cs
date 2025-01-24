using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.API.Abstractions;
using Alfateam.Telephony.API.Filters;
using Alfateam.Telephony.API.Models;
using Alfateam.Telephony.API.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Telephony.API.Controllers.Owner
{

    [Route("Owner/[controller]")]
    [RequiredRole(UserRole.Owner)]
    public class BusinessController : AbsController
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
