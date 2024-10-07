using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.API.Models.DTO.General.Subjects;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General.Subjects;
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

        [HttpGet, Route("GetMyAvailableSubjects")]
        public async Task<IEnumerable<EDMSubjectDTO>> GetMyAvailableSubjects()
        {
            var alfateamIDUser = this.AlfateamSession.User;

            var availableSubjects = new List<EDMSubject>();

            foreach(var subject in DB.EDMSubjects)
            {
                if(subject is Company company)
                {
                    var users = DB.Users.Where(o => o.CompanyId == company.Id && !o.IsDeleted);
                    if(users.Any(a => a.AlfateamID == alfateamIDUser.Guid && !a.IsDeleted && !a.IsBlocked))
                    {
                        availableSubjects.Add(subject);
                    }
                }
                else if(subject is Individual individual)
                {
                    var user = DB.Users.FirstOrDefault(o => o.IndividualId == individual.Id && !o.IsDeleted && o.AlfateamID == alfateamIDUser.Guid);
                    if (user != null)
                    {
                        availableSubjects.Add(subject);
                    }
                }
            }

            return new EDMSubjectDTO().CreateDTOs(availableSubjects).Cast<EDMSubjectDTO>();
        }
    }
}
