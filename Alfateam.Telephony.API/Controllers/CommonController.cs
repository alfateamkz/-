using Alfateam.Telephony.API.Abstractions;
using Alfateam.Telephony.API.Models;
using Alfateam.Telephony.API.Models.DTO.General;
using Alfateam.Telephony.Models.General;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Telephony.API.Controllers
{
    public class CommonController : AbsAuthorizedController
    {
        public CommonController(ControllerParams @params) : base(@params)
        {
        }


        [HttpGet, Route("GetMyUser")]
        public async Task<UserDTO> GetMyUser()
        {
            return new UserDTO().CreateDTO(this.AuthorizedUser, this.AlfateamSession.User);
        }

        [HttpGet, Route("GetMyAvailableCompanies")]
        public async Task<IEnumerable<BusinessCompanyDTO>> GetMyAvailableCompanies()
        {
            var alfateamIDUser = this.AlfateamSession.User;

            var availableCompanies = new List<BusinessCompany>();

            foreach (var company in DB.BusinessCompanies)
            {
                var users = DB.Users.Where(o => o.BusinessCompanyId == company.Id && !o.IsDeleted);
                if (users.Any(a => a.AlfateamID == alfateamIDUser.Guid && !a.IsDeleted && !a.IsBlocked))
                {
                    availableCompanies.Add(company);
                }
            }

            return new BusinessCompanyDTO().CreateDTOs(availableCompanies).Cast<BusinessCompanyDTO>();
        }
    }
}
