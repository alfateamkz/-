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
    public class Video : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public string VideoPath { get; set; }
        public string? PosterImgPath { get; set; }


        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<FeedbackEntry> Likes { get; set; } = new List<FeedbackEntry>();
        public List<FeedbackEntry> Dislikes { get; set; } = new List<FeedbackEntry>();


        public VideoCategory? Category { get; set; }
    }
}
