using Alfateam.Core.Helpers;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.HR
{
    public class JobVacancyLocalization : LocalizableModel
    {
        public string Title { get; set; }
        public Content InnerContent { get; set; }


        [NotMapped]
        public string Slug => $"{SlugHelper.GetLatynSlug(Title)}-{JobVacancyId}";


        /// <summary>
        /// Автоматическое поле
        /// Указывает на главную сущность (вакансию)
        /// </summary>
        public int JobVacancyId { get; set; }
    }
}
