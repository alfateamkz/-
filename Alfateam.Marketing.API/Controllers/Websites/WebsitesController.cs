using Alfateam.Core;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.API.Models.DTO.Autoposting;
using Alfateam.Marketing.API.Models.DTO.Websites;
using Alfateam.Marketing.API.Models.SearchFilters.Websites;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Autoposting;
using Alfateam.Marketing.Models.Websites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteModel = Alfateam.Marketing.Models.Websites.Website;

namespace Alfateam.Marketing.API.Controllers.Websites
{
    public class WebsitesController : AbsController
    {
        public WebsitesController(ControllerParams @params) : base(@params)
        {
        }


        #region Сайты

        [HttpGet, Route("GetWebsites")]
        public async Task<ItemsWithTotalCount<WebsiteDTO>> GetWebsites(WebsitesSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<WebsiteModel, WebsiteDTO>(GetAvailableWebsites(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &=  entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase)
                                  || entity.URL.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if(filter.GroupId != null)
                {
                    condition &= entity.GroupId == filter.GroupId;
                }

                return condition;
            });
        }

        [HttpGet, Route("GetWebsite")]
        public async Task<WebsiteDTO> GetWebsite(int id)
        {
            return (WebsiteDTO)DBService.TryGetOne(GetAvailableWebsites(), id, new WebsiteDTO());
        }





        [HttpPost, Route("CreateWebsite")]
        public async Task<WebsiteDTO> CreateWebsite(WebsiteDTO model)
        {
            return (WebsiteDTO)DBService.TryCreateEntity(DB.Websites, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление сайта", $"Добавлен сайт {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateWebsite")]
        public async Task<WebsiteDTO> UpdateWebsite(WebsiteDTO model)
        {
            var item = GetAvailableWebsites().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (WebsiteDTO)DBService.TryUpdateEntity(DB.Websites, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование сайта", $"Отредактирован сайт с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteWebsite")]
        public async Task DeleteWebsite(int id)
        {
            var item = GetAvailableWebsites().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.Websites, item);

            this.AddHistoryAction("Удаление сайта", $"Удален сайт {item.Title} с id={id}");
        }

        #endregion

        #region Категории сайтов

        [HttpGet, Route("GetWebsiteGroups")]
        public async Task<ItemsWithTotalCount<WebsiteGroupDTO>> GetWebsiteGroups(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<WebsiteGroup, WebsiteGroupDTO>(GetAvailableWebsiteGroups(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetWebsiteGroup")]
        public async Task<WebsiteGroupDTO> GetWebsiteGroup(int id)
        {
            return (WebsiteGroupDTO)DBService.TryGetOne(GetAvailableWebsiteGroups(), id, new WebsiteGroupDTO());
        }





        [HttpPost, Route("CreateWebsiteGroup")]
        public async Task<WebsiteGroupDTO> CreateWebsiteGroup(WebsiteGroupDTO model)
        {
            return (WebsiteGroupDTO)DBService.TryCreateEntity(DB.WebsiteGroups, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление категории (группы) сайтов", $"Добавлена категория (группа) сайтов {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateWebsiteGroup")]
        public async Task<WebsiteGroupDTO> UpdateWebsiteGroup(WebsiteGroupDTO model)
        {
            var item = GetAvailableWebsiteGroups().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (WebsiteGroupDTO)DBService.TryUpdateEntity(DB.WebsiteGroups, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование категории (группы) сайтов", $"Отредактирована категория (группа) сайтов с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteWebsiteGroup")]
        public async Task DeleteWebsiteGroup(int id)
        {
            var item = GetAvailableWebsiteGroups().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.WebsiteGroups, item);

            this.AddHistoryAction("Удаление категории (группы) сайтов", $"Удалена категория (группа) сайтов {item.Title} с id={id}");
        }


        #endregion








        #region Private methods

        private IEnumerable<WebsiteModel> GetAvailableWebsites()
        {
            return DB.Websites.Include(o => o.Group)
                              .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }


        private IEnumerable<WebsiteGroup> GetAvailableWebsiteGroups()
        {
            return DB.WebsiteGroups.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
