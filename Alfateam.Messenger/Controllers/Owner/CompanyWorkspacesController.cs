using Alfateam.Core.Enums;
using Alfateam.Core.Exceptions;
using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models.DTO.General;
using Alfateam.Messenger.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.Messenger.API.Controllers.Owner
{
    public class CompanyWorkspacesController : AbsController
    {
        public CompanyWorkspacesController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetWorkspaces")]
        public async Task<IEnumerable<CompanyWorkSpaceDTO>> GetWorkspaces()
        {
            var workspaces = DB.CompanyWorkSpaces.Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
            return new CompanyWorkSpaceDTO().CreateDTOs(workspaces).Cast<CompanyWorkSpaceDTO>();
        }

        [HttpGet, Route("GetWorkspace")]
        public async Task<CompanyWorkSpaceDTO> GetWorkspace(int id)
        {
            return (CompanyWorkSpaceDTO)new CompanyWorkSpaceDTO().CreateDTO(TryGetWorkspace(id));
        }

        [HttpPost, Route("CreateWorkspace")]
        public async Task<CompanyWorkSpaceDTO> CreateWorkspace(CompanyWorkSpaceDTO model)
        {
            return (CompanyWorkSpaceDTO)DBService.TryCreateEntity(DB.CompanyWorkSpaces, model, (entity) =>
            {
                entity.BusinessId = (int)this.BusinessId;
                entity.Department = new Department
                {
                    Title = "Головное подразделение",
                    IsRoot = true,
                };
            });
        }



        [HttpPut, Route("UpdateWorkspace")]
        public async Task<CompanyWorkSpaceDTO> UpdateWorkspace(CompanyWorkSpaceDTO model)
        {
            var workspace = TryGetWorkspace(model.Id);
            return (CompanyWorkSpaceDTO)DBService.TryUpdateEntity(DB.CompanyWorkSpaces, model, workspace);
        }

        [HttpPut, Route("UploadLogo")]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем logoFile")]
        public async Task<string> UploadLogo(int companyId)
        {
            const string formFilename = "logoFile";

            var workspace = TryGetWorkspace(companyId);

            workspace.LogoPath = FilesService.TryUploadFile(formFilename, FileType.Image);
            DBService.UpdateEntity(DB.CompanyWorkSpaces, workspace);

            return workspace.LogoPath;
        }




        [HttpDelete, Route("DeleteWorkspace")]
        public async Task DeleteWorkspace(int id)
        {
            var workspace = TryGetWorkspace(id);

            //TODO: деактивация юзеров тоже

            DBService.TryDeleteEntity(DB.CompanyWorkSpaces, workspace);
        }







        #region Private methods

        private CompanyWorkSpace TryGetWorkspace(int workspaceId)
        {
            var workspaces = DB.CompanyWorkSpaces.Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
            return DBService.TryGetOne(workspaces, workspaceId);
        }


        #endregion
    }
}
