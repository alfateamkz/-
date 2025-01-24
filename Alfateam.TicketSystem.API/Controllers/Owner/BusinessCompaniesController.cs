using Alfateam.Core.Enums;
using Alfateam.TicketSystem.Models.Enums;
using Alfateam.TicketSystem.API.Abstractions;
using Alfateam.TicketSystem.API.Filters;
using Alfateam.TicketSystem.API.Models;
using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.DTO.General;
using Alfateam.TicketSystem.Models.DTO.Tickets.DistributionStrategies;
using Alfateam.TicketSystem.Models.General;
using Alfateam.TicketSystem.Models.General.WorkingDays;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.TicketSystem.API.Controllers.Owner
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
                var middlePriority = new TicketSystem.Models.TicketPriority("Средний", 3);
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
                        Permissions = new TicketSystem.Models.General.Security.UserPermissions(),
                        Position = "Генерал",
                        AlfateamID = this.AlfateamSession.User.Guid,
                        Department = department,            
                    }
                };
                entity.BusinessId = (int)this.BusinessId;
                entity.Department = department;
                entity.TicketPriorities = new List<TicketSystem.Models.TicketPriority>
                {
                    new TicketSystem.Models.TicketPriority("Очень низкий", 1),
                    new TicketSystem.Models.TicketPriority("Низкий", 2),
                    middlePriority,
                    new TicketSystem.Models.TicketPriority("Высокий", 4),
                    new TicketSystem.Models.TicketPriority("Очень высокий", 5),
                };
                entity.TicketCategories = new List<TicketSystem.Models.TicketCategory>
                {
                    new TicketSystem.Models.TicketCategory("Технический вопрос"),
                    new TicketSystem.Models.TicketCategory("По продукту"),
                    new TicketSystem.Models.TicketCategory("Другое"),
                };
                entity.TicketSettings = new BusinessCompanyTicketSettings
                {
                    DefaultPriority = middlePriority,
                    MakeTicketClosedAfterHours = 24,
                    TicketDistributionStrategy = new RandomTicketDistributionStrategy()
                };
                entity.WorkingDays = new CompanyWorkingDays
                {
                    Monday = new CompanyWorkingDay(new TimeSpan(9, 0, 0), new TimeSpan(18, 0, 0)),
                    Tuesday = new CompanyWorkingDay(new TimeSpan(9, 0, 0), new TimeSpan(18, 0, 0)),
                    Wednesday = new CompanyWorkingDay(new TimeSpan(9, 0, 0), new TimeSpan(18, 0, 0)),
                    Thursday = new CompanyWorkingDay(new TimeSpan(9, 0, 0), new TimeSpan(18, 0, 0)),
                    Friday = new CompanyWorkingDay(new TimeSpan(9, 0, 0), new TimeSpan(18, 0, 0)),
                    Saturday = new CompanyWorkingDay(new TimeSpan(9, 0, 0), new TimeSpan(13, 0, 0)),
                    Sunday = new CompanyWorkingDay(false)
                };
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
