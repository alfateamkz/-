﻿using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.General;
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



        [HttpGet, Route("GetCounterparties")]
        public async Task<IEnumerable<CounterpartyDTO>> GetCounterparties()
        {
            var counterparties = DB.Counterparties.Include(o => o.Group)
                                                  .Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);
            return new CounterpartyDTO().CreateDTOs(counterparties).Cast<CounterpartyDTO>();
        }

        [HttpGet, Route("GetCounterparty")]
        public async Task<CounterpartyDTO> GetCounterparty(int id)
        {
            var counterparties = DB.Counterparties.Include(o => o.Group)
                                                  .Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);
            return (CounterpartyDTO)DBService.TryGetOne(counterparties, id, new CounterpartyDTO());
        }


        [HttpPost, Route("CreateCounterparty")]
        public async Task<CounterpartyDTO> CreateCounterparty(CounterpartyDTO model)
        {
            return (CounterpartyDTO)DBService.TryCreateEntity(DB.Counterparties, model, (entity) =>
            {
                entity.EDMSubjectId = (int)this.EDMSubjectId;
            });
        }

        [HttpPut, Route("UpdateCounterparty")]
        public async Task<CounterpartyDTO> UpdateCounterparty(CounterpartyDTO model)
        {
            var counterparties = DB.Counterparties.Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);
            var counterparty = DBService.TryGetOne(counterparties, model.Id);

            return (CounterpartyDTO)DBService.TryUpdateEntity(DB.Counterparties, model, counterparty);
        }

        [HttpDelete, Route("DeleteCounterparty")]
        public async Task DeleteCounterparty(int id)
        {
            var counterparties = DB.Counterparties.Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId);
            var counterparty = DBService.TryGetOne(counterparties, id);

            DBService.TryDeleteEntity(DB.Counterparties, counterparty);
        }

    }
}
