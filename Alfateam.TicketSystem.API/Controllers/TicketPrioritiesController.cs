using Alfateam.Core;
using Alfateam.Sales.Models.Customers.Categories;
using Alfateam.TicketSystem.API.Abstractions;
using Alfateam.TicketSystem.API.Models;
using Alfateam.TicketSystem.Models;
using Alfateam.TicketSystem.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.TicketSystem.API.Controllers
{
    public class TicketPrioritiesController : AbsAuthorizedController
    {
        public TicketPrioritiesController(ControllerParams @params) : base(@params)
        {
        }

        #region Приоритеты тикетов

        [HttpGet, Route("GetPriorities")]
        public async Task<ItemsWithTotalCount<TicketPriorityDTO>> GetPriorities(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<TicketPriority, TicketPriorityDTO>(GetAvailablePriorities(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetPriority")]
        public async Task<TicketPriorityDTO> GetPriority(int id)
        {
            return (TicketPriorityDTO)DBService.TryGetOne(GetAvailablePriorities(), id, new TicketPriorityDTO());
        }











        [HttpPost, Route("CreatePriority")]
        public async Task<TicketPriorityDTO> CreatePriority(TicketPriorityDTO model)
        {
            return (TicketPriorityDTO)DBService.TryCreateEntity(DB.TicketPriorities, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            });
        }

        [HttpPut, Route("UpdatePriority")]
        public async Task<TicketPriorityDTO> UpdatePriority(TicketPriorityDTO model)
        {
            var item = GetAvailablePriorities().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (TicketPriorityDTO)DBService.TryUpdateEntity(DB.TicketPriorities, model, item);
        }

        [HttpDelete, Route("DeletePriority")]
        public async Task DeletePriority(int id)
        {
            var item = GetAvailablePriorities().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.TicketPriorities, item);
        }

        #endregion







        #region Private methods
        private IEnumerable<TicketPriority> GetAvailablePriorities()
        {
            return DB.TicketPriorities.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
