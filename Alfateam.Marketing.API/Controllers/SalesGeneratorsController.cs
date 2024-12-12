using Alfateam.Core;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Enums;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO;
using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.API.Models.SearchFilters;
using Alfateam.Marketing.Models;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.SalesGenerators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Marketing.API.Controllers
{
    public class SalesGeneratorsController : AbsController
    {
        public SalesGeneratorsController(ControllerParams @params) : base(@params)
        {
        }

        #region Генераторы продаж

        [HttpGet, Route("GetSalesGenerators")]
        public async Task<ItemsWithTotalCount<SalesGeneratorDTO>> GetSalesGenerators(SalesGeneratorsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<SalesGenerator, SalesGeneratorDTO>(GetAvailableSalesGenerators(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if (filter.ModelType == SalesGeneratorsModelType.Leads)
                {
                    condition &= entity is RepeatLeadsSalesGenerator;
                }
                if (filter.ModelType == SalesGeneratorsModelType.Customers)
                {
                    condition &= entity is RepeatOrdersSalesGenerator;
                }
                return condition;
            });
        }

        [HttpGet, Route("GetSalesGenerator")]
        public async Task<SalesGeneratorDTO> GetSalesGenerator(int id)
        {
            return (SalesGeneratorDTO)DBService.TryGetOne(GetAvailableSalesGenerators(), id, new SalesGeneratorDTO());
        }





        [HttpPost, Route("CreateSalesGenerator")]
        public async Task<SalesGeneratorDTO> CreateSalesGenerator(SalesGeneratorDTO model)
        {
            return (SalesGeneratorDTO)DBService.TryCreateEntity(DB.SalesGenerators, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление генератора продаж", $"Добавлен генератор продаж {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateSalesGenerator")]
        public async Task<SalesGeneratorDTO> UpdateSalesGenerator(SalesGeneratorDTO model)
        {
            var item = GetAvailableSalesGenerators().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (SalesGeneratorDTO)DBService.TryUpdateEntity(DB.SalesGenerators, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование генератора продаж", $"Отредактирован генератор продаж с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteSalesGenerator")]
        public async Task DeleteSalesGenerator(int id)
        {
            var item = GetAvailableSalesGenerators().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.SalesGenerators, item);

            this.AddHistoryAction("Удаление генератора продаж", $"Удален генератор продаж {item.Title} с id={id}");
        }





        #endregion








        #region Private methods

        private IEnumerable<SalesGenerator> GetAvailableSalesGenerators()
        {
            //TODO: SalesGenerators includes
            return DB.SalesGenerators.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
