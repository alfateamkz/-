using Alfateam.Core;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO;
using Alfateam.Marketing.API.Models.DTO.Templates;
using Alfateam.Marketing.API.Models.SearchFilters;
using Alfateam.Marketing.Models;
using Alfateam.Marketing.Models.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Marketing.API.Controllers
{
    public class TemplatesController : AbsController
    {
        public TemplatesController(ControllerParams @params) : base(@params)
        {
        }

        #region Шаблоны

        [HttpGet, Route("GetTemplates")]
        public async Task<ItemsWithTotalCount<TemplateDTO>> GetTemplates(TemplatesSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Template, TemplateDTO>(GetAvailableTemplates(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if (filter.ContactType != null)
                {
                    condition &= entity.Type == filter.ContactType;
                }
                return condition;
            });
        }

        [HttpGet, Route("GetTemplate")]
        public async Task<TemplateDTO> GetTemplate(int id)
        {
            return (TemplateDTO)DBService.TryGetOne(GetAvailableTemplates(), id, new TemplateDTO());
        }





        [HttpPost, Route("CreateTemplate")]
        public async Task<TemplateDTO> CreateTemplate(TemplateDTO model)
        {
            return (TemplateDTO)DBService.TryCreateEntity(DB.Templates, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление шаблона", $"Добавлен шаблон {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateTemplate")]
        public async Task<TemplateDTO> UpdateTemplate(TemplateDTO model)
        {
            var item = GetAvailableTemplates().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (TemplateDTO)DBService.TryUpdateEntity(DB.Templates, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование шаблона", $"Отредактирован шаблон с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteTemplate")]
        public async Task DeleteTemplate(int id)
        {
            var item = GetAvailableTemplates().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.Templates, item);

            this.AddHistoryAction("Удаление шаблона", $"Удален шаблон {item.Title} с id={id}");
        }





        #endregion








        #region Private methods

        private IEnumerable<Template> GetAvailableTemplates()
        {
            return DB.Templates.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
