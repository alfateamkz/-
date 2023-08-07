using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items
{
    public class ComplianceDocumentLocalization : LocalizableModel
    {
        /// <summary>
        /// Размер в килобайтах. 
        /// Проставляется автоматически при заливки документа по пути DocumentPath
        /// </summary>
        public long KBSize { get; set; }
        public string Title { get; set; }
        public string ImgPreviewPath { get; set; }
        public string DocumentPath { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// Указывает на владеющую сущность
        /// </summary>
        public int ComplianceDocumentId { get; set; }
    }
}
