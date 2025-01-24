using Alfateam.Administration.Models.Blogs.Feedbacks.Reactions;
using Alfateam.Core;
using Alfateam.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Blogs.Feedbacks.Comments
{
    public class CommentsCounter : AbsModel
    {
        public int Count { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();


        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
            Count++;
        }
        public void AddComment(Comment comment, int replyToId)
        {
            var found = Comments.FirstOrDefault(o => o.Id == replyToId);
            if(found == null)
            {
                throw new Exception404("Комментарий с данным id не найден");
            }

            found.Subcomments.Add(comment);
            Count++;
        }




        public bool RemoveComment(Comment comment, bool deleteThread)
        {
            if(comment.IsDeleted || comment.IsDeletedWithoutThread)
            {
                return false;
            }

            var found = Comments.FirstOrDefault(o => o.Id == comment.Id);
            if(found != null)
            {
                if (deleteThread)
                {
                    Comments.Remove(found);
                    Count -= GetCommentsCountWithThread(found);
                }
                else
                {
                    found.IsDeletedWithoutThread = true;
                    Count--;
                }
                return true;
            }
            return false;
        }


        private int GetCommentsCountWithThread(Comment comment)
        {
            int count = 1;
            foreach (var sub in comment.Subcomments.Where(o => !o.IsDeleted && !o.IsDeletedWithoutThread))
            {
                count += GetCommentsCountWithThread(sub);
            }
            return count;
        }
    }
}
