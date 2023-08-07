using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models
{
    /// <summary>
    /// Сущность документа на странице комплаенс
    /// </summary>
    public class ComplianceDocument : AvailabilityModel
    {
        /// <summary>
        /// Размер в килобайтах. 
        /// Проставляется автоматически при заливки документа по пути DocumentPath
        /// </summary>
        public long KBSize { get; set; }
        public string Title { get; set; }
        public string ImgPreviewPath { get; set; }
        public string DocumentPath { get; set; }




        public List<ComplianceDocumentLocalization> Localizations { get; set; } = new List<ComplianceDocumentLocalization>();

        public override bool IsValid()
        {
            bool isValid = true; 

            isValid &= !string.IsNullOrEmpty(Title);
            isValid &= !string.IsNullOrEmpty(ImgPreviewPath);
            isValid &= !string.IsNullOrEmpty(DocumentPath);

            foreach (var localization in Localizations)
            {
                isValid &= !string.IsNullOrEmpty(localization.Title);
                isValid &= !string.IsNullOrEmpty(localization.ImgPreviewPath);
                isValid &= !string.IsNullOrEmpty(localization.DocumentPath);
            }

            return isValid;
        }
    }
}
