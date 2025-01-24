using Alfateam.Core;
using Alfateam.TicketSystem.API.Abstractions;
using Alfateam.TicketSystem.API.Models;
using Alfateam.TicketSystem.Models;
using Alfateam.TicketSystem.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.TicketSystem.API.Controllers
{
    public class TicketCategoriesController : AbsAuthorizedController
    {
        public TicketCategoriesController(ControllerParams @params) : base(@params)
        {
        }

        #region Категории тикетов

        [HttpGet, Route("GetCategories")]
        public async Task<ItemsWithTotalCount<TicketCategoryDTO>> GetCategories(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<TicketCategory, TicketCategoryDTO>(GetAvailableCategories(false), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetCategory")]
        public async Task<TicketCategoryDTO> GetCategory(int id)
        {
            return (TicketCategoryDTO)DBService.TryGetOne(GetAvailableCategories(false), id, new TicketCategoryDTO());
        }











        [HttpPost, Route("CreateCategory")]
        public async Task<TicketCategoryDTO> CreateCategory(TicketCategoryDTO model)
        {
            return (TicketCategoryDTO)DBService.TryCreateEntity(DB.TicketCategories, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            });
        }

        [HttpPut, Route("UpdateCategory")]
        public async Task<TicketCategoryDTO> UpdateCategory(TicketCategoryDTO model)
        {
            var item = GetAvailableCategories(false).FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (TicketCategoryDTO)DBService.TryUpdateEntity(DB.TicketCategories, model, item);
        }

        [HttpDelete, Route("DeleteCategory")]
        public async Task DeleteCategory(int id)
        {
            var item = GetAvailableCategories(false).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.TicketCategories, item);
        }


        #endregion









        #region Private methods
        private IEnumerable<TicketCategory> GetAvailableCategories(bool topLevelOnly)
        {
            if (topLevelOnly)
            {
                return DB.TicketCategories.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId && o.TicketCategoryId == null);
            }
            return DB.TicketCategories.Include(o => o.Subcategories)
                                      .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
