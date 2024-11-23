using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers.Owner
{
    [Route("Owner/[controller]")]
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
