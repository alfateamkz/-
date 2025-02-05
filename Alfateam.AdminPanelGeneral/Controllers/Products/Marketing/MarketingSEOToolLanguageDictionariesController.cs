using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Core;
using Alfateam.Core.Enums;
using Alfateam.Marketing.API.Models.DTO.General.SEO;
using Alfateam.Marketing.Models.General.SEO;
using Alfateam.Telephony.API.Models.DTO.General.AudioRecords.Internal;
using Alfateam.Telephony.Models.General.AudioRecords.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Products.Marketing
{
    [Route("Products/Marketing/[controller]")]
    public class MarketingSEOToolLanguageDictionariesController : AbsController
    {
        public MarketingSEOToolLanguageDictionariesController(ControllerParams @params) : base(@params)
        {
        }

        #region Языковые словари

        [HttpGet, Route("GetLanguageDictionaries")]
        public async Task<ItemsWithTotalCount<LanguageDictionaryDTO>> GetLanguageDictionaries([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<LanguageDictionary, LanguageDictionaryDTO>(GetAvailableLanguageDictionaries(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetLanguageDictionary")]
        public async Task<LanguageDictionaryDTO> GetLanguageDictionary(int id)
        {
            return (LanguageDictionaryDTO)DBService.TryGetOne(GetAvailableLanguageDictionaries(), id, new LanguageDictionaryDTO());
        }








        [HttpPost, Route("CreateLanguageDictionary")]
        public async Task<LanguageDictionaryDTO> CreateLanguageDictionary([FromForm(Name = "model")] LanguageDictionaryDTO model, IFormFile file)
        {
            return (LanguageDictionaryDTO)DBService.TryCreateEntity(MarketingDb.LanguageDictionaries, model, async (entity) =>
            {
                entity.DictionaryPath = FilesService.TryUploadFile(file, FileType.Any);
            });
        }

        [HttpPut, Route("UpdateLanguageDictionary")]
        public async Task<LanguageDictionaryDTO> UpdateLanguageDictionary(LanguageDictionaryDTO model, IFormFile file = null)
        {
            var group = DBService.TryGetOne(GetAvailableLanguageDictionaries(), model.Id);
            return (LanguageDictionaryDTO)DBService.TryUpdateEntity(MarketingDb.LanguageDictionaries, model, group, (entity) =>
            {
                if (file != null)
                {
                    entity.DictionaryPath = FilesService.TryUploadFile(file, FileType.Any);
                }
            });
        }

        [HttpDelete, Route("DeleteLanguageDictionary")]
        public async Task DeleteLanguageDictionary(int id)
        {
            var group = DBService.TryGetOne(GetAvailableLanguageDictionaries(), id);
            DBService.TryDeleteEntity(MarketingDb.LanguageDictionaries, group);
        }

        #endregion









        #region Private methods
        private IEnumerable<LanguageDictionary> GetAvailableLanguageDictionaries()
        {
            return MarketingDb.LanguageDictionaries.Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
