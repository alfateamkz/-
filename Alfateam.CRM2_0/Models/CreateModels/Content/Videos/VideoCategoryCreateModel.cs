using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Content.Videos;

namespace Alfateam.CRM2_0.Models.CreateModels.Content.Videos
{
    public class VideoCategoryCreateModel : CreateModel<VideoCategory>
    {
        public string Title { get; set; }
    }
}
