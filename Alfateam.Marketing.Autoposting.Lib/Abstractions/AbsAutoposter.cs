using Alfateam.Marketing.Autoposting.Lib.Abstractions.Posts;
using Alfateam.Marketing.Autoposting.Lib.Models;
using Alfateam.Marketing.Autoposting.Lib.Models.Comments;
using Alfateam.Marketing.Autoposting.Lib.Models.CrtUpdDTO.Comments;
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
        public abstract Task<AuthResult> Auth();
        public abstract Task<AuthResult> Send2FACode(string code);
        public abstract Task<AuthResult> Ping();
        public abstract Task<Profile> GetAuthorizedProfile();
        public abstract Task<LogoutResult> Logout();



        public abstract Task<IEnumerable<Post>> GetPosts(int offset = 0, int count = 20);
        public abstract Task<Post> GetPost(string postId);



        public abstract Task<IEnumerable<Comment>> GetPostComments(string postId, int offset = 0, int count = 20);
        public abstract Task<Comment> GetPostComment(string postId, string commentId);




        public abstract Task<CommentCreationResult> CreateComment(string postId, CommentCrtUpdDTO model, string? replyCommentId = null);
        public abstract bool CanEditComment(string postId, string commentId);
        public abstract Task<CommentUpdateResult> EditComment(string postId, string commentId, CommentCrtUpdDTO model);
        public abstract Task<CommentDeletionResult> DeleteComment(string postId, string commentId);




        public abstract Task<PostCreationResult> CreatePost(PostCrtUpdDTO model);
        public abstract bool CanUpdatePost(string postId);
        public abstract Task<PostUpdateResult> UpdatePost(string postId, PostCrtUpdDTO model);
        public abstract Task<PostDeletionResult> DeletePost(string postId);



    }
}
