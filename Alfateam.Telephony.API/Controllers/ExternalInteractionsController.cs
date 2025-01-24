using Alfateam.Core;
using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.API.Abstractions;
using Alfateam.Telephony.API.Models;
using Alfateam.Telephony.API.Models.DTO;
using Alfateam.Telephony.Models;
using Microsoft.AspNetCore.Mvc;
using Alfateam.Telephony.API.Models.DTO.Abstractions;

namespace Alfateam.Telephony.API.Controllers
{
    public class ExternalInteractionsController : AbsAuthorizedController
    {
        public ExternalInteractionsController(ControllerParams @params) : base(@params)
        {
        }


        #region Внешние взаимодействия

        [HttpGet, Route("GetExtInteractions")]
        public async Task<ItemsWithTotalCount<ExtInteractionDTO>> GetExtInteractions(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<ExtInteraction, ExtInteractionDTO>(GetAvailableExtInteractions(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetExtInteraction")]
        public async Task<ExtInteractionDTO> GetExtInteraction(int id)
        {
            return (ExtInteractionDTO)DBService.TryGetOne(GetAvailableExtInteractions(), id, new ExtInteractionDTO());
        }





        [HttpPost, Route("CreateExtInteraction")]
        public async Task<ExtInteractionDTO> CreateExtInteraction(ExtInteractionDTO model)
        {
            return (ExtInteractionDTO)DBService.TryCreateEntity(DB.ExtInteractions, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление внешнего взаимодействия", $"Добавлено внешнее взаимодействие {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateExtInteraction")]
        public async Task<ExtInteractionDTO> UpdateExtInteraction(ExtInteractionDTO model)
        {
            var item = GetAvailableExtInteractions().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (ExtInteractionDTO)DBService.TryUpdateEntity(DB.ExtInteractions, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование внешнего взаимодействия", $"Отредактировано внешнее взаимодействие с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteExtInteraction")]
        public async Task DeleteExtInteraction(int id)
        {
            var item = GetAvailableExtInteractions().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.ExtInteractions, item);

            this.AddHistoryAction("Удаление внешнего взаимодействия", $"Удалено внешнее взаимодействие {item.Title} с id={id}");
        }



        #endregion


        //TODO: реализовать логику их работы, круд сделан только





        #region Private methods
        private IEnumerable<ExtInteraction> GetAvailableExtInteractions()
        {
            return DB.ExtInteractions.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
