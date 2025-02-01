using Alfateam.Core;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.Models;
using Alfateam.EDM.Models.Counterparties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Controllers.Counterparties
{
    public class CounterpartyGroupsController : AbsAuthorizedController
    {
        public CounterpartyGroupsController(ControllerParams @params) : base(@params)
        {
        }

        #region Группы (категории) контрагентов

        [HttpGet, Route("GetCounterpartyGroups")]
        public async Task<ItemsWithTotalCount<CounterpartyGroupDTO>> GetCounterpartyGroups([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<CounterpartyGroup, CounterpartyGroupDTO>(GetAvailableCounterpartyGroups(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.ToString().Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetCounterpartyGroup")]
        public async Task<CounterpartyGroupDTO> GetCounterpartyGroup(int id)
        {
            return (CounterpartyGroupDTO)DBService.TryGetOne(GetAvailableCounterpartyGroups(), id, new CounterpartyGroupDTO());
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
            var group = DBService.TryGetOne(GetAvailableCounterpartyGroups(), model.Id);
            return (CounterpartyGroupDTO)DBService.TryUpdateEntity(DB.CounterpartyGroups, model, group);
        }


        [HttpDelete, Route("DeleteCounterpartyGroup")]
        public async Task DeleteCounterpartyGroup(int id)
        {
            var group = DBService.TryGetOne(GetAvailableCounterpartyGroups(), id);
            DBService.TryDeleteEntity(DB.CounterpartyGroups, group);
        }

        #endregion









        #region Private methods
        private IEnumerable<CounterpartyGroup> GetAvailableCounterpartyGroups()
        {
            return DB.CounterpartyGroups.Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);
        }


        #endregion
    }
}
