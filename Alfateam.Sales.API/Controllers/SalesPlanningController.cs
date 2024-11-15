using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.Funnel;
using Alfateam.Sales.API.Models.DTO.Plan;
using Alfateam.Sales.API.Models.DTO.Scripting;
using Alfateam.Sales.Models.Plan;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.Sales.API.Controllers
{
    public class SalesPlanningController : AbsController
    {
        public SalesPlanningController(ControllerParams @params) : base(@params)
        {
        }

        #region Планирование продаж

        [HttpGet, Route("GetSalesPlannings")]
        public async Task<ItemsWithTotalCount<SalesPlanningDTO>> GetSalesPlannings(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<SalesPlanning, SalesPlanningDTO>(GetAvailableSalesPlannings(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetSalesPlanning")]
        public async Task<SalesPlanningDTO> GetSalesPlanning(int id)
        {
            return (SalesPlanningDTO)DBService.TryGetOne(GetAvailableSalesPlannings(), id, new SalesPlanningDTO());
        }

        [HttpGet, Route("GetActualSalesPlanning")]
        public async Task<SalesPlanningDTO> GetActualSalesPlanning()
        {
            var actualPlan = GetAvailableSalesPlannings().FirstOrDefault(o => o.IsInPeriod(DateTime.UtcNow));
            if(actualPlan == null)
            {
                throw new Exception404("Пока еще не задан план продаж на текущую дату");
            }
            return (SalesPlanningDTO)new SalesPlanningDTO().CreateDTO(actualPlan);
        }





        [HttpPost, Route("CreateSalesPlanning")]
        public async Task<SalesPlanningDTO> CreateSalesPlanning(SalesPlanningDTO model)
        {
            ThrowIfSalesPlanningNotVaild(model);
            return (SalesPlanningDTO)DBService.TryCreateEntity(DB.SalesPlannings, model, (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление планирования продаж", $"Добавлено планирование продаж {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateSalesPlanning")]
        public async Task<SalesPlanningDTO> UpdateSalesPlanning(SalesPlanningDTO model)
        {
            var item = GetAvailableSalesPlannings().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            ThrowIfSalesPlanningNotVaild(model);
            return (SalesPlanningDTO)DBService.TryUpdateEntity(DB.SalesPlannings, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование планирования продаж", $"Отредактировано планирование продаж с id={entity.Id}");
            });
        }


        [HttpDelete, Route("DeleteSalesPlanning")]
        public async Task DeleteSalesPlanning(int id)
        {
            var item = GetAvailableSalesPlannings().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.SalesPlannings, item);

            this.AddHistoryAction("Удаление планирования продаж", $"Удалено планирование продаж {item.Title} с id={id}");
        }



        #endregion

        #region Планы продаж

        [HttpPost, Route("CreateSalesPlan")]
        public async Task<SalesPlanDTO> CreateSalesPlan(int planningId, SalesPlanDTO model)
        {
            ThrowIfPlanningDontExist(planningId);
            return (SalesPlanDTO)DBService.TryCreateEntity(DB.SalesPlans, model, (entity) =>
            {
                entity.SalesPlanningId = planningId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление плана продаж", $"Добавлен план продаж {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateSalesPlan")]
        public async Task<SalesPlanDTO> UpdateSalesPlan(SalesPlanDTO model)
        {
            var item = TryGetSalesPlan(model.Id);
            return (SalesPlanDTO)DBService.TryUpdateEntity(DB.SalesPlans, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование плана продаж", $"Отредактирован план продаж с id={entity.Id}");
            });
        }

        [HttpDelete, Route("DeleteSalesPlan")]
        public async Task DeleteSalesPlan(int id)
        {
            var item = TryGetSalesPlan(id);
            DBService.TryDeleteEntity(DB.SalesPlans, item);

            this.AddHistoryAction("Удаление плана продаж", $"Удален план продаж {item.Title} с id={id}");
        }

        #endregion

        #region Пункты плана продаж

        [HttpPost, Route("CreateSalesPlanItem")]
        public async Task<SalesPlanItemDTO> CreateSalesPlanItem(int planId, SalesPlanItemDTO model)
        {
            ThrowIfPlanDontExist(planId);
            return (SalesPlanItemDTO)DBService.TryCreateEntity(DB.SalesPlanItems, model, (entity) =>
            {
                entity.SalesPlanId = planId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление пункта плана продаж", $"Добавлен пункт плана продаж {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateSalesPlanItem")]
        public async Task<SalesPlanItemDTO> UpdateSalesPlanItem(SalesPlanItemDTO model)
        {
            var item = TryGetSalesPlanItem(model.Id);
            return (SalesPlanItemDTO)DBService.TryUpdateEntity(DB.SalesPlanItems, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование пункта плана продаж", $"Отредактирован пункт плана продаж с id={entity.Id}");
            });
        }

        [HttpDelete, Route("DeleteSalesPlanItem")]
        public async Task DeleteSalesPlanItem(int id)
        {
            var item = TryGetSalesPlanItem(id);
            DBService.TryDeleteEntity(DB.SalesPlanItems, item);

            this.AddHistoryAction("Удаление пункта плана продаж", $"Удален пункт плана продаж {item.Title} с id={id}");
        }


        #endregion







        #region Private methods
        private IEnumerable<SalesPlanning> GetAvailableSalesPlannings()
        {
            return DB.SalesPlannings.Include(o => o.Plans).ThenInclude(o => o.Items)
                                    .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }
        private void ThrowIfSalesPlanningNotVaild(SalesPlanningDTO model)
        {
            if (GetAvailableSalesPlannings().Any(o => o.IsInPeriod(model.StartDate) || o.IsInPeriod(model.EndDate)))
            {
                throw new Exception403("Уже задано планирование, который попадает в дату начала или дату завершения");
            }
            else if (model.StartDate < DateTime.UtcNow || model.EndDate < DateTime.UtcNow)
            {
                throw new Exception400("Дата начала и завершения планирования должна быть позже сегодняшнего дня");
            }
            else if (model.StartDate >= model.EndDate)
            {
                throw new Exception400("Дата завершения должна быть позже даты начала планирования");
            }

        }



        private void ThrowIfPlanningDontExist(int planningId)
        {
            DBService.TryGetOne(GetAvailableSalesPlannings(), planningId);
        }
        private SalesPlan TryGetSalesPlan(int planId)
        {
            var plan = DBService.TryGetOne(DB.SalesPlans, planId);
            if (!GetAvailableSalesPlannings().Any(o => o.Id == plan.SalesPlanningId))
            {
                throw new Exception403("Нет доступа к данной сущности");
            }
            return plan;
        }




        private void ThrowIfPlanDontExist(int planId)
        {
            TryGetSalesPlan(planId);
        }
        private SalesPlanItem TryGetSalesPlanItem(int itemId)
        {
            var item = DBService.TryGetOne(DB.SalesPlanItems, itemId);
            ThrowIfPlanDontExist(item.SalesPlanId);

            return item;
        }

        #endregion
    }
}
