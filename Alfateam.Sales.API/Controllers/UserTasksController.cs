using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.Abstractions.Tasks;
using Alfateam.Sales.API.Models.DTO.General.Security;
using Alfateam.Sales.API.Models.DTO.Orders;
using Alfateam.Sales.API.Models.DTO.Tasks.AsCompleted;
using Alfateam.Sales.API.Models.DTO.Tasks.CompletionCheck;
using Alfateam.Sales.API.Models.SearchFilters.Tasks;
using Alfateam.Sales.Models.Abstractions.Tasks;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.General.Security;
using Alfateam.Sales.Models.Tasks;
using Alfateam.Sales.Models.Tasks.AsCompleted;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Alfateam.Sales.API.Controllers
{
    public class UserTasksController : AbsController
    {
        public UserTasksController(ControllerParams @params) : base(@params)
        {
        }


        #region CRUD операции для задач

        [HttpGet, Route("GetTasksAssignedByMe")]
        public async Task<ItemsWithTotalCount<UserTaskDTO>> GetTasksAssignedByMe(TasksAssignedByMeSearchFilter filter)
        {
            var userId = this.AuthorizedUser.Id;

            var myActions = GetAvailableTasks().Where(o => o.CreatedById == userId && o.TaskForId != userId);
            return DBService.GetManyWithTotalCount<UserTask, UserTaskDTO>(myActions, filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (filter.Status != null)
                {
                    condition &= entity.Status == filter.Status;
                }
                if (filter.TaskForId != null)
                {
                    condition &= entity.TaskForId == filter.TaskForId;
                }
                if (filter.DeadlinePassed != null)
                {
                    condition &= entity.IsDeadlinePassed() == filter.DeadlinePassed;
                }

                return condition;
            });
        }

        [HttpGet, Route("GetTasksForMe")]
        public async Task<ItemsWithTotalCount<UserTaskDTO>> GetTasksForMe(TasksForMeSearchFilter filter)
        {
            var myActions = GetAvailableTasks().Where(o => o.TaskForId == this.AuthorizedUser.Id);
            return DBService.GetManyWithTotalCount<UserTask, UserTaskDTO>(myActions, filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (filter.Status != null)
                {
                    condition &= entity.Status == filter.Status;
                }
                if (filter.DeadlinePassed != null)
                {
                    condition &= entity.IsDeadlinePassed() == filter.DeadlinePassed;
                }

                return condition;
            });
        }




        [HttpPost, Route("CreateTask")]
        public async Task<UserTaskDTO> CreateTask(UserTaskDTO model)
        {
            var user = this.AuthorizedUser;

            return (UserTaskDTO)DBService.TryCreateEntity(DB.UserTasks, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
                entity.CreatedById = user.Id;
                entity.Status = UserTaskStatus.Active;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление задачи пользователю", $"Назначена задача {entity.Title} для пользователя с id={entity.TaskForId}");
            });
        }

        [HttpPut, Route("UpdateTask")]
        public async Task<UserTaskDTO> UpdateTask(UserTaskDTO model)
        {
            var item = GetAvailableTasks().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (UserTaskDTO)DBService.TryUpdateEntity(DB.UserTasks, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование задачи пользователю", $"Отредактирована задача с id={entity.Id} для пользователя с id={entity.TaskForId}");
            });
        }

        [HttpDelete, Route("DeleteTask")]
        public async Task DeleteTask(int id)
        {
            var item = GetAvailableTasks().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.UserTasks, item);

            this.AddHistoryAction("Удаление задачи пользователю", $"Удалена задача {item.Title} с id={id} для пользователя с id={item.TaskForId}");
        }

        #endregion

        #region Бизнес процесс, связанный с задачами

        [HttpPut, Route("MarkTaskAsCompleted")]
        public async Task<MarkedAsCompletedDTO> MarkTaskAsCompleted(int id, MarkedAsCompletedDTO model)
        {
            var task = DBService.TryGetOne(GetAvailableTasks(), id);
            if(task.TaskForId != this.AuthorizedUser.Id)
            {
                throw new Exception403("Данное действие может выполнить только тот, для кого задача создана");
            }
            else if (task.Status != UserTaskStatus.Active)
            {
                throw new Exception403("Данное действие можно выполнить только для активной задачи");
            }
            else if(model is SimpleMarkedAsCompletedDTO && task is not SimpleUserTask)
            {
                throw new Exception400("SimpleMarkedAsCompletedDTO предназначен только для SimpleUserTask");
            }
            else if (model is WithAmountMarkedAsCompletedDTO && task is not WithAmountUserTask)
            {
                throw new Exception400("WithAmountMarkedAsCompletedDTO предназначен только для WithAmountUserTask");
            }

            return (MarkedAsCompletedDTO)DBService.TryCreateEntity(DB.MarkedAsCompleted, model, callback: (entity) =>
            {
                entity.UserTaskId = task.Id;
            }, 
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Задача отмечена как выполненная", $"Задача {task.Title} с id={task.Id} отмечена как выполенная");
            });
        }

        [HttpPut, Route("SetTaskCompletionCheckResult")]
        public async Task<TaskCompletionCheckResultDTO> SetTaskCompletionCheckResult(int id, TaskCompletionCheckResultDTO model)
        {
            var task = DBService.TryGetOne(GetAvailableTasks(), id);
            ThrowIfTaskNotActiveOrUserNotCreator(task);

            if(task.CompletionCheckResults.Any(o => o.MarkedAsCompletedId == model.MarkedAsCompletedId))
            {
                throw new Exception400($"Уже установлен статус выполнения задачи по сущности 'Отмечено выполненным' с id={model.MarkedAsCompletedId}");
            }

            return (TaskCompletionCheckResultDTO)DBService.TryCreateEntity(DB.TaskCompletionCheckResults, model, callback: (entity) =>
            {
                entity.UserTaskId = task.Id;
            }, 
            afterSuccessCallback: (entity) =>
            {
                if(task is WithAmountUserTask withAmountTask)
                {
                    var markedAsCompleted = DB.MarkedAsCompleted.FirstOrDefault(o => o.Id == model.MarkedAsCompletedId) as WithAmountMarkedAsCompleted;
                    withAmountTask.CompletedAmount += markedAsCompleted.Amount;

                    DBService.UpdateEntity(DB.UserTasks, withAmountTask);
                    this.AddHistoryAction("Проверено выполнение задачи", $"Проверено выполнение задачи {task.Title} с id={task.Id} ");
                }
            });
        }

        [HttpPut, Route("SetTaskStatus")]
        public async Task SetTaskStatus(int id, UserTaskStatus status)
        {
            var task = DBService.TryGetOne(GetAvailableTasks(), id);
            ThrowIfTaskNotActiveOrUserNotCreator(task);

            if (status == UserTaskStatus.Active)
            {
                throw new Exception403("Данный статус нельзя установить");
            }

            task.Status = status;
            DBService.UpdateEntity(DB.UserTasks, task);

            this.AddHistoryAction("Изменение статуса задачи", $"Изменен статус задачи {task.Title} с id={task.Id} на {status.ToString()}");
        }



        #endregion









        #region Private methods
        private IEnumerable<UserTask> GetAvailableTasks()
        {
            return DB.UserTasks.Include(o => o.TaskFor)
                               .Include(o => o.CreatedBy)
                               .Include(o => o.MarkedAsCompleted)
                               .Include(o => o.CompletionCheckResults).ThenInclude(o => o.MarkedAsCompleted)
                               .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        private void ThrowIfTaskNotActiveOrUserNotCreator(UserTask task)
        {
            if (task.CreatedById != this.AuthorizedUser.Id)
            {
                throw new Exception403("Данное действие может выполнить только тот, кто создал задачу");
            }
            else if (task.Status != UserTaskStatus.Active)
            {
                throw new Exception403("Нельзя изменить статус у неактивной задачи");
            }
        }

        #endregion
    }
}
