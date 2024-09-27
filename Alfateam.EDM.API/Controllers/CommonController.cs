using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Controllers
{

    [AuthorizedUser]
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
        public async Task<IEnumerable<CompanyDTO>> GetMyAvailableCompanies()
        {
            var alfateamIDUser = this.AlfateamSession.User;

            var companies = DB.Companies.Include(o => o.Users)
                                        .Where(o => !o.IsDeleted)
                                        .AsEnumerable()
                                        .Where(o => o.Users.Any(a => a.AlfateamID == alfateamIDUser.Guid && !a.IsDeleted && !a.IsBlocked));

            return new CompanyDTO().CreateDTOs(companies).Cast<CompanyDTO>();
        }
    }
}
