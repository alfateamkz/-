﻿using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Localization.Items.Posts;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Models.DTOLocalization.Posts
{
    public class PostCategoryLocalizationDTO : LocalizationDTOModel<PostCategoryLocalization>
    {
        public string Title { get; set; }
    }
}
