﻿using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Models.DTO.Posts
{
    public class PostIndustryDTO : DTOModel<PostIndustry>
    {
        public string Title { get; set; }
        public string Slug => SlugHelper.GetLatynSlug(Title);


        public int MainLanguageId { get; set; }
    }
}
