using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdCreatives
{
    public enum AdCreativeLinkDataFormatOption
    {
        [Description("carousel_ar_effects")]
        CarouselAREffects = 1,
        [Description("carousel_images_multi_items")]
        CarouselImagesMultiItems = 2,
        [Description("carousel_images_single_item")]
        CarouselImagesSingleItem = 3,
        [Description("carousel_slideshows")]
        CarouselSlideshows = 4,
        [Description("collection_video")]
        CollectionVideo = 5,
        [Description("single_image")]
        SingleImage = 6,
    }
}
