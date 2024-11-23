using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.Abstractions.ExtInterations;
using Alfateam.Sales.API.Models.DTO.BusinessProposals;
using Alfateam.Sales.API.Models.SearchFilters;
using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.BusinessProposals;
using Alfateam.Sales.Models.ExternalInteractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers.ExternalInteractions
{
    [Route("ExtIntegrations/[controller]")]
    public class ExternalInteractionsController : AbsController
    {
        public ExternalInteractionsController(ControllerParams @params) : base(@params)
        {
        }


        #region Внешние взаимодействия - CRUD операции

        [HttpGet, Route("GetInteractions")]
        public async Task<ItemsWithTotalCount<ExternalInteractionDTO>> GetInteractions(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<ExternalInteraction, ExternalInteractionDTO>(GetAvailableInteractions(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetInteraction")]
        public async Task<ExternalInteractionDTO> GetInteraction(int id)
        {
            return (ExternalInteractionDTO)DBService.TryGetOne(GetAvailableInteractions(), id, new ExternalInteractionDTO());
        }


        [HttpPost, Route("CreateInteraction")]
        public async Task<ExternalInteractionDTO> CreateInteraction(ExternalInteractionDTO model)
        {
            return (ExternalInteractionDTO)DBService.TryCreateEntity(DB.ExternalInteractions, model, (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление интеграции взаимодействия", $"Добавлена интеграция взаимодействия {entity.Title}, тип {entity.GetSelfTypeName()}");
            });
        }

        [HttpPut, Route("UpdateInteraction")]
        public async Task<ExternalInteractionDTO> UpdateInteraction(ExternalInteractionDTO model)
        {
            var item = GetAvailableInteractions().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if(item.GetType() != model.GetTypeOfDBEntity())
            {
                throw new Exception400($"Передан DTO model не того типа, нужен {item.GetType().Name}DTO");
            } 

            return (ExternalInteractionDTO)DBService.TryUpdateEntity(DB.ExternalInteractions, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование интеграции взаимодействия", $"Отредактирована интеграция взаимодействия с id={entity.Id}");
            });
        }

        [HttpDelete, Route("DeleteInteraction")]
        public async Task DeleteInteraction(int id)
        {
            var item = GetAvailableInteractions().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.ExternalInteractions, item);

            this.AddHistoryAction("Удаление интеграции взаимодействия", $"Удален интеграция взаимодействия {item.Title} с id={id}, тип {item.GetSelfTypeName()}");
        }

        #endregion

        #region Внешние взаимодействия - получение действий



        #endregion





        #region Private methods

        private IEnumerable<ExternalInteraction> GetAvailableInteractions()
        {
            var interactions = DB.ExternalInteractions.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
            foreach(var interaction in interactions)
            {
                if(interaction is WebsiteFormExtInteration websiteForm)
                {
                    websiteForm.Inputs = DB.WebsiteFormInputs.Where(o => !o.IsDeleted && o.WebsiteFormExtInterationId == websiteForm.Id).ToList();
                }
                else if(interaction is CommunitationButtonsExtInteration communitationButtons)
                {
                    communitationButtons.Contacts = DB.ContactInfos.Where(o => !o.IsDeleted && o.CommunitationButtonsExtInterationId == communitationButtons.Id).ToList();
                }
            }
            return interactions;
        }


        #endregion
    }
}
