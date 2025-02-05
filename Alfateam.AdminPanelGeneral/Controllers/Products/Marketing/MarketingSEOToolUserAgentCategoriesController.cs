using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Core;
using Alfateam.Marketing.API.Models.DTO.General.SEO;
using Alfateam.Marketing.API.Models.DTO.General.SEO.UserAgents;
using Alfateam.Marketing.Models.General.SEO;
using Alfateam.Marketing.Models.General.SEO.UserAgents;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Products.Marketing
{
    [Route("Products/Marketing/[controller]")]
    public class MarketingSEOToolUserAgentCategoriesController : AbsController
    {
        public MarketingSEOToolUserAgentCategoriesController(ControllerParams @params) : base(@params)
        {
        }

        #region Категории юзер агентов

        [HttpGet, Route("GetUserAgentCategories")]
        public async Task<ItemsWithTotalCount<UserAgentCategoryDTO>> GetUserAgentCategories([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<UserAgentCategory, UserAgentCategoryDTO>(GetAvailableUserAgentCategories(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetUserAgentCategory")]
        public async Task<UserAgentCategoryDTO> GetUserAgentCategory(int id)
        {
            return (UserAgentCategoryDTO)DBService.TryGetOne(GetAvailableUserAgentCategories(), id, new UserAgentCategoryDTO());
        }








        [HttpPost, Route("CreateUserAgentCategory")]
        public async Task<UserAgentCategoryDTO> CreateUserAgentCategory(UserAgentCategoryDTO model)
        {
            return (UserAgentCategoryDTO)DBService.TryCreateEntity(MarketingDb.UserAgentCategories, model);
        }

        [HttpPut, Route("UpdateUserAgentCategory")]
        public async Task<UserAgentCategoryDTO> UpdateUserAgentCategory(UserAgentCategoryDTO model)
        {
            var group = DBService.TryGetOne(GetAvailableUserAgentCategories(), model.Id);
            return (UserAgentCategoryDTO)DBService.TryUpdateEntity(MarketingDb.UserAgentCategories, model, group);
        }

        [HttpDelete, Route("DeleteUserAgentCategory")]
        public async Task DeleteUserAgentCategory(int id)
        {
            var group = DBService.TryGetOne(GetAvailableUserAgentCategories(), id);
            DBService.TryDeleteEntity(MarketingDb.UserAgentCategories, group);
        }

        #endregion









        #region Private methods
        private IEnumerable<UserAgentCategory> GetAvailableUserAgentCategories()
        {
            return MarketingDb.UserAgentCategories.Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
