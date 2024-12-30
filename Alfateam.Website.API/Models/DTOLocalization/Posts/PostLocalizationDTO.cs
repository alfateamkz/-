using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.ContentItems;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Localization.Items.Posts;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Models.DTOLocalization.Posts
{
    public class PostLocalizationDTO : LocalizationDTOModel<PostLocalization>
    {
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }

        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public ContentDTO Content { get; set; }

       
    }
}
