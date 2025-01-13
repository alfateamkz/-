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

namespace Alfateam.Marketing.Autoposting.Lib.Resources
{
    public class PikabuAutoposter : AbsAutoposter
    {
        public override AuthResult Auth()
        {
            throw new NotImplementedException();
        }

        public override CommentCreationResult CreateComment(string postId, CommentCrtUpdDTO model, string? replyCommentId = null)
        {
            throw new NotImplementedException();
        }

        public override PostCreationResult CreatePost(PostCrtUpdDTO model)
        {
            throw new NotImplementedException();
        }

        public override CommentDeletionResult DeleteComment(string postId, string commentId)
        {
            throw new NotImplementedException();
        }

        public override PostDeletionResult DeletePost(string postId)
        {
            throw new NotImplementedException();
        }

        public override CommentUpdateResult EditComment(string postId, string commentId, CommentCrtUpdDTO model)
        {
            throw new NotImplementedException();
        }

        public override Post GetPost(string postId)
        {
            throw new NotImplementedException();
        }

        public override Comment GetPostComment(string postId, string commentId)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Comment> GetPostComments(string postId, int offset = 0, int count = 20)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Post> GetPosts(int offset = 0, int count = 20)
        {
            throw new NotImplementedException();
        }

        public override LogoutResult Logout()
        {
            throw new NotImplementedException();
        }

        public override AuthResult Ping()
        {
            throw new NotImplementedException();
        }

        public override AuthResult Send2FACode(string code)
        {
            throw new NotImplementedException();
        }

        public override PostUpdateResult UpdatePost(string postId, PostCrtUpdDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
