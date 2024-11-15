using Alfateam.Core;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.BusinessProposals;
using Alfateam.Sales.API.Models.SearchFilters;
using Alfateam.Sales.Models.BusinessProposals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers.BusinessProposals
{
    public class BusinessProposalsController : AbsController
    {
        public BusinessProposalsController(ControllerParams @params) : base(@params)
        {
        }

        #region Коммерческие предложения клиентам

        [HttpGet, Route("GetProposals")]
        public async Task<ItemsWithTotalCount<BusinessProposalDTO>> GetProposals(BusinessProposalsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<BusinessProposal, BusinessProposalDTO>(GetAvailableProposals(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if (filter.CustomerId != null)
                {
                    condition &= entity.CustomerId == filter.CustomerId;
                }
                return condition;
            });
        }

        [HttpGet, Route("GetProposal")]
        public async Task<BusinessProposalDTO> GetProposal(int id)
        {
            return (BusinessProposalDTO)DBService.TryGetOne(GetAvailableProposals(), id, new BusinessProposalDTO());
        }




        [HttpPost, Route("CreateProposal")]
        public async Task<BusinessProposalDTO> CreateProposal(BusinessProposalDTO model)
        {
            return (BusinessProposalDTO)DBService.TryCreateEntity(DB.BusinessProposals, model, (entity) =>
            {
                entity.CustomerId = model.CustomerId;
            },
            afterSuccessCallback: (entity) =>
            {
                var customer = DB.Customers.FirstOrDefault(o => o.Id == model.CustomerId);
                this.AddHistoryAction("Выставление КП клиенту", $"Выставлено КП {entity.Title} клиенту {customer.FIO}");
            });
        }

        [HttpPut, Route("UpdateProposal")]
        public async Task<BusinessProposalDTO> UpdateProposal(BusinessProposalDTO model)
        {
            var item = GetAvailableProposals().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (BusinessProposalDTO)DBService.TryUpdateEntity(DB.BusinessProposals, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование КП клиенту", $"Отредактировано КП с id={entity.Id}");
            });
        }

        [HttpDelete, Route("DeleteProposal")]
        public async Task DeleteProposal(int id)
        {
            var item = GetAvailableProposals().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.BusinessProposals, item);

            this.AddHistoryAction("Удаление КП клиенту", $"Удалено КП {item.Title} клиенту {item.Customer.FIO} с id={id}");
        }

        #endregion







        #region Private methods

        private IEnumerable<BusinessProposal> GetAvailableProposals()
        {
            return DB.BusinessProposals.Include(o => o.Customer)
                                       .Where(o => !o.IsDeleted && o.Customer.BusinessCompanyId == this.CompanyId);
        }


        #endregion
    }
}
