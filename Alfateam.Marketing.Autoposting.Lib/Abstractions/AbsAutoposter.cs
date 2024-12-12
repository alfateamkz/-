using Alfateam.Marketing.Autoposting.Lib.Models.Comments;
using Alfateam.Marketing.Autoposting.Lib.Models.CrtUpdDTO.Comments;
using Alfateam.Marketing.Autoposting.Lib.Models.CrtUpdDTO.Posts;
using Alfateam.Marketing.Autoposting.Lib.Models.Posts;
using Alfateam.Marketing.Autoposting.Lib.Models.Results;
using Alfateam.Marketing.Autoposting.Lib.Models.Results.Comments;
using Alfateam.Marketing.Autoposting.Lib.Models.Results.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Abstractions
{
    public abstract class AbsAutoposter
    {
        public abstract AuthResult Auth();
        public abstract AuthResult Send2FACode(string code);
        public abstract AuthResult Ping();
        public abstract LogoutResult Logout();



        public abstract IEnumerable<Post> GetPosts(int offset = 0, int count = 20);
        public abstract Post GetPost(string postId);



        public abstract IEnumerable<Comment> GetPostComments(string postId, int offset = 0, int count = 20);
        public abstract Comment GetPostComment(string postId, string commentId);




        public abstract CommentCreationResult CreateComment(string postId, CommentCrtUpdDTO model, string? replyCommentId = null);
        public abstract CommentUpdateResult EditComment(string postId, string commentId, CommentCrtUpdDTO model);
        public abstract CommentDeletionResult DeleteComment(string postId, string commentId);




        public abstract PostCreationResult CreatePost(PostCrtUpdDTO model);
        public abstract PostUpdateResult UpdatePost(string postId, PostCrtUpdDTO model);
        public abstract PostDeletionResult DeletePost(string postId);
    }
}
