using Alfateam.Core.Enums;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO.General;
using Alfateam.Marketing.Models.General;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.Marketing.API.Controllers.Owner
{
    [Route("Owner/[controller]")]
    public class BusinessCompaniesController : AbsController
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
                entity.BusinessId = (int)this.BusinessId;
                entity.Department = new Department
                {
                    Title = "Головное подразделение",
                    IsRoot = true,
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

            //TODO: деактивация юзеров тоже и все прочее

            DBService.TryDeleteEntity(DB.BusinessCompanies, company);
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
