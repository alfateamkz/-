using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO;
using Alfateam.Sales.API.Models.DTO.Funnel;
using Alfateam.Sales.API.Models.DTO.Scripting;
using Alfateam.Sales.Models;
using Alfateam.Sales.Models.Scripting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers
{
    public class SalesScriptsController : AbsController
    {
        public SalesScriptsController(ControllerParams @params) : base(@params)
        {
        }


        #region Скрипты продаж

        [HttpGet, Route("GetSalesScripts")]
        public async Task<ItemsWithTotalCount<SalesScriptDTO>> GetSalesScripts(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<SalesScript, SalesScriptDTO>(GetAvailableSalesScripts(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetSalesScript")]
        public async Task<SalesScriptDTO> GetSalesScript(int id)
        {
            return (SalesScriptDTO)DBService.TryGetOne(GetAvailableSalesScripts(), id, new SalesScriptDTO());
        }




        [HttpPost, Route("CreateSalesScript")]
        public async Task<SalesScriptDTO> CreateSalesScript(SalesScriptDTO model)
        {
            return (SalesScriptDTO)DBService.TryCreateEntity(DB.SalesScripts, model, (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
                entity.StartBlock = new SalesScriptBlock
                {
                    Text = "Начало разговора",
                    Type = Sales.Models.Enums.SalesScriptBlockType.Intro,
                    BGHexColor = "#2FC6F6",
                    TextHexColor = "#000000",
                };
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление скрипта продаж", $"Добавлен скрипт продаж {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateSalesScript")]
        public async Task<SalesScriptDTO> UpdateSalesScript(SalesScriptDTO model)
        {
            var item = GetAvailableSalesScripts().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (SalesScriptDTO)DBService.TryUpdateEntity(DB.SalesScripts, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование скрипта продаж", $"Отредактирован скрипт продаж с id={entity.Id}");
            });
        }



        [HttpDelete, Route("DeleteSalesScript")]
        public async Task DeleteSalesScript(int id)
        {
            var item = GetAvailableSalesScripts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.SalesScripts, item);

            this.AddHistoryAction("Удаление скрипта продаж", $"Удален скрипт продаж {item.Title} с id={id}");
        }

        #endregion

        #region Блоки скриптов продаж

        [HttpPost, Route("CreateSalesScriptBlock")]
        public async Task<SalesScriptBlockDTO> CreateSalesScriptBlock(int scriptId, int parentBlockId, SalesScriptBlockDTO model)
        {
            ThrowIfScriptDontExist(scriptId);
            TryGetScriptBlock(parentBlockId);

            return (SalesScriptBlockDTO)DBService.TryCreateEntity(DB.SalesScriptBlocks, model, (entity) =>
            {
                entity.SalesScriptId = scriptId;
                entity.SalesScriptBlockId = parentBlockId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление блока в скрипте продаж", $"Добавлен блок в скрипте продаж {entity.Text}");
            });
        }

        [HttpPut, Route("UpdateSalesScriptBlock")]
        public async Task<SalesScriptBlockDTO> UpdateSalesScriptBlock(SalesScriptBlockDTO model)
        {
            var item = TryGetScriptBlock(model.Id);
            return (SalesScriptBlockDTO)DBService.TryUpdateEntity(DB.SalesScriptBlocks, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование блока в скрипте продаж", $"Отредактирован блок в скрипте продаж с id={entity.Id}");
            });
        }

        [HttpDelete, Route("DeleteSalesScriptBlock")]
        public async Task DeleteSalesScriptBlock(int id)
        {
            var item = TryGetScriptBlock(id);
            DBService.TryDeleteEntity(DB.SalesScriptBlocks, item);

            this.AddHistoryAction("Удаление блока в скрипте продаж", $"Удален блок в скрипте продаж {item.Text} с id={id}");
        }

        #endregion







        #region Private methods
        private IEnumerable<SalesScript> GetAvailableSalesScripts()
        {
            return DB.SalesScripts.Include(o => o.StartBlock).ThenInclude(o => o.Nodes)
                                  .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }


        private void ThrowIfScriptDontExist(int funnelId)
        {
            DBService.TryGetOne(GetAvailableSalesScripts(), funnelId);
        }

        private SalesScriptBlock TryGetScriptBlock(int blockId)
        {
            var block = DBService.TryGetOne(DB.SalesScriptBlocks, blockId);
            if (!GetAvailableSalesScripts().Any(o => o.Id == block.SalesScriptId))
            {
                throw new Exception403("Нет доступа к данной сущности");
            }
            return block;
        }
        #endregion

    }
}
