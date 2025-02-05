using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Core;
using Alfateam.Telephony.API.Models.DTO.General;
using Alfateam.Telephony.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Products.Telephony
{
    [Route("Products/Telephony/[controller]")]
    public class TelephonyLanguagesController : AbsController
    {
        public TelephonyLanguagesController(ControllerParams @params) : base(@params)
        {
        }

        #region Языки

        [HttpGet, Route("GetLanguages")]
        public async Task<ItemsWithTotalCount<LanguageDTO>> GetLanguages([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Language, LanguageDTO>(GetAvailableLanguages(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
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
            return (LanguageDTO)DBService.TryCreateEntity(TelephonyDb.Languages, model);
        }

        [HttpPut, Route("UpdateLanguage")]
        public async Task<LanguageDTO> UpdateLanguage(LanguageDTO model)
        {
            var group = DBService.TryGetOne(GetAvailableLanguages(), model.Id);
            return (LanguageDTO)DBService.TryUpdateEntity(TelephonyDb.Languages, model, group);
        }


        [HttpDelete, Route("DeleteLanguage")]
        public async Task DeleteLanguage(int id)
        {
            var group = DBService.TryGetOne(GetAvailableLanguages(), id);
            DBService.TryDeleteEntity(TelephonyDb.Languages, group);
        }

        #endregion









        #region Private methods
        private IEnumerable<Language> GetAvailableLanguages()
        {
            return TelephonyDb.Languages.Where(o => !o.IsDeleted);
        }


        #endregion
    }
}
