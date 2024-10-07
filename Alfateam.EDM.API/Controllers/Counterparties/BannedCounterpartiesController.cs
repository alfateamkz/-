using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Controllers.Counterparties
{
    public class BannedCounterpartiesController : AbsAuthorizedController
    {
        public BannedCounterpartiesController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetCounterparties")]
        public async Task<IEnumerable<BannedCounterpartyDTO>> GetCounterparties()
        {
            var counterparties = DB.BannedCounterparties.Include(o => o.Counterparty).ThenInclude(o => o.Group)
                                                        .Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);
            return new BannedCounterpartyDTO().CreateDTOs(counterparties).Cast<BannedCounterpartyDTO>();
        }

        [HttpGet, Route("GetCounterparty")]
        public async Task<BannedCounterpartyDTO> GetCounterparty(int id)
        {
            var counterparties = DB.BannedCounterparties.Include(o => o.Counterparty).ThenInclude(o => o.Group)
                                                        .Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);
            return (BannedCounterpartyDTO)DBService.TryGetOne(counterparties, id, new BannedCounterpartyDTO());
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
            var counterparties = DB.BannedCounterparties.Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);
            var counterparty = DBService.TryGetOne(counterparties, model.Id);

            return (BannedCounterpartyDTO)DBService.TryUpdateEntity(DB.BannedCounterparties, model, counterparty);
        }

        [HttpDelete, Route("DeleteCounterparty")]
        public async Task DeleteCounterparty(int id)
        {
            var counterparties = DB.BannedCounterparties.Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);
            var counterparty = DBService.TryGetOne(counterparties, id);

            DBService.TryDeleteEntity(DB.BannedCounterparties, counterparty, false);
        }
    }
}
