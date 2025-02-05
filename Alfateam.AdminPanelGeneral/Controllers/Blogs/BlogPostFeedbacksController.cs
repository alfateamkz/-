using Alfateam.Administration.Models.Blogs;
using Alfateam.Administration.Models.Blogs.Feedbacks.Comments;
using Alfateam.Administration.Models.Blogs.Feedbacks.Reactions;
using Alfateam.Administration.Models.Blogs.Feedbacks.Watches;
using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Administration.Models.DTO.Blogs;
using Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Comments;
using Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Reactions;
using Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Watches;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alfateam.AdminPanelGeneral.API.Models.Filters.Blogs;
using Alfateam.AdminPanelGeneral.API.Filters;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Blogs
{
    [Route("Blogs/[controller]")]
    [BlogsAccessFilter]
    public class BlogPostFeedbacksController : AbsBlogController
    {
        public BlogPostFeedbacksController(ControllerParams @params) : base(@params)
        {
        }

        #region Просмотры

        [HttpGet, Route("GetWatches")]
        public async Task<ItemsWithTotalCount<WatchDTO>> GetWatches(BlogPostFeedbacksSearchFilter filter)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), filter.PostId);
            return DBService.GetManyWithTotalCount<Watch, WatchDTO>(post.WatchesCounter.Watches, filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.IP.Contains(filter.Query, StringComparison.OrdinalIgnoreCase)
                        || entity.UserAgent.Contains(filter.Query, StringComparison.OrdinalIgnoreCase)
                        || entity.Fingerprint.Contains(filter.Query, StringComparison.OrdinalIgnoreCase)
                        || entity.AdditionalInfo.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetWatch")]
        public async Task<WatchDTO> GetWatch(int postId, int watchId)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), postId);
            return (WatchDTO)DBService.TryGetOne(post.WatchesCounter.Watches, watchId, new WatchDTO());
        }

        #endregion

        #region Реакции

        [HttpGet, Route("GetSetReactions")]
        public async Task<ItemsWithTotalCount<SetReactionDTO>> GetSetReactions(BlogPostFeedbacksReactionsSearchFilter filter)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), filter.PostId);
            var reactionCounter = post.ReactionCounters.FirstOrDefault(o => o.ReactionId == filter.ReactionId);

            if(reactionCounter == null)
            {
                return new ItemsWithTotalCount<SetReactionDTO>();
            }
            else return DBService.GetManyWithTotalCount<SetReaction, SetReactionDTO>(reactionCounter.SetReactions, filter.Offset, filter.Count, (entity) =>
            {
                return true;
            });
        }

        [HttpGet, Route("GetSetReaction")]
        public async Task<SetReactionDTO> GetSetReaction(int postId, int reactionId, int setReactionId)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), postId);
            var reactionCounter = post.ReactionCounters.FirstOrDefault(o => o.ReactionId == reactionId);

            return (SetReactionDTO)DBService.TryGetOne(reactionCounter.SetReactions, setReactionId, new SetReactionDTO());
        }


        #endregion

        #region Комментарии 

        [HttpGet, Route("GetComments")]
        public async Task<ItemsWithTotalCount<CommentDTO>> GetComments(BlogPostFeedbacksSearchFilter filter)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), filter.PostId);
            return DBService.GetManyWithTotalCount<Comment, CommentDTO>(post.CommentsCounter.Comments, filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Text.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetComment")]
        public async Task<CommentDTO> GetComment(int postId, int commentId)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), postId);
            return (CommentDTO)DBService.TryGetOne(post.CommentsCounter.Comments, commentId, new CommentDTO());
        }

        [HttpGet, Route("DeleteComment")]
        public async Task DeleteComment(int postId, int commentId, bool deleteThread)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), postId);
            var comment = DBService.TryGetOne(post.CommentsCounter.Comments, commentId);

            post.CommentsCounter.RemoveComment(comment, deleteThread);
            DBService.UpdateEntity(AdmininstrationDb.BlogPosts, post);
        }

        #endregion









        #region Private methods
        private IEnumerable<BlogPost> GetAvailablePosts()
        {
            return AdmininstrationDb.BlogPosts.Include(o => o.Categories)
                                              .Include(o => o.Blocks)
                                              .Include(o => o.ReactionCounters).ThenInclude(o => o.Reaction)
                                              .Include(o => o.ReactionCounters).ThenInclude(o => o.SetReactions)
                                              .Include(o => o.CommentsCounter).ThenInclude(o => o.Comments).ThenInclude(o => o.Attachments)
                                              .Include(o => o.WatchesCounter).ThenInclude(o => o.Watches)
                                              .Where(o => !o.IsDeleted && o.BlogLanguageZoneId == this.BlogLanguageZoneId);
        }

        #endregion
    }
}
