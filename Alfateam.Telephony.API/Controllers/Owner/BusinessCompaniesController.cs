using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.API.Abstractions;
using Alfateam.Telephony.API.Filters;
using Alfateam.Telephony.API.Models;
using Alfateam.Telephony.API.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Alfateam.Telephony.Models.General;
using Swashbuckle.AspNetCore.Annotations;
using Alfateam.Core.Enums;

namespace Alfateam.Telephony.API.Controllers.Owner
{
    [Route("Owner/[controller]")]
    [RequiredRole(UserRole.Owner)]
    public class BusinessCompaniesController : AbsAuthorizedController
    {
        public BusinessCompaniesController(ControllerParams @params) : base(@params)
        {
        }

        #region CRUD операции с компаниями

        [HttpGet, Route("GetCompanies")]
        public async Task<IEnumerable<BusinessCompanyDTO>> GetCompanies()
        {
            return new BusinessCompanyDTO().CreateDTOs(GetAvailableCompanies()).Cast<BusinessCompanyDTO>();
        }

        [HttpGet, Route("GetCompany")]
        public async Task<BusinessCompanyDTO> GetCompany(int id)
        {
            return (BusinessCompanyDTO)new BusinessCompanyDTO().CreateDTO(TryGetCompany(id));
        }

        [HttpPost, Route("CreateCompany")]
        public async Task<BusinessCompanyDTO> CreateCompany(BusinessCompanyDTO model)
        {
            return (BusinessCompanyDTO)DBService.TryCreateEntity(DB.BusinessCompanies, model, (entity) =>
            {
                var department = new Department
                {
                    Title = "Головное подразделение",
                    IsRoot = true,
                };

                entity.Users = new List<User>
                {
                    new User
                    {
                        Role = UserRole.Owner,
                        Permissions = new Telephony.Models.General.Security.UserPermissions(),
                        Position = "Генерал",
                        AlfateamID = this.AlfateamSession.User.Guid,
                        Department = department,
                    }
                };
                entity.BusinessId = (int)this.BusinessId;
                entity.Department = department;
            });
        }



        [HttpPut, Route("UpdateCompany")]
        public async Task<BusinessCompanyDTO> UpdateCompany(BusinessCompanyDTO model)
        {
            var company = TryGetCompany(model.Id);
            return (BusinessCompanyDTO)DBService.TryUpdateEntity(DB.BusinessCompanies, model, company);
        }

        [HttpPut, Route("UploadLogo")]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем logoFile")]
        public async Task<string> UploadLogo(int companyId)
        {
            const string formFilename = "logoFile";

            var company = TryGetCompany(companyId);

            company.LogoPath = FilesService.TryUploadFile(formFilename, FileType.Image);
            DBService.UpdateEntity(DB.BusinessCompanies, company);

            return company.LogoPath;
        }




        [HttpDelete, Route("DeleteCompany")]
        public async Task DeleteCompany(int id)
        {
            var company = TryGetCompany(id);
            var companyUsers = DB.Users.Where(o => o.BusinessCompanyId == company.Id);

            foreach (var user in companyUsers)
            {
                user.IsDeleted = true;
            }

            DBService.TryDeleteEntity(DB.BusinessCompanies, company);
            DBService.UpdateEntities(DB.Users, companyUsers);
        }

        #endregion










        #region Private methods
        private IEnumerable<BusinessCompany> GetAvailableCompanies()
        {
            return DB.BusinessCompanies.Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
        }
        private BusinessCompany TryGetCompany(int companyId)
        {
            return DBService.TryGetOne(GetAvailableCompanies(), companyId);
        }




        #endregion

    }
}
