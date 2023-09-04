using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Content.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Content.Videos
{
    /// <summary>
    /// Сущность видеозаписи
    /// </summary>
    public class Video : ContentModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public string VideoPath { get; set; }
        public string? PosterImgPath { get; set; }

        public bool AreCommentsEnabled { get; set; } = true;


        public List<Comment> CommentsList { get; set; } = new List<Comment>();
        public List<FeedbackEntry> LikesList { get; set; } = new List<FeedbackEntry>();
        public List<FeedbackEntry> DislikesList { get; set; } = new List<FeedbackEntry>();

        public int Watches { get; set; }
        public int Comments { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }


        public VideoCategory? Category { get; set; }
        public int? CategoryId { get; set; }
    }
}
