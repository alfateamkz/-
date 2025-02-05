using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Core;
using Alfateam.Marketing.API.Models.DTO.General.SEO.UserAgents;
using Alfateam.Marketing.Models.General.SEO.UserAgents;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Products.Marketing
{
    [Route("Products/Marketing/[controller]")]
    public class MarketingSEOToolUserAgentTemplatesController : AbsController
    {
        public MarketingSEOToolUserAgentTemplatesController(ControllerParams @params) : base(@params)
        {
        }

        #region Шаблоны юзер агентов

        [HttpGet, Route("GetUserAgentTemplates")]
        public async Task<ItemsWithTotalCount<UserAgentTemplateDTO>> GetUserAgentTemplates([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<UserAgentTemplate, UserAgentTemplateDTO>(GetAvailableUserAgentTemplates(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetUserAgentTemplate")]
        public async Task<UserAgentTemplateDTO> GetUserAgentTemplate(int id)
        {
            return (UserAgentTemplateDTO)DBService.TryGetOne(GetAvailableUserAgentTemplates(), id, new UserAgentTemplateDTO());
        }








        [HttpPost, Route("CreateUserAgentTemplate")]
        public async Task<UserAgentTemplateDTO> CreateUserAgentTemplate(UserAgentTemplateDTO model)
        {
            return (UserAgentTemplateDTO)DBService.TryCreateEntity(MarketingDb.UserAgentTemplates, model);
        }

        [HttpPut, Route("UpdateUserAgentTemplate")]
        public async Task<UserAgentTemplateDTO> UpdateUserAgentTemplate(UserAgentTemplateDTO model)
        {
            var group = DBService.TryGetOne(GetAvailableUserAgentTemplates(), model.Id);
            return (UserAgentTemplateDTO)DBService.TryUpdateEntity(MarketingDb.UserAgentTemplates, model, group);
        }

        [HttpDelete, Route("DeleteUserAgentTemplate")]
        public async Task DeleteUserAgentTemplate(int id)
        {
            var group = DBService.TryGetOne(GetAvailableUserAgentTemplates(), id);
            DBService.TryDeleteEntity(MarketingDb.UserAgentTemplates, group);
        }

        #endregion









        #region Private methods
        private IEnumerable<UserAgentTemplate> GetAvailableUserAgentTemplates()
        {
            return MarketingDb.UserAgentTemplates.Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
