using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models.DTO.General.Chats;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Messenger.API.Controllers
{
    public class QuickAnswersController : AbsMessengerController
    {
        public QuickAnswersController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetQuickAnswers")]
        public async Task<IEnumerable<QuickAnswerDTO>> GetQuickAnswers()
        {
            var quickAnswers = DB.QuickAnswers.Where(o => !o.IsDeleted && o.AccountId == this.AccountId);
            return new QuickAnswerDTO().CreateDTOs(quickAnswers).Cast<QuickAnswerDTO>();
        }

        [HttpGet, Route("GetQuickAnswer")]
        public async Task<QuickAnswerDTO> GetQuickAnswer(int id)
        {
            var quickAnswers = DB.QuickAnswers.Where(o => !o.IsDeleted && o.AccountId == this.AccountId);
            return (QuickAnswerDTO)new QuickAnswerDTO().CreateDTO(DBService.TryGetOne(quickAnswers, id));
        }





        [HttpPost, Route("CreateQuickAnswer")]
        public async Task<QuickAnswerDTO> CreateQuickAnswer(QuickAnswerDTO model)
        {
            return (QuickAnswerDTO)DBService.TryCreateEntity(DB.QuickAnswers, model, (entity) =>
            {
                entity.AccountId = (int)this.AccountId;
            });
        }

        [HttpPut, Route("UpdateQuickAnswer")]
        public async Task<QuickAnswerDTO> UpdateQuickAnswer(QuickAnswerDTO model)
        {
            var quickAnswers = DB.QuickAnswers.Where(o => !o.IsDeleted && o.AccountId == this.AccountId);
            var quickAnswer = DBService.TryGetOne(quickAnswers, model.Id);

            return (QuickAnswerDTO)DBService.TryUpdateEntity(DB.QuickAnswers, model, quickAnswer);
        }

        [HttpDelete, Route("DeleteQuickAnswer")]
        public async Task DeleteQuickAnswer(int id)
        {
            var quickAnswers = DB.QuickAnswers.Where(o => !o.IsDeleted && o.AccountId == this.AccountId);
            var quickAnswer = DBService.TryGetOne(quickAnswers, id);

            DBService.DeleteEntity(DB.QuickAnswers, quickAnswer);
        }
    }
}
