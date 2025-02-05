using Alfateam.Administration.Models.Blogs;
using Alfateam.Administration.Models.DTO.Blogs;
using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Filters;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Blogs
{
    [Route("Blogs/[controller]")]
    [BlogsAccessFilter]
    public class BlogLanguageZonesController : AbsBlogController
    {
        public BlogLanguageZonesController(ControllerParams @params) : base(@params)
        {
        }

        #region Языковые зоны

        [HttpGet, Route("GetLanguageZones")]
        public async Task<ItemsWithTotalCount<BlogLanguageZoneDTO>> GetLanguageZones(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<BlogLanguageZone, BlogLanguageZoneDTO>(GetAvailableLanguageZones(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Language.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetLanguageZone")]
        public async Task<BlogLanguageZoneDTO> GetLanguageZone(int id)
        {
            return (BlogLanguageZoneDTO)DBService.TryGetOne(GetAvailableLanguageZones(), id, new BlogLanguageZoneDTO());
        }





        [HttpPost, Route("CreateLanguageZone")]
        public async Task<BlogLanguageZoneDTO> CreateLanguageZone(BlogLanguageZoneDTO model)
        {
            return (BlogLanguageZoneDTO)DBService.TryCreateEntity(AdmininstrationDb.BlogLanguageZones, model, callback: (entity) =>
            {
                entity.BlogId = (int)this.BlogId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление языковой зоны блога", $"Добавлена языковая зона блога");
            });
        }


        [HttpPut, Route("UpdateLanguageZone")]
        public async Task<BlogLanguageZoneDTO> UpdateLanguageZone(BlogLanguageZoneDTO model)
        {
            var item = GetAvailableLanguageZones().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (BlogLanguageZoneDTO)DBService.TryUpdateEntity(AdmininstrationDb.BlogLanguageZones, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование языковой зоны блога", $"Отредактирована языковая зона блога с id={item.Id}");
            });
        }


        [HttpDelete, Route("DeleteLanguageZone")]
        public async Task DeleteLanguageZone(int id)
        {
            var item = GetAvailableLanguageZones().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(AdmininstrationDb.BlogLanguageZones, item);

            this.AddHistoryAction("Удаление языковой зоны блога", $"Удалена языковая зона блога {item.Language.Code} с id={id}");
        }

        #endregion







        #region Private methods
        private IEnumerable<BlogLanguageZone> GetAvailableLanguageZones()
        {
            return AdmininstrationDb.BlogLanguageZones.Include(o => o.Language)
                                                      .Where(o => !o.IsDeleted && o.BlogId == this.BlogId);
        }

        #endregion
    }
}
