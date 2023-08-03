using Alfateam2._0.Models.Abstractions;
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
    public class ComplianceDocument : AbsModel
    {
        /// <summary>
        /// Размер в килобайтах. 
        /// Проставляется автоматически при заливки документа по пути DocumentPath
        /// </summary>
        public int KBSize { get; set; }
        public string Title { get; set; }
        public string ImgPreviewPath { get; set; }
        public string DocumentPath { get; set; }


        public List<ComplianceDocumentLocalization> Localizations { get; set; } = new List<ComplianceDocumentLocalization>();
    }
}
