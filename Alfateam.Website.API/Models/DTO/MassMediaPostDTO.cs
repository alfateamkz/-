﻿using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models;

namespace Alfateam.Website.API.Models.DTO
{
    public class MassMediaPostDTO : AvailabilityDTOModel<MassMediaPost>
    {
        public string ImgPath { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string URL { get; set; }

        
        public int MainLanguageId { get; set; }
    }
}