using Alfateam.Core;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO.MobileApps;
using Alfateam.Marketing.API.Models.SearchFilters.MobileApps;
using Alfateam.Marketing.Models.MobileApps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Marketing.API.Controllers.MobileApps
{
    public class MobileAppsController : AbsController
    {
        public MobileAppsController(ControllerParams @params) : base(@params)
        {
        }

        #region Сайты

        [HttpGet, Route("GetMobileApps")]
        public async Task<ItemsWithTotalCount<MobileAppDTO>> GetMobileApps(MobileAppsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<MobileApp, MobileAppDTO>(GetAvailableMobileApps(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if (filter.GroupId != null)
                {
                    condition &= entity.GroupId == filter.GroupId;
                }

                return condition;
            });
        }

        [HttpGet, Route("GetMobileApp")]
        public async Task<MobileAppDTO> GetMobileApp(int id)
        {
            return (MobileAppDTO)DBService.TryGetOne(GetAvailableMobileApps(), id, new MobileAppDTO());
        }





        [HttpPost, Route("CreateMobileApp")]
        public async Task<MobileAppDTO> CreateMobileApp(MobileAppDTO model)
        {
            return (MobileAppDTO)DBService.TryCreateEntity(DB.MobileApps, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление сайта", $"Добавлен сайт {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateMobileApp")]
        public async Task<MobileAppDTO> UpdateMobileApp(MobileAppDTO model)
        {
            var item = GetAvailableMobileApps().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (MobileAppDTO)DBService.TryUpdateEntity(DB.MobileApps, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование сайта", $"Отредактирован сайт с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteMobileApp")]
        public async Task DeleteMobileApp(int id)
        {
            var item = GetAvailableMobileApps().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.MobileApps, item);

            this.AddHistoryAction("Удаление сайта", $"Удален сайт {item.Title} с id={id}");
        }

        #endregion

        #region Категории сайтов

        [HttpGet, Route("GetMobileAppGroups")]
        public async Task<ItemsWithTotalCount<MobileAppGroupDTO>> GetMobileAppGroups(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<MobileAppGroup, MobileAppGroupDTO>(GetAvailableMobileAppGroups(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetMobileAppGroup")]
        public async Task<MobileAppGroupDTO> GetMobileAppGroup(int id)
        {
            return (MobileAppGroupDTO)DBService.TryGetOne(GetAvailableMobileAppGroups(), id, new MobileAppGroupDTO());
        }





        [HttpPost, Route("CreateMobileAppGroup")]
        public async Task<MobileAppGroupDTO> CreateMobileAppGroup(MobileAppGroupDTO model)
        {
            return (MobileAppGroupDTO)DBService.TryCreateEntity(DB.MobileAppGroups, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление категории (группы) сайтов", $"Добавлена категория (группа) сайтов {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateMobileAppGroup")]
        public async Task<MobileAppGroupDTO> UpdateMobileAppGroup(MobileAppGroupDTO model)
        {
            var item = GetAvailableMobileAppGroups().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (MobileAppGroupDTO)DBService.TryUpdateEntity(DB.MobileAppGroups, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование категории (группы) сайтов", $"Отредактирована категория (группа) сайтов с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteMobileAppGroup")]
        public async Task DeleteMobileAppGroup(int id)
        {
            var item = GetAvailableMobileAppGroups().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.MobileAppGroups, item);

            this.AddHistoryAction("Удаление категории (группы) сайтов", $"Удалена категория (группа) сайтов {item.Title} с id={id}");
        }


        #endregion








        #region Private methods

        private IEnumerable<MobileApp> GetAvailableMobileApps()
        {
            return DB.MobileApps.Include(o => o.Group)
                                .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }


        private IEnumerable<MobileAppGroup> GetAvailableMobileAppGroups()
        {
            return DB.MobileAppGroups.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
