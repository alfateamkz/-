using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.Counterparties;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Counterparties;
using Alfateam.EDM.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Controllers.Counterparties
{

    public class CounterpartiesController : AbsAuthorizedController
    {
        public CounterpartiesController(ControllerParams @params) : base(@params)
        {
        }

        #region Список контрагентов 

        [HttpGet, Route("GetCounterparties")]
        public async Task<ItemsWithTotalCount<CounterpartyDTO>> GetCounterparties([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Counterparty, CounterpartyDTO>(GetAvailableCounterparties(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.ToString().Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetCounterparty")]
        public async Task<CounterpartyDTO> GetCounterparty(int id)
        {
            return (CounterpartyDTO)DBService.TryGetOne(GetAvailableCounterparties(), id, new CounterpartyDTO());
        }


        [HttpPost, Route("CreateCounterparty")]
        public async Task<CounterpartyDTO> CreateCounterparty(CounterpartyDTO model)
        {
            if (model is EDMCounterpartyDTO)
            {
                throw new Exception403("Контрагента с привязкой к ЭДО нельзя создать. Для этого есть механизм приглашений");
            }

            return (CounterpartyDTO)DBService.TryCreateEntity(DB.Counterparties, model, (entity) =>
            {
                entity.EDMSubjectId = (int)this.EDMSubjectId;
            });
        }

        [HttpPut, Route("UpdateCounterparty")]
        public async Task<CounterpartyDTO> UpdateCounterparty(CounterpartyDTO model)
        {
            if(model is EDMCounterpartyDTO)
            {
                throw new Exception403("Контрагента с привязкой к ЭДО нельзя редактировать");
            }

            var counterparty = DBService.TryGetOne(GetAvailableCounterparties(), model.Id);
            return (CounterpartyDTO)DBService.TryUpdateEntity(DB.Counterparties, model, counterparty);
        }

        [HttpDelete, Route("DeleteCounterparty")]
        public async Task DeleteCounterparty(int id)
        {
            var counterparty = DBService.TryGetOne(GetAvailableCounterparties(), id);
            if (counterparty is EDMCounterparty edmCounterparty)
            {
                //Удаляем себя из списка контрагентов у другого контрагента
                var counterpartiesOfMyCounterparty = DB.Counterparties.Where(o => !o.IsDeleted && o.EDMSubjectId == edmCounterparty.SubjectId)
                                                                      .Cast<EDMCounterparty>();
                var meInMyCounterparty = counterpartiesOfMyCounterparty.FirstOrDefault(o => o.SubjectId == this.EDMSubjectId);
                if(meInMyCounterparty != null)
                {
                    DBService.TryDeleteEntity(DB.Counterparties, meInMyCounterparty);
                }
            }

            DBService.TryDeleteEntity(DB.Counterparties, counterparty);
        }

        #endregion








        #region Private methods
        private IEnumerable<Counterparty> GetAvailableCounterparties()
        {
            var counterparties = DB.Counterparties.Include(o => o.Group)
                                                  .Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);

            foreach (var counterparty in counterparties)
            {
                if (counterparty is EDMCounterparty edmCounterparty)
                {
                    edmCounterparty.Subject = DB.EDMSubjects.FirstOrDefault(o => o.Id == edmCounterparty.SubjectId);
                }
            }

            return counterparties;
        }


        #endregion

    }
}
