using Alfateam.Core;
using Alfateam.Telephony.API.Abstractions;
using Alfateam.Telephony.API.Models;
using Alfateam.Telephony.API.Models.DTO.Abstractions;
using Alfateam.Telephony.Models.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Telephony.API.Controllers
{
    public class ExtLinesController : AbsAuthorizedController
    {
        public ExtLinesController(ControllerParams @params) : base(@params)
        {
        }

        #region Внешние линии

        [HttpGet, Route("GetExtLines")]
        public async Task<ItemsWithTotalCount<ExtLineDTO>> GetExtLines(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<ExtLine, ExtLineDTO>(GetAvailableExtLines(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetExtLine")]
        public async Task<ExtLineDTO> GetExtLine(int id)
        {
            return (ExtLineDTO)DBService.TryGetOne(GetAvailableExtLines(), id, new ExtLineDTO());
        }





        [HttpPost, Route("CreateExtLine")]
        public async Task<ExtLineDTO> CreateExtLine(ExtLineDTO model)
        {
            return (ExtLineDTO)DBService.TryCreateEntity(DB.ExtLines, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление внешнего взаимодействия", $"Добавлено внешнее взаимодействие {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateExtLine")]
        public async Task<ExtLineDTO> UpdateExtLine(ExtLineDTO model)
        {
            var item = GetAvailableExtLines().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (ExtLineDTO)DBService.TryUpdateEntity(DB.ExtLines, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование внешнего взаимодействия", $"Отредактировано внешнее взаимодействие с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteExtLine")]
        public async Task DeleteExtLine(int id)
        {
            var item = GetAvailableExtLines().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.ExtLines, item);

            this.AddHistoryAction("Удаление внешнего взаимодействия", $"Удалено внешнее взаимодействие {item.Title} с id={id}");
        }



        #endregion


        //TODO: реализовать логику их работы, круд сделан только





        #region Private methods
        private IEnumerable<ExtLine> GetAvailableExtLines()
        {
            return DB.ExtLines.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
