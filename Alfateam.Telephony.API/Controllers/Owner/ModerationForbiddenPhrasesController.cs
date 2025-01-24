using Alfateam.Core;
using Alfateam.Telephony.API.Abstractions;
using Alfateam.Telephony.API.Models;
using Alfateam.Telephony.API.Models.DTO;
using Alfateam.Telephony.API.Models.DTO.Contacts;
using Alfateam.Telephony.Models;
using Alfateam.Telephony.Models.Contacts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Telephony.API.Controllers.Owner
{
    public class ModerationForbiddenPhrasesController : AbsAuthorizedController
    {
        public ModerationForbiddenPhrasesController(ControllerParams @params) : base(@params)
        {
        }


        #region Запрещенные фразы

        [HttpGet, Route("GetPhrases")]
        public async Task<ItemsWithTotalCount<ModerationForbiddenPhraseDTO>> GetPhrases(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<ModerationForbiddenPhrase, ModerationForbiddenPhraseDTO>(GetAvailablePhrases(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Phrase.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetPhrase")]
        public async Task<ModerationForbiddenPhraseDTO> GetPhrase(int id)
        {
            return (ModerationForbiddenPhraseDTO)DBService.TryGetOne(GetAvailablePhrases(), id, new ModerationForbiddenPhraseDTO());
        }





        [HttpPost, Route("CreatePhrase")]
        public async Task<ModerationForbiddenPhraseDTO> CreatePhrase(ModerationForbiddenPhraseDTO model)
        {
            return (ModerationForbiddenPhraseDTO)DBService.TryCreateEntity(DB.ModerationForbiddenPhrases, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление запрещенной фразы", $"Добавлена запрещенная фраза {entity.Phrase}");
            });
        }

        [HttpPut, Route("UpdatePhrase")]
        public async Task<ModerationForbiddenPhraseDTO> UpdatePhrase(ModerationForbiddenPhraseDTO model)
        {
            var item = GetAvailablePhrases().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (ModerationForbiddenPhraseDTO)DBService.TryUpdateEntity(DB.ModerationForbiddenPhrases, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование запрещенной фразы", $"Отредактирована запрещенная фраза с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeletePhrase")]
        public async Task DeletePhrase(int id)
        {
            var item = GetAvailablePhrases().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.ModerationForbiddenPhrases, item);

            this.AddHistoryAction("Удаление запрещенной фразы", $"Удалена запрещенная фраза {item.Phrase} с id={id}");
        }



        #endregion








        #region Private methods
        private IEnumerable<ModerationForbiddenPhrase> GetAvailablePhrases()
        {
            return DB.ModerationForbiddenPhrases.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
