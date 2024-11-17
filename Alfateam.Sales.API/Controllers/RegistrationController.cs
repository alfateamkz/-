using Alfateam.Core.Exceptions;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.Integrations.API;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Sales.API.Controllers
{
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
            else if (DB.Businesses.Any(o => o.OwnerAlfateamID == alfateamID && !o.IsDeleted))
            {
                throw new Exception403("Для одного Alfateam ID доступен только один домен");
            }

            var business = new Business
            {
                Domain = domain,
                OwnerAlfateamID = alfateamID,
                SubscriptionInfo = new SubscriptionInfo
                {
                    SubscriptionBefore = DateTime.Now.AddDays(14),
                },
                APIKeys = new List<AlfateamAPIKey>
                {
                    new AlfateamAPIKey
                    {
                        Title = "Скрытый ключ для сайта",
                        IsDefault = true,
                    }
                }
            };

            DBService.CreateEntity(DB.Businesses, business);
            return (BusinessDTO)new BusinessDTO().CreateDTO(business);
        }
    }
}
