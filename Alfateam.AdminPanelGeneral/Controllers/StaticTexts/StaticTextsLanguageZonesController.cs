using Alfateam.Administration.Models.Blogs;
using Alfateam.Administration.Models.DTO.Blogs;
using Alfateam.Administration.Models.DTO.StaticTextsConstructor;
using Alfateam.Administration.Models.StaticTextsConstructor;
using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.AdminPanelGeneral.API.Controllers.StaticTexts
{
    [Route("StaticTexts/[controller]")]
    public class StaticTextsLanguageZonesController : AbsStaticTextsController
    {
        public StaticTextsLanguageZonesController(ControllerParams @params) : base(@params)
        {
        }

        #region Языковые зоны

        [HttpGet, Route("GetLanguageZones")]
        public async Task<ItemsWithTotalCount<TextsSetLanguageZoneDTO>> GetLanguageZones(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<TextsSetLanguageZone, TextsSetLanguageZoneDTO>(GetAvailableLanguageZones(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Language.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetLanguageZone")]
        public async Task<TextsSetLanguageZoneDTO> GetLanguageZone(int id)
        {
            return (TextsSetLanguageZoneDTO)DBService.TryGetOne(GetAvailableLanguageZones(), id, new TextsSetLanguageZoneDTO());
        }





        [HttpPost, Route("CreateLanguageZone")]
        public async Task<TextsSetLanguageZoneDTO> CreateLanguageZone(TextsSetLanguageZoneDTO model)
        {
            return (TextsSetLanguageZoneDTO)DBService.TryCreateEntity(AdmininstrationDb.TextsSetLanguageZones, model, callback: (entity) =>
            {
                entity.TextsSetId = (int)this.TextsSetId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление языковой зоны статических текстов", $"Добавлена языковая зона статических текстов");
            });
        }


        [HttpPut, Route("UpdateLanguageZone")]
        public async Task<TextsSetLanguageZoneDTO> UpdateLanguageZone(TextsSetLanguageZoneDTO model)
        {
            var item = GetAvailableLanguageZones().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (TextsSetLanguageZoneDTO)DBService.TryUpdateEntity(AdmininstrationDb.TextsSetLanguageZones, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование языковой зоны статических текстов", $"Отредактирована языковая зона статических текстов с id={item.Id}");
            });
        }


        [HttpDelete, Route("DeleteLanguageZone")]
        public async Task DeleteLanguageZone(int id)
        {
            var item = GetAvailableLanguageZones().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(AdmininstrationDb.TextsSetLanguageZones, item);

            this.AddHistoryAction("Удаление языковой зоны статических текстов", $"Удалена языковая зона статических текстов {item.Language.Code} с id={id}");
        }

        #endregion







        #region Private methods
        private IEnumerable<TextsSetLanguageZone> GetAvailableLanguageZones()
        {
            return AdmininstrationDb.TextsSetLanguageZones.Include(o => o.Language)
                                                          .Where(o => !o.IsDeleted && o.TextsSetId == this.TextsSetId);
        }

        #endregion
    }
}
