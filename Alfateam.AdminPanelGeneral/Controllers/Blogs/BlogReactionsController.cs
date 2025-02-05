using Alfateam.Administration.Models.Blogs;
using Alfateam.Administration.Models.Blogs.Feedbacks.Reactions;
using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Filters;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Administration.Models.DTO.Blogs;
using Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Reactions;
using Alfateam.Core;
using Alfateam.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Blogs
{
    [BlogsAccessFilter]
    [Route("Blogs/[controller]")]
    public class BlogReactionsController : AbsBlogController
    {
        public BlogReactionsController(ControllerParams @params) : base(@params)
        {
        }

        #region Доступные реакции для блога

        [HttpGet, Route("GetReactions")]
        public async Task<ItemsWithTotalCount<ReactionDTO>> GetReactions(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Reaction, ReactionDTO>(GetAvailableReactions(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetReaction")]
        public async Task<ReactionDTO> GetReaction(int id)
        {
            return (ReactionDTO)DBService.TryGetOne(GetAvailableReactions(), id, new ReactionDTO());
        }



        [SwaggerOperation("Нужно загрузить изображение по пути imgFile")]
        [HttpPost, Route("CreateReaction")]
        public async Task<ReactionDTO> CreateReaction([FromForm(Name = "model")] ReactionDTO model)
        {
            return (ReactionDTO)DBService.TryCreateEntity(AdmininstrationDb.Reactions, model, callback: (entity) =>
            {
                entity.ImagePath = FilesService.TryUploadFile("imgFile", FileType.Image);
                entity.BlogId = (int)this.BlogId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление реакции для блога", $"Добавлена реакция для блога {entity.Title}");
            });
        }

        [SwaggerOperation("Нужно загрузить изображение по пути imgFile, если его изменяем")]
        [HttpPut, Route("UpdateReaction")]
        public async Task<ReactionDTO> UpdateReaction(ReactionDTO model)
        {
            var item = GetAvailableReactions().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (ReactionDTO)DBService.TryUpdateEntity(AdmininstrationDb.Reactions, model, item, callback: (entity) =>
            {
                if (FilesService.IsFileUploaded("imgFile"))
                {
                    entity.ImagePath = FilesService.TryUploadFile("imgFile", FileType.Image);
                }
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование реакции для блога", $"Отредактирована реакция для блога с id={item.Id}");
            });
        }



        [HttpDelete, Route("DeleteReaction")]
        public async Task DeleteReaction(int id)
        {
            var item = GetAvailableReactions().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(AdmininstrationDb.Reactions, item);

            this.AddHistoryAction("Удаление реакции для блога", $"Удалена реакция для блога {item.Title} с id={id}");
        }

        #endregion






        #region Private methods
        private IEnumerable<Reaction> GetAvailableReactions()
        {
            return AdmininstrationDb.Reactions.Where(o => !o.IsDeleted && o.BlogId == this.BlogId);
        }

        #endregion
    }
}
