using Alfateam.Marketing.Autoposting.Lib.Abstractions;
using Alfateam.Marketing.Autoposting.Lib.Models.CrtUpdDTO.Comments;
using Alfateam.Marketing.Autoposting.Lib.Models.Results.Comments;
using Alfateam.Marketing.Autoposting.Lib.Models.Results.Posts;
using Alfateam.Marketing.Autoposting.Lib.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Marketing.Autoposting.Lib.Models.Posts;
using Alfateam.Marketing.Autoposting.Lib.Models.Comments;
using Alfateam.Marketing.Autoposting.Lib.Abstractions.Posts;
using Alfateam.Marketing.Autoposting.Lib.Models;

namespace Alfateam.Marketing.Autoposting.Lib.Resources
{
    public class PikabuAutoposter : AbsAutoposter
    {
        public override Task<AuthResult> Auth()
        {
            throw new NotImplementedException();
        }

        public override bool CanEditComment(string postId, string commentId)
        {
            throw new NotImplementedException();
        }

        public override bool CanUpdatePost(string postId)
        {
            throw new NotImplementedException();
        }

        public override Task<CommentCreationResult> CreateComment(string postId, CommentCrtUpdDTO model, string? replyCommentId = null)
        {
            throw new NotImplementedException();
        }

        public override Task<PostCreationResult> CreatePost(PostCrtUpdDTO model)
        {
            throw new NotImplementedException();
        }

        public override Task<CommentDeletionResult> DeleteComment(string postId, string commentId)
        {
            throw new NotImplementedException();
        }

        public override Task<PostDeletionResult> DeletePost(string postId)
        {
            throw new NotImplementedException();
        }

        public override Task<CommentUpdateResult> EditComment(string postId, string commentId, CommentCrtUpdDTO model)
        {
            throw new NotImplementedException();
        }

        public override Task<Profile> GetAuthorizedProfile()
        {
            throw new NotImplementedException();
        }

        public override Task<Post> GetPost(string postId)
        {
            throw new NotImplementedException();
        }

        public override Task<Comment> GetPostComment(string postId, string commentId)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Comment>> GetPostComments(string postId, int offset = 0, int count = 20)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Post>> GetPosts(int offset = 0, int count = 20)
        {
            throw new NotImplementedException();
        }

        public override Task<LogoutResult> Logout()
        {
            throw new NotImplementedException();
        }

        public override Task<AuthResult> Ping()
        {
            throw new NotImplementedException();
        }

        public override Task<AuthResult> Send2FACode(string code)
        {
            throw new NotImplementedException();
        }

        public override Task<PostUpdateResult> UpdatePost(string postId, PostCrtUpdDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
