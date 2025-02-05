using Alfateam.Administration.Models.DTO.General;
using Alfateam.Administration.Models.General;
using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.AdminPanelGeneral.API.Models.Filters;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers
{
    public class LanguagesController : AbsController
    {
        public LanguagesController(ControllerParams @params) : base(@params)
        {
        }

        #region Языки

        [HttpGet, Route("GetLanguages")]
        public async Task<ItemsWithTotalCount<LanguageDTO>> GetLanguages(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Language, LanguageDTO>(GetAvailableLanguages(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition = entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetLanguage")]
        public async Task<LanguageDTO> GetLanguage(int id)
        {
            return (LanguageDTO)DBService.TryGetOne(GetAvailableLanguages(), id, new LanguageDTO());
        }






        [HttpPost, Route("CreateLanguage")]
        public async Task<LanguageDTO> CreateLanguage(LanguageDTO model)
        {
            return (LanguageDTO)DBService.TryCreateEntity(AdmininstrationDb.Languages, model,
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление языка", $"Добавлен язык {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateLanguage")]
        public async Task<LanguageDTO> UpdateLanguage(LanguageDTO model)
        {
            var item = GetAvailableLanguages().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (LanguageDTO)DBService.TryUpdateEntity(AdmininstrationDb.Languages, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование языка", $"Отредактирован язык с id={item.Id}");
            });
        }

        [HttpDelete, Route("DeleteLanguage")]
        public async Task DeleteLanguage(int id)
        {
            var item = GetAvailableLanguages().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(AdmininstrationDb.Languages, item);

            this.AddHistoryAction("Удаление языка", $"Удален язык {item.Title} с id={id}");
        }



        #endregion









        #region Private methods
        private IEnumerable<Language> GetAvailableLanguages()
        {
            return AdmininstrationDb.Languages.Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
