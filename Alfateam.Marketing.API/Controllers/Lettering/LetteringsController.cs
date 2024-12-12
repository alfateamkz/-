using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Enums;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.API.Models.DTO.Autoposting;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Autoposting;
using Alfateam.Marketing.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Marketing.API.Controllers.Lettering
{
    public class LetteringsController : AbsController
    {
        public LetteringsController(ControllerParams @params) : base(@params)
        {
        }


        #region Рассылки

        [HttpGet, Route("GetLetteringCampaigns")]
        public async Task<ItemsWithTotalCount<LetteringCampaignDTO>> GetLetteringCampaigns(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<LetteringCampaign, LetteringCampaignDTO>(GetAvailableLetteringCampaigns(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetLetteringCampaign")]
        public async Task<LetteringCampaignDTO> GetLetteringCampaign(int id)
        {
            return (LetteringCampaignDTO)DBService.TryGetOne(GetAvailableLetteringCampaigns(), id, new LetteringCampaignDTO());
        }





        [HttpPost, Route("CreateLetteringCampaign")]
        public async Task<LetteringCampaignDTO> CreateLetteringCampaign(LetteringCampaignDTO model)
        {
            return (LetteringCampaignDTO)DBService.TryCreateEntity(DB.LetteringCampaigns, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                AddHistoryAction("Добавление рассылки", $"Добавлена рассылка {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateLetteringCampaign")]
        public async Task<LetteringCampaignDTO> UpdateLetteringCampaign(LetteringCampaignDTO model)
        {
            var item = GetAvailableLetteringCampaigns().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (LetteringCampaignDTO)DBService.TryUpdateEntity(DB.LetteringCampaigns, model, item, afterSuccessCallback: (entity) =>
            {
                AddHistoryAction("Редактирование рассылки", $"Отредактирована рассылка с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteLetteringCampaign")]
        public async Task DeleteLetteringCampaign(int id)
        {
            var item = GetAvailableLetteringCampaigns().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.LetteringCampaigns, item);

            AddHistoryAction("Удаление рассылки", $"Удалена рассылка {item.Title} с id={id}");
        }



        #endregion

        #region Изменение статуса рассылки

        [HttpPut, Route("SetLetteringStatus")]
        public async Task SetLetteringStatus(int id, SetLetteringStatusType status)
        {
            var lettering = DBService.TryGetOne(GetAvailableLetteringCampaigns(), id);

            if(lettering.Status == LetteringStatus.Finished)
            {
                throw new Exception400("Рассылка уже завершена");
            }
            else if ((lettering.Status == LetteringStatus.Active && status == SetLetteringStatusType.Active)
                     || (lettering.Status == LetteringStatus.Paused && status == SetLetteringStatusType.Pause)
                     || (lettering.Status == LetteringStatus.Stopped && status == SetLetteringStatusType.Stop))
            {
                throw new Exception400("Данный статус уже установлен");
            }
            else if (lettering.Status == LetteringStatus.Stopped && status == SetLetteringStatusType.Pause)
            {
                throw new Exception400("Рассылка уже была остановлена");
            }

            switch (status)
            {
                case SetLetteringStatusType.Active:
                    lettering.Status = LetteringStatus.Active;
                    break;
                case SetLetteringStatusType.Stop:
                    lettering.Status = LetteringStatus.Stopped;
                    break;
                case SetLetteringStatusType.Pause:
                    lettering.Status = LetteringStatus.Paused;
                    break;
            }
            DBService.UpdateEntity(DB.LetteringCampaigns, lettering);   
        }

        #endregion






        #region Private methods

        private IEnumerable<LetteringCampaign> GetAvailableLetteringCampaigns()
        {
            return DB.LetteringCampaigns.Include(o => o.IncludedSegments)
                                        .Include(o => o.ExcludedSegments)
                                        .Include(o => o.LetteringSentResults)
                                        .Where(o => !o.IsDeleted && o.BusinessCompanyId == CompanyId);
        }

        #endregion
    }
}
