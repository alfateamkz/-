using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General.Subjects;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.Models.General;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Sales.API.Controllers
{
    public class CommonController : AbsController
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
