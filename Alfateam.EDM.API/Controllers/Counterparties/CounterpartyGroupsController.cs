using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.EDM.API.Controllers.Counterparties
{
    public class CounterpartyGroupsController : AbsAuthorizedController
    {
        public CounterpartyGroupsController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetCounterpartyGroups")]
        public async Task<IEnumerable<CounterpartyGroupDTO>> GetCounterpartyGroups()
        {
            var groups = DB.CounterpartyGroups.Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);
            return new CounterpartyGroupDTO().CreateDTOs(groups).Cast<CounterpartyGroupDTO>();
        }

        [HttpGet, Route("GetCounterpartyGroup")]
        public async Task<CounterpartyGroupDTO> GetCounterpartyGroup(int id)
        {
            var groups = DB.CounterpartyGroups.Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);
            return (CounterpartyGroupDTO)DBService.TryGetOne(groups, id, new CounterpartyGroupDTO());
        }


        [HttpPost, Route("CreateCounterpartyGroup")]
        public async Task<CounterpartyGroupDTO> CreateCounterpartyGroup(CounterpartyGroupDTO model)
        {
            return (CounterpartyGroupDTO)DBService.TryCreateEntity(DB.CounterpartyGroups, model, (entity) =>
            {
                entity.EDMSubjectId = (int)this.EDMSubjectId;
            });
        }

        [HttpPut, Route("UpdateCounterpartyGroup")]
        public async Task<CounterpartyGroupDTO> UpdateCounterpartyGroup(CounterpartyGroupDTO model)
        {
            var groups = DB.CounterpartyGroups.Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);
            var group = DBService.TryGetOne(groups, model.Id);

            return (CounterpartyGroupDTO)DBService.TryUpdateEntity(DB.CounterpartyGroups, model, group);
        }


        [HttpDelete, Route("DeleteCounterpartyGroup")]
        public async Task DeleteCounterpartyGroup(int id)
        {
            var groups = DB.CounterpartyGroups.Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);
            var group = DBService.TryGetOne(groups, id);

            DBService.TryDeleteEntity(DB.CounterpartyGroups, group);
        }
    }
}
