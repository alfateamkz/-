using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Content.Feedback;
using Alfateam.CRM2_0.Models.Content.Videos;

namespace Alfateam.CRM2_0.Models.ClientModels.Content.Videos
{
    public class VideoClientModel : ClientModel<Video>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public string VideoPath { get; set; }
        public string? PosterImgPath { get; set; }

        public int Comments { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }


        public VideoCategoryClientModel? Category { get; set; }
    }
}
