using Alfateam.Core.Enums;
using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.EDM.API.Controllers.Director
{

    [RequiredRole(UserRole.Owner)]
    public class CompaniesController : AbsAuthorizedController
    {
        public CompaniesController(ControllerParams @params) : base(@params)
        {
        }


        [HttpGet, Route("GetCompanies")]
        public async Task<IEnumerable<CompanyDTO>> GetCompanies()
        {
            var companies = DB.Companies.Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
            return new CompanyDTO().CreateDTOs(companies).Cast<CompanyDTO>();
        }

        [HttpGet, Route("GetCompany")]
        public async Task<CompanyDTO> GetCompany(int id)
        {
            var companies = DB.Companies.Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
            return (CompanyDTO)DBService.TryGetOne(companies, id, new CompanyDTO());
        }

        [HttpPost, Route("CreateCompany")]
        public async Task<CompanyDTO> CreateCompany(CompanyDTO model)
        {
            return (CompanyDTO)DBService.TryCreateEntity(DB.Companies, model, (entity) =>
            {
                entity.BusinessId = (int)this.BusinessId;
                entity.Department = new EDM.Models.General.Department
                {
                    Title = "Головное подразделение",
                    IsRoot = true,
                };
            });
        }



        [HttpPut, Route("UpdateCompany")]
        public async Task<CompanyDTO> UpdateCompany(CompanyDTO model)
        {
            var companies = DB.Companies.Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
            var company = DBService.TryGetOne(companies, model.Id);

            return (CompanyDTO)DBService.TryUpdateEntity(DB.Companies, model, company);
        }

        [HttpPut, Route("UploadCompanyLogo")]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем logoFile")]
        public async Task<string> UploadCompanyLogo(int companyId)
        {
            const string formFilename = "logoFile";

            var companies = DB.Companies.Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
            var company = DBService.TryGetOne(companies, companyId);

            company.LogoPath = await FilesService.TryUploadFile(formFilename, FileType.Image);
            DBService.UpdateEntity(DB.Companies, company);

            return company.LogoPath;
        }




        [HttpDelete, Route("DeleteCompany")]
        public async Task DeleteCompany(int id)
        {
            var companies = DB.Companies.Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
            var company = DBService.TryGetOne(companies, id);


            var allDepartments = DB.Departments.Include(o => o.Documents)
                                               .Where(o => o.CompanyId == id && !o.IsDeleted);
            if (allDepartments.SelectMany(o => o.Documents).Any(o => !o.IsDeleted))
            {
                throw new Exception403("Невозможно удалить компанию, т.к. она уже участвовала в документообороте");
            }

            DBService.TryDeleteEntity(DB.Companies, company); 
        }
    }
}
