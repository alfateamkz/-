﻿using Alfateam.Core.Attributes.DTO;
using Alfateam.Core.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Portfolios;

namespace Alfateam.Website.API.Models.DTO.Portfolios
{
    public class PortfolioIndustryDTO : AvailabilityDTOModel<PortfolioIndustry>
    {
        public string Title { get; set; }
        [ForClientOnly]
        public string Slug => SlugHelper.GetLatynSlug(Title);

    }
}
