using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Telephony.API.Abstractions;
using Alfateam.Telephony.API.Enums;
using Alfateam.Telephony.API.Models;
using Alfateam.Telephony.API.Models.DTO;
using Alfateam.Telephony.API.Models.DTO.HLR;
using Alfateam.Telephony.API.Models.DTO.HLR.Results;
using Alfateam.Telephony.API.Models.SearchFilters;
using Alfateam.Telephony.Models;
using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.HLR;
using Alfateam.Telephony.Models.HLR.Results;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Telephony.API.Controllers
{
    public class HLRController : AbsAuthorizedController
    {
        public HLRController(ControllerParams @params) : base(@params)
        {
        }

        #region HLR задачи

        [HttpGet, Route("GetHLRTasks")]
        public async Task<ItemsWithTotalCount<HLRTaskDTO>> GetHLRTasks(HLRTasksSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<HLRTask, HLRTaskDTO>(GetHLRTasks(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if(filter.Status != null)
                {
                    condition &= entity.Status == filter.Status;
                }

                return condition;
            });
        }

        [HttpGet, Route("GetHLRTask")]
        public async Task<HLRTaskDTO> GetHLRTask(int id)
        {
            return (HLRTaskDTO)DBService.TryGetOne(GetHLRTasks(), id, new HLRTaskDTO());
        }




        [HttpGet, Route("SetHLRTaskStatus")]
        public async Task SetHLRTaskStatus(int id, HLRTaskSetStatusType status)
        {
            var task = DBService.TryGetOne(GetHLRTasks(), id);
            if (task.Status == HLRTaskStatus.Finished)
            {
                throw new Exception400("Невозможно изменить статус, задача уже выполнена");
            }
            else if (task.Status != HLRTaskStatus.Active && status == HLRTaskSetStatusType.Cancel)
            {
                throw new Exception400("Невозможно отменить, задача не в работе");
            }
            else if (task.Status != HLRTaskStatus.NotStarted && status == HLRTaskSetStatusType.Start)
            {
                throw new Exception400("Невозможно запустить, задача уже в работе");
            }

            switch (status)
            {
                case HLRTaskSetStatusType.Start:
                    task.Status = HLRTaskStatus.Active;
                    //TODO: фактический старт HLR задачи
                    break;
                case HLRTaskSetStatusType.Cancel:
                    task.Status = HLRTaskStatus.Cancelled;
                    //TODO: фактическая отмена HLR задачи
                    break;
                default:
                    throw new NotImplementedException("Не реализовано, это баг. Напишите в саппорт, если вы столкнулись с ошибкой");
            }

            DBService.UpdateEntity(DB.HLRTasks, task);
        }




        [HttpPost, Route("CreateHLRTask")]
        public async Task<HLRTaskDTO> CreateHLRTask(HLRTaskDTO model)
        {
            return (HLRTaskDTO)DBService.TryCreateEntity(DB.HLRTasks, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление HLR задачи", $"Добавлена HLR задача {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateHLRTask")]
        public async Task<HLRTaskDTO> UpdateHLRTask(HLRTaskDTO model)
        {
            var item = GetHLRTasks().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (item.Status != HLRTaskStatus.NotStarted && item.Status == HLRTaskStatus.Cancelled)
            {
                throw new Exception400("Невозможно отредактировать задачу, пока она в работе");
            }

            return (HLRTaskDTO)DBService.TryUpdateEntity(DB.HLRTasks, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование HLR задачи", $"Отредактирована HLR задача с id={item.Id}");
            });
        }

        [HttpDelete, Route("DeleteHLRTask")]
        public async Task DeleteHLRTask(int id)
        {
            var item = GetHLRTasks().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if(item.Status != HLRTaskStatus.NotStarted && item.Status == HLRTaskStatus.Cancelled)
            {
                throw new Exception400("Невозможно удалить задачу, пока она в работе");
            }

            DBService.TryDeleteEntity(DB.HLRTasks, item);
            this.AddHistoryAction("Удаление HLR задачи", $"Удалена HLR задача {item.Title} с id={id}");
        }

        #endregion

        #region Результаты выполнения HLR задачи

        [HttpGet, Route("GetHLRTaskResults")]
        public async Task<ItemsWithTotalCount<HLRTaskIterationResultDTO>> GetHLRTaskResults(HLRTaskResultsSearchFilter filter)
        {
            var task = DBService.TryGetOne(GetHLRTasks(), filter.TaskId);
            var iterationResults = DB.HLRTaskIterationResults.Where(o => o.HLRTaskId == task.Id);

            if(filter.IterationId != null)
            {
                iterationResults = iterationResults.Where(o => o.IterationId == filter.IterationId);
            }

            foreach(var iterationResult in iterationResults)
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    iterationResult.Numbers = iterationResult.Numbers.Where(o => o.Phone.Contains(filter.Query, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                if (filter.IsActive != null)
                {
                    iterationResult.Numbers = iterationResult.Numbers.Where(o => o.IsActive == filter.IsActive).ToList();
                }
                if (!string.IsNullOrEmpty(filter.Status))
                {
                    iterationResult.Numbers = iterationResult.Numbers.Where(o => o.Status.Contains(filter.Query, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                if (!string.IsNullOrEmpty(filter.MCC))
                {
                    iterationResult.Numbers = iterationResult.Numbers.Where(o => o.MCC.Contains(filter.Query, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                if (!string.IsNullOrEmpty(filter.MNC))
                {
                    iterationResult.Numbers = iterationResult.Numbers.Where(o => o.MNC.Contains(filter.Query, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                if (!string.IsNullOrEmpty(filter.OriginalNetworkName))
                {
                    iterationResult.Numbers = iterationResult.Numbers.Where(o => o.OriginalNetworkName.Contains(filter.Query, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                if (!string.IsNullOrEmpty(filter.ErrorDescription))
                {
                    iterationResult.Numbers = iterationResult.Numbers.Where(o => o.ErrorDescription.Contains(filter.Query, StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }

            return DBService.GetManyWithTotalCount<HLRTaskIterationResult, HLRTaskIterationResultDTO>(iterationResults, filter.Offset, filter.Count);
        }

        #endregion







        #region Private methods
        private IEnumerable<HLRTask> GetHLRTasks()
        {
            return DB.HLRTasks.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
