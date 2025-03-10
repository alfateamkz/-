﻿using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.Abstractions;
using Alfateam.Sales.API.Models.DTO.BusinessProposals;
using Alfateam.Sales.API.Models.DTO.Invoices;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.BusinessProposals;
using Alfateam.Sales.Models.Invoices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers.Invoices
{
    [Route("Invoices/[controller]")]
    public class InvoiceTemplatesController : AbsController
    {
        public InvoiceTemplatesController(ControllerParams @params) : base(@params)
        {
        }

        #region Шаблоны счетов на оплату

        [HttpGet, Route("GetTemplates")]
        public async Task<ItemsWithTotalCount<InvoiceTemplateDTO>> GetTemplates(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<InvoiceTemplate, InvoiceTemplateDTO>(GetAvailableTemplates(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetTemplate")]
        public async Task<InvoiceTemplateDTO> GetTemplate(int id)
        {
            return (InvoiceTemplateDTO)DBService.TryGetOne(GetAvailableTemplates(), id, new InvoiceTemplateDTO());
        }



        [HttpPost, Route("CreateTemplate")]
        public async Task<InvoiceTemplateDTO> CreateSaleFunnel(InvoiceTemplateDTO model)
        {
            return (InvoiceTemplateDTO)DBService.TryCreateEntity(DB.InvoiceTemplates, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление шаблона счета на оплату", $"Добавлен шаблон счета на оплату {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateTemplate")]
        public async Task<InvoiceTemplateDTO> UpdateTemplate(InvoiceTemplateDTO model)
        {
            var item = GetAvailableTemplates().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (InvoiceTemplateDTO)DBService.TryUpdateEntity(DB.InvoiceTemplates, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование шаблона счета на оплату", $"Отредактирован шаблон счета на оплату с id={entity.Id}");
            });
        }


        [HttpDelete, Route("DeleteTemplate")]
        public async Task DeleteTemplate(int id)
        {
            var item = GetAvailableTemplates().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.InvoiceTemplates, item);

            this.AddHistoryAction("Удаление шаблона счета на оплату", $"Удален шаблон счета на оплату {item.Title} с id={id}");
        }

        #endregion

        #region Плейсхолдеры для шаблонов счетов на оплату

        [HttpPost, Route("CreateTemplatePlaceholder")]
        public async Task<InvoiceTemplatePlaceholderDTO> CreateTemplatePlaceholder(int templateId, InvoiceTemplatePlaceholderDTO model)
        {
            ThrowIfTemplateExist(templateId);
            return (InvoiceTemplatePlaceholderDTO)DBService.TryCreateEntity(DB.InvoiceTemplatePlaceholders, model, (entity) =>
            {
                entity.InvoiceTemplateId = templateId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление плейсхолдера к шаблону счета на оплату", $"Добавлен плейсхолдер {entity.PlaceholderName} к шаблону счета на оплату");
            });
        }

        [HttpPut, Route("UpdateTemplatePlaceholder")]
        public async Task<InvoiceTemplatePlaceholderDTO> UpdateTemplatePlaceholder(InvoiceTemplatePlaceholderDTO model)
        {
            var item = TryGetTemplatePlaceholder(model.Id);
            return (InvoiceTemplatePlaceholderDTO)DBService.TryUpdateEntity(DB.InvoiceTemplatePlaceholders, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование плейсхолдера к шаблону счета на оплату", $"Отредактирован плейсхолдер к шаблону счета на оплату с id={entity.Id}");
            });
        }

        [HttpDelete, Route("DeleteTemplatePlaceholder")]
        public async Task DeleteTemplatePlaceholder(int id)
        {
            var item = TryGetTemplatePlaceholder(id);
            DBService.TryDeleteEntity(DB.InvoiceTemplatePlaceholders, item);

            this.AddHistoryAction("Удаление плейсхолдера к шаблону счета на оплату", $"Удален плейсхолдер {item.PlaceholderName} к шаблону счета на оплату с id={id}");
        }


        #endregion






        #region Private methods

        private IEnumerable<InvoiceTemplate> GetAvailableTemplates()
        {
            return DB.InvoiceTemplates.Include(o => o.Placeholders)
                                      .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        private void ThrowIfTemplateExist(int funnelId)
        {
            DBService.TryGetOne(GetAvailableTemplates(), funnelId);
        }

        private InvoiceTemplatePlaceholder TryGetTemplatePlaceholder(int placeholderId)
        {
            var placeholder = DBService.TryGetOne(DB.InvoiceTemplatePlaceholders, placeholderId);
            if (!GetAvailableTemplates().Any(o => o.Id == placeholder.InvoiceTemplateId))
            {
                throw new Exception403("Нет доступа к данной сущности");
            }
            return placeholder;
        }

        #endregion
    }
}
