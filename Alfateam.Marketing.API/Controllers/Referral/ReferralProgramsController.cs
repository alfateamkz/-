using Alfateam.Core;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Enums;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.API.Models.SearchFilters;
using Alfateam.Marketing.Models.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Marketing.API.Controllers.Referral
{
    public class ReferralProgramsController : AbsController
    {
        public ReferralProgramsController(ControllerParams @params) : base(@params)
        {
        }

        #region Реферальные программы

        [HttpGet, Route("GetReferralPrograms")]
        public async Task<ItemsWithTotalCount<ReferralProgramDTO>> GetReferralPrograms(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<ReferralProgram, ReferralProgramDTO>(GetAvailableReferralPrograms(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return condition;
            });
        }

        [HttpGet, Route("GetReferralProgram")]
        public async Task<ReferralProgramDTO> GetReferralProgram(int id)
        {
            return (ReferralProgramDTO)DBService.TryGetOne(GetAvailableReferralPrograms(), id, new ReferralProgramDTO());
        }





        [HttpPost, Route("CreateReferralProgram")]
        public async Task<ReferralProgramDTO> CreateReferralProgram(ReferralProgramDTO model)
        {
            return (ReferralProgramDTO)DBService.TryCreateEntity(DB.ReferralPrograms, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление реферальной программы", $"Добавлена реферальная программа {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateReferralProgram")]
        public async Task<ReferralProgramDTO> UpdateReferralProgram(ReferralProgramDTO model)
        {
            var item = GetAvailableReferralPrograms().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (ReferralProgramDTO)DBService.TryUpdateEntity(DB.ReferralPrograms, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование реферальной программы", $"Отредактирована реферальная программа с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteReferralProgram")]
        public async Task DeleteReferralProgram(int id)
        {
            var item = GetAvailableReferralPrograms().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.ReferralPrograms, item);

            this.AddHistoryAction("Удаление реферальной программы", $"Удалена реферальная программа {item.Title} с id={id}");
        }





        #endregion








        #region Private methods

        private IEnumerable<ReferralProgram> GetAvailableReferralPrograms()
        {
            //TODO: ReferralPrograms includes
            return DB.ReferralPrograms.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
