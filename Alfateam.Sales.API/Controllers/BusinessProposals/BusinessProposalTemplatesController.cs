using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.API.Models.DTO.BusinessProposals;
using Alfateam.Sales.API.Models.DTO.Funnel;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.BusinessProposals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers.BusinessProposals
{
    [Route("BP/[controller]")]
    public class BusinessProposalTemplatesController : AbsController
    {
        public BusinessProposalTemplatesController(ControllerParams @params) : base(@params)
        {
        }

        #region Шаблоны КП

        [HttpGet, Route("GetTemplates")]
        public async Task<ItemsWithTotalCount<BusinessProposalTemplateDTO>> GetTemplates(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<BusinessProposalTemplate, BusinessProposalTemplateDTO>(GetAvailableTemplates(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetTemplate")]
        public async Task<BusinessProposalTemplateDTO> GetTemplate(int id)
        {
            return (BusinessProposalTemplateDTO)DBService.TryGetOne(GetAvailableTemplates(), id, new BusinessProposalTemplateDTO());
        }



        [HttpPost, Route("CreateTemplate")]
        public async Task<BusinessProposalTemplateDTO> CreateTemplate(BusinessProposalTemplateDTO model)
        {
            return (BusinessProposalTemplateDTO)DBService.TryCreateEntity(DB.BusinessProposalTemplates, model, (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление шаблона КП", $"Добавлен шаблон КП {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateTemplate")]
        public async Task<BusinessProposalTemplateDTO> UpdateTemplate(BusinessProposalTemplateDTO model)
        {
            var item = GetAvailableTemplates().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (BusinessProposalTemplateDTO)DBService.TryUpdateEntity(DB.BusinessProposalTemplates, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование шаблона КП ", $"Отредактирован шаблон КП с id={entity.Id}");
            });
        }


        [HttpDelete, Route("DeleteTemplate")]
        public async Task DeleteTemplate(int id)
        {
            var item = GetAvailableTemplates().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.BusinessProposalTemplates, item);

            this.AddHistoryAction("Удаление шаблона КП", $"Удален шаблон КП {item.Title} с id={id}");
        }


        #endregion

        #region Плейсхолдеры для шаблонов КП

        [HttpPost, Route("CreateTemplatePlaceholder")]
        public async Task<BPTemplatePlaceholderDTO> CreateTemplatePlaceholder(int templateId, BPTemplatePlaceholderDTO model)
        {
            ThrowIfTemplateExist(templateId);
            return (BPTemplatePlaceholderDTO)DBService.TryCreateEntity(DB.BPTemplatePlaceholders, model, callback: (entity) =>
            {
                entity.BusinessProposalTemplateId = templateId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление плейсхолдера к шаблону КП", $"Добавлен плейсхолдер {entity.PlaceholderName} к шаблону КП");
            });
        }


        [HttpPut, Route("UpdateTemplatePlaceholder")]
        public async Task<BPTemplatePlaceholderDTO> UpdateTemplatePlaceholder(BPTemplatePlaceholderDTO model)
        {
            var item = TryGetTemplatePlaceholder(model.Id);
            return (BPTemplatePlaceholderDTO)DBService.TryUpdateEntity(DB.BPTemplatePlaceholders, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование плейсхолдера к шаблону КП", $"Отредактирован плейсхолдер к шаблону КП с id={entity.Id}");
            });
        }


        [HttpDelete, Route("DeleteTemplatePlaceholder")]
        public async Task DeleteTemplatePlaceholder(int id)
        {
            var item = TryGetTemplatePlaceholder(id);
            DBService.TryDeleteEntity(DB.BPTemplatePlaceholders, item);

            this.AddHistoryAction("Удаление плейсхолдера к шаблону КП", $"Удален плейсхолдер {item.PlaceholderName} к шаблону КП с id={id}");
        }

        #endregion






        #region Private methods

        private IEnumerable<BusinessProposalTemplate> GetAvailableTemplates()
        {
            return DB.BusinessProposalTemplates.Include(o => o.Placeholders)
                                               .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        private void ThrowIfTemplateExist(int funnelId)
        {
            DBService.TryGetOne(GetAvailableTemplates(), funnelId);
        }

        private BPTemplatePlaceholder TryGetTemplatePlaceholder(int placeholderId)
        {
            var placeholder = DBService.TryGetOne(DB.BPTemplatePlaceholders, placeholderId);
            if (!GetAvailableTemplates().Any(o => o.Id == placeholder.BusinessProposalTemplateId))
            {
                throw new Exception403("Нет доступа к данной сущности");
            }
            return placeholder;
        }

        #endregion
    }
}
