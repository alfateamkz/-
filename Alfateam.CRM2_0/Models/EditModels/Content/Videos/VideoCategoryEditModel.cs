using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Content.Videos;

namespace Alfateam.CRM2_0.Models.EditModels.Content.Videos
{
    public class VideoCategoryEditModel : EditModel<VideoCategory>
    {
        public string Title { get; set; }
    }
}
