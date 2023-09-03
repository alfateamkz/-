using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Content.Videos;

namespace Alfateam.CRM2_0.Models.ClientModels.Content.Videos
{
    public class VideoCategoryClientModel : ClientModel<VideoCategory>
    {
        public string Title { get; set; }
    }
}
