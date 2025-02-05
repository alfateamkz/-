using Alfateam.Administration.Models.Blogs.Feedbacks.Reactions;
using Alfateam.Administration.Models.Blogs;
using Alfateam.ForPubilcWebsites.API.Abstractions;
using Alfateam.ForPubilcWebsites.API.Models;
using Microsoft.EntityFrameworkCore;
using Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Reactions;
using Alfateam.Core;
using Alfateam.ForPubilcWebsites.API.Models.SearchFilters;
using Microsoft.AspNetCore.Mvc;
using Alfateam.Core.Exceptions;
using Alfateam.Administration.Models.Enums;
using Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Comments;
using Alfateam.Administration.Models.Blogs.Feedbacks.Comments;
using Alfateam.ForPubilcWebsites.API.Filters;
using System.Collections.Generic;
using Alfateam.Administration.Models.DTO.Blogs;
using Alfateam.Administration.Models.Abstractions;

namespace Alfateam.ForPubilcWebsites.API.Controllers.Blog
{
    public class BlogCommentsController : AbsBlogController
    {
        public BlogCommentsController(ControllerParams @params) : base(@params)
        {
        }

        #region Комментарии

        [HttpGet, Route("GetPostComments")]
        public async Task<ItemsWithTotalCount<CommentDTO>> GetPostComments(BlogPostCommentsSearchFilter filter)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), filter.PostId);
            ThrowIfPostCommentsHidden(post);

            return DBService.GetManyWithTotalCount<Comment, CommentDTO>(post.CommentsCounter.Comments, filter.Offset, filter.Count);
        }

        [HttpGet, Route("GetMyComments")]
        public async Task<IEnumerable<CommentDTO>> GetMyComments(int postId)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), postId);

            var myComments = post.CommentsCounter.Comments.Where(o => o.CreatedByIdentifier == this.AlfateamUser.Guid);
            return DBService.GetMany<Comment, CommentDTO>(myComments);
        }















        [HttpPost, Route("CreateComment")]
        public async Task<CommentDTO> CreateComment(int postId, CommentDTO model)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), postId);
            if(post.CommentsStatus != BlogCommentsStatus.CanComment)
            {
                throw new Exception403("Под этим постом нельзя оставлять комментарии");
            }

            return (CommentDTO)DBService.TryCreateEntity(AdmininstrationDb.Comments, model, callback: (entity) =>
            {
                foreach (var attachment in entity.Attachments)
                {
                    UploadedFilesService.ThrowIfFileNotAvailable(attachment.FileId);
                }
            },
            afterSuccessCallback: (entity) =>
            {
                foreach (var attachment in entity.Attachments)
                {
                    UploadedFilesService.TryBindFileWithEntity(attachment.FileId);
                }
            });
        }

        [HttpPut, Route("UpdateComment")]
        public async Task<CommentDTO> UpdateComment(int postId, CommentDTO model)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), postId);
            var oldComment = DBService.TryGetOne(post.CommentsCounter.Comments, model.Id);
            var newComment = model.CreateDBModelFromDTO();

            var deletedAttacments = new List<CommentAttachment>();
            var sameAttacments = new List<CommentAttachment>();
            var newAttacments = new List<CommentAttachment>();

            foreach (var attachment in oldComment.Attachments)
            {
                if (!newComment.Attachments.Any(o => o.Id == attachment.Id))
                {
                    deletedAttacments.Add(attachment);
                }
                else
                {
                    sameAttacments.Add(attachment);
                }
            }

            foreach (var attachment in newComment.Attachments)
            {
                if (!oldComment.Attachments.Any(o => o.Id == attachment.Id))
                {
                    newAttacments.Add(attachment);
                }
            }

            if (!model.IsValid())
            {
                throw new Exception400("Проверьте корректность заполения полей");
            }


            foreach (var block in sameAttacments)
            {
                var newPostBlock = newAttacments.FirstOrDefault(o => o.Id == block.Id);
                UploadedFilesService.TryBindFileWithEntityIfChanged(block.FileId, newPostBlock.FileId);
            }
            foreach (var block in newAttacments)
            {
                UploadedFilesService.TryBindFileWithEntity(block.FileId);
            }
            foreach (var block in deletedAttacments)
            {
                UploadedFilesService.TryUnbindFile(block.FileId);
            }

            DBService.UpdateEntity(AdmininstrationDb.Comments, newComment);
            return (CommentDTO)new CommentDTO().CreateDTO(newComment);
        }


        [HttpDelete, Route("DeleteComment")]
        public async Task DeleteComment(int postId, int commentId, bool deleteThread)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), postId);
            var comment = DBService.TryGetOne(post.CommentsCounter.Comments, commentId);

            if (comment.CreatedByIdentifier != this.AlfateamUser.Guid)
            {
                throw new Exception403("Данный комментарий не принадлежит Вам");
            }
            else if(comment.IsDeleted || comment.IsDeletedWithoutThread)
            {
                throw new Exception404("Данный комментарий был ранее удален");
            }

            post.CommentsCounter.RemoveComment(comment, deleteThread);
            DBService.UpdateEntity(AdmininstrationDb.BlogPosts, post);
        }


        #endregion

        #region Реакции к комментариям 

        [HttpGet, Route("GetCommentReactionCounters")]
        public async Task<IEnumerable<ReactionCounterDTO>> GetCommentReactionCounters(int postId, int commentId)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), postId);
            ThrowIfPostCommentReactionsDisabled(post);

            var comment = DBService.TryGetOne(GetPostAllLevelComments(post), commentId);
            return DBService.GetMany<ReactionCounter, ReactionCounterDTO>(comment.ReactionCounters);
        }

        [HttpGet, Route("GetCommentSetReactions")]
        public async Task<ItemsWithTotalCount<SetReactionDTO>> GetCommentSetReactions(BlogPostCommentSetReactionsSearchFilter filter)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), filter.PostId);
            ThrowIfPostCommentReactionsDisabled(post);

            var comment = DBService.TryGetOne(GetPostAllLevelComments(post), filter.CommentId);
            var reactionsCounter = comment.ReactionCounters.FirstOrDefault(o => o.ReactionId == filter.ReactionId);
            if (reactionsCounter == null)
            {
                return new ItemsWithTotalCount<SetReactionDTO>();
            }
            return DBService.GetManyWithTotalCount<SetReaction, SetReactionDTO>(reactionsCounter.SetReactions, filter.Offset, filter.Count);
        }


        [HttpPut, Route("GetMyReactions"), AuthorizedUserFilter]
        public async Task<IEnumerable<SetReactionDTO>> GetMyReactions(int postId, int commentId)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), postId);
            ThrowIfPostCommentReactionsDisabled(post);

            var comment = DBService.TryGetOne(GetPostAllLevelComments(post), commentId);
            var reactions = comment.ReactionCounters.SelectMany(o => o.SetReactions)
                                                 .Where(o => o.CreatedByIdentifier == this.AlfateamUser.Guid);
            return DBService.GetMany<SetReaction, SetReactionDTO>(reactions);
        }

        [HttpPut, Route("ToggleReaction"), AuthorizedUserFilter]
        public async Task<bool> ToggleReaction(int postId, int commentId, int reactionId)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), postId);
            ThrowIfPostCommentReactionsDisabled(post);

            var comment = DBService.TryGetOne(GetPostAllLevelComments(post), commentId);
            var reactionsCounter = comment.ReactionCounters.FirstOrDefault(o => o.ReactionId == reactionId);
            if (reactionsCounter == null)
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
        private IEnumerable<BlogPost> GetAvailablePosts()
        {
            return AdmininstrationDb.BlogPosts.Include(o => o.CommentsCounter).ThenInclude(o => o.Comments).ThenInclude(o => o.Attachments)
                                              .Include(o => o.CommentsCounter).ThenInclude(o => o.Comments).ThenInclude(o => o.Subcomments).ThenInclude(o => o.Attachments)
                                              .Include(o => o.CommentsCounter).ThenInclude(o => o.Comments).ThenInclude(o => o.ReactionCounters).ThenInclude(o => o.Reaction)
                                              .Include(o => o.CommentsCounter).ThenInclude(o => o.Comments).ThenInclude(o => o.ReactionCounters).ThenInclude(o => o.SetReactions).ThenInclude(o => o.Reaction)
                                              .Where(o => !o.IsDeleted && o.BlogLanguageZoneId == this.BlogLanguageZoneId);
        }

        private IEnumerable<Comment> GetPostAllLevelComments(BlogPost post)
        {
            var comments = new List<Comment>();

            foreach(var comment in post.CommentsCounter.Comments)
            {
                comments.AddRange(GetPostAllLevelCommentsRecursively(comment));
            }

            return comments;
        }
        private IEnumerable<Comment> GetPostAllLevelCommentsRecursively(Comment comment)
        {
            var comments = new List<Comment>() { comment };

            foreach (var subcomment in comment.Subcomments)
            {
                comments.AddRange(GetPostAllLevelCommentsRecursively(comment));
            }

            return comments;
        }

        #endregion

        #region Private check methods

        private void ThrowIfPostCommentsHidden(BlogPost post)
        {
            if (post.CommentsStatus == BlogCommentsStatus.Hidden)
            {
                throw new Exception403("Комментарии недоступны для данной записи");
            }
        }
        private void ThrowIfPostCommentsReadOnly(BlogPost post)
        {
            if (post.CommentsStatus != BlogCommentsStatus.CanComment)
            {
                throw new Exception403("Для данной записи невозможно добавление комментариев");
            }
        }
        private void ThrowIfPostCommentReactionsDisabled(BlogPost post)
        {
            if (!post.CommentReactionsEnabled)
            {
                throw new Exception403("Реакции на комментарии недоступны для данной записи");
            }
        }

        #endregion
    }
}
