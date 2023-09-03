using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Content.Videos;

namespace Alfateam.CRM2_0.Models.EditModels.Content.Videos
{
    public class VideoEditModel : EditModel<Video>
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public int? CategoryId { get; set; }
    }
}
