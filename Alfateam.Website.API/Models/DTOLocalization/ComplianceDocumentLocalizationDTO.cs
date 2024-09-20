﻿using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam2._0.Models.Localization.Items;

namespace Alfateam.Website.API.Models.DTOLocalization
{
    public class ComplianceDocumentLocalizationDTO : LocalizationDTOModel<ComplianceDocumentLocalization>
    {

        /// <summary>
        /// Размер в килобайтах. 
        /// Проставляется автоматически при заливки документа по пути DocumentPath
        /// </summary>
        [ForClientOnly]
        public long KBSize { get; set; }
        public string Title { get; set; }


        [ForClientOnly]
        public string ImgPreviewPath { get; set; }
        [ForClientOnly]
        public string DocumentPath { get; set; }


        public override bool IsValid()
        {
            return base.IsValid() && KBSize > 0;
        }
    }
}
