using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.Funnel;
using Alfateam.Sales.Models.Funnel;
using Alfateam2._0.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers
{
    public class SaleFunnelsController : AbsController
    {
        public SaleFunnelsController(ControllerParams @params) : base(@params)
        {
        }


        #region Воронки продаж

        [HttpGet, Route("GetSaleFunnels")]
        public async Task<ItemsWithTotalCount<SalesFunnelDTO>> GetSaleFunnels(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<SalesFunnel, SalesFunnelDTO>(GetAvailableSalesFunnels(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetSaleFunnel")]
        public async Task<SalesFunnelDTO> GetSaleFunnel(int id)
        {
            return (SalesFunnelDTO)DBService.TryGetOne(GetAvailableSalesFunnels(), id, new SalesFunnelDTO());
        }


        [HttpPost, Route("CreateSaleFunnel")]
        public async Task<SalesFunnelDTO> CreateSaleFunnel(SalesFunnelDTO model)
        {
            return (SalesFunnelDTO)DBService.TryCreateEntity(DB.SalesFunnels, model, (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            });
        }

        [HttpPut, Route("UpdateSaleFunnel")]
        public async Task<SalesFunnelDTO> UpdateSaleFunnel(SalesFunnelDTO model)
        {
            var item = GetAvailableSalesFunnels().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (SalesFunnelDTO)DBService.TryUpdateEntity(DB.SalesFunnels, model, item);
        }





        [HttpDelete, Route("DeleteSaleFunnel")]
        public async Task DeleteSaleFunnel(int id)
        {
            var item = GetAvailableSalesFunnels().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.SalesFunnels, item);
        }

        #endregion

        #region Этапы воронок продаж

        [HttpPost, Route("CreateSaleFunnelStage")]
        public async Task<SalesFunnelStageDTO> CreateSaleFunnelStage(int funnelId, SalesFunnelStageDTO model)
        {
            ThrowIfFunnelDontExist(funnelId);

            return (SalesFunnelStageDTO)DBService.TryCreateEntity(DB.SalesFunnelStages, model, (entity) =>
            {
                entity.SalesFunnelId = funnelId;
            });
        }

        [HttpPut, Route("UpdateSaleFunnelStage")]
        public async Task<SalesFunnelStageDTO> UpdateSaleFunnelStage(SalesFunnelStageDTO model)
        {
            var item = TryGetFunnelStage(model.Id);
            return (SalesFunnelStageDTO)DBService.TryUpdateEntity(DB.SalesFunnelStages, model, item);
        }

        [HttpDelete, Route("DeleteSaleFunnelStage")]
        public async Task DeleteSaleFunnelStage(int id)
        {
            var item = TryGetFunnelStage(id);
            DBService.TryDeleteEntity(DB.SalesFunnelStages, item);
        }

        #endregion

        #region Типы этапов воронок продаж

        [HttpGet, Route("GetSaleFunnelStageTypes")]
        public async Task<ItemsWithTotalCount<SalesFunnelStageTypeDTO>> GetSaleFunnelStageTypes(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<SalesFunnelStageType, SalesFunnelStageTypeDTO>(GetAvailableSalesFunnelTypes(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetSaleFunnelStageType")]
        public async Task<SalesFunnelStageTypeDTO> GetSaleFunnelStageType(int id)
        {
            return (SalesFunnelStageTypeDTO)DBService.TryGetOne(GetAvailableSalesFunnelTypes(), id, new SalesFunnelStageTypeDTO());
        }





        [HttpPost, Route("CreateSaleFunnelStageType")]
        public async Task<SalesFunnelStageTypeDTO> CreateSaleFunnelStageType(SalesFunnelStageTypeDTO model)
        {
            return (SalesFunnelStageTypeDTO)DBService.TryCreateEntity(DB.SalesFunnelStageTypes, model, (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            });
        }

        [HttpPut, Route("UpdateSaleFunnelStageType")]
        public async Task<SalesFunnelStageTypeDTO> UpdateSaleFunnelStageType(SalesFunnelStageTypeDTO model)
        {
            var item = GetAvailableSalesFunnelTypes().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (SalesFunnelStageTypeDTO)DBService.TryUpdateEntity(DB.SalesFunnelStageTypes, model, item);
        }



        [HttpDelete, Route("DeleteSaleFunnelStageType")]
        public async Task DeleteSaleFunnelStageType(int id)
        {
            var item = GetAvailableSalesFunnelTypes().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.SalesFunnelStageTypes, item);
        }


        #endregion










        #region Private methods

        private IEnumerable<SalesFunnel> GetAvailableSalesFunnels()
        {
            return DB.SalesFunnels.Include(o => o.Stages).ThenInclude(o => o.Type)
                                  .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }
        private IEnumerable<SalesFunnelStageType> GetAvailableSalesFunnelTypes()
        {
            return DB.SalesFunnelStageTypes.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        private void ThrowIfFunnelDontExist(int funnelId)
        {
            DBService.TryGetOne(GetAvailableSalesFunnels(), funnelId);
        }

        private SalesFunnelStage TryGetFunnelStage(int stageId)
        {
            var stage = DBService.TryGetOne(DB.SalesFunnelStages, stageId);
            if(!GetAvailableSalesFunnels().Any(o => o.Id == stage.SalesFunnelId))
            {
                throw new Exception403("Нет доступа к данной сущности");
            }
            return stage;
        }

        #endregion
    }
}
