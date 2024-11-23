using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.Leads;
using Alfateam.Sales.API.Models.SearchFilters;
using Alfateam.Sales.Models.Enums.Statuses;
using Alfateam.Sales.Models.Leads;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers.Leads
{
    [Route("Leads/[controller]")]
    public class LeadsController : AbsController
    {
        public LeadsController(ControllerParams @params) : base(@params)
        {
        }

        #region Лиды компании

        [HttpGet, Route("GetLeads")]
        public async Task<ItemsWithTotalCount<LeadDTO>> GetLeads(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Lead, LeadDTO>(GetAvailableLeads(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetLead")]
        public async Task<LeadDTO> GetLead(int id)
        {
            return (LeadDTO)DBService.TryGetOne(GetAvailableLeads(), id, new LeadDTO());
        }






        [HttpPost, Route("CreateLead")]
        public async Task<LeadDTO> CreateLead(LeadDTO model)
        {
            return (LeadDTO)DBService.TryCreateEntity(DB.Leads, model, (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление лида", $"Добавлен лид {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateLead")]
        public async Task<LeadDTO> UpdateLead(LeadDTO model)
        {
            var item = GetAvailableLeads().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (LeadDTO)DBService.TryUpdateEntity(DB.Leads, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование лида", $"Отредактирован лид с id={entity.Id}");
            });
        }

        [HttpDelete, Route("DeleteLead")]
        public async Task DeleteLead(int id)
        {
            var item = GetAvailableLeads().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            
            DBService.TryDeleteEntity(DB.Leads, item);
            this.AddHistoryAction("Удаление лида", $"Удален лид {item.Title} с id={id}");
        }



        #endregion


        [HttpPost, Route("TransformLead")]
        public async Task TransformLead(LeadTransformationModel model)
        {
            var lead = DBService.TryGetOne(GetAvailableLeads(), model.LeadId);
            ThrowIfNotValid(lead, model);

            lead.KanbanData.StageId = DB.LeadsKanbanStages.FirstOrDefault(o => o.LeadsKanbanId == lead.KanbanData.KanbanId
                                                                           && o.IsSystemStage
                                                                           && o.Status == LeadsKanbanStageStatus.ConvertedLead).Id;
            DBService.UpdateEntity(DB.Leads, lead);

            if(model.NewPersonContact != null)
            {
                DBService.TryCreateEntity(DB.PersonContacts, model.NewPersonContact, (entity) =>
                {
                    entity.BusinessCompanyId = (int)this.CompanyId;
                });
            }
            if (model.NewCompany != null)
            {
                DBService.TryCreateEntity(DB.Companies, model.NewCompany, (entity) =>
                {
                    entity.BusinessCompanyId = (int)this.CompanyId;
                });
            }
            if (model.NewOrder != null)
            {
                DBService.TryCreateEntity(DB.Orders, model.NewOrder, (entity) =>
                {
                    entity.BusinessCompanyId = (int)this.CompanyId;
                });
            }
        }




        #region Private methods

        private IEnumerable<Lead> GetAvailableLeads()
        {
            return DB.Leads.Include(o => o.PersonContact)
                           .Include(o => o.Company)
                           .Include(o => o.KanbanData).ThenInclude(o => o.Kanban)
                           .Include(o => o.KanbanData).ThenInclude(o => o.Stage)
                           .Include(o => o.UTMMark)
                           .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }


        #endregion

        #region Private transform lead validation methods

        private void ThrowIfNotValid(Lead lead, LeadTransformationModel model)
        {
            if (model.NewCompany == null && model.NewPersonContact == null && model.NewOrder == null)
            {
                throw new Exception400("Нужно добавить как минимум одну из трех сущностей");
            }
            else if (lead.KanbanData.Stage.Status == LeadsKanbanStageStatus.ConvertedLead)
            {
                throw new Exception400("Лид уже был ранее сконвертирован, действие невозможно");
            }
            else if (model.NewPersonContact != null && lead.PersonContactId != null)
            {
                throw new Exception400("Невозможно задать новый контакт, т.к. у лида уже выбран контакт");
            }
            else if (model.NewCompany != null && lead.CompanyId != null)
            {
                throw new Exception400("Невозможно задать новую компанию, т.к. у лида уже выбрана компания");
            }
            else if (model.NewPersonContact != null && !model.NewPersonContact.IsValid())
            {
                throw new Exception400("Ошибка. Сущность нового контакта неправильно заполнена");
            }
            else if (model.NewCompany != null && !model.NewCompany.IsValid())
            {
                throw new Exception400("Ошибка. Сущность новой компании неправильно заполнена");
            }
            else if (model.NewOrder != null && !model.NewOrder.IsValid())
            {
                throw new Exception400("Ошибка. Сущность нового заказа неправильно заполнена");
            }
        }

        #endregion
    }
}
