using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.API.Models.DTO.Autoposting;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Autoposting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Marketing.API.Controllers.Autoposting
{
    public class AutopostingContentController : AbsController
    {
        public AutopostingContentController(ControllerParams @params) : base(@params)
        {
        }

        #region Контент-планы

        [HttpGet, Route("GetContentPlans")]
        public async Task<ItemsWithTotalCount<ContentPlanDTO>> GetContentPlans(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<ContentPlan, ContentPlanDTO>(GetAvailableContentPlans(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetContentPlan")]
        public async Task<ContentPlanDTO> GetContentPlan(int id)
        {
            return (ContentPlanDTO)DBService.TryGetOne(GetAvailableContentPlans(), id, new ContentPlanDTO());
        }





        [HttpPost, Route("CreateContentPlan")]
        public async Task<ContentPlanDTO> CreateContentPlan(ContentPlanDTO model)
        {
            return (ContentPlanDTO)DBService.TryCreateEntity(DB.ContentPlans, model, callback: (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление контент-плана", $"Добавлен контент-план {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateContentPlan")]
        public async Task<ContentPlanDTO> UpdateContentPlan(ContentPlanDTO model)
        {
            var item = GetAvailableContentPlans().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (ContentPlanDTO)DBService.TryUpdateEntity(DB.ContentPlans, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование контент-плана", $"Отредактирован контент-план с id={item.Id}");
            });
        }




        [HttpDelete, Route("DeleteContentPlan")]
        public async Task DeleteContentPlan(int id)
        {
            var item = GetAvailableContentPlans().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.ContentPlans, item);

            this.AddHistoryAction("Удаление контент-плана", $"Удален контент-план {item.Title} с id={id}");
        }




        #endregion

        #region Публикации для контент плана

        [HttpGet, Route("GetPosts")]
        public async Task<ItemsWithTotalCount<PostDTO>> GetPosts(int contentPlanId, SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Post, PostDTO>(GetAvailablePosts(contentPlanId), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Content.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetPost")]
        public async Task<PostDTO> GetPost(int contentPlanId, int id)
        {
            return (PostDTO)DBService.TryGetOne(GetAvailablePosts(contentPlanId), id, new PostDTO());
        }





        [HttpPost, Route("CreatePost")]
        public async Task<PostDTO> CreatePost(int contentPlanId, PostDTO model)
        {
            return (PostDTO)DBService.TryCreateEntity(DB.Posts, model, callback: (entity) =>
            {
                entity.ContentPlanId = contentPlanId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление публикации для контент-плана", $"Добавлена публикация для контент-плана");
            });
        }

        [HttpPut, Route("UpdatePost")]
        public async Task<PostDTO> UpdatePost(int contentPlanId, PostDTO model)
        {
            var item = GetAvailablePosts(contentPlanId).FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (PostDTO)DBService.TryUpdateEntity(DB.Posts, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование публикации для контент-плана", $"Отредактирована публикация для контент-плана с id={item.Id}");
            });
        }






        [HttpDelete, Route("DeletePost")]
        public async Task DeletePost(int contentPlanId, int id)
        {
            var item = GetAvailablePosts(contentPlanId).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.Posts, item);

            this.AddHistoryAction("Удаление публикации для контент-плана", $"Удален публикация для контент-план с id={id}");
        }


        #endregion

        #region Аккаунты для контент плана

        [HttpGet, Route("GetAccounts")]
        public async Task<ItemsWithTotalCount<AutopostingAccountDTO>> GetAccounts(int contentPlanId, SearchFilter filter)
        {
            var plan = DBService.TryGetOne(GetAvailableContentPlans(), contentPlanId);
            return DBService.GetManyWithTotalCount<AutopostingAccount, AutopostingAccountDTO>(plan.Accounts, filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetAccount")]
        public async Task<AutopostingAccountDTO> GetAccount(int contentPlanId, int id)
        {
            var plan = DBService.TryGetOne(GetAvailableContentPlans(), contentPlanId);
            return (AutopostingAccountDTO)DBService.TryGetOne(plan.Accounts, id, new AutopostingAccountDTO());
        }





        [HttpPut, Route("AttachAccount")]
        public async Task AttachAccount(int contentPlanId, int accountId)
        {
            var plan = DBService.TryGetOne(GetAvailableContentPlans(), contentPlanId);
            var account = DBService.TryGetOne(GetAvailableAccounts(), accountId);

            plan.Accounts.Add(account);
            DBService.UpdateEntity(DB.ContentPlans, plan);
        }

        [HttpDelete, Route("DetachAccount")]
        public async Task DetachAccount(int contentPlanId, int accountId)
        {
            var plan = DBService.TryGetOne(GetAvailableContentPlans(), contentPlanId);
            var account = DBService.TryGetOne(plan.Accounts, accountId);

            plan.Accounts.Remove(account);
            DBService.UpdateEntity(DB.ContentPlans, plan);
        }

        #endregion

        #region Управление контент планом и постами

        [HttpPost, Route("PublishPostImmediately")]
        public async Task PublishPostImmediately(int contentPlanId, int postId)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(contentPlanId), postId);

            //TODO: немедленная публикация поста
        }


        #endregion










        #region Private methods

        private IEnumerable<ContentPlan> GetAvailableContentPlans()
        {
            return DB.ContentPlans.Include(o => o.Accounts)
                                  .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }
        private IEnumerable<Post> GetAvailablePosts(int contentPlanId)
        {
            if(!GetAvailableContentPlans().Any(o => o.Id == contentPlanId))
            {
                throw new Exception404("Контент план с id={contentPlanId} не найден");
            }

            return DB.Posts.Include(o => o.Attachments)
                           .Where(o => !o.IsDeleted && o.ContentPlanId == contentPlanId);
        }

        private IEnumerable<AutopostingAccount> GetAvailableAccounts()
        {
            return DB.AutopostingAccounts.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        #endregion
    }
}
