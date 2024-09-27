using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.General;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.EDM.API.Controllers
{
    [AuthorizedUser]
    public class RegistrationController : AbsController
    {
        public RegistrationController(ControllerParams @params) : base(@params)
        {
        }

        [HttpPost, Route("Register")]
        public async Task<BusinessDTO> Register(string domain)
        {
            var alfateamID = this.AlfateamSession.User.Guid;

            if (DB.Businesses.Any(o => o.Domain == domain && !o.IsDeleted))
            {
                throw new Exception403("Данный домен уже занят");
            }
            else if(DB.Businesses.Any(o => o.OwnerAlfateamID == alfateamID && !o.IsDeleted))
            {
                throw new Exception403("Для одного Alfateam ID доступен только один домен");
            }

            var business = new Business
            {
                Domain = domain,
                OwnerAlfateamID = alfateamID,
                SubscriptionInfo = new SubscriptionInfo
                {
                    OutgoingDocumentsLeftCount = 10,
                    SubscriptionBefore = DateTime.Now.AddMonths(1),
                }
            };

            DBService.CreateEntity(DB.Businesses, business);
            return (BusinessDTO) new BusinessDTO().CreateDTO(business);
        }
    }
}
