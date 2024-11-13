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
            });
        }

        [HttpPut, Route("UpdateTemplate")]
        public async Task<BusinessProposalTemplateDTO> UpdateTemplate(BusinessProposalTemplateDTO model)
        {
            var item = GetAvailableTemplates().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (BusinessProposalTemplateDTO)DBService.TryUpdateEntity(DB.BusinessProposalTemplates, model, item);
        }


        [HttpDelete, Route("DeleteTemplate")]
        public async Task DeleteTemplate(int id)
        {
            var item = GetAvailableTemplates().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.BusinessProposalTemplates, item);
        }


        #endregion

        #region Плейсхолдеры для шаблонов КП

        [HttpPost, Route("CreateTemplatePlaceholder")]
        public async Task<BPTemplatePlaceholderDTO> CreateTemplatePlaceholder(int templateId, BPTemplatePlaceholderDTO model)
        {
            ThrowIfTemplateExist(templateId);
            return (BPTemplatePlaceholderDTO)DBService.TryCreateEntity(DB.BPTemplatePlaceholders, model, (entity) =>
            {
                entity.BusinessProposalTemplateId = templateId;
            });
        }


        [HttpPut, Route("UpdateTemplatePlaceholder")]
        public async Task<BPTemplatePlaceholderDTO> UpdateTemplatePlaceholder(BPTemplatePlaceholderDTO model)
        {
            var item = TryGetTemplatePlaceholder(model.Id);
            return (BPTemplatePlaceholderDTO)DBService.TryUpdateEntity(DB.BPTemplatePlaceholders, model, item);
        }


        [HttpDelete, Route("DeleteTemplatePlaceholder")]
        public async Task DeleteTemplatePlaceholder(int id)
        {
            var item = TryGetTemplatePlaceholder(id);
            DBService.TryDeleteEntity(DB.BPTemplatePlaceholders, item);
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
