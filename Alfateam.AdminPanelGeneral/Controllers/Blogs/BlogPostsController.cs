using Alfateam.Administration.Models.Blogs;
using Alfateam.Administration.Models.Blogs.Feedbacks.Reactions;
using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Filters;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Administration.Models.DTO.Blogs;
using Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Reactions;
using Alfateam.AdminPanelGeneral.API.Models.Filters.Blogs;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alfateam.Administration.Models.Abstractions;
using Alfateam.Administration.Models.Enums;
using Alfateam.Administration.Models.DTO.Abstractions;
using Alfateam.Core.Exceptions;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Blogs
{
    [BlogsAccessFilter]
    [Route("Blogs/[controller]")]
    public class BlogPostsController : AbsBlogController
    {
        public BlogPostsController(ControllerParams @params) : base(@params)
        {
        }


        #region Посты

        [HttpGet, Route("GetPosts")]
        public async Task<ItemsWithTotalCount<BlogPostDTO>> GetPosts(BlogPostsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<BlogPost, BlogPostDTO>(GetAvailablePosts(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition  &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if(filter.CategoryId != null)
                {
                    condition &= entity.Categories.Any(o => o.Id == filter.CategoryId);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetPost")]
        public async Task<BlogPostDTO> GetPost(int id)
        {
            return (BlogPostDTO)DBService.TryGetOne(GetAvailablePosts(), id, new BlogPostDTO());
        }









        [HttpPost, Route("CreatePost")]
        public async Task<BlogPostDTO> CreatePost(BlogPostDTO model)
        {
            return (BlogPostDTO)DBService.TryCreateEntity(AdmininstrationDb.BlogPosts, model, callback: (entity) =>
            {
                foreach(var block in entity.Blocks)
                {
                    if(block is BlogPostBlockWithFile withFileBlock)
                    {
                        UploadedFilesService.ThrowIfFileNotAvailable(withFileBlock.FileId);
                    }
                }
            },
            afterSuccessCallback: (entity) =>
            {
                foreach (var block in entity.Blocks)
                {
                    if (block is BlogPostBlockWithFile withFileBlock)
                    {
                        UploadedFilesService.TryBindFileWithEntity(withFileBlock.FileId);
                    }
                }
                this.AddHistoryAction("Добавление поста для блога", $"Добавлен пост для блога {entity.Title} с id={entity.Id}");
            });
        }

        [HttpPut, Route("UpdatePost")]
        public async Task<BlogPostDTO> UpdatePost(BlogPostDTO model)
        {
            var oldPost = DBService.TryGetOne(GetAvailablePosts(), model.Id);
            var newPost = model.CreateDBModelFromDTO();

            var deletedBlocks = new List<BlogPostBlockWithFile>();
            var sameBlocks = new List<BlogPostBlockWithFile>();
            var newBlocks = new List<BlogPostBlockWithFile>();

            foreach (var block in oldPost.Blocks.Cast<BlogPostBlockWithFile>())
            {
                if(!newPost.Blocks.Any(o => o.Id == block.Id))
                {
                    deletedBlocks.Add(block);
                }
                else
                {
                    sameBlocks.Add(block);
                }
            }

            foreach(var block in newPost.Blocks.Cast<BlogPostBlockWithFile>())
            {
                if (!oldPost.Blocks.Any(o => o.Id == block.Id))
                {
                    newBlocks.Add(block);
                }
            }

            if (!model.IsValid())
            {
                throw new Exception400("Проверьте корректность заполения полей");
            }

            foreach(var block in sameBlocks)
            {
                var newPostBlock = newBlocks.FirstOrDefault(o => o.Id == block.Id);
                UploadedFilesService.TryBindFileWithEntityIfChanged(block.FileId, newPostBlock.FileId);
            }
            foreach(var block in newBlocks)
            {
                UploadedFilesService.TryBindFileWithEntity(block.FileId);
            }
            foreach (var block in deletedBlocks)
            {
                UploadedFilesService.TryUnbindFile(block.FileId);
            }

            DBService.UpdateEntity(AdmininstrationDb.BlogPosts, newPost);
            this.AddHistoryAction("Редактирование поста для блога", $"Отредактирован пост для блога {newPost.Title} с id={newPost.Id}");
            return (BlogPostDTO)new BlogPostDTO().CreateDTO(newPost);
        }

        [HttpDelete, Route("DeletePost")]
        public async Task DeletePost(int id)
        {
            var item = GetAvailablePosts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(AdmininstrationDb.BlogPosts, item);

            this.AddHistoryAction("Удаление поста для блога", $"Удалена поста для блога {item.Title} с id={id}");
        }

        #endregion








        #region Private methods
        private IEnumerable<BlogPost> GetAvailablePosts()
        {
            return AdmininstrationDb.BlogPosts.Include(o => o.Categories)
                                              .Include(o => o.Blocks)
                                              .Include(o => o.ReactionCounters).ThenInclude(o => o.Reaction)
                                              .Include(o => o.WatchesCounter)
                                              .Include(o => o.CommentsCounter)
                                              .Where(o => !o.IsDeleted && o.BlogLanguageZoneId == this.BlogLanguageZoneId);
        }

        #endregion
    }
}
