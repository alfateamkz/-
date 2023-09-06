using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Content.Videos;

namespace Alfateam.CRM2_0.Models.CreateModels.Content.Videos
{
    public class VideoCreateModel : CreateModel<Video>
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public int? CategoryId { get; set; }

        public bool AreCommentsEnabled { get; set; } = true;
    }
}
