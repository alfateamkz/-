using Alfateam.Administration.Models.Blogs;
using Alfateam.Administration.Models.Blogs.Feedbacks.Reactions;
using Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Reactions;
using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.ForPubilcWebsites.API.Abstractions;
using Alfateam.ForPubilcWebsites.API.Filters;
using Alfateam.ForPubilcWebsites.API.Models;
using Alfateam.ForPubilcWebsites.API.Models.SearchFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.ForPubilcWebsites.API.Controllers.Blog
{
    public class BlogReactionsController : AbsBlogController
    {
        public BlogReactionsController(ControllerParams @params) : base(@params)
        {
        }

        #region Доступные реакции

        [HttpGet, Route("GetAvailableReactions")]
        public async Task<ItemsWithTotalCount<ReactionDTO>> GetAvailableReactions(SearchFilter filter)
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

        [HttpGet, Route("GetAvailableReaction")]
        public async Task<ReactionDTO> GetReaction(int id)
        {
            return (ReactionDTO)DBService.TryGetOne(GetAvailableReactions(), id, new ReactionDTO());
        }

        #endregion

        #region Реакции поста

        [HttpGet, Route("GetPostReactionCounters")]
        public async Task<IEnumerable<ReactionCounterDTO>> GetPostReactionCounters(int postId)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), postId);
            ThrowIfPostReactionsDisabled(post);

            return DBService.GetMany<ReactionCounter, ReactionCounterDTO>(post.ReactionCounters);
        }

        [HttpGet, Route("GetPostSetReactions")]
        public async Task<ItemsWithTotalCount<SetReactionDTO>> GetPostSetReactions(BlogPostSetReactionsSearchFilter filter)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), filter.PostId);
            ThrowIfPostReactionsDisabled(post);

            var reactionsCounter = post.ReactionCounters.FirstOrDefault(o => o.ReactionId == filter.ReactionId);
            if(reactionsCounter == null)
            {
                return new ItemsWithTotalCount<SetReactionDTO>();
            }
            return DBService.GetManyWithTotalCount<SetReaction, SetReactionDTO>(reactionsCounter.SetReactions, filter.Offset,filter.Count);
        }


        [HttpPut, Route("GetMyReactions"), AuthorizedUserFilter]
        public async Task<IEnumerable<SetReactionDTO>> GetMyReactions(int postId)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), postId);
            ThrowIfPostReactionsDisabled(post);

            var reactions = post.ReactionCounters.SelectMany(o => o.SetReactions)
                                                 .Where(o => o.CreatedByIdentifier == this.AlfateamUser.Guid);
            return DBService.GetMany<SetReaction, SetReactionDTO>(reactions);
        }

        [HttpPut, Route("ToggleReaction"), AuthorizedUserFilter]
        public async Task<bool> ToggleReaction(int postId, int reactionId)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), postId);
            ThrowIfPostReactionsDisabled(post);

            var reactionsCounter = post.ReactionCounters.FirstOrDefault(o => o.ReactionId == reactionId);
            if(reactionsCounter == null)
            {
                reactionsCounter = new ReactionCounter
                {
                    ReactionId = reactionId,
                };
                DBService.UpdateEntity(AdmininstrationDb.BlogPosts, post);
            }

            bool result = reactionsCounter.ToggleReaction(this.AlfateamUser.Guid);
            DBService.UpdateEntity(AdmininstrationDb.ReactionCounters, reactionsCounter);

            return result;
        }

        #endregion







        #region Private get methods
        private IEnumerable<Reaction> GetAvailableReactions()
        {
            return AdmininstrationDb.Reactions.Where(o => !o.IsDeleted && o.BlogId == this.BlogId);
        }

        private IEnumerable<BlogPost> GetAvailablePosts()
        {
            return AdmininstrationDb.BlogPosts.Include(o => o.ReactionCounters).ThenInclude(o => o.Reaction)
                                              .Include(o => o.ReactionCounters).ThenInclude(o => o.SetReactions).ThenInclude(o => o.Reaction)
                                              .Where(o => !o.IsDeleted && o.BlogLanguageZoneId == this.BlogLanguageZoneId);
        }

        #endregion

        #region Private check methods

        private void ThrowIfPostReactionsDisabled(BlogPost post)
        {
            if (!post.PostReactionsEnabled)
            {
                throw new Exception403("Реакции недоступны для данной записи");
            }
        }


        #endregion
    }
}
