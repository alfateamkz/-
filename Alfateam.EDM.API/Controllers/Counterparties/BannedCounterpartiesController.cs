using Alfateam.Core;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO;
using Alfateam.EDM.Models;
using Alfateam.EDM.Models.Counterparties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Controllers.Counterparties
{
    public class BannedCounterpartiesController : AbsAuthorizedController
    {
        public BannedCounterpartiesController(ControllerParams @params) : base(@params)
        {
        }

        #region Забаненные контрагенты

        [HttpGet, Route("GetCounterparties")]
        public async Task<ItemsWithTotalCount<BannedCounterpartyDTO>> GetCounterparties([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<BannedCounterparty, BannedCounterpartyDTO>(GetAvailableBannedCounterparties(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Counterparty.ToString().Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetCounterparty")]
        public async Task<BannedCounterpartyDTO> GetCounterparty(int id)
        {
            return (BannedCounterpartyDTO)DBService.TryGetOne(GetAvailableBannedCounterparties(), id, new BannedCounterpartyDTO());
        }


        [HttpPost, Route("CreateCounterparty")]
        public async Task<BannedCounterpartyDTO> CreateCounterparty(BannedCounterpartyDTO model)
        {
            return (BannedCounterpartyDTO)DBService.TryCreateEntity(DB.BannedCounterparties, model, (entity) =>
            {
                entity.EDMSubjectId = (int)this.EDMSubjectId;
            });
        }

        [HttpPut, Route("UpdateCounterparty")]
        public async Task<BannedCounterpartyDTO> UpdateCounterparty(BannedCounterpartyDTO model)
        {
            var counterparty = DBService.TryGetOne(GetAvailableBannedCounterparties(), model.Id);
            return (BannedCounterpartyDTO)DBService.TryUpdateEntity(DB.BannedCounterparties, model, counterparty);
        }

        [HttpDelete, Route("DeleteCounterparty")]
        public async Task DeleteCounterparty(int id)
        {
            var counterparty = DBService.TryGetOne(GetAvailableBannedCounterparties(), id);
            DBService.TryDeleteEntity(DB.BannedCounterparties, counterparty, false);
        }

        #endregion







        #region Private methods

        private IEnumerable<BannedCounterparty> GetAvailableBannedCounterparties()
        {
            var counterparties = DB.BannedCounterparties.Include(o => o.Counterparty).ThenInclude(o => o.Group)
                                                        .Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);

            foreach(var counterparty in counterparties)
            {
                if(counterparty.Counterparty is EDMCounterparty edmCounterparty)
                {
                    edmCounterparty.Subject = DB.EDMSubjects.FirstOrDefault(o => o.Id == edmCounterparty.SubjectId);
                }       
            }

            return counterparties;
        }


        #endregion

    }
}
