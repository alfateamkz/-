﻿using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.Integrations.API;
using Alfateam.Sales.API.Models.DTO.Orders;
using Alfateam.Sales.API.Models.SearchFilters;
using Alfateam.Sales.Models.Integrations.API;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Sales.API.Controllers.Integrations
{
    [Route("Integrations/[controller]")]
    public class AlfateamAPIController : AbsController
    {
        public AlfateamAPIController(ControllerParams @params) : base(@params)
        {
        }

        #region CRUD операции с API ключами

        [HttpGet, Route("GetAPIKeys")]
        public async Task<ItemsWithTotalCount<AlfateamAPIKeyDTO>> GetAPIKeys(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<AlfateamAPIKey, AlfateamAPIKeyDTO>(GetAvailableAPIKeys(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetAPIKey")]
        public async Task<AlfateamAPIKeyDTO> GetAPIKey(int id)
        {
            return (AlfateamAPIKeyDTO)DBService.TryGetOne(GetAvailableAPIKeys(), id, new AlfateamAPIKeyDTO());
        }

        [HttpGet, Route("GetDefaultAPIKey")]
        public async Task<string> GetDefaultAPIKey()
        {
            return DB.AlfateamAPIKeys.FirstOrDefault(o => o.IsDefault && o.BusinessId == this.BusinessId && !o.IsDeleted).Key;
        }




        [HttpPost, Route("CreateAPIKey")]
        public async Task<AlfateamAPIKeyDTO> CreateAPIKey(AlfateamAPIKeyDTO model)
        {
            return (AlfateamAPIKeyDTO)DBService.TryCreateEntity(DB.AlfateamAPIKeys, model, callback: (entity) =>
            {
                entity.BusinessId = (int)this.BusinessId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление API ключа", $"Добавлен API ключ {entity.Title} - {entity.Key}");
            });
        }

        [HttpPut, Route("UpdateAPIKey")]
        public async Task<AlfateamAPIKeyDTO> UpdateAPIKey(AlfateamAPIKeyDTO model)
        {
            var item = DBService.TryGetOne(GetAvailableAPIKeys(), model.Id);
            return (AlfateamAPIKeyDTO)DBService.TryUpdateEntity(DB.AlfateamAPIKeys, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование API ключа", $"Отредактирован API ключ с id={entity.Id}");
            });
        }

        [HttpPut, Route("RefreshAPIKey")]
        public async Task<string> RefreshAPIKey(int id)
        {
            var item = DBService.TryGetOne(GetAvailableAPIKeys(), id);
            item.Key = System.Guid.NewGuid().ToString();

            DBService.UpdateEntity(DB.AlfateamAPIKeys, item);
            return item.Key;
        }

        [HttpDelete, Route("DeleteAPIKey")]
        public async Task DeleteAPIKey(int id)
        {
            var item = DBService.TryGetOne(GetAvailableAPIKeys(), id);
            if (item.PaidBefore != null && item.PaidBefore > DateTime.UtcNow)
            {
                throw new Exception403($"Нельзя удалить API ключ, так как он оплачен до {item.PaidBefore.Value} по UTC\r\n" +
                                       $"Вы можете деактивировать API ключ в настройках");
            }

            DBService.TryDeleteEntity(DB.AlfateamAPIKeys, item);
            this.AddHistoryAction("Удаление API ключа", $"Удален API ключ {item.Title} с id={id}");
        }

        #endregion

        #region История запросов по API ключам

        [HttpGet, Route("GetAPIKeyRequests")]
        public async Task<ItemsWithTotalCount<AlfateamAPIRequestEntryDTO>> GetAPIKeyRequests(AlfateamAPIKeysSearchFilter filter)
        {
            var key = DBService.TryGetOne(GetAvailableAPIKeys(), filter.ApiKeyId);
            var datePeriod = filter.DateFilter.GetPeriod();

            var requests = DB.AlfateamAPIRequestEntries.Where(o => o.AlfateamAPIKeyId == key.Id)
                                                       .Where(o => o.CreatedAt >= datePeriod.From && o.CreatedAt <= datePeriod.To);

            return DBService.GetManyWithTotalCount<AlfateamAPIRequestEntry, AlfateamAPIRequestEntryDTO>(requests, filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.URL.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetAPIKeyRequest")]
        public async Task<AlfateamAPIRequestEntryDTO> GetAPIKeyRequest(int apiKeyId,int requestId)
        {
            var key = DBService.TryGetOne(GetAvailableAPIKeys(), apiKeyId);
            var requests = DB.AlfateamAPIRequestEntries.Where(o => o.AlfateamAPIKeyId == key.Id);

            return (AlfateamAPIRequestEntryDTO)DBService.TryGetOne(requests, requestId, new AlfateamAPIRequestEntryDTO());
        }


        #endregion










        #region Private methods
        private IEnumerable<AlfateamAPIKey> GetAvailableAPIKeys()
        {
            return DB.AlfateamAPIKeys.Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId && !o.IsDefault);
        }

        #endregion
    }
}
